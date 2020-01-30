using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.Model
{
    public class MultipleChoiceQuestion : IQuestion,INotifyPropertyChanged
    {
       

        private string _questionContent;

        public string QuestionContent
        {
            get
            {
                return _questionContent;
            }
            set
            {
                _questionContent = value;
                OnPropertyChanged();
            }
        }

        private List<Option> _options;

        public List<Option> Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        private int _questionNo;

        public int QuestionNumber
        {
            get
            {
                return _questionNo;
            }
            set
            {
                _questionNo = value;
                OnPropertyChanged();
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
