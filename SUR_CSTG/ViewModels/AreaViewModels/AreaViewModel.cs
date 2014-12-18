using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views;
using SUR_CSTG.Views.AreaViews;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class AreaViewModel : ViewModel
    {
        #region Fields

        AreaListViewModel _areaListViewModel;
        AreaSerchListViewModel _areaSerchListViewModel;
        GeneralWindowViewModel _generalWindowViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        public ObservableCollection<Area> Areas { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        string _nameToSerch;
        string _descriptionToSerch;
        ICommand _openAddArea;
        ICommand _openEditArea;
        ICommand _openDeleteArea;
        ICommand _serchArea;

        #endregion

        #region Constructors

        public AreaViewModel(GeneralWindowViewModel generalWindowViewModel)
        {
            _generalWindowViewModel = generalWindowViewModel;
            AreaListViewModel = new AreaListViewModel();
            AreaSerchListViewModel = new AreaSerchListViewModel();
            Areas = new ObservableCollection<Area>(_ctx.Areas);
            Devices = new ObservableCollection<Device>(_ctx.Devices);
        }

        #endregion

        #region Properities

        public SUR_DbContext Ctx { get { return _ctx; } }

        public AreaListViewModel AreaListViewModel
        {
            get { return _areaListViewModel; }
            set
            {
                _areaListViewModel = value;
                _areaListViewModel.Areas = new ObservableCollection<Area>(_ctx.Areas);
                OnPropertyChanged("");
            }
        }

        public AreaSerchListViewModel AreaSerchListViewModel
        {
            get { return _areaSerchListViewModel; }
            set
            {
                _areaSerchListViewModel = value;
                _areaListViewModel.Areas = new ObservableCollection<Area>(_ctx.Areas);
                OnPropertyChanged("");
            }
        }

        public string NameToSerch
        {
            get { return _nameToSerch; }
            set
            {
                _nameToSerch = value;
                OnPropertyChanged("");
            }
        }

        public string DescriptionToSerch
        {
            get { return _descriptionToSerch; }
            set
            {
                _descriptionToSerch = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Commands

        public ICommand OpenAddAreaCommand 
        { 
            get { return _openAddArea ?? (_openAddArea = new RelayCommand(OpenAddAreaWindowView, CanAddArea)); } 
        }

        private bool CanAddArea(object obj)
        {
            if (_generalWindowViewModel.Position == Position.Mistrz || _generalWindowViewModel.Position == Position.Kierownik)
                return true;
            else
                return false;
        }

        private void OpenAddAreaWindowView(object obj)
        {
            var window = new AddAreaWindowView();
            window.ShowDialog();
            AreaListViewModel.Areas = new ObservableCollection<Area>(_ctx.Areas);
            OnPropertyChanged("");
        }

        public ICommand OpenEditAreaCommand 
        { 
            get { return _openEditArea ?? (_openEditArea = new RelayCommand(OpenEditAreaWindowView)); } 
        }

        private void OpenEditAreaWindowView(object obj)
        {
            if (this._areaListViewModel.SelectedArea != null)
            {
                var window = new EditAreaWindowView();
                EditAreaWindowViewModel vm = new EditAreaWindowViewModel(this);
                vm.AreaToEdit = this._areaListViewModel.SelectedArea;
                window.DataContext = vm;
                window.ShowDialog();
                _ctx.SaveChanges();
                _areaListViewModel.Areas = _ctx.Areas.ToList();
                OnPropertyChanged("");
            }
            else
            {
                string mess = "Nie wybrano obiektu do edycji";
                var message = MessageBox.Show(mess);
            }
        }

        public ICommand OpenDeleteAreaCommand
        {
            get { return _openDeleteArea ?? (_openDeleteArea = new RelayCommand(OpenDeleteAreaWindowView)); }
        }

        private void OpenDeleteAreaWindowView(object obj)
        {
            if (this._areaListViewModel.SelectedArea != null)
            {
                if (this._areaListViewModel.SelectedArea.Devices.LongCount() == 0)
                {
                    var window = new DeleteAreaWindowView();
                    DeleteAreaWindowViewModel vm = new DeleteAreaWindowViewModel(this);
                    vm.AreaToDelete = this._areaListViewModel.SelectedArea;
                    window.DataContext = vm;
                    window.ShowDialog();
                }
                else
                {
                    string mess = "W rejonie znajduje się urządzeń: " + _areaListViewModel.SelectedArea.Devices.LongCount();
                    var message = MessageBox.Show(mess);
                }
            }
            else
            {
                string mess = "Nie wybrano obiektu do usunięcia";
                var message = MessageBox.Show(mess);
            }
        }

        public ICommand SerchAreaCommand
        {
            get { return _serchArea ?? (_serchArea = new RelayCommand(Serch)); }
        }

        private void Serch(object obj)
        {
            AreaSerchListViewModel.Areas = new ObservableCollection<Area>();
            if (_nameToSerch != null && _descriptionToSerch != null)
            {
                var resultSerch = _ctx.Areas.Where(area => area.Name == NameToSerch && area.Description == DescriptionToSerch).ToList();
                if (resultSerch.Count != 0)
                {
                    AreaSerchListViewModel.Areas = new ObservableCollection<Area>(resultSerch);
                    NameToSerch = null;
                    DescriptionToSerch = null;
                }
                else
                {
                    string mess = "Nie znaleziono rejonu \n o nazwie: " + NameToSerch +
                                    "\n i opisie: " + DescriptionToSerch;
                    var message = MessageBox.Show(mess);
                    NameToSerch = null;
                    DescriptionToSerch = null;
                }
            }
            else if (_nameToSerch != null && _descriptionToSerch == null)
            {
                var resultSerch = _ctx.Areas.Where(area => area.Name == NameToSerch).ToList();
                if (resultSerch.Count != 0)
                {
                    AreaSerchListViewModel.Areas = new ObservableCollection<Area>(resultSerch);
                    NameToSerch = null;
                }
                else
                {
                    string mess = "Nie znaleziono rejonu \n o nazwie: " + NameToSerch;
                    var message = MessageBox.Show(mess);
                    NameToSerch = null;
                }
            }
            else if (_nameToSerch == null && _descriptionToSerch != null)
            {
                var resultSerch = _ctx.Areas.Where(area => area.Description == DescriptionToSerch).ToList();
                if (resultSerch.Count != 0)
                {
                    AreaSerchListViewModel.Areas = new ObservableCollection<Area>(resultSerch);
                    DescriptionToSerch = null;
                }
                else
                {
                    string mess = "Nie znaleziono rejonu \n o opisie: " + DescriptionToSerch;
                    var message = MessageBox.Show(mess);
                    DescriptionToSerch = null;
                }
            }
            else
            {
                string mess = "Nie podano parametrów wyszukiwania";
                var message = MessageBox.Show(mess);
            }           
        }

        #endregion

    }
}
