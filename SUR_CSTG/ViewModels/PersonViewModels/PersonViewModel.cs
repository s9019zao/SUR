using SUR_CSTG.Data;
using SUR_CSTG.Views.PersonViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SUR_CSTG.ViewModels.PersonViewModels
{
    public class PersonViewModel : ViewModel
    {
        #region Fields

        PersonListViewModel _personListViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _openAddPerson;
        ICommand _openDeletePerson;
        ICommand _openEditPerson;

        #endregion

        #region Constructors
        public PersonViewModel()
        {
            PersonListViewModel = new PersonListViewModel();
           // AreaSerchListViewModel = new AreaSerchListViewModel();
        }

        #endregion

        #region Properities

        public SUR_DbContext Ctx { get { return _ctx; } }

        public PersonListViewModel PersonListViewModel
        {
            get { return _personListViewModel; }
            set
            {
                _personListViewModel = value;
                _personListViewModel.Persons = new ObservableCollection<Person>(_ctx.Persons);
                OnPropertyChanged("");
            }
        }
        #endregion

        #region Commands

        public ICommand OpenAddPersonCommand
        {
            get { return _openAddPerson ?? (_openAddPerson = new RelayCommand(OpenAddPersonWindowView)); }
        }

        private void OpenAddPersonWindowView(object obj)
        {
            var window = new AddPersonWindowView();
            window.ShowDialog();
            PersonListViewModel.Persons = new ObservableCollection<Person>(_ctx.Persons);
            OnPropertyChanged("");
        }


        public ICommand OpenDeletePersonCommand
        {
            get { return _openDeletePerson ?? (_openDeletePerson = new RelayCommand(OpenDeletePersonWindowView)); }
        }

        private void OpenDeletePersonWindowView(object obj)
        {
            if (this._personListViewModel.SelectedPerson != null)
            {
                var window = new DeletePersonWindowView();
                DeletePersonWindowViewModel vm = new DeletePersonWindowViewModel(this);
                vm.PersonToDelete = this._personListViewModel.SelectedPerson;
                window.DataContext = vm;
                window.ShowDialog();
            }
            else
            {
                string mess = "Nie wybrano obiektu do usunięcia";
                var message = MessageBox.Show(mess);
            }
        }

        public ICommand OpenEditPersonCommand
        {
            get { return _openEditPerson ?? (_openEditPerson = new RelayCommand(OpenEditPersonWindowView)); }
        }

        private void OpenEditPersonWindowView(object obj)
        {
            if (this._personListViewModel.SelectedPerson != null)
            {
                var window = new EditPersonWindowView();
                EditPersonWindowViewModel vm = new EditPersonWindowViewModel(this);
                vm.PersonToEdit = this._personListViewModel.SelectedPerson;
                window.DataContext = vm;
                window.ShowDialog();
                _ctx.SaveChanges();
                _personListViewModel.Persons = _ctx.Persons.ToList();
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
