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
            public IDOLView MasterIDOL { get; }
            public IEnumerable<DataGridValue> BodyDatas { get; }
            public IEnumerable<DataGridValue> DevDatas { get; }
            #endregion

            #region コンストラクタ
            public SearchData(IDOLView idol, IDOLDeviation deviation)
            {
                MasterIDOL = idol;
                IEnumerable<DataGridValue> bodyDatas()
                {
                    yield return new DataGridValue(nameof(idol.Age), idol.Age);
                    yield return new DataGridValue(nameof(idol.Height), idol.Height);
                    yield return new DataGridValue(nameof(idol.Weight), idol.Weight);
                    yield return new DataGridValue(nameof(idol.Bust), idol.Bust);
                    yield return new DataGridValue(nameof(idol.Waist), idol.Waist);
                    yield return new DataGridValue(nameof(idol.Hip), idol.Hip);
                    yield return new DataGridValue(nameof(idol.BMI), idol.BMI);
                    yield return new DataGridValue(nameof(idol.Under), idol.Under);
                    yield return new DataGridValue(nameof(idol.Diffe), idol.Diffe);
                }
                BodyDatas = idol is null ? throw new ArgumentNullException(nameof(idol)) : bodyDatas();

                IEnumerable<DataGridValue> devDatas()
                {
                    yield return new DataGridValue(nameof(deviation.AgeScore), deviation.AgeScore);
                    yield return new DataGridValue(nameof(deviation.WeightScore), deviation.WeightScore);
                    yield return new DataGridValue(nameof(deviation.BustScore), deviation.BustScore);
                    yield return new DataGridValue(nameof(deviation.WaistScore), deviation.WaistScore);
                    yield return new DataGridValue(nameof(deviation.HipScore), deviation.HipScore);
                    yield return new DataGridValue(nameof(deviation.BMIScore), deviation.BMIScore);
                    yield return new DataGridValue(nameof(deviation.UnderScore), deviation.UnderScore);
                    yield return new DataGridValue(nameof(deviation.DiffScore), deviation.DiffScore);
                    yield return new DataGridValue(nameof(deviation.TotalScore), deviation.TotalScore);
                }
                DevDatas = deviation is null ? throw new ArgumentNullException(nameof(deviation)) : devDatas().ToList();
            }
            #endregion

            public class DataGridValue
            {
                public string Param { get; }
                public double Value { get; }

                public DataGridValue(string param, double value)
                {
                    Param = param;
                    Value = value;
                }
            }
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
        public IReadOnlyList<Checked> CheckedList { get; set; }
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
            CheckedList[0].IsChecked = true;
            selectedText = NameList[0];
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

            var (name, score) = GetSimilarity(baseIDOL, baseDev, nowWork, comparison);
            var compIDOL = Model.IDOLList.First(x => x.Name == name);
            var compDev = Model.IDOLDeviations.First(x => x.Name == name);
            ComparisonRecord = new SearchData(compIDOL, compDev);
            Score = score;

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

        private (string name, double score) GetSimilarity(IDOLView idol, IDOLDeviation dev, WorkType nowWork, string comparison)
        {
            if (string.IsNullOrEmpty(comparison))
            {
                var workList = GetWorkList(nowWork, idol.Work);
                return Model.IDOLDeviations.Similarity(dev)
                                           .OrderBy(x => x.Score)
                                           .First(x => workList.Any(y => x.Name == y.Name) && x.Score != 0);
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
