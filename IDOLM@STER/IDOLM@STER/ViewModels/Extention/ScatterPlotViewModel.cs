using System;
using System.Collections.Generic;
using System.Linq;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Livet;
using Livet.Commands;
using Models.Master;
using Reactive.Bindings;

namespace ViewModels.Extention
{
    public class ScatterPlotViewModel : ViewModel
    {
        #region クラス
        public class ScatterPlot
        {
            public Dictionary<string, double> Param { get; set; }
            public string Name { get; set; }
            public string Blood { get; set; }
            public WorkType Work { get; set; }

            public ScatterPlot(IDOLView idol)
            {
                IEnumerable<(string key, double value)> f()
                {
                    yield return (nameof(idol.Height), idol.Height);
                    yield return (nameof(idol.Weight), idol.Weight);
                    yield return (nameof(idol.Bust), idol.Bust);
                    yield return (nameof(idol.Waist), idol.Waist);
                    yield return (nameof(idol.Hip), idol.Hip);
                    yield return (nameof(idol.Diffe), idol.Diffe);
                    yield return (nameof(idol.Age), idol.Age);
                }
                Param = f().ToDictionary(key => key.key, value => value.value);
                Blood = idol.Blood;
                Work = idol.Work;
                Name = idol.Name;
            }
        }

        public class CheckItemData : IComparable<CheckItemData>
        {
            public string Text { get; set; }
            public bool IsChecked { get; set; }
            public CheckItemData(string text, bool isChecked)
            {
                Text = text;
                IsChecked = isChecked;
            }

            public int CompareTo(CheckItemData other)
            {
                if (other is null)
                {
                    throw new ArgumentNullException(nameof(other));
                }
                if (nowFilter == "None")
                {
                    return 0;
                }
                if (nowFilter == "Blood")
                {
                    var bloodDict = new Dictionary<string, int>
                    {
                        { "A", 0 },
                        { "B", 1 },
                        { "O", 2 },
                        { "AB", 3 },
                        { "", 4 },
                    };
                    return bloodDict[Text] - bloodDict[other.Text];
                }
                if (nowFilter == "Work")
                {
                    return (int)Enum.Parse(typeof(WorkType), Text) - (int)Enum.Parse(typeof(WorkType), other.Text);
                }
                throw new ArgumentException("undefined", other.Text);
            }
        }

        private class GraphDataFilter
        {
            public Func<ScatterPlot, string> GroupFilter { get; set; }
            public Func<ScatterPlot, string, bool> ProtsFilter { get; set; }

            public GraphDataFilter(Func<ScatterPlot, string> groupFilter, Func<ScatterPlot, string, bool> protsFilter)
            {
                GroupFilter = groupFilter;
                ProtsFilter = protsFilter;
            }
        }
        #endregion

        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;

        private readonly IReadOnlyList<ScatterPlot> MasterList;
        public SeriesCollection ScatterCollection { get; set; }
        public List<string> ParamList { get; set; }

        private string horizontalValue;
        private string verticalValue;
        public string HorizontalValue { get => horizontalValue; set { horizontalValue = value; GrapgEdit(); } }
        public string VerticalValue { get => verticalValue; set { verticalValue = value; GrapgEdit(); } }

        public ReactiveProperty<double> MaxHeight { get; set; } = new ReactiveProperty<double>();
        public ReactiveProperty<double> MinHeight { get; set; } = new ReactiveProperty<double>();
        public ReactiveProperty<double> MaxWidth { get; set; } = new ReactiveProperty<double>();
        public ReactiveProperty<double> MinWidth { get; set; } = new ReactiveProperty<double>();

        private static string nowFilter = "None";
        public Dictionary<string, CheckItemData> RadioButtonFilter { get; private set; }
        public List<CheckItemData> CheckBoxFilter { get; private set; }

        private readonly ReactiveProperty<string> allCrearText = new ReactiveProperty<string>();
        public ReactiveProperty<string> AllCrearText
        {
            get
            {
                allCrearText.Value = CheckBoxFilter.All(x => x.IsChecked) ? "Select Clear" : "Select All";
                return allCrearText;
            }
        }
        #endregion

        #region コンストラクタ
        public ScatterPlotViewModel()
        {
            MasterList = Model.IDOLList.Select(x => new ScatterPlot(x)).ToList();

            RadioButtonFilter = new Dictionary<string, CheckItemData>
            {
                { "None", new CheckItemData("None", true) },
                { nameof(IDOLView.Blood), new CheckItemData(nameof(IDOLView.Blood), false) },
                { nameof(IDOLView.Work), new CheckItemData(nameof(IDOLView.Work), false) }
            };

            CheckBoxFilter = new List<CheckItemData>();
            ParamList = new List<string>(){
                nameof(IDOLView.Height),
                nameof(IDOLView.Weight),
                nameof(IDOLView.Bust),
                nameof(IDOLView.Waist),
                nameof(IDOLView.Hip),
                nameof(IDOLView.Diffe),
                nameof(IDOLView.Age),
            };
            horizontalValue = nameof(IDOLView.Height);
            verticalValue = nameof(IDOLView.Weight);

            GrapgEdit();
        }
        #endregion

        #region グラフ描画
        private ViewModelCommand _GrapgEditCommand;
        public ViewModelCommand GrapgEditCommand => _GrapgEditCommand ??= new ViewModelCommand(GrapgEdit);

        public void GrapgEdit()
        {
            var grapheList = MasterList.Where(x => x.Param[HorizontalValue] != 0 && x.Param[VerticalValue] != 0);
            MaxHeight.Value = grapheList.Max(x => x.Param[VerticalValue]);
            MinHeight.Value = grapheList.Min(x => x.Param[VerticalValue]);
            MaxWidth.Value = grapheList.Max(x => x.Param[HorizontalValue]);
            MinWidth.Value = grapheList.Min(x => x.Param[HorizontalValue]);

            if (RadioButtonFilter["None"].IsChecked)
            {
                NoneFilterGraphEdit(grapheList);
            }
            else
            {
                FilterGraphEdit(grapheList);
            }
            RaisePropertyChanged(nameof(CheckBoxFilter));
            RaisePropertyChanged(nameof(ScatterCollection));
            RaisePropertyChanged(nameof(AllCrearText));
        }

        private void NoneFilterGraphEdit(IEnumerable<ScatterPlot> grapheList)
        {
            CheckBoxFilter = new List<CheckItemData>();
            var values = new ChartValues<ObservablePoint>(grapheList.Select(x => new ObservablePoint(x.Param[HorizontalValue], x.Param[VerticalValue])));

            ScatterCollection = new SeriesCollection {
                new ScatterSeries {
                    Title = HorizontalValue + "-" + VerticalValue,
                    Values = values,
                }
            };
        }

        private void FilterGraphEdit(IEnumerable<ScatterPlot> grapheList)
        {
            var funcDict = new Dictionary<string, GraphDataFilter> {
                ["Blood"] = new GraphDataFilter(x => x.Blood, (x, y) => x.Blood == y),
                ["Work"] = new GraphDataFilter(x => x.Work.ToString(), (x, y) => x.Work.ToString() == y),
            };

            nowFilter = RadioButtonFilter.First(x => x.Value.IsChecked).Key;
            var graphFiletr = funcDict[nowFilter];
            var filter = new HashSet<string>(grapheList.Select(graphFiletr.GroupFilter));

            //チェックボックスの種類が変わったとき
            if (!CheckBoxFilter.Any(x => x.Text == filter.First()))
            {
                CheckBoxFilter = filter.Select(x => new CheckItemData(x, true)).OrderBy(x => x).ToList();
            }

            var detailSelected = CheckBoxFilter.Where(y => y.IsChecked).Select(y => y.Text);
            grapheList = grapheList.Where(x => detailSelected.Any(y => graphFiletr.ProtsFilter(x, y)));

            ScatterCollection = new SeriesCollection();
            ScatterCollection.AddRange(
                grapheList.GroupBy(graphFiletr.GroupFilter).Select(x => new ScatterSeries {
                    Title = x.Key,
                    Values = new ChartValues<ObservablePoint>(x.Select(y => new ObservablePoint(y.Param[HorizontalValue], y.Param[VerticalValue]))),
                })
            );
        }
        #endregion

        #region ボタン
        private ViewModelCommand _AllClearCommand;
        public ViewModelCommand AllClearCommand => _AllClearCommand ??= new ViewModelCommand(AllClear);

        public void AllClear()
        {
            var setValue = !CheckBoxFilter.All(x => x.IsChecked);
            CheckBoxFilter = CheckBoxFilter.Select(x => new CheckItemData(x.Text, setValue)).ToList();
            GrapgEdit();
        }
        #endregion
    }
}

