using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.BreakdownViewModels
{
    public class EditBreakdownWindowViewModel : ViewModel
    {
        #region Fields

        BreakdownViewModel _breakedownViewModel;
        Breakdown _breakdownToEdit;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _closeWinndow;
        ICommand _edit;


        #endregion

        #region Constructors

        public EditBreakdownWindowViewModel(BreakdownViewModel breakdownViewModel)
        {
            _breakedownViewModel = breakdownViewModel;
           
        }

        #endregion

        #region Properities

        public BreakdownViewModel BreakdownViewModel
        {
            get { return _breakedownViewModel; }
            set
            {
                _breakedownViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Breakdown BreakdownToEdit
        {
            get { return _breakdownToEdit; }
            set
            {
                _breakdownToEdit = value;
//                Name = value.Name;
//                Description = value.Description;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand EditCommand
        {
            get { return _edit ?? (_edit = new RelayCommand(Edit)); }
        }

        public void Edit(object obj)
        {
//            BreakdownToEdit.Name = Name;
//            BreakdownToEdit.Description = Description;
            _ctx.SaveChanges();
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
