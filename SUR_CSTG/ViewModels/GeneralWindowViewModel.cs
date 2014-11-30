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

namespace SUR_CSTG.ViewModels
{
    public class GeneralWindowViewModel : ViewModel
    {
        #region Fields

        ICommand _showArea;
        ICommand _showDevice;
        ICommand _showPerson;
        UserControl _selectedView;
        SUR_DbContext _ctx = new SUR_DbContext();

        #endregion

        #region Properities
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

        public ICommand OpenAreaViewCommand 
        { 
            get { return _showArea ?? (_showArea = new RelayCommand(OpenAreaView)); } 
        }

        private void OpenAreaView(object obj)
        {
            var view = new AreaView();
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

        #endregion
    }
}
