using System;
using System.Linq;
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
        }

        public QuizData Answer { get; set; }
        #endregion

        #region コンストラクタ
        public IdolQuizViewModel()
        {
            MakeQuiz();
        }
        #endregion

        #region メソッド
        private void MakeQuiz()
        {
            var score = Model.IDOLDeviations.Where(x => x.HasScore()).Random();
            var idol = Model.IDOLList.First(x => x.Name == score.Name);
            Answer = new QuizData(score, idol);
        }
        #endregion

        #region ボタン押した時
        private ViewModelCommand _NewQuizCommand;
        public ViewModelCommand NewQuizCommand => _NewQuizCommand ??= new ViewModelCommand(NewQuiz);
        public void NewQuiz()
        {
            MakeQuiz();
            RaisePropertyChanged(nameof(Answer));
        }

        private ViewModelCommand _AnswerCommand;
        public ViewModelCommand AnswerCommand => _AnswerCommand ??= new ViewModelCommand(SetAnswer);
        public void SetAnswer()
        {
            Answer.IsAnswer = true;
            RaisePropertyChanged(nameof(Answer));
        }

        private ViewModelCommand _HintCommand;
        public ViewModelCommand HintCommand => _HintCommand ??= new ViewModelCommand(SetHint);
        public void SetHint()
        {
            Answer.IsHint = true;
            RaisePropertyChanged(nameof(Answer));
        }
        #endregion
    }
}
