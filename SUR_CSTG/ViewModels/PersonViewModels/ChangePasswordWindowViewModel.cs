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
    class ChangePasswordWindowViewModel : ViewModel
    {
        #region Fields

        
//        PersonViewModel _personViewModel;
        GeneralWindowViewModel _generalWindowViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        public ObservableCollection<Person> Persons { get; set; }
        ICommand _changePassword;
        ICommand _closeWinndow;
        Person _personToEdit;
        string _password;
        string _newPassword;
        string _confirmPassword;

        #endregion

        #region Constructors


        public ChangePasswordWindowViewModel(GeneralWindowViewModel generalWindowViewModel)
        {

            _generalWindowViewModel = generalWindowViewModel;
            Persons = new ObservableCollection<Person>(_ctx.Persons);
        }

        #endregion

        #region Properities

        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                OnPropertyChanged("");

            }
        }

        public string NewPassword
        {
            get { return _newPassword; }

            set
            {
                _newPassword = value;
                OnPropertyChanged("");
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }

            set
            {
                _confirmPassword = value;
                OnPropertyChanged("");
            }
        }

        public Person PersonToEdit
        {
            get { return _personToEdit; }
            set
            {
                _personToEdit = value;
                OnPropertyChanged("");
            }
        }

        #endregion
        #region Command

        public ICommand ChangePasswordCommand
        {
            get { return _changePassword ?? (_changePassword = new RelayCommand(Change)); }
        }

        public void Change(object obj)
        {
            List<Person> PersonsToEdit = new List<Person>();
            foreach(Person p in Persons)
                if (p.Name == _generalWindowViewModel .Person.Name &
                    p.Surname == _generalWindowViewModel.Person.Surname &
                    p.Position == _generalWindowViewModel.Person.Position)
                {
                    PersonsToEdit.Add(p);
                    PersonToEdit = PersonsToEdit.FirstOrDefault();
                }

            if (Password == _generalWindowViewModel.Person.Password)
            {
                if (ConfirmPassword == NewPassword)
                {
                    PersonToEdit.Password = NewPassword;
                    _ctx.SaveChanges();
                    MessageBox.Show("Hasło zostało zmienione");
                   // _workerGeneralWindowViewModel.SelectedView = new AddBreakdownView();  
                   Close(obj);
                }
                else
                {
                    string mess = "Porównanie haseł \nnie powiodło się";
                    MessageBox.Show(mess);
                    NewPassword = null;
                    ConfirmPassword = null;
                }
            }
            else
            {
                string mess = "Nieprawidłowe stare hasło";
                MessageBox.Show(mess);
                Password = null;
                }
            

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