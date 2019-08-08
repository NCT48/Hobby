using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ViewModels.Utility
{
    public static class UtilityFunction
    {
        public static bool NormalSearch(string target, Regex regex) =>
            regex is null ? throw new ArgumentNullException(nameof(regex)) : regex.IsMatch(target);


        public static bool AmbiguousSearch(string target, string filter)
        {
            if (filter.All(x => 'A' <= x && x <= 'z'))
            {
                return AmbiguousSearchJa(target.ToUpper(), filter.ToUpper());
            }
            if (filter.All(x => x < 'A' || 'z' < x))
            {
                return AmbiguousSearchJa(ToUpperJapanese(target), ToUpperJapanese(filter));
            }
            return false;
        }

        public static bool AmbiguousSearchJa(string target, string filter)
        {
            if (string.IsNullOrEmpty(target) || string.IsNullOrEmpty(filter))
            {
                return true;
            }

            int i = 0;

            for (int j = 0; j < target.Length; j++)
            {
                if (target[j] == filter[i])
                {
                    i++;
                }
                if (i == filter.Length)
                {
                    return true;
                }
            }
            return false;
        }

        private static string ToUpperJapanese(string s)
        {
            var upJp = s;
            var replaceList = new List<(string key, string value)>()
            {
                ("ぁ","あ"),
                ("ぃ","い"),
                ("ぅ","う"),
                ("ぇ","え"),
                ("ぉ","お"),
                ("っ","つ"),
                ("ゃ","や"),
                ("ゅ","ゆ"),
                ("ょ","よ"),
                ("ゎ","わ"),
                (" ",""),
            };
            foreach (var (key, value) in replaceList)
            {
                upJp = upJp.Replace(key, value);
            }
            return upJp;
        }
    }
}
