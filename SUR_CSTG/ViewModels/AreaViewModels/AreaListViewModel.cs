using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class AreaListViewModel : ViewModel
    {
        #region Fields

        ICollection<Area> _area;
        Area _selectedArea;

        #endregion

        #region Properities

        public ICollection<Area> Areas
        {
            get { return _area; }
            set
            {
                _area = new ObservableCollection<Area>(value);
                OnPropertyChanged("");
            }
        }

        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnPropertyChanged("");
            }
        }

        #endregion
    }
}
