using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views.BreakdownViews;

namespace SUR_CSTG.ViewModels.BreakdownViewModels
{
    public class ChangeStatusBreakdownViewModel : ViewModel
    {
        #region Fields

        BreakdownViewModel _breakdownViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        bool _isChecked1;
        bool _isChecked2;
        ICommand _changeStatus;
        ICommand _close;

        #endregion

        #region Constructors

        public ChangeStatusBreakdownViewModel(BreakdownViewModel breakdownViewModel)
        {
            _breakdownViewModel = breakdownViewModel;
        }

        #endregion

        #region Properities

        public bool IsChecked1
        {
            get { return _isChecked1; }
            set
            {
                _isChecked1 = value;
                if (_isChecked1 == true)
                {
                    IsChecked2 = false;
                }
                OnPropertyChanged("IsChecked1");
            }
        }

        public bool IsChecked2
        {
            get { return _isChecked2; }
            set
            {
                _isChecked2 = value;
                if (_isChecked2 == true)
                {
                    IsChecked1 = false;
                }
                OnPropertyChanged("IsChecked2");
            }
        }

        public BreakdownViewModel BreakdownViewModel
        {
            get { return _breakdownViewModel; }
            set
            {
                _breakdownViewModel = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand ChangeStatusBreakdownCommand
        {
            get { return _changeStatus ?? (_changeStatus = new RelayCommand(ChangeStatusBreakdown, CanChangeStatusBreakdown)); }
        }

        private bool CanChangeStatusBreakdown(object obj)
        {
            if (IsChecked1 == true || IsChecked2 == true)
                return true;
            else
                return false;
        }

        private void ChangeStatusBreakdown(object obj)
        {
            if (IsChecked1 == true)
            {
                this._breakdownViewModel.BreakdownListViewModel.SelectedBreakdown.Status = Data.StatusBreakdown.Oczekująca;
                _breakdownViewModel.Ctx.SaveChanges();
//                _breakdownViewModel.BreakdownListViewModel.Breakdowns = new ObservableCollection<Breakdown>(_ctx.Breakdowns);
                OnPropertyChanged("");
            }
            else
            {
                if (IsChecked2 == true)
                {
                    this._breakdownViewModel.BreakdownListViewModel.SelectedBreakdown.Status = Data.StatusBreakdown.Usuwana;
                    _breakdownViewModel.Ctx.SaveChanges();
//                    _breakdownViewModel.BreakdownListViewModel.Breakdowns = new ObservableCollection<Breakdown>(_ctx.Breakdowns);
                    OnPropertyChanged("");
                }
            }               
            _breakdownViewModel.SelectedViewChangeStatus = null;
            OnPropertyChanged("");
        }

        public ICommand CloseChangeStatusBreakdownCommand
        {
            get { return _close ?? (_close = new RelayCommand(CloseChangeStatusBreakdown)); }
        }

        private void CloseChangeStatusBreakdown(object obj)
        {
            _breakdownViewModel.SelectedViewChangeStatus = null;
        }

      #endregion

    }
}
