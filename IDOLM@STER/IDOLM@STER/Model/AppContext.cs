using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ExtendLinq;
using Utf8Json;

namespace Models.Master
{
    #region アイドルJsonデータ
    public class RootobjectIDOL
    {
        public List<IDOLJson> IDOLs { get; set; }
    }

    public class IDOLJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonetic { get; set; }
        public string Attribute { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bust { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public string BirthDay { get; set; }
        public string Blood { get; set; }
        public string Work { get; set; }
        public string BirthPlace { get; set; }

        #region コンストラクタ
        public IDOLJson()
        {

        }

        public IDOLJson(IDOLView view)
        {
            if (view is null)
            {
                return;
            }
            Name = view.Name;
            Phonetic = view.Phonetic;
            Attribute = view.Attribute;
            Age = view.Age;
            Height = view.Height;
            Weight = view.Weight;
            Bust = view.Bust;
            Waist = view.Waist;
            Hip = view.Hip;
            BirthDay = view.BirthDay;
            Blood = view.Blood;
            Work = view.Work.ToString();
            BirthPlace = view.BirthPlace;
        }
        #endregion
    }
    #endregion

    #region 画面表示用データ
    public class IDOLView
    {
        #region プロパティ・フィールド
        public string Name { get; }
        public string Phonetic { get; }
        public string Attribute { get; }
        public int Age { get; }
        public double Height { get; }
        public double Weight { get; }
        public double Bust { get; }
        public double Waist { get; }
        public double Hip { get; }
        public string BirthDay { get; }
        public string Blood { get; }
        public WorkType Work { get; }
        public string BirthPlace { get; }
        public static IEqualityComparer<IDOLView> ComparerName => new EqualityrName();
        public static IEqualityComparer<IDOLView> ComparerAge => new EqualityrAge();

        public double BMI => Height == 0 ? 0 : Math.Round(Weight * 10000 / Height / Height, 2, MidpointRounding.AwayFromZero);
        private double? diffe = null;
        public double Diffe
        {
            get
            {
                diffe ??= SetDiffe();
                return Math.Round(diffe.Value, 2, MidpointRounding.AwayFromZero);
            }
        }
        public double Under => Math.Round(Bust - Diffe, 2, MidpointRounding.AwayFromZero);
        public string Cup => SetCup();
        public double Script => Height == 0 ? 0 : Math.Round((Bust * Bust - Waist) / Height, 2, MidpointRounding.AwayFromZero);
        #endregion

        #region メソッド        
        //画面に出したくないからメソッド
        public bool HasValue() => Age * Height * Weight * Bust * Waist * Hip != 0;

        private double SetDiffe()
        {
            var hosei = 0.3261;
            return Height * Bust * Waist != 0 ? Bust - Height * 0.54 + (Height * 0.38 - Waist) * 0.73 + (Height - 158.8) * hosei + 17.5 : 0;
        }

        private string SetCup()
        {
            if (Bust == 0)
                return "";
            if (Diffe < 3.75)
                return "AAAA";
            if (Diffe < 6.25)
                return "AAA";
            if (Diffe < 8.75)
                return "AA";
            if (Diffe < 11.25)
                return "A";
            if (Diffe < 13.75)
                return "B";
            if (Diffe < 16.25)
                return "C";
            if (Diffe < 18.75)
                return "D";
            if (Diffe < 21.25)
                return "E";
            if (Diffe < 23.75)
                return "F";
            if (Diffe < 26.25)
                return "G";
            if (Diffe < 28.75)
                return "H";
            if (Diffe < 31.25)
                return "I";
            if (Diffe < 33.75)
                return "J";
            if (Diffe < 36.25)
                return "K";
            return "L↑";
        }
        #endregion

        #region コンストラクタ
        public IDOLView(double? height, double? weight, double? bust, double? waist, double? hip)
        {
            Height = height ?? 0.0;
            Weight = weight ?? 0.0;
            Bust = bust ?? 0.0;
            Waist = waist ?? 0.0;
            Hip = hip ?? 0.0;
        }

        public IDOLView(IDOLJson data)
        {
            if (data is null)
            {
                return;
            }
            Name = data.Name;
            Phonetic = data.Phonetic;
            Attribute = data.Attribute;
            Age = data.Age;
            Height = data.Height;
            Weight = data.Weight;
            Bust = data.Bust;
            Waist = data.Waist;
            Hip = data.Hip;
            BirthDay = data.BirthDay;
            Blood = data.Blood;
            Work = (WorkType)Enum.Parse(typeof(WorkType), data.Work);
            BirthPlace = data.BirthPlace;
        }
        #endregion

        #region IEqualityComparer
        class EqualityrName : IEqualityComparer<IDOLView>
        {
            public bool Equals(IDOLView x, IDOLView y)
            {
                return x.Name == y.Name;
            }

            public int GetHashCode(IDOLView obj)
            {
                return obj.Name.GetHashCode();
            }

            public EqualityrName()
            {
            }
        }

        class EqualityrAge : IEqualityComparer<IDOLView>
        {
            public bool Equals(IDOLView x, IDOLView y)
            {
                return x.Age == y.Age;
            }

            public int GetHashCode(IDOLView obj)
            {
                return obj.Age.GetHashCode();
            }
        }
        #endregion
    }

    public enum WorkType
    {
        All,
        CinderellaGirls,
        MillionLive,
        AllStars,
        DearlyStars,
        ShinyColors,
        Same,
    }
    #endregion

    #region 偏差値画面用クラス
    public class IDOLDeviation
    {
        public string Name { get; set; }
        public string Phonetic { get; set; }
        public double AgeScore { get; set; }
        public double HeightScore { get; set; }
        public double WeightScore { get; set; }
        public double BustScore { get; set; }
        public double WaistScore { get; set; }
        public double HipScore { get; set; }
        public double BMIScore { get; set; }
        public double UnderScore { get; set; }
        public double DiffScore { get; set; }
        public double TotalScore => Score();

        private double Score()
        {
            var value = 0.0;
            value += Eva(AgeScore);
            value += Eva(HeightScore);
            value += Eva(WeightScore);
            value += Eva(BustScore);
            value += Eva(WaistScore);
            value += Eva(HipScore);
            //value += Eva(BMIScore);
            //value += Eva(UnderScore);
            //value += Eva(DiffScore);
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        private double Eva(double score) => Math.Pow(score - 50, 2);

        //画面に出したくないからメソッド
        public bool HasScore() => AgeScore * HeightScore * WeightScore * BustScore * WaistScore * HipScore != 0;
    }
    #endregion

    #region ユニットデータ
    public class RootobjectUnit
    {
        public List<UnitJson> Units { get; set; }
    }

    public class UnitJson
    {
        public string Name { get; set; }
        public List<string> Members { get; set; }
    }

    public class UnitView
    {
        public string Name { get; }
        public IReadOnlyList<IDOLView> Members { get; }
        public IReadOnlyList<IDOLDeviation> Deviations { get; }

        public UnitView(string name, IEnumerable<IDOLView> members, IEnumerable<IDOLDeviation> deviations)
        {
            Name = name;
            Members = members.ToList();
            Deviations = deviations.ToList();
        }
    }
    #endregion

    #region モデル
    public class IdolModel
    {
        public static readonly IdolModel Instance = new IdolModel();

        public IReadOnlyList<IDOLView> IDOLList { get; }
        public IReadOnlyList<IDOLDeviation> IDOLDeviations { get; }
        public IReadOnlyList<UnitView> UnitList { get; }

        private IdolModel()
        {
            IDOLList = LoadIDOLData().ToList();
            IDOLDeviations = IDOLList.ToDevitation().ToList();
            UnitList = LoadUnit().ToList();
        }

        private List<IDOLView> GetDB()
        {
            using var db = new IDOLDbContext();
            var iDOLs = db.IDOLs.AsEnumerable();
            return iDOLs.Select(x => new IDOLView(x)).OrderBy(x => x.Work).ThenBy(x => x.Phonetic).ToList();
        }

        private void SetDB()
        {
            using var fs = new FileStream(@"Resource\IDOLData.json", FileMode.Open, FileAccess.Read);
            var idolJson = JsonSerializer.Deserialize<RootobjectIDOL>(fs);

            using var db = new IDOLDbContext();
            db.IDOLs.AddRange(idolJson.IDOLs);
            db.SaveChanges();
        }

        private IEnumerable<IDOLView> LoadIDOLData()
        {
            using var fs = new FileStream(@"Resource\IDOLData.json", FileMode.Open, FileAccess.Read);
            var idolJson = JsonSerializer.Deserialize<RootobjectIDOL>(fs);
            return idolJson.IDOLs.Select(x => new IDOLView(x)).OrderBy(x => x.Work).ThenBy(x => x.Phonetic);
        }

        private IEnumerable<UnitView> LoadUnit()
        {
            using var fs = new FileStream(@"Resource\UnitData.json", FileMode.Open, FileAccess.Read);
            var unitJson = JsonSerializer.Deserialize<RootobjectUnit>(fs);
            return unitJson.Units.Select(x => new UnitView(x.Name,
                                                           x.Members.Join(IDOLList, y => y, z => z.Name, (y, z) => z),
                                                           x.Members.Join(IDOLDeviations, y => y, z => z.Name, (y, z) => z)
                                                           ));
        }

        public void SaveJsonIDOL()
        {
            try
            {
                var idolJson = new RootobjectIDOL {
                    IDOLs = IDOLList.Select(x => new IDOLJson(x)).ToList(),
                };
                using var fs = new FileStream(@"Resource\IDOLData.json", FileMode.OpenOrCreate, FileAccess.Write);
                JsonSerializer.Serialize(fs, idolJson);
            }
            catch (IOException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        public void SaveIcsIdol()
        {
            using var sw = new StreamWriter(@"Resource\IDOLBirthday.ics", false, Encoding.UTF8);
            sw.WriteLine("BEGIN:VCALENDAR");
            sw.WriteLine("PRODID:-IM@SBirthday Calendar//JP");
            sw.WriteLine("VERSION:2.0");
            sw.WriteLine("METHOD:PUBLISH");
            sw.WriteLine("CALSCALE:GREGORIAN");
            sw.WriteLine("X-WR-CALNAME:アイドルマスター誕生日カレンダー");
            sw.WriteLine("X-WR-TIMEZONE:Asia/Tokyo");
            sw.WriteLine("BEGIN:VTIMEZONE");
            sw.WriteLine("TZID:Asia/Tokyo");
            sw.WriteLine("BEGIN:STANDARD");
            sw.WriteLine("TZOFFSETFROM:+0900");
            sw.WriteLine("TZOFFSETTO:+0900");
            sw.WriteLine("TZNAME:JST");
            sw.WriteLine("DTSTART:19700101T000000");
            sw.WriteLine("END:STANDARD");
            sw.WriteLine("END:VTIMEZONE");

            foreach (var idol in IDOLList)
            {
                if (!DateTime.TryParse(idol.BirthDay, out var bd))
                {
                    continue;
                }
                sw.WriteLine("BEGIN:VEVENT");
                sw.WriteLine($"UID:birthday-2019@calendar.imas.NCT48.jp");
                sw.WriteLine($"DTSTART; VALUE = DATE:{bd.ToString("yyyyMMdd")}");
                sw.WriteLine($"DTEND; VALUE = DATE:{bd.AddDays(1).ToString("yyyyMMdd")}");
                sw.WriteLine($"SUMMARY:{idol.Name.Replace(" ", "")}の誕生日");
                sw.WriteLine($"RRULE: FREQ=YEARLY;BYMONTHDAY={bd.Day};BYMONTH={bd.Month}");
                sw.WriteLine("DESCRIPTION:");
                sw.WriteLine("BEGIN:VALARM");
                sw.WriteLine("TRIGGER:PT0S");
                sw.WriteLine("ACTION:DISPLAY");
                sw.WriteLine($"DESCRIPTION:{idol.Name.Replace(" ", "")}の誕生日");
                sw.WriteLine("END:VALARM");
                sw.WriteLine("CATEGORIES:誕生日");
                sw.WriteLine("END:VEVENT");
            }
            sw.WriteLine("END:VCALENDAR");
        }
    }
    #endregion
}
