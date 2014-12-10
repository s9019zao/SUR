using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class PartListViewModel : ViewModel 
    {
        #region Fields

        ICollection<Part> _part;
        Part _selectedPart;

        #endregion

        #region Properities

        public ICollection<Part> Parts
        {
            get { return _part; }
            set
            {
                _part = new ObservableCollection<Part>(value);
                OnPropertyChanged("");
            }
        }

        public Part SelectedPart
        {
            get { return _selectedPart; }
            set
            {
                _selectedPart = value;
                OnPropertyChanged("");
            }
        }

        #endregion
    }
}
