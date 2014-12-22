using SUR_CSTG.Data;
using SUR_CSTG.ViewModels.BreakdownViewModels;
using SUR_CSTG.Views.BreakdownViews;
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
    public class ChangePasswordViewModel : ViewModel
    {
          #region Fields

        WorkerGeneralWindowViewModel _workerGeneralWindowViewModel;
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

        public ChangePasswordViewModel(WorkerGeneralWindowViewModel workerGeneralWindowViewModel)
        {
            _workerGeneralWindowViewModel = workerGeneralWindowViewModel;
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

        public void BackMainView()
        {
            var view = new AddBreakdownView();
            AddBreakdownViewModel vm = new AddBreakdownViewModel(this._workerGeneralWindowViewModel);
            vm.PersonToAdd = _workerGeneralWindowViewModel.Person;
            view.DataContext = vm;
            _workerGeneralWindowViewModel.SelectedView = view;
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
                if (p.Name == _workerGeneralWindowViewModel.Person.Name &
                    p.Surname == _workerGeneralWindowViewModel.Person.Surname &
                    p.Position == _workerGeneralWindowViewModel.Person.Position)
                {
                    PersonsToEdit.Add(p);
                    PersonToEdit = PersonsToEdit.FirstOrDefault();
                }
            
            if (Password == _workerGeneralWindowViewModel.Person.Password)
            {
                if (ConfirmPassword == NewPassword)
                {
                    PersonToEdit.Password = NewPassword;
                    _ctx.SaveChanges();
                    MessageBox.Show("Hasło zostało zmienione");
                    BackMainView();
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
            BackMainView();
        }

        #endregion
    }
}
