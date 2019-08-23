using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDOLDataBase;

namespace IDOLData
{
    static class Program
    {
        static void Main(string[] args)
        {
            foreach (var idol in IDOLDB.IDOLList.OfType<IWomanIdol>())
            {
                Console.WriteLine(idol.Name + ", " + idol.Cup);
            }
        }

        private static void OutOutCSV(IReadOnlyList<IIDOL> db)
        {
            static void Header(StreamWriter sw, Type type)
            {
                var header = type.GetProperties();
                foreach (var h in header)
                {
                    sw.Write(h.Name);
                    sw.Write(",");
                }
                sw.WriteLine();
            }

            using var dere = new StreamWriter("csvs/dere.csv", false, new UTF8Encoding(true));
            using var miri = new StreamWriter("csvs/miri.csv", false, new UTF8Encoding(true));
            using var AS = new StreamWriter("csvs/as.csv", false, new UTF8Encoding(true));
            using var shani = new StreamWriter("csvs/shani.csv", false, new UTF8Encoding(true));
            using var bana = new StreamWriter("csvs/bana.csv", false, new UTF8Encoding(true));
            using var sm = new StreamWriter("csvs/sm.csv", false, new UTF8Encoding(true));

            Header(dere, typeof(CinderellaGirls));
            Header(miri, typeof(MillionStars));
            Header(AS, typeof(AllStars));
            Header(shani, typeof(ShinyColors));
            Header(bana, typeof(DearlyStars));
            Header(sm, typeof(SideM));

            foreach (var item in db)
            {
                var sw = item switch
                {
                    CinderellaGirls _ => dere,
                    MillionStars _ => miri,
                    AllStars _ => AS,
                    ShinyColors _ => shani,
                    DearlyStars _ => bana,
                    SideM _ => sm,
                    _ => throw new InvalidOperationException(),
                };

                var props = item.GetType().GetProperties();
                foreach (var p in props)
                {
                    sw.Write("\"");
                    sw.Write(p.GetValue(item));
                    sw.Write("\"");
                    sw.Write(",");
                }
                sw.WriteLine();
            }
        }
    }
}
