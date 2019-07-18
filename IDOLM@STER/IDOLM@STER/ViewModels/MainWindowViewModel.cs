using System;
using System.Collections.Generic;
using System.Linq;
using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.Windows;
using Models.Master;
using ViewModels.Utility;

namespace ViewModels.Main
{
    public class MainWindowViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;
        private bool isAmbiguous;
        public bool IsAmbiguous
        {
            get => isAmbiguous;
            set
            {
                isAmbiguous = value;
                SetFilter(filterText);
            }
        }
        public IReadOnlyList<IDOLView> IDOLList { get; set; }
        private string filterText;
        public string FilterText { get => filterText; set => SetFilter(value); }
        #endregion

        #region コンストラクタ
        public MainWindowViewModel()
        {
            IDOLList = Model.IDOLList;
            SelectedIDOL = IDOLList[0];
            filterText = string.Empty;
        }
        #endregion

        #region 画面オープンボタンクリックイベント
        private ListenerCommand<string> _ShowViewCommand;
        public ListenerCommand<string> ShowViewCommand => _ShowViewCommand ??= new ListenerCommand<string>(ShowView);
        public void ShowView(string command) => Messenger.Raise(new TransitionMessage(command + "Open"));
        #endregion

        #region 画面クローズボタンクリックイベント
        private ViewModelCommand _ReturnCommand;
        public ViewModelCommand ReturnCommand => _ReturnCommand ??= new ViewModelCommand(ReturnComm);
        public void ReturnComm() => Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        #endregion

        #region 保存ボタンイベント
        private ViewModelCommand _OutPutJsonCommand;
        public ViewModelCommand OutPutJsonCommand
        {
            get
            {
                if (_OutPutJsonCommand == null)
                {
                    _OutPutJsonCommand = new ViewModelCommand(OutPutJson);
                }
                return _OutPutJsonCommand;
            }
        }

        public void OutPutJson() => Model.SaveJsonIDOL();
        #endregion

        #region フィルタ
        private void SetFilter(string filter)
        {
            var search = isAmbiguous ? (Func<string, string, bool>)UtilityFunction.AmbiguousSearch : (x, y) => x.Contains(y.Replace(" ", ""));
            IDOLList = Model.IDOLList.Where(x => search(x.Name, filter) || search(x.Phonetic, filter)).ToList();
            filterText = filter;
            RaisePropertyChanged(nameof(IDOLList));
        }
        #endregion

        #region DataGridタブルクリック
        public IDOLView SelectedIDOL { get; set; }
        public void DataGridDoubleClick()
        {
            if (SelectedIDOL == null)
            {
                return;
            }
            var selectedDev = Model.IDOLDeviations.FirstOrDefault(x => x.Name == SelectedIDOL.Name);
            using var detailDataViewModel = new Extention.DetailDataViewModel(SelectedIDOL, selectedDev);
            Messenger.Raise(new TransitionMessage(detailDataViewModel, "DetailDataViewOpen"));
        }
        #endregion
    }
}
