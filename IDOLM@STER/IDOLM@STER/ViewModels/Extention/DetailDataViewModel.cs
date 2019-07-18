using System.Collections.Generic;
using System.Linq;
using ExtendLinq;
using Livet;
using Livet.Commands;
using Models.Master;
using Reactive.Bindings;

namespace ViewModels.Extention
{
    #region レコード
    public class DetailData
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;
        public IDOLView MasterIDOL { get; set; }
        public string Age => MasterIDOL.Age + "歳";
        public string Cup => MasterIDOL.Cup + "カップ";
        public string Blood => MasterIDOL.Blood + "型";
        public List<RankData> RankDatas { get; set; }
        public List<SimData> SimDatas { get; set; }
        public List<UnitData> UnitList { get; set; }
        #endregion

        #region コンストラクタ
        public DetailData(IDOLView idol, IDOLDeviation deviation)
        {
            if (idol is null)
            {
                return;
            }

            MasterIDOL = idol;
            var idolList = Model.IDOLList;
            if (deviation != null)
            {
                var tikaiList = Model.IDOLDeviations.Similarity(deviation).OrderBy(x => x.Score).Where(x => x.Name != deviation.Name).Take(5);
                SimDatas = tikaiList.Select(x => new SimData(x.Name, x.Score)).ToList();
            }

            RankDatas = new List<RankData>
            {
                new RankData(
                    nameof(idol.Height),
                    idol.Height,
                    deviation?.HeightScore,
                    Model.IDOLList.Count(x => x.Height > idol.Height) + 1,
                    Model.IDOLList.Count(x => x.Height != 0)
                    ),
                new RankData(
                    nameof(idol.Weight),
                    idol.Weight,
                    deviation?.WeightScore,
                    idolList.Count(x => x.Weight > idol.Weight) + 1,
                    Model.IDOLList.Count(x => x.Weight != 0)
                    ),
                new RankData(
                    nameof(idol.Bust),
                    idol.Bust,
                    deviation?.BustScore,
                    idolList.Count(x => x.Bust > idol.Bust) + 1,
                    Model.IDOLList.Count(x => x.Bust != 0)
                    ),
                new RankData(
                    nameof(idol.Waist),
                    idol.Waist,
                    deviation?.WaistScore,
                    idolList.Count(x => x.Waist > idol.Waist) + 1,
                    Model.IDOLList.Count(x => x.Waist != 0)
                    ),
                new RankData(
                    nameof(idol.Hip),
                    idol.Hip,
                    deviation?.HipScore,
                    idolList.Count(x => x.Hip > idol.Hip) + 1,
                    Model.IDOLList.Count(x => x.Hip != 0)
                    ),
                new RankData(
                    nameof(idol.BMI),
                    idol.BMI,
                    deviation?.BMIScore,
                    idolList.Count(x => x.BMI > idol.BMI) + 1,
                    Model.IDOLList.Count(x => x.BMI != 0)
                    ),
                new RankData(
                    nameof(idol.Under),
                    idol.Under,
                    deviation?.UnderScore,
                    idolList.Count(x => x.Under > idol.Under) + 1,
                    Model.IDOLList.Count(x => x.Under != 0)
                    ),
                new RankData(
                    nameof(idol.Diffe),
                    idol.Diffe,
                    deviation?.DiffScore,
                    idolList.Count(x => x.Diffe > idol.Diffe) + 1,
                    Model.IDOLList.Count(x => x.Diffe != 0)
                    ),
            };

            UnitList = Model.UnitList
                .Where(x => x.Members.Any(y => MasterIDOL == y))
                .Select(x => new UnitData() { Name = x.Name, Member = x.Members.Count }).ToList();
        }
        #endregion
    }
    #endregion

    #region ランキング
    public class RankData
    {
        public string Name { get; set; }
        public double Param { get; set; }
        public double? Score { get; set; }
        public string Rank { get; set; }
        public RankData(string name, double param, double? score, int rank, int count)
        {
            Name = name;
            Param = param;
            Score = score;
            if (param == 0)
            {
                Rank = 0 + "/" + 0;
            }
            else if (rank > count)
            {
                Rank = count.ToString() + "/" + count.ToString();
            }
            else
            {
                Rank = rank.ToString() + "/" + count.ToString();
            }
        }
    }
    #endregion

    #region 近似
    public class SimData
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bust { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }

        public SimData(string name, double score)
        {
            Score = score;
            Name = name;
            var idol = IdolModel.Instance.IDOLList.First(x => x.Name == name);
            Height = idol.Height;
            Weight = idol.Weight;
            Bust = idol.Bust;
            Waist = idol.Waist;
            Hip = idol.Hip;
        }
    }
    #endregion

    #region ユニット
    public class UnitData
    {
        public string Name { get; set; }
        public int Member { get; set; }
    }
    #endregion

    public class DetailDataViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;
        public DetailData Record { get; set; }
        private List<DetailData> Records;
        private int index;
        public ReactiveProperty<bool> BuckButtonEnabled { get; set; }
        public ReactiveProperty<bool> ForwardButtonEnabled { get; set; }
        #endregion

        #region コンストラクタ
        public DetailDataViewModel(IDOLView idol, IDOLDeviation deviation)
        {
            Record = new DetailData(idol, deviation);
            Records = new List<DetailData> { Record };
            index = 0;
            BuckButtonEnabled = new ReactiveProperty<bool>(false);
            ForwardButtonEnabled = new ReactiveProperty<bool>(false);
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
                Record = new DetailData(selectedIdol, selectedDev);
                index++;
                Records = Records.Take(index).Append(Record).ToList();
                RaisePropertyChanged(nameof(Record));
                BuckButtonEnabled.Value = true;
                ForwardButtonEnabled.Value = false;
            }
        }

        public UnitData Selectedunit { get; set; }
        public void DataGridDoubleClickUnit()
        {
            if (Selectedunit == null)
            {
                return;
            }
            var selectedUnit = Model.UnitList.FirstOrDefault(x => x.Name == Selectedunit.Name);
            using var unitDetailViewModel = new UnitDetailDataViewModel(selectedUnit);
            Messenger.Raise(new Livet.Messaging.TransitionMessage(unitDetailViewModel, "UnitDetailDataViewOpen"));
        }
        #endregion

        #region ボタン押した時
        private ViewModelCommand _MoveIdolCommand;
        public ViewModelCommand MoveIdolCommand => _MoveIdolCommand ??= new ViewModelCommand(ForwardIdol);
        public void ForwardIdol()
        {
            if (index == Records.Count - 1)
            {
                return;
            }
            index++;
            Record = Records[index];
            RaisePropertyChanged(nameof(Record));
            if (index == Records.Count - 1)
            {
                ForwardButtonEnabled.Value = false;
            }
            BuckButtonEnabled.Value = true;
        }

        private ViewModelCommand _ReturnIdolCommand;
        public ViewModelCommand ReturnIdolCommand => _ReturnIdolCommand ??= new ViewModelCommand(BackIdol);

        public void BackIdol()
        {
            if (index == 0)
            {
                return;
            }
            index--;
            Record = Records[index];
            RaisePropertyChanged(nameof(Record));
            if (index == 0)
            {
                BuckButtonEnabled.Value = false;
            }
            ForwardButtonEnabled.Value = true;
        }
        #endregion
    }
}
