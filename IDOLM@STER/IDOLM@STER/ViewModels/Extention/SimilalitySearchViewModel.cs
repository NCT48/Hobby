using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ExtendLinq;
using Livet;
using Livet.Commands;
using Models.Master;

namespace ViewModels.Extention
{
    public class SimilalitySearchViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;

        private double? height;
        public string Height { get => height?.ToString(); set => height = CheckDouble(value); }
        private double? weight;
        public string Weight { get => weight?.ToString(); set => weight = CheckDouble(value); }
        private double? bust;
        public string Bust { get => bust?.ToString(); set => bust = CheckDouble(value); }
        private double? waist;
        public string Waist { get => waist?.ToString(); set => waist = CheckDouble(value); }
        private double? hip;
        public string Hip { get => hip?.ToString(); set => hip = CheckDouble(value); }

        public string BMI { get; set; }
        public string Cup { get; set; }
        public SimilalityData SimilalityRecord { get; set; }

        private double? CheckDouble(string value, [CallerMemberName] string propertyName = "")
        {
            if (!double.TryParse(value, out double d))
            {
                return null;
            }
            if (d < 0)
            {
                return null;
            }
            RaisePropertyChanged(propertyName);
            return d;
        }
        #endregion

        #region レコード
        public class SimilalityData
        {
            #region プロパティ・フィールド
            private readonly IdolModel Model = IdolModel.Instance;
            public List<SimData> SimDatas { get; set; }
            #endregion

            #region コンストラクタ
            public SimilalityData(IDOLDeviation deviation)
            {
                if (deviation != null)
                {
                    var tikaiList = Model.IDOLDeviations.Where(x => x.HasScore())
                        .Similarity(deviation).OrderBy(x => x.Score).Where(x => x.Name != deviation.Name).Take(5);
                    SimDatas = tikaiList.Select(x => new SimData(x.Name, x.Score)).ToList();
                }
            }
            #endregion
        }
        #endregion

        #region コンストラクタ
        public SimilalitySearchViewModel()
        {
        }
        #endregion

        #region DataGridタブルクリック
        public SimData SelectedSim { get; set; }
        public void DataGridDoubleClick()
        {
            if (SelectedSim != null)
            {
                var selectedIdol = Model.IDOLList.FirstOrDefault(x => x.Name == SelectedSim.Name);
                var selectedDev = Model.IDOLDeviations.FirstOrDefault(x => x.Name == SelectedSim.Name);
                using var transitionViewModel = new DetailDataViewModel(selectedIdol, selectedDev);
                Messenger.Raise(new Livet.Messaging.TransitionMessage(transitionViewModel, "DetailDataViewOpen"));
            }
        }
        #endregion

        #region ボタン押した時
        private ViewModelCommand _SearchSimilalityCommand;
        public ViewModelCommand SearchSimilalityCommand => _SearchSimilalityCommand ??= new ViewModelCommand(SearchSimilality);
        public void SearchSimilality()
        {
            var view = new IDOLView(height, weight, bust, waist, hip);
            BMI = "BMI:" + view.BMI;
            Cup = view.Cup;
            var dev = Model.IDOLList.Append(view).ToDevitation().First(x => string.IsNullOrEmpty(x.Name));
            SimilalityRecord = new SimilalityData(dev);
            RaisePropertyChanged(nameof(SimilalityRecord));
            RaisePropertyChanged(nameof(BMI));
            RaisePropertyChanged(nameof(Cup));
        }
        #endregion
    }
}
