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
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace QuizAPP.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
       public MainWindowViewModel()
        {
            TestViewModel = new TestWindowViewModel();
            LoginViewModel = new LoginViewModel();
            ResultViewModel = new ResultWindowViewModel();
            LoginWindowVisibility = Visibility.Visible;
            TestWindowVisibility = Visibility.Collapsed;
            ResultWindowVisibility = Visibility.Collapsed;
            StartTestCommand = new DelegateCommand(ExecuteStartTestCommand, CanExecuteStartTestCommand);
            NextQuestionCommand = new DelegateCommand(ExecuteNextQuestionCommand, CanExecuteNextQuestionCommand);
            PreviousQuestionCommand = new DelegateCommand(ExecutePreviousQuestionCommand, CanExecutePreviousQuestionCommand);
            SubmitCommand = new DelegateCommand(ExecuteSubmitQuestionCommand, CanExecuteSubmitQuestionCommand);
            SkipCommand = new DelegateCommand(ExecuteSkipQuestionCommand, CanExecuteSkipQuestionCommand);
            CloseCommand = new DelegateCommand(ExecuteCloseCommand, CanExecuteCloseCommand);
        }

        public bool IsTimeEllapsed { get; set; }
        private bool CanExecuteCloseCommand(object obj)
        {
            return true;
        }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        public bool ShowOnlySkippedQuestions { get; set; }

        private bool CanExecuteStartTestCommand(object obj)
        {
            return true;
        }

        private void ExecuteStartTestCommand(object obj)
        {
            if(this.LoginViewModel!=null && this.LoginViewModel.Validate())
            {
                LoginWindowVisibility = Visibility.Collapsed;
                TestWindowVisibility = Visibility.Visible;
                ResultWindowVisibility = Visibility.Collapsed;
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            testStartedTime = DateTime.Now.TimeOfDay;

        }

        private TimeSpan testStartedTime;
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TestViewModel.Time = (testStartedTime - DateTime.Now.TimeOfDay).ToString().Substring(1,8);
            if(this.TestViewModel.Time == "00:05:00")
            {
                this.IsTimeEllapsed = true;
                this.ExecuteSubmitQuestionCommand(null);
            }
        }

        private bool CanExecutePreviousQuestionCommand(object obj)
        {
            return true;
        }

        private void ExecutePreviousQuestionCommand(object obj)
        {
            if (!ShowOnlySkippedQuestions)
            {
                if (this.TestViewModel != null && this.TestViewModel.QuestionList != null &&  this.TestViewModel.SelectedQutionIndex !=0 )
                {
                    SetIsAnswered(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex]);
                    this.TestViewModel.SelectedQutionIndex -= 1 ;
                }
            }
            else
            {
                if (this.TestViewModel != null && this.TestViewModel.QuestionList != null && this.TestViewModel.QuestionList.Take(this.TestViewModel.SelectedQutionIndex).Where(x=>x.IsAnswered == false).Count()>0)
                {
                    SetIsAnswered(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex]);
                    var item = this.TestViewModel.QuestionList.Take(this.TestViewModel.SelectedQutionIndex).Where(x => x.IsAnswered == false).LastOrDefault();
                    if (item != null)
                    {
                        this.TestViewModel.SelectedQutionIndex = this.TestViewModel.QuestionList.IndexOf(item);
                    }
                    
                }
            }
        }

        private bool CanExecuteSkipQuestionCommand(object obj)
        {
            return true;
        }

        private void ExecuteSkipQuestionCommand(object obj)
        {
            if (!ShowOnlySkippedQuestions)
            {
                if (this.TestViewModel != null && this.TestViewModel.QuestionList != null && this.TestViewModel.QuestionList.Count >= this.TestViewModel.SelectedQutionIndex + 1)
                {
                    SetIsAnswered(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex]);
                    if (!this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex].IsAnswered)
                        this.TestViewModel.SelectedQutionIndex += 1;
                }
            }
            
            
        }

        private bool CanExecuteSubmitQuestionCommand(object obj)
        {
            return true;
        }

        private void moveToResult()
        {
            this.calculateAndSetResults();

            LoginWindowVisibility = Visibility.Collapsed;
            TestWindowVisibility = Visibility.Collapsed;
            ResultWindowVisibility = Visibility.Visible;
        }

        private void ExecuteSubmitQuestionCommand(object obj)
        {
            if(this.IsTimeEllapsed)
            {
                moveToResult();
            }
            else
            {
                if (this.TestViewModel != null && this.TestViewModel.Validate())
                {
                    moveToResult();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("You have skipped Questions are you sure to sumbit?", "My App", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        this.TestViewModel.IsOkToSkipQuestionAndSubmit = true;

                        moveToResult();
                    }
                    else
                    {
                        this.TestViewModel.IsOkToSkipQuestionAndSubmit = false;
                        var item = this.TestViewModel.QuestionList.Where(x => x.IsAnswered == false).FirstOrDefault();
                        if (item != null)
                        {
                            this.TestViewModel.SelectedQutionIndex = this.TestViewModel.QuestionList.IndexOf(item);
                        }
                        this.ShowOnlySkippedQuestions = true;
                    }
                }
            }
            
            //if (this.TestViewModel != null && this.TestViewModel.QuestionList != null && this.TestViewModel.QuestionList.Count >= this.TestViewModel.SelectedQutionIndex + 1)
            //{
            //    this.TestViewModel.SelectedQutionIndex += 1;
            //}

        }

        private bool CanExecuteNextQuestionCommand(object obj)
        {
            return true;
        }

        private void ExecuteNextQuestionCommand(object obj)
        {

            if (!ShowOnlySkippedQuestions )
            {
                if (this.TestViewModel != null && this.TestViewModel.QuestionList != null && this.TestViewModel.QuestionList.Count >= this.TestViewModel.SelectedQutionIndex + 1)
                {
                    SetIsAnswered(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex]);
                    if(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex].IsAnswered)
                    {
                        this.TestViewModel.SelectedQutionIndex += 1;
                        calculateProgress();
                    }
                    
                }
            }
            else
            {
                if (this.TestViewModel != null && this.TestViewModel.QuestionList != null && this.TestViewModel.QuestionList.Skip(this.TestViewModel.SelectedQutionIndex).Where(x => x.IsAnswered == false).Count() > 0)
                {
                    SetIsAnswered(this.TestViewModel.QuestionList[this.TestViewModel.SelectedQutionIndex]);
                    var item = this.TestViewModel.QuestionList.Skip(this.TestViewModel.SelectedQutionIndex).Where(x => x.IsAnswered == false).FirstOrDefault();
                    if (item != null)
                    {
                        this.TestViewModel.SelectedQutionIndex = this.TestViewModel.QuestionList.IndexOf(item);
                    }

                }
            }
        }

        

        private  void SetIsAnswered(QuestionModel item)
        {
            if (item != null && item is QuestionModel)
            {
                var model = item as QuestionModel;
                if (model.QuestionType == QuestionTypes.EssayTypeQuestions)
                {
                   EssayTypeQuestion question = item.Question as EssayTypeQuestion;
                    if(question!=null)
                    model.IsAnswered = !string.IsNullOrWhiteSpace(question.Answer);
                }
                else 
                {
                    MultipleChoiceQuestion question = item.Question as MultipleChoiceQuestion;
                    if (question != null && question.Options != null)
                        model.IsAnswered = question.Options.Where(x => x.IsSelected).Count() > 0;
                }
                
            }
           
        }

        private void calculateProgress()
        {
           if( TestViewModel != null  && TestViewModel.QuestionList!=null && TestViewModel.QuestionList.Count()>0)
            {
                TestViewModel.CurrentProgressValue = TestViewModel.QuestionList.Where(x => x.IsAnswered).Count() * 10;
            }
        }
        private void calculateAndSetResults()
        {
            if (TestViewModel != null  && this.ResultViewModel !=null && this.LoginViewModel !=null)
            {
                this.ResultViewModel.Mark = Math.Round( this.TestViewModel.CalculateTotalMarks());
                this.ResultViewModel.IsPass = this.ResultViewModel.Mark > 35;
                if (this.ResultViewModel.IsPass)
                {
                    this.ResultViewModel.ResultSummary = "Congratulations " + this.LoginViewModel.Name + " you are Pass with " + this.ResultViewModel.Mark.ToString() + " % ";
                }
                else
                {
                    this.ResultViewModel.ResultSummary = "Sorry " + this.LoginViewModel.Name + " you are Failed with " + this.ResultViewModel.Mark.ToString() + " % "+"\n Try Agin!";
                }
                this.ResultViewModel.DateString = DateTime.Now.Date.ToString().Substring(0,10);
            }
        }
        public TestWindowViewModel TestViewModel { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

        public ResultWindowViewModel ResultViewModel { get; set; }

        private ICommand _nextQuestionCommand;
        public ICommand NextQuestionCommand
        {
            get { return _nextQuestionCommand; }
            set
            {
                _nextQuestionCommand = value;
                OnPropertyChanged();
            }
        }
        private ICommand _previousQuestionCommand;
        public ICommand PreviousQuestionCommand
        {
            get { return _previousQuestionCommand; }
            set
            {
                _previousQuestionCommand = value;
                OnPropertyChanged();
            }
        }
        private ICommand _startTest;
        public ICommand StartTestCommand
        {
            get { return _startTest; }
            set
            {
                _startTest = value;
                OnPropertyChanged();
            }
        }

        private ICommand _skipCommand;
        public ICommand SkipCommand
        {
            get { return _skipCommand; }
            set
            {
                _skipCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get { return _submitCommand; }
            set
            {
                _submitCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                _closeCommand = value;
                OnPropertyChanged();
            }
        }


        private Visibility _loginWindowVisibility;
        public Visibility LoginWindowVisibility
        {
            get
            {
               return _loginWindowVisibility;
            }
            set
            {
                _loginWindowVisibility = value;
                this.OnPropertyChanged();
            }
        }

        private Visibility _testWindowVisibility;
        public Visibility TestWindowVisibility
        {
            get
            {
                return _testWindowVisibility;
            }
            set
            {
                _testWindowVisibility = value;
                this.OnPropertyChanged();
            }
        }

        private Visibility _resultWindowVisibility;
        public Visibility ResultWindowVisibility
        {
            get
            {
                return _resultWindowVisibility;
            }
            set
            {
                _resultWindowVisibility = value;
                this.OnPropertyChanged();
            }
        }

        //InotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propeetyname = "")
        {
            if(PropertyChanged!=null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propeetyname));
        }
    }
}
