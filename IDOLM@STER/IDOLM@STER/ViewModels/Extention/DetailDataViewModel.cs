using System;
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

            IEnumerable<RankData> rankDatas()
            {
                yield return new RankData(nameof(idol.Age), idol, deviation?.AgeScore, x => x.Age);
                yield return new RankData(nameof(idol.Height), idol, deviation?.HeightScore, x => x.Height);
                yield return new RankData(nameof(idol.Weight), idol, deviation?.WeightScore, x => x.Weight);
                yield return new RankData(nameof(idol.Bust), idol, deviation?.BustScore, x => x.Bust);
                yield return new RankData(nameof(idol.Waist), idol, deviation?.WaistScore, x => x.Waist);
                yield return new RankData(nameof(idol.Hip), idol, deviation?.HipScore, x => x.Hip);
                yield return new RankData(nameof(idol.BMI), idol, deviation?.BMIScore, x => x.BMI);
                yield return new RankData(nameof(idol.Under), idol, deviation?.UnderScore, x => x.Under);
                yield return new RankData(nameof(idol.Diffe), idol, deviation?.DiffScore, x => x.Diffe);
            }

            RankDatas = rankDatas().ToList();

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
        private readonly IdolModel Model = IdolModel.Instance;
        public string Name { get; set; }
        public double Param { get; set; }
        public double? Score { get; set; }
        public string Rank { get; set; }

        public RankData(string name, IDOLView idol, double? score, Func<IDOLView, double> selector)
        {
            Name = name;
            Param = selector(idol);
            Score = score;
            var rank = Model.IDOLList.Count(x => selector(x) > Param) + 1;
            var count = Model.IDOLList.Count(x => selector(x) != 0);

            if ( Param == 0)
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
        public double Age { get; set; }
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
            Age = idol.Age;
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
