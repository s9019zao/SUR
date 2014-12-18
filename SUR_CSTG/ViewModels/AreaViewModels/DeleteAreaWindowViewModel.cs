using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class DeleteAreaWindowViewModel : ViewModel
    {
        #region Fields

        AreaViewModel _areaViewModel;
        Area _areaToDelete;
        ICommand _closeWinndow;
        ICommand _delete;

        #endregion

        #region Constructors

        public DeleteAreaWindowViewModel(AreaViewModel areaViewModel)
        {
            _areaViewModel = areaViewModel;
        }

        #endregion

        #region Properities

        public AreaViewModel AreaViewModel
        {
            get { return _areaViewModel; }
            set
            {
                _areaViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Area AreaToDelete
        {
            get { return _areaToDelete; }
            set
            {
                _areaToDelete = value;
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
            if (AreaToDelete.Devices.LongCount() == 0)
            {
                _areaViewModel.AreaListViewModel.Areas.Remove(AreaToDelete);
                _areaViewModel.Ctx.Areas.Remove(AreaToDelete);
                _areaViewModel.Ctx.SaveChanges();
                OnPropertyChanged("");
                Close(obj);
            }
            else
            {
                string mess = "W rejonie znajdują się urządzenia";
                var message = MessageBox.Show(mess);
            }

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
