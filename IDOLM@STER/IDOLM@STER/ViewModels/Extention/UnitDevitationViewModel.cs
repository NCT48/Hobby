using System;
using System.Collections.Generic;
using System.Linq;
using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.Windows;
using Models.Master;

namespace ViewModels.Extention
{
    #region ユニット偏差値画面用クラス
    public class UnitDevitation
    {
        public string Name { get; set; }
        public int Member { get; set; }
        public double HeightScore { get; set; }
        public double WeightScore { get; set; }
        public double BustScore { get; set; }
        public double WaistScore { get; set; }
        public double HipScore { get; set; }
        public double BMIScore { get; set; }
        public double UnderScore { get; set; }
        public double DiffScore { get; set; }
        public double TotalScore => Score();
        public double Score()
        {
            var value = Eva(HeightScore);
            value += Eva(WeightScore);
            value += Eva(BustScore);
            value += Eva(WaistScore);
            value += Eva(HipScore);
            //value += Eva(BMIScore);
            //value += Eva(UnderScore);
            //value += Eva(DiffScore);
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
        //private double Eva(double score) => Math.Pow(score - 50, 2);
        private double Eva(double score) => Math.Abs(score - 50);
    }
    #endregion

    public class UnitDevitationViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;

        public List<UnitDevitation> DevList { get; set; }
        public List<UnitDevitation> MasterDevList { get; set; }
        public List<string> UnitCount { get; set; }
        private string nowUnitCount;
        public string NowUnitCount { get => nowUnitCount; set => SetDevFilter(filterDevText, value); }
        private string filterDevText;
        public string FilterDevText { get => filterDevText; set => SetDevFilter(value, nowUnitCount); }
        #endregion

        #region コンストラクタ
        public UnitDevitationViewModel()
        {
            MasterDevList = DevList = Model.UnitList.Select(SetUnitDevitation).ToList();
            SelectedDevUnit = DevList.First();
            UnitCount = new HashSet<int>(MasterDevList.Select(x => x.Member).OrderBy(x => x)).Select(x => x.ToString()).ToList();
            UnitCount.Insert(0, string.Empty);
            filterDevText = string.Empty;
            nowUnitCount = string.Empty;
        }

        private UnitDevitation SetUnitDevitation(UnitView unit) => new UnitDevitation() {
            Name = unit.Name,
            Member = unit.Members.Count,
            HeightScore = Math.Round(unit.Deviations.Average(x => x.HeightScore), 2, MidpointRounding.AwayFromZero),
            WeightScore = Math.Round(unit.Deviations.Average(x => x.WeightScore), 2, MidpointRounding.AwayFromZero),
            BustScore = Math.Round(unit.Deviations.Average(x => x.BustScore), 2, MidpointRounding.AwayFromZero),
            WaistScore = Math.Round(unit.Deviations.Average(x => x.WaistScore), 2, MidpointRounding.AwayFromZero),
            HipScore = Math.Round(unit.Deviations.Average(x => x.HipScore), 2, MidpointRounding.AwayFromZero),
            BMIScore = Math.Round(unit.Deviations.Average(x => x.BMIScore), 2, MidpointRounding.AwayFromZero),
            UnderScore = Math.Round(unit.Deviations.Average(x => x.UnderScore), 2, MidpointRounding.AwayFromZero),
            DiffScore = Math.Round(unit.Deviations.Average(x => x.DiffScore), 2, MidpointRounding.AwayFromZero),
        };
        #endregion

        #region 画面クローズボタンクリックイベント
        private ViewModelCommand _ReturnCommand;
        public ViewModelCommand ReturnCommand
        {
            get
            {
                if (_ReturnCommand == null)
                {
                    _ReturnCommand = new ViewModelCommand(ReturnComm);
                }
                return _ReturnCommand;
            }
        }
        public void ReturnComm()
        {
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        }
        #endregion

        #region フィルタ
        private void SetDevFilter(string nameFilter, string countFilter)
        {
            DevList = MasterDevList.Where(x => x.Name.ToUpper().Contains(nameFilter.ToUpper()) || x.Name.ToLower().Contains(nameFilter.ToLower())).ToList();
            if (!string.IsNullOrEmpty(countFilter))
            {
                DevList = DevList.Where(x => x.Member.ToString() == countFilter).ToList();
            }
            filterDevText = nameFilter;
            nowUnitCount = countFilter;
            RaisePropertyChanged(nameof(DevList));
        }
        #endregion

        #region DataGridタブルクリック
        public UnitDevitation SelectedDevUnit { get; set; }
        public void DataGridDevDoubleClick()
        {
            if (SelectedDevUnit == null)
            {
                return;
            }
            var selectedUnit = Model.UnitList.FirstOrDefault(x => x.Name == SelectedDevUnit.Name);
            using var unitDataViewModel = new UnitDetailDataViewModel(selectedUnit);
            Messenger.Raise(new TransitionMessage(unitDataViewModel, "UnitDetailDataViewOpen"));
        }
        #endregion
    }
}
