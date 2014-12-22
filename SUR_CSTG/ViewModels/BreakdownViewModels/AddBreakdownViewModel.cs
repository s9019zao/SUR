using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views.BreakdownViews;

namespace SUR_CSTG.ViewModels.BreakdownViewModels
{
    public class AddBreakdownViewModel : ViewModel
    {
        #region Fields

        WorkerGeneralWindowViewModel _workerGeneralWindowViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        public ObservableCollection<Area> Areas { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        IEnumerable<BreakedownType> _typeBreakdown;
        BreakedownType _selectedBreakedownType;
        Person _personToAdd;
        Area _selectedArea;
        Device _selctedDevice;
        DateTime _requestDate;
        string _name;
        string _surname;
        string _description;
        ICommand _addBreakdownCommand;
        ICommand _closeWinndow;

        #endregion

        #region Constructors

        public AddBreakdownViewModel(WorkerGeneralWindowViewModel workerGeneralWindowViewModel)
        {
            _workerGeneralWindowViewModel = workerGeneralWindowViewModel;
            Areas = new ObservableCollection<Area>(_ctx.Areas);
            Devices = new ObservableCollection<Device>(_ctx.Devices);
            Persons = new ObservableCollection<Person>(_ctx.Persons);
            GetAreas();
            _requestDate = DateTime.Now;
        }

        #endregion

        #region Properities

        public ObservableCollection<Area> AllAreas { get; set; }
        public ObservableCollection<Device> DevicesArea { get; set; }

        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                GetDevicesArea();
                OnPropertyChanged("");
            }
        }

        public DateTime RequestDate
        {
            get { return _requestDate; }
            set
            {
                _requestDate = value;
                OnPropertyChanged("");
            }
        }

        public Device SelectedDevice
        {
            get { return _selctedDevice; }
            set
            {
                _selctedDevice = value;
                OnPropertyChanged("");
            }
        }

        public BreakedownType SelectedBreakedownType
        {
            get { return _selectedBreakedownType; }
            set
            {
                _selectedBreakedownType = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public IEnumerable<BreakedownType> TypeBreakdown
        {
            get { return Enum.GetValues(typeof(BreakedownType)).Cast<BreakedownType>(); }

            set
            {
                _typeBreakdown = value;
                OnPropertyChanged("DeviceStatus");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Surname");
            }
        }

        public Person PersonToAdd
        {
            get { return _personToAdd; }
            set
            {
                _personToAdd = value;
                Name = value.Name;
                Surname = value.Surname;
                OnPropertyChanged("");
            }
        }

        public void GetAreas()
        {
            AllAreas = new ObservableCollection<Area>(_ctx.Areas);
        }

        public void GetDevicesArea()
        {
            DevicesArea = new ObservableCollection<Device>(SelectedArea.Devices);
        }

        #endregion

        #region Command

        public ICommand AddBreakdownCommand
        {
            get { return _addBreakdownCommand ?? (_addBreakdownCommand = new RelayCommand(Add, CanAdd)); }
        }

        private void Add(object obj)
        {
            string message = "Dodano awarię\n";
            string titel = "Informacja o dodaniu awarii";
            _ctx.Breakdowns.Add(new Breakdown {Device = SelectedDevice, 
                                               Type = SelectedBreakedownType, 
                                               RequestDate = RequestDate,
                                               ReportingPerson = PersonToAdd,
                                               RequestDescription = Description,
                                               Status = StatusBreakdown.Zgłoszona,
                                               OverhaulDate = DateTime.Now
                                               });
            _ctx.SaveChanges();
            var result = MessageBox.Show(message, titel);
            var view = new AddBreakdownView();
            AddBreakdownViewModel vm = new AddBreakdownViewModel(this._workerGeneralWindowViewModel);
            vm.PersonToAdd = _workerGeneralWindowViewModel.Person;
            view.DataContext = vm;
            _workerGeneralWindowViewModel.SelectedView = view;
        }

        private bool CanAdd(object obj)
        {
            if (SelectedDevice != null)
                return true;
            else
                return false;
        }

        public ICommand CloseCommand
        {
            get { return _closeWinndow ?? (_closeWinndow = new RelayCommand(Close)); }
        }
        public void Close(object obj)
        {
            var view = new AddBreakdownView();
            AddBreakdownViewModel vm = new AddBreakdownViewModel(this._workerGeneralWindowViewModel);
            vm.PersonToAdd = _workerGeneralWindowViewModel.Person;
            view.DataContext = vm;
            _workerGeneralWindowViewModel.SelectedView = view;
        }

        #endregion

    }
}
