using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.DeviceViewModels
{
    public class DeleteDeviceWindowViewModel : ViewModel
    {
        #region Fields

        DeviceViewModel _deviceViewModel;
        Device _deviceToDelete;
        ICommand _closeWinndow;
        ICommand _delete;

        #endregion

        #region Constructors

        public DeleteDeviceWindowViewModel(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
        }

        #endregion

        #region Properities

        public DeviceViewModel DeviceViewModel
        {
            get { return _deviceViewModel; }
            set
            {
                _deviceViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Device DeviceToDelete
        {
            get { return _deviceToDelete; }
            set
            {
                _deviceToDelete = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command
        public ICommand DeleteCommand
        {
            get { return _delete ?? (_delete = new RelayCommand(Delete)); }
        }

        public void Delete(object obj)
        {
            _deviceViewModel.DeviceListViewModel.Devices.Remove(DeviceToDelete);
            _deviceViewModel.Ctx.Devices.Remove(DeviceToDelete);
            _deviceViewModel.Ctx.SaveChanges();
            OnPropertyChanged("");
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
