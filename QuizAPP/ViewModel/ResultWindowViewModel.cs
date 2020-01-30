using QuizAPP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.ViewModel
{
   public class ResultWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private string _resultSummary;
        public string ResultSummary
        {
            get
            {
                return _resultSummary;
            }
            set
            {
                _resultSummary = value;
                OnPropertyChanged();
            }
        }

        private string _dateString;
        public string DateString
        {
            get
            {
                return _dateString;
            }
            set
            {
                _dateString = value;
                OnPropertyChanged();
            }
        }

        private bool _isPass;
        public bool IsPass
        {
            get
            {
                return _isPass;
            }
            set
            {
                _isPass = value;
                OnPropertyChanged();
            }
        }

        private double _mark;
        public double Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
                OnPropertyChanged();
            }
        }
        public override bool Validate()
        {
            return true;
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
