using SUR_CSTG.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SUR_CSTG.ViewModels.PersonViewModels
{
    public class AddPersonWindowViewModel : ViewModel
    {
        #region Fields

        SUR_DbContext _ctx = new SUR_DbContext();
        IEnumerable<Position> _position;
        ICommand _addPersonCommand;
        ICommand _closeWinndow;
        string _name;
        string _surname;
        string _login;
        string _password;
        Position _selectedPosition;
        string _phoneNumber;

        #endregion

        #region Properities

        public Position SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                _selectedPosition = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public IEnumerable<Position> Position
        {
            get { return Enum.GetValues(typeof(Position)).Cast<Position>(); }

            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        #endregion

        #region Command

        public ICommand AddPersonCommand
        {
            get { return _addPersonCommand ?? (_addPersonCommand = new RelayCommand(Add, CanAdd)); }
        }

        private void Add(object obj)
        {
            string message = "Dodano pracownika\n";
            string titel = "Informacja o dodaniu pracownika";
            _ctx.Persons.Add(new Person { Name = Name, Surname = Surname, Login = Login, Password = Password, PhoneNumber = PhoneNumber, Position = SelectedPosition });
            _ctx.SaveChanges();
            var result = MessageBox.Show(message + " " + Name + " " + Surname, titel);
            Close(obj);
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(_surname)
                & !string.IsNullOrWhiteSpace(_name)
                & !string.IsNullOrWhiteSpace(_login)
                & !string.IsNullOrWhiteSpace(_password);
        }

        public ICommand CloseCommand
        {
            get { return _closeWinndow ?? (_closeWinndow = new RelayCommand(Close)); }
        }
        public void Close(object obj)
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        #endregion

    }
}
