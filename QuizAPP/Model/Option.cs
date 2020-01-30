using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.Model
{
   public class Option : INotifyPropertyChanged
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        

             private string _optionNumber;

        public string OptionNumber
        {
            get
            {
                return _optionNumber;
            }
            set
            {
                _optionNumber = value;
                OnPropertyChanged();
            }
        }
        private string _answerContent;

        public string AnswerContent
        {
            get
            {
                return _answerContent;
            }
            set
            {
                _answerContent = value;
                OnPropertyChanged();
            }
        }

        //InotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propeetyname ="")
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propeetyname));
        }
    }
}
