using System;
using System.Collections.Generic;
using System.Linq;
using ExtendLinq;
using Livet;
using Livet.Commands;
using Models.Master;

namespace ViewModels.Extention
{
    public class FigureSearchViewModel : ViewModel
    {
        #region レコード
        public class SearchData
        {
            #region プロパティ・フィールド
            private readonly IdolModel Model = IdolModel.Instance;
            public IDOLView MasterIDOL { get; set; }
            public List<RankData> BodyDatas { get; set; }
            public List<RankData> DevDatas { get; set; }
            #endregion

            #region コンストラクタ
            public SearchData(IDOLView idol, IDOLDeviation deviation)
            {
                MasterIDOL = idol;
                var idolList = Model.IDOLList;

                BodyDatas = new List<RankData>
            {
                new RankData(
                    nameof(idol.Height),
                    idol.Height
                    ),
                new RankData(
                    nameof(idol.Weight),
                    idol.Weight
                    ),
                new RankData(
                    nameof(idol.Bust),
                    idol.Bust
                    ),
                new RankData(
                    nameof(idol.Waist),
                    idol.Waist
                    ),
                new RankData(
                    nameof(idol.Hip),
                    idol.Hip
                    ),
                new RankData(
                    nameof(idol.BMI),
                    idol.BMI
                    ),
                new RankData(
                    nameof(idol.Under),
                    idol.Under
                    ),
                new RankData(
                    nameof(idol.Diffe),
                    idol.Diffe
                    ),
            };

                DevDatas = new List<RankData>
            {
                new RankData(
                    nameof(deviation.HeightScore),
                    deviation.HeightScore
                    ),
                new RankData(
                    nameof(deviation.WeightScore ),
                    deviation.WeightScore
                    ),
                new RankData(
                    nameof(deviation.BustScore),
                    deviation.BustScore
                    ),
                new RankData(
                    nameof(deviation.WaistScore),
                    deviation.WaistScore
                    ),
                new RankData(
                    nameof(deviation.HipScore),
                    deviation.HipScore
                    ),
                new RankData(
                    nameof(deviation.BMIScore),
                    deviation.BMIScore
                    ),
                new RankData(
                    nameof(deviation.UnderScore),
                    deviation.UnderScore
                    ),
                new RankData(
                    nameof(deviation.DiffScore),
                    deviation.DiffScore
                    ),
                new RankData(
                    nameof(deviation.TotalScore),
                    deviation.TotalScore
                    ),
            };
            }
            #endregion

            #region 体型
            public class RankData
            {
                public string Name { get; set; }
                public double Param { get; set; }

                public RankData(string name, double param)
                {
                    Name = name;
                    Param = param;
                }
            }
            #endregion
        }
        #endregion

        #region ラジオボタン
        public class Checked
        {
            public bool IsChecked { get; set; }
            public WorkType Work { get; set; }
        }
        #endregion

        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;
        public SearchData BaseRecord { get; set; }
        public SearchData ComparisonRecord { get; set; }
        public IReadOnlyList<string> NameList { get; set; }
        public IReadOnlyList<string> ComparisonNameList { get; set; }
        public List<Checked> CheckedList { get; set; }
        private string selectedText;
        public string SelectedText { get => selectedText; set => SetFilter(value, selectedComparison); }
        private string selectedComparison;
        public string SelectedComparison { get => selectedComparison; set => SetFilter(selectedText, value); }
        public double Score { get; set; }
        public bool RaddioButtonEnabled { get; set; }
        public bool ComparisonEnabled { get; set; }
        #endregion

        #region コンストラクタ
        public FigureSearchViewModel()
        {
            NameList = Model.IDOLList.Where(x => x.HasValue()).Select(x => x.Name).ToList();
            ComparisonNameList = NameList.Prepend(string.Empty).ToList();
            CheckedList = Enum.GetValues(typeof(WorkType)).OfType<WorkType>().Select(x => new Checked() { IsChecked = false, Work = x }).ToList();
            CheckedList.First().IsChecked = true;
            selectedText = NameList.First();
            selectedComparison = string.Empty;
            RaddioButtonEnabled = true;
            SetFilter();
        }
        #endregion

        #region 検索処理
        private ViewModelCommand _SetFilterCommand;
        public ViewModelCommand SetFilterCommand => _SetFilterCommand ??= new ViewModelCommand(SetFilter);

        private void SetFilter()
        {
            SetFilter(selectedText, selectedComparison);
        }

        private void SetFilter(string text, string comparison)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var baseIDOL = Model.IDOLList.First(x => x.Name == text);
            var baseDev = Model.IDOLDeviations.First(x => x.Name == text);
            BaseRecord = new SearchData(baseIDOL, baseDev);

            var nowWork = CheckedList.First(x => x.IsChecked).Work;
            SetEnabled(nowWork, comparison);

            var comparisonData = GetSimilarity(baseIDOL, baseDev, nowWork, comparison);
            var compIDOL = Model.IDOLList.First(x => x.Name == comparisonData.Name);
            var compDev = Model.IDOLDeviations.First(x => x.Name == comparisonData.Name);
            ComparisonRecord = new SearchData(compIDOL, compDev);
            Score = comparisonData.Score;

            selectedText = text;
            selectedComparison = comparison;

            RaiseProperties();
        }

        private void RaiseProperties()
        {
            RaisePropertyChanged(nameof(BaseRecord));
            RaisePropertyChanged(nameof(ComparisonRecord));
            RaisePropertyChanged(nameof(Score));
            RaisePropertyChanged(nameof(RaddioButtonEnabled));
            RaisePropertyChanged(nameof(ComparisonEnabled));
        }

        private void SetEnabled(WorkType nowWork, string comparison)
        {
            ComparisonEnabled = nowWork == WorkType.All;
            RaddioButtonEnabled = string.IsNullOrEmpty(comparison);
        }

        private (string Name, double Score) GetSimilarity(IDOLView idol, IDOLDeviation dev, WorkType nowWork, string comparison)
        {
            if (string.IsNullOrEmpty(comparison))
            {
                var workList = GetWorkList(nowWork, idol.Work);
                return Model.IDOLDeviations.Where(x => x.Name != dev.Name)
                                           .Similarity(dev)
                                           .OrderBy(x => x.Score)
                                           .First(x => workList.Any(y => x.Name == y.Name));
            }
            else
            {
                return Model.IDOLDeviations.Similarity(dev).First(x => x.Name == comparison);
            }
        }

        private IEnumerable<IDOLView> GetWorkList(WorkType work, WorkType baseWork)
        {
            if (work == WorkType.All)
            {
                return Model.IDOLList;
            }
            if (work == WorkType.Same)
            {
                return Model.IDOLList.Where(x => x.Work == baseWork);
            }
            return Model.IDOLList.Where(x => x.Work == work);
        }
        #endregion
    }
}
