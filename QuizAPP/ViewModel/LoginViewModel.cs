using QuizAPP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizAPP.ViewModel
{
    public class LoginViewModel :ViewModelBase,INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            
        }

        private bool CanExecuteStartTestCommand(object obj)
        {
            return true;
        }

        private void ExecuteStartTestCommand(object obj)
        {
           
        }
        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _message;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public override bool Validate()
        {
            this.Message = "";
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email))
            {
                return true;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Name))
                    this.Message += "Please Enter name.";
                if (string.IsNullOrWhiteSpace(Email))
                    this.Message += "\n Please Enter Email.";
                return false;
            }
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
