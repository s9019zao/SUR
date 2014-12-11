using SUR_CSTG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using SUR_CSTG.Data;
using System.Collections.ObjectModel;

namespace SUR_CSTG.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        SUR_DbContext _ctx = new SUR_DbContext();
        public ObservableCollection<Area> Areas { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Part> Parts { get; set; }
        string _login;
        string _password;
        Person _personToLogin;
        ICommand _openGeneralWindow;
        ICommand _closeWinndow;

        public MainWindowViewModel()
        {
            Areas = new ObservableCollection<Area>(_ctx.Areas);
            Devices = new ObservableCollection<Device>(_ctx.Devices);
            Persons = new ObservableCollection<Person>(_ctx.Persons);
            Parts = new ObservableCollection<Part>(_ctx.Parts);
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

        public Person PersonToLogin
        {
            get { return _personToLogin; }
            set
            {
                _personToLogin = value;
                OnPropertyChanged("");
            }
        }

        public ICommand LoginCommand 
        {
            get { return _openGeneralWindow ?? (_openGeneralWindow = new RelayCommand(OpenGeneralWindow, CanOpenGeneralWindow)); } 
        }

        private bool CanOpenGeneralWindow(object obj)
        {
            return !string.IsNullOrWhiteSpace(Login);
        }

        private void OpenGeneralWindow(object obj)
        {

            var result = _ctx.Persons.Where(person => person.Login == Login);
            if (result.LongCount() > 0)
            {
                PersonToLogin = result.First();
                if (PersonToLogin.Login == Login && PersonToLogin.Password == Password)
                {
                    if (PersonToLogin.Position == Position.Pracownik)
                    {
                        var window = new WorkerGeneralWindowView();
                        WorkerGeneralWindowViewModel vm = new WorkerGeneralWindowViewModel(this);
                        vm.Person = this.PersonToLogin;
                        window.DataContext = vm;
                        window.Show();
                        Close(obj);
                    }
                    else
                    {
                        var window = new GeneralWindowView();
                        GeneralWindowViewModel vm = new GeneralWindowViewModel(this);
                        vm.Person = this.PersonToLogin;
                        window.DataContext = vm;
                        window.Show();
                        Close(obj);
                    }
                }
                else
                {
                    string mess = "Login i Hasło \nNie pasują do siebie";
                    var message = MessageBox.Show(mess);
                    Login = null;
                    Password = null;
                }
            }
            else
            {
                string mess = "Nie znaleziono urzytkownika \nO loginie: " + Login;
                var message = MessageBox.Show(mess);
                Login = null;
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
    }
}