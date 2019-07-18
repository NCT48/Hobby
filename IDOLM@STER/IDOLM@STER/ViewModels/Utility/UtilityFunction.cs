using System.Collections.Generic;

namespace ViewModels.Utility
{
    public static class UtilityFunction
    {
        public static bool AmbiguousSearch(string target, string filter)
        {
            if (string.IsNullOrEmpty(target) || string.IsNullOrEmpty(filter))
            {
                return true;
            }
            var targetDai = ToUpperJapanese(target);
            var filterDai = ToUpperJapanese(filter);
            int i = 0;

            for (int j = 0; j < targetDai.Length; j++)
            {
                if (targetDai[j] == filterDai[i])
                {
                    i++;
                }
                if (i == filterDai.Length)
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
