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
    public class BreakdownViewModel : ViewModel
    {
        #region Fields

        BreakdownListViewModel _breakdownListViewModel;
        GeneralWindowViewModel _generalWindowViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        public ObservableCollection<Person> Persons { get; set; }
        ICommand _openAddBreakdown;
        ICommand _openEditBrekdown;

        #endregion

        #region Constructors

        public BreakdownViewModel(GeneralWindowViewModel generalWindowViewModel)
        {
            BreakdownListViewModel = new BreakdownListViewModel();
            _generalWindowViewModel = generalWindowViewModel;
            Persons = new ObservableCollection<Person>(_ctx.Persons);
            GetPersons();
            GetDevices();
        }

        #endregion

        #region Properities

        public SUR_DbContext Ctx { get { return _ctx; } }
        public ObservableCollection<Person> AllPersons { get; set; }
        public ObservableCollection<Device> AllDevices { get; set; }

        public BreakdownListViewModel BreakdownListViewModel
        {
            get { return _breakdownListViewModel; }
            set
            {
                _breakdownListViewModel = value;
                _breakdownListViewModel.Breakdowns = new ObservableCollection<Breakdown>(_ctx.Breakdowns);
                OnPropertyChanged("");
            }
        }

        public void GetPersons()
        {
            AllPersons = new ObservableCollection<Person>(_ctx.Persons);
        }

        public void GetDevices()
        {
            AllDevices = new ObservableCollection<Device>(_ctx.Devices);
        }

        #endregion

        #region Command

        public ICommand OpenAddBreakdownCommand
        {
            get { return _openAddBreakdown ?? (_openAddBreakdown = new RelayCommand(OpenAddBreakdownWindowView)); }
        }

        private void OpenAddBreakdownWindowView(object obj)
        {
            var window = new AddBreakdownWindowView();
            AddBreakdownWindowViewModel vm = new AddBreakdownWindowViewModel(this);
            vm.PersonToAdd = this._generalWindowViewModel.Person;
            window.DataContext = vm;
            window.ShowDialog();
            BreakdownListViewModel.Breakdowns = new ObservableCollection<Breakdown>(_ctx.Breakdowns);
            OnPropertyChanged("");
        }

        public ICommand OpenEditBreakdownCommand
        {
            get { return _openEditBrekdown ?? (_openEditBrekdown = new RelayCommand(OpenEditBreakdownWindowView, CanEditBreakdown)); }
        }

        private bool CanEditBreakdown(object obj)
        {
            if (_generalWindowViewModel.Position == Position.Mistrz || _generalWindowViewModel.Position == Position.Kierownik)
                return true;
            else
                return false;
        }

        private void OpenEditBreakdownWindowView(object obj)
        {
            if (this._breakdownListViewModel.SelectedBreakdown != null)
            {
                var window = new EditBreakdownWindowView();
                EditBreakdownWindowViewModel vm = new EditBreakdownWindowViewModel(this);
                vm.BreakdownToEdit = this._breakdownListViewModel.SelectedBreakdown;
                window.DataContext = vm;
                window.ShowDialog();
                _ctx.SaveChanges();
                _breakdownListViewModel.Breakdowns = _ctx.Breakdowns.ToList();
                OnPropertyChanged("");
            }
            else
            {
                string mess = "Nie wybrano obiektu do edycji";
                var message = MessageBox.Show(mess);
            }
        }

        #endregion
    }
}
