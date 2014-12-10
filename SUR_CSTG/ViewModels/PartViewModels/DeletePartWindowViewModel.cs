using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class DeletePartWindowViewModel : ViewModel
    {
        #region Fields

        PartViewModel _partViewModel;
        Part _partToDelete;
        ICommand _closeWinndow;
        ICommand _delete;

        #endregion

        #region Constructors

        public DeletePartWindowViewModel(PartViewModel partViewModel)
        {
            _partViewModel = partViewModel;
        }

        #endregion

        #region Properities

        public PartViewModel PartViewModel
        {
            get { return _partViewModel; }
            set
            {
                _partViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Part PartToDelete
        {
            get { return _partToDelete; }
            set
            {
                _partToDelete = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand DeletePartCommand
        {
            get { return _delete ?? (_delete = new RelayCommand(Delete)); }
        }

        public void Delete(object obj)
        {

            _partViewModel.PartListViewModel.Parts.Remove(PartToDelete);
            _partViewModel.Ctx.Parts.Remove(PartToDelete);
            _partViewModel.Ctx.SaveChanges();
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
