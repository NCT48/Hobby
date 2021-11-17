using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utf8Json;

namespace IDOLDataBase
{
    public static class IDOLDB
    {
        private static IDOLList idolList;

        public static IDOLList IDOLList => idolList ??= Initialaize();

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
                jsonDictionary = JsonSerializer.Deserialize<dynamic>(fs);

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
                    if (t is IWomanIdol tw)
                        BustDifferenceGenerator(ref tw);

                    yield return t;
                }
            }
        }

        private static void BustDifferenceGenerator<T>(ref T t) where T : IWomanIdol
        {
            var diff = t.GetType().GetProperty("Diff");
            var under = t.GetType().GetProperty("Under");
            var cup = t.GetType().GetProperty("Cup");

            var hosei = 0.3261;
            var d = t.Height * t.Bust * t.Waist == 0 ? 0 : t.Bust - t.Height * 0.54 + (t.Height * 0.38 - t.Waist) * 0.73 + (t.Height - 158.8) * hosei + 17.5;

            diff.SetValue(t, Math.Round(d, 0, MidpointRounding.AwayFromZero));
            under.SetValue(t, Math.Round(t.Bust - d, 0, MidpointRounding.AwayFromZero));
            cup.SetValue(t, t.Bust == 0 ? string.Empty : SetCup(d));
        }

        private static string SetCup(double diff)
        {
            return diff < 3.75 ? "AAAA"
                : diff < 6.25 ? "AAA"
                : diff < 8.75 ? "AA"
                : diff < 11.25 ? "A"
                : diff < 13.75 ? "B"
                : diff < 16.25 ? "C"
                : diff < 18.75 ? "D"
                : diff < 21.25 ? "E"
                : diff < 23.75 ? "F"
                : diff < 26.25 ? "G"
                : diff < 28.75 ? "H"
                : diff < 31.25 ? "I"
                : diff < 33.75 ? "J"
                : diff < 36.25 ? "K"
                : "L↑";
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
