using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views.PartViews;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class PartViewModel : ViewModel
    {
        #region Fields

        PartListViewModel _partListViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _showElectricalPart;
        ICommand _showMechanicalPart;
        ICommand _showAutomaticalPart;
        ICommand _openAddPart;
        ICommand _openDeletePart;
        ICommand _openEditPart;
        ICommand _openEditQuantityPart;

        #endregion

        #region Constructors
        public PartViewModel()
        {
            PartListViewModel = new PartListViewModel();
           // AreaSerchListViewModel = new AreaSerchListViewModel();
        }

        #endregion

        #region Properities

        public SUR_DbContext Ctx { get { return _ctx; } }

        public PartListViewModel PartListViewModel
        {
            get { return _partListViewModel; }
            set
            {
                _partListViewModel = value;
                _partListViewModel.Parts = new ObservableCollection<Part>(_ctx.Parts);
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand ShowElectricalPartCommand
        {
            get { return _showElectricalPart ?? (_showElectricalPart = new RelayCommand(ShowElectricalPart)); }
        }

        private void ShowElectricalPart(object obj)
        {
            PartListViewModel.Parts = new ObservableCollection<Part>();
            var result = _ctx.Parts.Where(part => part.PartType == Data.PartType.Elektryka).ToList();
            PartListViewModel.Parts = new ObservableCollection<Part>(result);        
        }

        public ICommand ShowMechanicalPartCommand
        {
            get { return _showMechanicalPart ?? (_showMechanicalPart = new RelayCommand(ShowMechanicalPart)); }
        }

        private void ShowMechanicalPart(object obj)
        {
            PartListViewModel.Parts = new ObservableCollection<Part>();
            var result = _ctx.Parts.Where(part => part.PartType == Data.PartType.Mechanika).ToList();
            PartListViewModel.Parts = new ObservableCollection<Part>(result);
        }

        public ICommand ShowAutomaticalPartCommand
        {
            get { return _showAutomaticalPart ?? (_showAutomaticalPart = new RelayCommand(ShowAutomaticalPart)); }
        }

        private void ShowAutomaticalPart(object obj)
        {
            PartListViewModel.Parts = new ObservableCollection<Part>();
            var result = _ctx.Parts.Where(part => part.PartType == Data.PartType.Automatyka).ToList();
            PartListViewModel.Parts = new ObservableCollection<Part>(result);
        }

        public ICommand OpenAddPartCommand
        {
            get { return _openAddPart ?? (_openAddPart = new RelayCommand(OpenAddPartWindowView)); }
        }

        private void OpenAddPartWindowView(object obj)
        {
            var window = new AddPartWindowView();
            window.ShowDialog();
            PartListViewModel.Parts = new ObservableCollection<Part>(_ctx.Parts);
            OnPropertyChanged("");
        }


        public ICommand OpenDeletePartCommand
        {
            get { return _openDeletePart ?? (_openDeletePart = new RelayCommand(OpenDeletePartWindowView)); }
        }

        private void OpenDeletePartWindowView(object obj)
        {
            if (this._partListViewModel.SelectedPart != null)
            {
                var window = new DeletePartWindowView();
                DeletePartWindowViewModel vm = new DeletePartWindowViewModel(this);
                vm.PartToDelete = this._partListViewModel.SelectedPart;
                window.DataContext = vm;
                window.ShowDialog();
            }
            else
            {
                string mess = "Nie wybrano obiektu do usunięcia";
                var message = MessageBox.Show(mess);
            }
        }

        public ICommand OpenEditPartCommand
        {
            get { return _openEditPart ?? (_openEditPart = new RelayCommand(OpenEditPartWindowView)); }
        }

        private void OpenEditPartWindowView(object obj)
        {
            if (this._partListViewModel.SelectedPart != null)
            {
                var window = new EditPartWindowView();
                EditPartWindowViewModel vm = new EditPartWindowViewModel(this);
                vm.PartToEdit = this._partListViewModel.SelectedPart;
                window.DataContext = vm;
                window.ShowDialog();
                _ctx.SaveChanges();
                _partListViewModel.Parts = _ctx.Parts.ToList();
                OnPropertyChanged("");
            }
            else
            {
                string mess = "Nie wybrano obiektu do edycji";
                var message = MessageBox.Show(mess);
            }
        }

        public ICommand OpenEditQuantityPartCommand
        {
            get { return _openEditQuantityPart ?? (_openEditQuantityPart = new RelayCommand(OpenEditQuantityPartView)); }
        }

        private void OpenEditQuantityPartView(object obj)
        {
            if (this._partListViewModel.SelectedPart != null)
            {
                var window = new EditQuantityPartWindowView();
                EditQuantityPartWindowViewModel vm = new EditQuantityPartWindowViewModel(this);
                vm.PartToEditQuantity = this._partListViewModel.SelectedPart;
                window.DataContext = vm;
                window.ShowDialog();
                _ctx.SaveChanges();
                _partListViewModel.Parts = _ctx.Parts.ToList();
                OnPropertyChanged("");
            }
            else
            {
                string mess = "Nie wybrano obiektu do usunięcia";
                var message = MessageBox.Show(mess);
            }
        }

        #endregion
    }
}
