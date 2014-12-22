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
using SUR_CSTG.ViewModels.PersonViewModels;


namespace SUR_CSTG.ViewModels.PersonViewModels
{
    public class PersonViewModel : ViewModel
    {
        #region Fields

        PersonListViewModel _personListViewModel;
        GeneralWindowViewModel _generalWindowViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        Person _person;
        string _nameSurname;
        string _surname;
        string _name;
        Position _position;
        ICommand _openAddPerson;
        ICommand _openDeletePerson;
        ICommand _openEditPerson;
        ICommand _showChangePassword;

        #endregion

        #region Constructors
        public PersonViewModel(GeneralWindowViewModel generalWindowViewModel)
        {
            _generalWindowViewModel = generalWindowViewModel;
            PersonListViewModel = new PersonListViewModel();
        }

        #endregion

        #region Properities

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                Position = value.Position;
                Name = value.Name;
                Surname = value.Surname;
                NameSurname = value.Name + " " + value.Surname;
                OnPropertyChanged("");
            }
        }

        public Position Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("");
            }
        }

        public string NameSurname
        {
            get { return _nameSurname; }
            set
            {
                _nameSurname = value;
                OnPropertyChanged("");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("");
            }
        }

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

        public ICommand OpenChangePasswordWindowViewCommand                                                                                         
        {
            get { return _showChangePassword ?? (_showChangePassword = new RelayCommand(OpenChangePasswordWindowView)); }
        }

        private void OpenChangePasswordWindowView(object obj)
        {
            var view = new ChangePasswordWindowView();
            ChangePasswordWindowViewModel vm = new ChangePasswordWindowViewModel(_generalWindowViewModel);
            view.DataContext = vm;
            view.ShowDialog();
        }


        #endregion
    }
}
