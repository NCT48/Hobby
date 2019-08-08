using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace IDOLDataBase
{
    public class IDOLDB
    {
        private static IReadOnlyList<IIDOL> idolList;
        public static IReadOnlyList<IIDOL> IDOLList => idolList ?? (idolList = Initialaize());

        private static IReadOnlyList<IIDOL> Initialaize()
        {
            var list = new List<IIDOL>(512);
            using (var fs = new FileStream(@"Resources\AllStars.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).AllStars);
            using (var fs = new FileStream(@"Resources\CinderellaGirls.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).CinderellaGirls);
            using (var fs = new FileStream(@"Resources\MillionStars.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).MillionStars);
            using (var fs = new FileStream(@"Resources\DearlyStars.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).DearlyStars);
            using (var fs = new FileStream(@"Resources\ShinyColors.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).ShinyColors);
            using (var fs = new FileStream(@"Resources\SideM.json", FileMode.Open, FileAccess.Read))
                list.AddRange(JsonSerializer.Deserialize<IDOLDB>(fs).SideM);
            return list;
        }

        public IReadOnlyList<AllStar> AllStars { get; set; }
        public IReadOnlyList<CinderellaGirl> CinderellaGirls { get; set; }
        public IReadOnlyList<MillionStar> MillionStars { get; set; }
        public IReadOnlyList<DearlyStar> DearlyStars { get; set; }
        public IReadOnlyList<ShinyColor> ShinyColors { get; set; }
        public IReadOnlyList<SideM> SideM { get; set; }
    }
}
