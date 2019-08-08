using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using ExtendLinq;
using Utf8Json;

namespace Models.Master
{
    #region アイドルJson
    public class RootobjectIDOL
    {
        public List<IDOLJson> IDOLs { get; set; }
    }

    public class IDOLJson
    {
        public string Name { get; set; }
        public string Phonetic { get; set; }
        public string English { get; set; }
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
        public IDOLJson() { }

        public IDOLJson(IDOLView view)
        {
            if (view is null)
            {
                return;
            }
            Name = view.Name;
            Phonetic = view.Phonetic;
            English = view.English;
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

    #region ユニットJson
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
            var test = UnRomanaise("Kannippatsu");

            var roman = IDOLList.Select(x => string.Join(" ", UnRomanaise(x.English).Split(' ').Reverse())).ToList();
            var phone = IDOLList.Select(x => x.Phonetic).ToList();

            var check = roman.Zip(phone, (x, y) => (x, y)).Where(x => x.x != x.y);
            var impossible = check.Where(x => x.x.Contains("_"));
            var failure = check.Where(x => !x.x.Contains("_"));
        }

        private IEnumerable<(string Name, string Similarity, double Score)> SimilarityScore()
            => IDOLDeviations.Where(x => x.HasScore())
                             .Select(x => IDOLDeviations.Similarity(x)
                                                        .Where(y => y.Score != 0)
                                                        .OrderBy(y => y.Score)
                                                        .Select(y => (x.Name, Similarity: y.Name, y.Score))
                                                        .First());

        private IEnumerable<IDOLView> LoadIDOLData()
        {
            using var fs = new FileStream(@"Resource\IDOLData.json", FileMode.Open, FileAccess.Read);
            var idolJson = JsonSerializer.Deserialize<RootobjectIDOL>(fs);
            return idolJson.IDOLs.Select((x, i) => new IDOLView(x, i)).OrderBy(x => x.Work).ThenBy(x => x.Phonetic);
        }

        private IEnumerable<UnitView> LoadUnit()
        {
            using var fs = new FileStream(@"Resource\UnitData.json", FileMode.Open, FileAccess.Read);
            var unitJson = JsonSerializer.Deserialize<RootobjectUnit>(fs);
            return unitJson.Units.Select(x => new UnitView(x.Name,
                                                           x.Members.Join(IDOLList, y => y, z => z.Name, (_, z) => z),
                                                           x.Members.Join(IDOLDeviations, y => y, z => z.Name, (_, z) => z)));
        }

        public void SaveJsonIDOL()
        {
            try
            {
                var idolJson = new RootobjectIDOL {
                    IDOLs = IDOLList.OrderBy(x => x).Select(x => new IDOLJson(x)).ToList(),
                };
                using var fs = new FileStream(@"Resource\IDOLData_new.json", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, idolJson);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
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

        private string UnRomanaise(string romana)
        {
            var rTemp = new List<char>();
            var roman = new StringBuilder();
            foreach (var item in romana.ToUpper())
            {
                if (item < 'A' || 'Z' < item)
                {
                    if (rTemp.Any())
                    {
                        roman.Append(CheckRomanDict(new string(rTemp.ToArray())));
                        rTemp.Clear();
                    }
                    roman.Append(item.ToString());
                }
                else if (new char[] { 'A', 'I', 'U', 'E', 'O' }.Contains(item))
                {
                    rTemp.Add(item);
                    roman.Append(CheckRomanDict(new string(rTemp.ToArray())));
                    rTemp.Clear();
                }
                else if (rTemp.Contains('H') && item != 'Y')
                {
                    roman.Append("お");
                    rTemp.Remove('H');
                    rTemp.Add(item);
                }
                else if (rTemp.Contains('N') && item != 'Y')
                {
                    roman.Append(CheckRomanDict(new string(rTemp.ToArray())));
                    rTemp.Clear();
                    rTemp.Add(item);
                }
                else if (rTemp.Contains('M') && item != 'Y')
                {
                    roman.Append(CheckRomanDict(new string(rTemp.ToArray())));
                    rTemp.Clear();
                    rTemp.Add(item);
                }
                else if (rTemp.Contains(item))
                {
                    roman.Append('っ');
                }
                else
                {
                    rTemp.Add(item);
                }

            }
            if (rTemp.Any())
            {
                roman.Append(CheckRomanDict(new string(rTemp.ToArray())));
                rTemp.Clear();
            }
            return roman.ToString();
        }

        private string CheckRomanDict(string roman) => RomanDictonary.ContainsKey(roman) ? RomanDictonary[roman] : "_";

        private Dictionary<string, string> RomanDictonary = new Dictionary<string, string> {
            ["A"] = "あ",
            ["I"] = "い",
            ["U"] = "う",
            ["E"] = "え",
            ["O"] = "お",
            ["KA"] = "か",
            ["KI"] = "き",
            ["KU"] = "く",
            ["KE"] = "け",
            ["KO"] = "こ",
            ["SA"] = "さ",
            ["SHI"] = "し",
            ["SI"] = "し",
            ["SU"] = "す",
            ["SE"] = "せ",
            ["SO"] = "そ",
            ["TA"] = "た",
            ["CHI"] = "ち",
            ["TI"] = "ち",
            ["TSU"] = "つ",
            ["TU"] = "つ",
            ["TE"] = "て",
            ["TO"] = "と",
            ["NA"] = "な",
            ["NI"] = "に",
            ["NU"] = "ぬ",
            ["NE"] = "ね",
            ["NO"] = "の",
            ["HA"] = "は",
            ["HI"] = "ひ",
            ["FU"] = "ふ",
            ["HU"] = "ふ",
            ["HE"] = "へ",
            ["HO"] = "ほ",
            ["MA"] = "ま",
            ["MI"] = "み",
            ["MU"] = "む",
            ["ME"] = "め",
            ["MO"] = "も",
            ["YA"] = "や",
            ["YU"] = "ゆ",
            ["YO"] = "よ",
            ["RA"] = "ら",
            ["LA"] = "ら",
            ["RI"] = "り",
            ["LI"] = "り",
            ["RU"] = "る",
            ["LU"] = "る",
            ["RE"] = "れ",
            ["LE"] = "れ",
            ["RO"] = "ろ",
            ["LO"] = "ろ",
            ["WA"] = "わ",
            ["WO"] = "を",
            ["N"] = "ん",
            ["M"] = "ん",

            ["GA"] = "が",
            ["GI"] = "ぎ",
            ["GU"] = "ぐ",
            ["GE"] = "げ",
            ["GO"] = "ご",
            ["ZA"] = "ざ",
            ["JI"] = "じ",
            ["ZI"] = "じ",
            ["ZU"] = "ず",
            ["ZE"] = "ぜ",
            ["ZO"] = "ぞ",
            ["DA"] = "だ",
            ["DI"] = "ぢ",
            ["DU"] = "づ",
            ["DE"] = "で",
            ["DO"] = "ど",
            ["BA"] = "ば",
            ["BI"] = "び",
            ["BU"] = "ぶ",
            ["BE"] = "べ",
            ["BO"] = "ぼ",
            ["PA"] = "ぱ",
            ["PI"] = "ぴ",
            ["PU"] = "ぷ",
            ["PE"] = "ぺ",
            ["PO"] = "ぽ",

            ["KYA"] = "きゃ",
            ["KYU"] = "きゅ",
            ["KYO"] = "きょ",
            ["GYA"] = "ぎゃ",
            ["GYU"] = "ぎゅ",
            ["GYO"] = "ぎょ",
            ["SYA"] = "しゃ",
            ["SYU"] = "しゅ",
            ["SYO"] = "しょ",
            ["SHA"] = "しゃ",
            ["SHU"] = "しゅ",
            ["SHE"] = "しぇ",
            ["SHO"] = "しょ",
            ["TYA"] = "ちゃ",
            ["TYU"] = "ちゅ",
            ["TYO"] = "ちょ",
            ["CHA"] = "ちゃ",
            ["CHU"] = "ちゅ",
            ["CHO"] = "ちょ",
            ["JA"] = "じゃ",
            ["JU"] = "じゅ",
            ["JE"] = "じぇ",
            ["JO"] = "じょ",
            ["ZYA"] = "じゃ",
            ["ZYI"] = "じぃ",
            ["ZYU"] = "じゅ",
            ["ZYE"] = "じぇ",
            ["ZYO"] = "じょ",
            ["NYA"] = "にゃ",
            ["NYU"] = "にゅ",
            ["NYO"] = "にょ",
            ["HYA"] = "ひゃ",
            ["HYU"] = "ひゅ",
            ["HYO"] = "ひょ",
            ["BYA"] = "びゃ",
            ["BYU"] = "びゅ",
            ["BYO"] = "びょ",
            ["PYA"] = "ぴゃ",
            ["PYU"] = "ぴゅ",
            ["PYO"] = "ぴょ",
            ["FA"] = "ふぁ",
            ["FI"] = "ふぃ",
            ["FE"] = "ふぇ",
            ["FO"] = "ふぉ",
            ["MYA"] = "みゃ",
            ["MYU"] = "みゅ",
            ["MYO"] = "みょ",
            ["RYA"] = "りゃ",
            ["RYU"] = "りゅ",
            ["RYO"] = "りょ",

            ["XA"] = "ぁ",
            ["XI"] = "ぃ",
            ["XU"] = "ぅ",
            ["XE"] = "ぇ",
            ["XO"] = "ぉ",
            ["XTU"] = "っ",
            ["XYA"] = "ゃ",
            ["XYU"] = "ゅ",
            ["XYO"] = "ょ",
        };
    }
    #endregion
}
