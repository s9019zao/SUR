using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views.DeviceViews;

namespace SUR_CSTG.ViewModels.DeviceViewModels
{
    public class DeviceViewModel : ViewModel
    {
        #region Fields

        DeviceListViewModel _deviceListViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _openAddDevice;

        #endregion

        #region Constructors

        public DeviceViewModel()
        {
            DeviceListViewModel = new DeviceListViewModel();
        }

        #endregion

        #region Properities

        public SUR_DbContext Ctx { get { return _ctx; } }

        public DeviceListViewModel DeviceListViewModel
        {
            get { return _deviceListViewModel; }
            set
            {
                _deviceListViewModel = value;
                _deviceListViewModel.Devices = new ObservableCollection<Device>(_ctx.Devices);
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand OpenAddDeviceCommand
        {
            get { return _openAddDevice ?? (_openAddDevice = new RelayCommand(OpenAddDeviceWindowView)); }
        }

        private void OpenAddDeviceWindowView(object obj)
        {
            var window = new AddDeviceWindowView();
            window.ShowDialog();
            DeviceListViewModel.Devices = new ObservableCollection<Device>(_ctx.Devices);
            OnPropertyChanged("");
        }

        #endregion
    }
}
