using System;

namespace Models.Master
{
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
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        private double Eva(double score) => Math.Pow(score - 50, 2);

        //画面に出したくないからメソッド
        public bool HasScore() => AgeScore * HeightScore * WeightScore * BustScore * WaistScore * HipScore != 0;
    }
    #endregion
}
