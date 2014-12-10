using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class EditQuantityPartWindowViewModel : ViewModel
    {
        #region Fields

        PartViewModel _partViewModel;
        SUR_DbContext _ctx = new SUR_DbContext();
        Part _partToEditQuantity;
        double _addQuantity;
        double _removeQuantity;
        string _name;
        double _quantity;
        PartType _partTypeToEditQuantity;
        Unit _unitToEditQuantity;
        ICommand _closeWinndow;
        ICommand _addQuantityCommand;
        ICommand _removeQuantityCommand;

        #endregion

        #region Constructors

        public EditQuantityPartWindowViewModel(PartViewModel partViewModel)
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

        public double AddQuantity
        {
            get { return _addQuantity; }
            set
            {
                _addQuantity = value;
                OnPropertyChanged("");
            }
        }

        public double RemoveQuantity
        {
            get { return _removeQuantity; }
            set
            {
                _removeQuantity = value;
                OnPropertyChanged("");
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

        public PartType PartTypeToEditQuantity
        {
            get { return _partTypeToEditQuantity; }
            set
            {
                _partTypeToEditQuantity = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public Unit UnitToEditQuantity
        {
            get { return _unitToEditQuantity; }
            set
            {
                _unitToEditQuantity = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public Part PartToEditQuantity
        {
            get { return _partToEditQuantity; }
            set
            {
                _partToEditQuantity = value;
                Name = value.Name;
                Quantity = value.Quantity;
                PartTypeToEditQuantity = value.PartType;
                UnitToEditQuantity = value.Unit;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Command

        public ICommand AddQuantityPartCommand
        {
            get { return _addQuantityCommand ?? (_addQuantityCommand = new RelayCommand(Add,CanAdd)); }
        }

        private bool CanAdd(object obj)
        {
            if (AddQuantity != 0)
                return true;
            else
                return false;
        }

        private void Add(object obj)
        {
            PartToEditQuantity.Name = Name;
            PartToEditQuantity.Quantity = Quantity + AddQuantity;
            PartToEditQuantity.PartType = PartTypeToEditQuantity;
            PartToEditQuantity.Unit = UnitToEditQuantity;
            _ctx.SaveChanges();
            Close(obj);
        }

        public ICommand RemoveQuantityPartCommand
        {
            get { return _removeQuantityCommand ?? (_removeQuantityCommand = new RelayCommand(Remove,CanRemove)); }
        }

        private bool CanRemove(object obj)
        {
            if (RemoveQuantity != 0)
                return true;
            else
                return false;
        }

        private void Remove(object obj)
        {
            PartToEditQuantity.Name = Name;
            PartToEditQuantity.Quantity = Quantity - RemoveQuantity;
            PartToEditQuantity.PartType = PartTypeToEditQuantity;
            PartToEditQuantity.Unit = UnitToEditQuantity;
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
