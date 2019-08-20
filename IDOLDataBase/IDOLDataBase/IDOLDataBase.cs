using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace IDOLDataBase
{
    public static class IDOLDB
    {
        private static IDOLList idolList;
        public static IDOLList IDOLList => idolList ?? (idolList = Initialaize());

        private static IDOLList Initialaize()
        {
            var list = new List<IIDOL>(512);
            list.AddRange(DeserializeJson<AllStars>());
            list.AddRange(DeserializeJson<CinderellaGirls>());
            list.AddRange(DeserializeJson<MillionStars>());
            list.AddRange(DeserializeJson<DearlyStars>());
            list.AddRange(DeserializeJson<ShinyColors>());
            list.AddRange(DeserializeJson<SideM>());
            return new IDOLList(list);
        }

        private static IEnumerable<T> DeserializeJson<T>()
        {
            Dictionary<string, object> jsonDictionary;
            using (var fs = new FileStream($@"Resources\{typeof(T).Name}.json", FileMode.Open, FileAccess.Read))
            {
                jsonDictionary = JsonSerializer.Deserialize<dynamic>(fs);
            }
            foreach (var lists in jsonDictionary.Values.Cast<List<object>>())
            {
                foreach (var datas in lists.Cast<Dictionary<string, object>>())
                {
                    var t = Activator.CreateInstance<T>();
                    foreach (var data in datas)
                    {
                        var propertyInfo = t.GetType().GetProperty(data.Key);
                        propertyInfo.SetValue(t, Convert.ChangeType(data.Value, propertyInfo.PropertyType));
                    }
                    yield return t;
                }
            }
        }
    }

    public class IDOLList : IReadOnlyList<IIDOL>
    {
        private readonly IReadOnlyList<IIDOL> idols;

        public IIDOL this[int index] => idols[index];
        public IIDOL this[string index] => idols.First(x => CheckName(x.Name, index));

        private bool CheckName(string name, string index)
        {
            if (name.Replace(" ", "") == index.Replace(" ", ""))
                return true;

            var split = name.Split(' ');
            foreach (var item in split)
            {
                if (item == index)
                    return true;
            }

            return false;
        }

        public int Count => idols.Count;

        public IEnumerator<IIDOL> GetEnumerator() => idols.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => idols.GetEnumerator();

        public IDOLList(IReadOnlyList<IIDOL> source) => idols = source;
    }
}
