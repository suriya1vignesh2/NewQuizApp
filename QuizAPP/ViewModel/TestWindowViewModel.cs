using QuizAPP.Common;
using QuizAPP.Helper;
using QuizAPP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.ViewModel
{
    public class TestWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public TestWindowViewModel()
        {
            this.GenerateData();
        }

        private List<QuestionModel> _questionList;
        public List<QuestionModel> QuestionList
        {
            get
            {
                return _questionList;
            }
            set
            {
                _questionList = value;
                OnPropertyChanged();
            }
        }

        private int _selectedQutionIndex =0;
        public int SelectedQutionIndex
        {
            get
            {
                return _selectedQutionIndex;
            }
            set
            {
                _selectedQutionIndex = value;
                this.SelectedQutionNumber = (_selectedQutionIndex + 1).ToString() + "  ) ";
                OnPropertyChanged();
            }
        }

        private string _selectedQutionNumber = "1 ) ";
        public string SelectedQutionNumber
        {
            get
            {
                return _selectedQutionNumber;
            }
            set
            {
                _selectedQutionNumber = value;
                OnPropertyChanged();
            }
        }

        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }


        
        private double _currentProgressValue = 0;
        public double CurrentProgressValue
        {
            get
            {
                return _currentProgressValue;
            }
            set
            {
                _currentProgressValue = value;
                OnPropertyChanged();
            }
        }
        public bool IsOkToSkipQuestionAndSubmit { get; set; }
        private void GenerateData()
        {
            List<QuestionModel> questions = QuestionData.GetQuestions();
            var random = new Random();
           this.QuestionList = questions.OrderBy(x => random.Next()).Take(9).ToList();
            
        }
        public override bool Validate()
        {
            if (IsOkToSkipQuestionAndSubmit || this.QuestionList.Where(x => x.IsAnswered).Count() == this.QuestionList.Count)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public double CalculateTotalMarks()
        {
            double total = 0;
            foreach(QuestionModel model in this.QuestionList.Where(x=>x.IsAnswered))
            {
                if (model.QuestionType == QuestionTypes.EssayTypeQuestions)
                {
                    EssayTypeQuestion question = model.Question as EssayTypeQuestion;
                    
                        if(question != null && question.Answer == model.CorrectAnswer)
                        {
                        model.AnswerAccuracy = 100;
                        }
                }
                else
                {
                    MultipleChoiceQuestion question = model.Question as MultipleChoiceQuestion;
                    if (question != null && question.Options != null)
                    {
                        List<string> correctAnswer = model.CorrectAnswer.Split(',').ToList();
                        List<string> userAnswer = question.Options.Where(x => x.IsSelected).Select(s => s.AnswerContent).ToList();

                        foreach(string ans  in userAnswer)
                        {
                            if(correctAnswer.Contains(ans))
                            {
                                model.AnswerAccuracy += (100 / correctAnswer.Count);
                            }
                        }
                    }
                }
                model.AnswerAccuracy= Math.Round(model.AnswerAccuracy);
                total += model.AnswerAccuracy;
            }

            return total/this.QuestionList.Count;
        }

        //InotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propeetyname = "")
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propeetyname));
        }
    }
}
