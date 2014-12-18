using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.DeviceViewModels
{
    public class AddDeviceWindowViewModel : ViewModel
    {
        #region Fields

        SUR_DbContext _ctx = new SUR_DbContext();
        IEnumerable<DeviceStatus> _deviceStatus;
        ICommand _addDeviceCommand;
        ICommand _closeWinndow;
        string _name;
        string _description;
        DeviceStatus  _selectedDeviceStatus;
        Area _selectArea;

        #endregion

        #region Constructors

        public AddDeviceWindowViewModel()
        {
            GetAreas();
        }

        #endregion

        #region Properities

        public ObservableCollection<Area> AllAreas { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public DeviceStatus SelectedDeviceStatus
        {
            get { return _selectedDeviceStatus; }
            set
            {
                _selectedDeviceStatus = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public IEnumerable<DeviceStatus> DeviceStatus
        {
            get { return Enum.GetValues(typeof(DeviceStatus)).Cast<DeviceStatus>(); }

            set
            {
                _deviceStatus = value;
                OnPropertyChanged("DeviceStatus");
            }
        }


        public Area SelectArea
        {
            get { return _selectArea; }
            set
            {
                _selectArea = value;
                OnPropertyChanged("");
            }
        }

        public void GetAreas()
        {
            AllAreas = new ObservableCollection<Area>(_ctx.Areas);
        }

        #endregion

        #region Command

        public ICommand AddAreaCommand
        {
            get { return _addDeviceCommand ?? (_addDeviceCommand = new RelayCommand(Add, CanAdd)); }
        }

        private void Add(object obj)
        {
            string message = "Dodano urządzenie\n";
            string titel = "Informacja o dodaniu urządzenia";
            _ctx.Devices.Add(new Device { Name = Name, Description = Description, Area = SelectArea, Status = SelectedDeviceStatus });
            _ctx.SaveChanges();
            var result = MessageBox.Show(message + "O nazwie: " + Name, titel);
            Close(obj);
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(_name);
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
