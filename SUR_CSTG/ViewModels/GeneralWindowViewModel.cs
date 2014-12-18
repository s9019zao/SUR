using SUR_CSTG.Views.AreaViews;
using SUR_CSTG.Views.DeviceViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using SUR_CSTG.Data;
using SUR_CSTG.Views.PersonViews;
using SUR_CSTG.Views.PartViews;
using SUR_CSTG.ViewModels.AreaViewModels;
using SUR_CSTG.Views.BreakdownViews;
using SUR_CSTG.ViewModels.BreakdownViewModels;

namespace SUR_CSTG.ViewModels
{
    public class GeneralWindowViewModel : ViewModel
    {
        #region Fields

        MainWindowViewModel _mainWindowViewModel;
        Person _person;
        string _nameSurname;
        Position _position;
        ICommand _logout;
        ICommand _closeWinndow;
        ICommand _showArea;
        ICommand _showDevice;
        ICommand _showPerson;
        ICommand _showPart;
        ICommand _showBreakdown;
        UserControl _selectedView;

        #endregion

        #region Constructors

        public GeneralWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
           
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
                NameSurname = value.Name + " " + value.Surname;
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

        public ICommand OpenAreaViewCommand 
        { 
            get { return _showArea ?? (_showArea = new RelayCommand(OpenAreaView)); } 
        }

        private void OpenAreaView(object obj)
        {
            var view = new AreaView();
            AreaViewModel vm = new AreaViewModel(this);
            view.DataContext = vm;
            SelectedView = view;            
        }

        public ICommand OpenDeviceViewCommand 
        { 
            get { return _showDevice ?? (_showDevice = new RelayCommand(OpenDeviceView)); } 
        }

        private void OpenDeviceView(object obj)
        {
            var view = new DeviceView();
            SelectedView = view;
        }

        public ICommand OpenPersonViewCommand
        {
            get { return _showPerson ?? (_showPerson = new RelayCommand(OpenPersonView)); }
        }

        private void OpenPersonView(object obj)
        {
            var view = new PersonView();
            SelectedView = view;
        }

        public ICommand OpenPartViewCommand
        {
            get { return _showPart ?? (_showPart = new RelayCommand(OpenPartView)); }
        }

        private void OpenPartView(object obj)
        {
            var view = new PartView();
            SelectedView = view;
        }

        public ICommand OpenBreakdownViewCommand
        {
            get { return _showBreakdown ?? (_showBreakdown = new RelayCommand(OpenBreakdownView)); }
        }

        private void OpenBreakdownView(object obj)
        {
            var view = new BreakdownView();
            BreakdownViewModel vm = new BreakdownViewModel(this);
            view.DataContext = vm;
            SelectedView = view;
        }

        #endregion
    }
}
