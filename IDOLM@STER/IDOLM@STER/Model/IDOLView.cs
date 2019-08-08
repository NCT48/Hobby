using System;
using System.Linq;

namespace Models.Master
{
    #region 画面表示用データ
    public class IDOLView : IComparable<IDOLView>
    {
        #region プロパティ・フィールド
        private readonly int id;
        public string Name { get; }
        public string Phonetic { get; }
        public string English { get; }
        public string Initial { get; }
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

        public double BMI => Height == 0 ? 0 : Math.Round(Weight * 10000 / Height / Height, 2, MidpointRounding.AwayFromZero);
        private double? diffe = null;
        public double Diffe
        {
            get
            {
                diffe ??= Math.Round(SetDiffe(), 2, MidpointRounding.AwayFromZero);
                return diffe.Value;
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

        public int Getid() => id;
        #endregion

        #region コンストラクタ
        public IDOLView(double? height, double? weight, double? bust, double? waist, double? hip)
        {
            id = -1;
            Height = height ?? 0.0;
            Weight = weight ?? 0.0;
            Bust = bust ?? 0.0;
            Waist = waist ?? 0.0;
            Hip = hip ?? 0.0;
        }

        public IDOLView(IDOLJson data, int id)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            this.id = id;

            Name = data.Name;
            Phonetic = data.Phonetic;
            English = data.English;
            Initial = string.Join(".", English.Split(' ').Select(x => x[0])) + ".";
            Attribute = data.Attribute;
            Age = data.Age;
            Height = data.Height;
            Weight = data.Weight;
            Bust = data.Bust;
            Waist = data.Waist;
            Hip = data.Hip;
            BirthDay = DateTime.TryParse(data.BirthDay, out var rslt) ? rslt.ToString("MM/dd") : string.Empty;
            Blood = data.Blood;
            Work = (WorkType)Enum.Parse(typeof(WorkType), data.Work);
            BirthPlace = data.BirthPlace;
        }
        #endregion

        #region IComparable
        public int CompareTo(IDOLView other) => other is null ? throw new ArgumentNullException(nameof(other)) : id.CompareTo(other.id);
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
}
