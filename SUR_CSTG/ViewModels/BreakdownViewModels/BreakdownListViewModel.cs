using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.BreakdownViewModels
{
    public class BreakdownListViewModel : ViewModel
    {
        #region Fields

        ICollection<Breakdown> _breakdown;
        Breakdown _selectedBreakdown;

        #endregion

        #region Properities

        public ICollection<Breakdown> Breakdowns
        {
            get { return _breakdown; }
            set
            {
                _breakdown = new ObservableCollection<Breakdown>(value);
                OnPropertyChanged("");
            }
        }

        public Breakdown SelectedBreakdown
        {
            get { return _selectedBreakdown; }
            set
            {
                _selectedBreakdown = value;
                OnPropertyChanged("");
            }
        }

        #endregion
    }
}
