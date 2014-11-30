using SUR_CSTG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SUR_CSTG.ViewModels.PersonViewModels
{
    class DeletePersonWindowViewModel : ViewModel
    {
        #region Fields

        PersonViewModel _personViewModel;
        Person _personToDelete;
        ICommand _closeWinndow;
        ICommand _delete;

        #endregion

        #region Constructors

        public DeletePersonWindowViewModel(PersonViewModel personViewModel)
        {
            _personViewModel = personViewModel;
        }

        #endregion

        #region Properities

        public PersonViewModel PersonViewModel
        {
            get { return _personViewModel; }
            set
            {
                _personViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Person PersonToDelete
        {
            get { return _personToDelete; }
            set
            {
                _personToDelete = value;
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

            _personViewModel.PersonListViewModel.Persons.Remove(PersonToDelete);
            _personViewModel.Ctx.Persons.Remove(PersonToDelete);
            _personViewModel.Ctx.SaveChanges();
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
