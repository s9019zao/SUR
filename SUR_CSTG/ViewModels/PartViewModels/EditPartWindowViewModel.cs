using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class EditPartWindowViewModel : ViewModel
    {
        #region Fields

        IEnumerable<PartType> _partType;
        IEnumerable<Unit> _unit;
        PartViewModel _partViewModel;
        Part _partToEdit;
        PartType _selectedPartType;
        PartType _partTypeToEdit;
        Unit _selectedUnit;
        Unit _unitToEdit;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _closeWinndow;
        ICommand _edit;
        string _name;
        double _quantity;

        #endregion

        #region Constructors

        public EditPartWindowViewModel(PartViewModel partViewModel)
        {
            _partViewModel = partViewModel;
        }

        #endregion

        #region Properities

        public IEnumerable<PartType> PartType
        {
            get { return Enum.GetValues(typeof(PartType)).Cast<PartType>(); }
            set
            {
                _partType = value;
                OnPropertyChanged("");
            }
        }

        public IEnumerable<Unit> Unit
        {
            get { return Enum.GetValues(typeof(Unit)).Cast<Unit>(); }
            set
            {
                _unit = value;
                OnPropertyChanged("");
            }
        }

        public PartType SelectedPartType
        {
            get { return _selectedPartType; }
            set
            {
                _selectedPartType = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public PartType PartTypeToEdit
        {
            get { return _partTypeToEdit; }
            set
            {
                _partTypeToEdit = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public Unit SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                _selectedUnit = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public Unit UnitToEdit
        {
            get { return _unitToEdit; }
            set
            {
                _unitToEdit = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("");
            }
        }

        public Part PartToEdit
        {
            get { return _partToEdit; }
            set
            {
                _partToEdit = value;
                Name = value.Name;
                Quantity = value.Quantity;
                PartTypeToEdit = value.PartType;
                UnitToEdit = value.Unit;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand EditPartCommand
        {
            get { return _edit ?? (_edit = new RelayCommand(Edit)); }
        }

        public void Edit(object obj)
        {
            PartToEdit.Name = Name;
            PartToEdit.Quantity = Quantity;
            PartToEdit.PartType = SelectedPartType;
            PartToEdit.Unit = SelectedUnit;
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
