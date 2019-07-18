using System.Collections.Generic;
using System.Linq;
using Livet;
using Models.Master;

namespace ViewModels.Extention
{
    #region レコード
    public class UnitRecordData
    {
        #region プロパティ・フィールド
        public string Name { get; }
        public IReadOnlyList<IDOLView> Members { get; }
        #endregion

        #region コンストラクタ
        public UnitRecordData(string name, IReadOnlyList<IDOLView> members)
        {
            Name = name;
            Members = members;
        }
        #endregion
    }
    #endregion

    public class UnitDetailDataViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;
        public UnitRecordData Record { get; set; }
        #endregion

        #region コンストラクタ
        public UnitDetailDataViewModel(UnitView unit)
        {
            Record = new UnitRecordData(unit.Name, unit.Members);
        }
        #endregion

        #region DataGridタブルクリック
        public IDOLView SelectedIdol { get; set; }
        public void DataGridDoubleClick()
        {
            if (SelectedIdol != null)
            {
                var selectedDev = Model.IDOLDeviations.FirstOrDefault(x => x.Name == SelectedIdol.Name);
                using var transitionViewModel = new DetailDataViewModel(SelectedIdol, selectedDev);
                Messenger.Raise(new Livet.Messaging.TransitionMessage(transitionViewModel, "DetailDataViewOpen"));
            }
        }
        #endregion
    }
}
