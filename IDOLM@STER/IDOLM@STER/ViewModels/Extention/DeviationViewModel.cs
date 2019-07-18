using System;
using System.Collections.Generic;
using System.Linq;
using Livet;
using Livet.Messaging;
using Models.Master;
using ViewModels.Utility;

namespace ViewModels.Extention
{
    public class DeviationViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;

        private bool isAmbiguousDev;
        public bool IsAmbiguousDev
        {
            get => isAmbiguousDev;
            set
            {
                isAmbiguousDev = value;
                SetDevFilter(filterDevText);
            }
        }
        public IReadOnlyList<IDOLDeviation> DevList { get; set; }
        private string filterDevText;
        public string FilterDevText { get => filterDevText; set => SetDevFilter(value); }
        #endregion

        #region コンストラクタ
        public DeviationViewModel()
        {
            DevList = Model.IDOLDeviations;
            SelectedDevIDOL = DevList[0];
            filterDevText = string.Empty;
        }
        #endregion

        #region フィルタ
        private void SetDevFilter(string filter)
        {
            var search = isAmbiguousDev ? (Func<string, string, bool>)UtilityFunction.AmbiguousSearch : (x, y) => x.Contains(y.Replace(" ", ""));
            DevList = Model.IDOLDeviations.Where(x => search(x.Name, filter) || search(x.Phonetic, filter)).ToList();
            filterDevText = filter;
            RaisePropertyChanged(nameof(DevList));
        }
        #endregion

        #region DataGridタブルクリック
        public IDOLDeviation SelectedDevIDOL { get; set; }
        public void DataGridDevDoubleClick()
        {
            if (SelectedDevIDOL == null)
            {
                return;
            }
            var selectedIdol = Model.IDOLList.FirstOrDefault(x => x.Name == SelectedDevIDOL.Name);
            using var detailDataViewModel = new DetailDataViewModel(selectedIdol, SelectedDevIDOL);
            Messenger.Raise(new TransitionMessage(detailDataViewModel, "DetailDataViewOpen"));
        }
        #endregion
    }
}
