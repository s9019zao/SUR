using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.DeviceViewModels
{
    public class DeviceListViewModel : ViewModel
    {
        #region Fields

        ICollection<Device> _device;
        Device _selectedDevice;

        #endregion

        #region Properities

        public ICollection<Device> Devices
        {
            get { return _device; }
            set
            {
                _device = new ObservableCollection<Device>(value);
                OnPropertyChanged("");
            }
        }

        public Device SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged("");
            }
        }

        #endregion
    }
}
