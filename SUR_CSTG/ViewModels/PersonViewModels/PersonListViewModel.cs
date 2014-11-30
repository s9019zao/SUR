using SUR_CSTG.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.ViewModels.PersonViewModels
{
    public class PersonListViewModel : ViewModel
    {
        #region Fields

        ICollection<Person> _person;
        Person _selectedPerson;

        #endregion

        #region Properities

        public ICollection<Person> Persons
        {
            get { return _person; }
            set
            {
                _person = new ObservableCollection<Person>(value);
                OnPropertyChanged("");
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("");
            }
        }

        #endregion
  
    }
}
