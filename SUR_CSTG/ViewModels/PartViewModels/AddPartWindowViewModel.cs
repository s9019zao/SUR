using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.PartViewModels
{
    public class AddPartWindowViewModel : ViewModel
    {
        #region Fields

        SUR_DbContext _ctx = new SUR_DbContext();
        IEnumerable<PartType> _partType;
        IEnumerable<Unit> _unit;
        string _name;
        double _quantity;
        PartType _selectedPartType;
        Unit _selectedUnit;
        ICommand _addPartCommand;
        ICommand _closeWinndow;

        #endregion

        #region Properities

        public PartType SelectedPartType
        {
            get { return _selectedPartType; }
            set
            {
                _selectedPartType = value;
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public IEnumerable<PartType> PartType
        {
            get { return Enum.GetValues(typeof(PartType)).Cast<PartType>(); }

            set
            {
                _partType = value;
                OnPropertyChanged("Position");
            }
        }

        public IEnumerable<Unit> Unit
        {
            get { return Enum.GetValues(typeof(Unit)).Cast<Unit>(); }

            set
            {
                _unit = value;
                OnPropertyChanged("Position");
            }
        }

        #endregion

        #region Command

        public ICommand AddPartCommand
        {
            get { return _addPartCommand ?? (_addPartCommand = new RelayCommand(Add, CanAdd)); }
        }

        private void Add(object obj)
        {
            string message = "Dodano część\n";
            string titel = "Informacja o dodaniu części";
            _ctx.Parts.Add(new Part { Name = Name, Quantity = Quantity, PartType = SelectedPartType, Unit = SelectedUnit });
            _ctx.SaveChanges();
            var result = MessageBox.Show(message + " " + Name, titel);
            Close(obj);
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(_name);
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
