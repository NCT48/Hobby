using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ExtendLinq;
using Livet;
using Livet.Commands;
using Models.Master;

namespace ViewModels.Extention
{
    public class IdolQuizViewModel : ViewModel
    {
        #region プロパティ・フィールド
        private readonly IdolModel Model = IdolModel.Instance;

        public class QuizData
        {
            public bool IsHint { get; set; }
            public bool IsAnswer { get; set; }

            private readonly string name;
            public string Name => IsAnswer ? name : "";
            private readonly string phonethic;
            public string Phonethic => IsAnswer ? phonethic : "";

            public double Score { get; set; }
            public double Age { get; }
            public double Height { get; }
            public double Weight { get; }
            public double Bust { get; }
            public double Waist { get; }
            public double Hip { get; }

            private readonly string birthPlace;
            private readonly string birthDay;
            private readonly string blood;
            public string BirthPlace => IsHint ? birthPlace : "";
            public string BirthDay => IsHint ? birthDay : "";
            public string Blood => IsHint ? blood : "";

            public QuizData(IDOLDeviation dev, IDOLView idol)
            {
                name = dev.Name;
                phonethic = dev.Phonetic;
                Age = dev.AgeScore;
                Height = dev.HeightScore;
                Weight = dev.WeightScore;
                Bust = dev.BustScore;
                Waist = dev.WaistScore;
                Hip = dev.HipScore;
                Score = Math.Round(300 / dev.TotalScore, 2, MidpointRounding.AwayFromZero);

                birthPlace = idol.BirthPlace;
                birthDay = idol.BirthDay;
                blood = idol.Blood;

                IsHint = false;
                IsAnswer = false;
            }

            public bool CheckAnswer(string ans) => name == ans || phonethic == ans;
        }

        public QuizData Quiz { get; set; }

        private string answer;
        public string Answer { get => answer; set => SetFilter(value); }

        private IReadOnlyList<Tuple<string, string>> iDOLList;
        public IReadOnlyList<Tuple<string, string>> IDOLList { get; set; }

        private List<QuizData> quizDatas;
        #endregion

        #region コンストラクタ
        public IdolQuizViewModel()
        {
            iDOLList = Model.IDOLList.Select(x => new Tuple<string, string>(x.Name, x.Phonetic)).ToList();
            IDOLList = new List<Tuple<string, string>>();
            MakeQuiz();
        }
        #endregion

        #region メソッド
        private void MakeQuiz()
        {
            if (quizDatas?.Any() != true)
            {
                quizDatas = Model.IDOLList.Where(x => x.HasValue())
                                          .Shuffle()
                                          .Join(Model.IDOLDeviations, x => x.Name, y => y.Name, (x, y) => new QuizData(y, x))
                                          .ToList();
            }
            Quiz = quizDatas[0];
            quizDatas = quizDatas.Skip(1).ToList();
        }

        private void SetFilter(string value)
        {
            answer = value;
            var val = value.Replace(" ", "");
            IDOLList = val.Length > 1
                ? iDOLList.Where(x => x.Item1.Replace(" ", "").Contains(val) || x.Item2.Replace(" ", "").Contains(val)).ToList()
                : new List<Tuple<string, string>>();
            RaisePropertyChanged(nameof(IDOLList));
        }
        #endregion

        #region ボタン押した時
        private ViewModelCommand _NewQuizCommand;
        public ViewModelCommand NewQuizCommand => _NewQuizCommand ??= new ViewModelCommand(NewQuiz);
        public void NewQuiz()
        {
            MakeQuiz();
            Answer = string.Empty;
            RaisePropertyChanged(nameof(Quiz));
            RaisePropertyChanged(nameof(Answer));
        }

        private ViewModelCommand _AnswerCommand;
        public ViewModelCommand AnswerCommand => _AnswerCommand ??= new ViewModelCommand(SetAnswer);
        public void SetAnswer()
        {
            var message = Quiz.CheckAnswer(Answer) ? "Correct!" : "Wrong...";
            MessageBox.Show(message);
            RaisePropertyChanged(nameof(Quiz));
        }

        private ViewModelCommand _HintCommand;
        public ViewModelCommand HintCommand => _HintCommand ??= new ViewModelCommand(SetHint);
        public void SetHint()
        {
            Quiz.IsHint = true;
            RaisePropertyChanged(nameof(Quiz));
        }

        private ViewModelCommand _GiveUpCommand;
        public ViewModelCommand GiveUpCommand => _GiveUpCommand ??= new ViewModelCommand(GiveUp);
        public void GiveUp()
        {
            Quiz.IsAnswer = true;
            RaisePropertyChanged(nameof(Quiz));
        }
        #endregion

        public Tuple<string, string> SelectedName { get; set; }
        #region DataGridダブルクリック
        public void DataGridDoubleClick()
        {
            if (SelectedName is null)
            {
                return;
            }
            Answer = SelectedName.Item1;
            RaisePropertyChanged(nameof(Answer));
        }
        #endregion
    }
}
