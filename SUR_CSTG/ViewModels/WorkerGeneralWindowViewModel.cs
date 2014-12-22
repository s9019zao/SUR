using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views.BreakdownViews;
using SUR_CSTG.Views.PersonViews;
using SUR_CSTG.ViewModels.PersonViewModels;
using SUR_CSTG.ViewModels.BreakdownViewModels;
using System.Collections.ObjectModel;

namespace SUR_CSTG.ViewModels
{
    public class WorkerGeneralWindowViewModel : ViewModel
    {
        #region Fields

        MainWindowViewModel _mainWindowViewModel;
        Person _person;
        string _nameSurname;
        string _surname;
        string _name;
        Position _position;
        UserControl _selectedView;
        ICommand _showAddBreakdown;
        ICommand _showChangePassword;
        ICommand _logout;
        ICommand _closeWinndow;

       


        #endregion

        #region Constructors

        public void OpenViev()
        {
            var view = new AddBreakdownView();
            AddBreakdownViewModel vm = new AddBreakdownViewModel(this);
            vm.PersonToAdd = _mainWindowViewModel.PersonToLogin;
            view.DataContext = vm;
            SelectedView = view;
        }

        public WorkerGeneralWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            OpenViev();
        }

        #endregion

        #region Properities

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                Position = value.Position;
                Name = value.Name;
                Surname = value.Surname;
                NameSurname = value.Name + " " + value.Surname;
                OnPropertyChanged("");
            }
        }

        public Position Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("");
            }
        }

        public string NameSurname
        {
            get { return _nameSurname; }
            set
            {
                _nameSurname = value;
                OnPropertyChanged("");
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

        public UserControl SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand LogoutCommand
        {
            get { return _logout ?? (_logout = new RelayCommand(Logout)); }
        }

        private void Logout(object obj)
        {
            var window = new MainWindow();
            window.Show();
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

        public ICommand OpenAddBreakdownViewCommand
        {
            get { return _showAddBreakdown ?? (_showAddBreakdown = new RelayCommand(OpenAddBreakdownView)); }
        }

        private void OpenAddBreakdownView(object obj)
        {
            OpenViev();
        }

        public ICommand OpenChangePasswordViewCommand
        {
            get { return _showChangePassword ?? (_showChangePassword = new RelayCommand(OpenChangePasswordView)); }
        }

        private void OpenChangePasswordView(object obj)
        {
            var view = new ChangePasswordView();
            ChangePasswordViewModel vm = new ChangePasswordViewModel(this);
            view.DataContext = vm;
            SelectedView = view;
        }

        #endregion
    }
}
