using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class AreaSerchListViewModel : ViewModel
    {
        ICollection<Area> _area;

        public ICollection<Area> Areas
        {
            get { return _area; }
            set
            {
                _area = new ObservableCollection<Area>(value);
                OnPropertyChanged("");
            }
        }
    }
}
