using SUR_CSTG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SUR_CSTG.ViewModels.PersonViewModels
{
    class EditPersonWindowViewModel : ViewModel
    {
        #region Fields

        IEnumerable<Position> _position;
        PersonViewModel _personViewModel;
        Person _personToEdit;
        Position _selectedPosition;
        Position _positionToEdit;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _closeWinndow;
        ICommand _edit;
        string _name;
        string _surname;
        string _login;
        string _password;
        string _phoneNumber;

        #endregion

        #region Constructors

        public EditPersonWindowViewModel(PersonViewModel personViewModel)
        {
            _personViewModel = personViewModel;
        }

        #endregion

        #region Properities

        public IEnumerable<Position> Position
        {
            get { return Enum.GetValues(typeof(Position)).Cast<Position>(); }
            set
            {
                _position = value;
                OnPropertyChanged("");
            }
        }

        public Position SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                _selectedPosition = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public Position PositionToEdit
        {
            get { return _positionToEdit; }
            set
            {
                _positionToEdit = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("");
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("");
            }
        }
       
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("");
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("");
            }
        }

        public Person PersonToEdit
        {
            get { return _personToEdit; }
            set
            {
                _personToEdit = value;
                Name = value.Name;
                Surname = value.Surname;
                Login = value.Login;
                Password = value.Password;
                PositionToEdit = value.Position;
                PhoneNumber = value.PhoneNumber;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand EditPersonCommand
        {
            get { return _edit ?? (_edit = new RelayCommand(Edit)); }
        }

        public void Edit(object obj)
        {
            PersonToEdit.Name = Name;
            PersonToEdit.Surname = Surname;
            PersonToEdit.Login = Login;
            PersonToEdit.Password = Password;
            PersonToEdit.Position = SelectedPosition;
            PersonToEdit.PhoneNumber = PhoneNumber;
            _ctx.SaveChanges();
            Close(obj);
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
