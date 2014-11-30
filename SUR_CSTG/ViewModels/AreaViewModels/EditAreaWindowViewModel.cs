using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class EditAreaWindowViewModel : ViewModel
    {
        #region Fields

        AreaViewModel _areaViewModel;
        Area _areaToEdit;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _closeWinndow;
        ICommand _edit;
        string _name;
        string _description;

        #endregion

        #region Constructors

        public EditAreaWindowViewModel(AreaViewModel areaViewModel)
        {
            _areaViewModel = areaViewModel;
           
        }

        #endregion

        #region Properities

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }

        
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; ;
                OnPropertyChanged("");
            }
        }

        public AreaViewModel AreaViewModel
        {
            get { return _areaViewModel; }
            set
            {
                _areaViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Area AreaToEdit
        {
            get { return _areaToEdit; }
            set
            {
                _areaToEdit = value;
                Name = value.Name;
                Description = value.Description;
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
            AreaToEdit.Name = Name;
            AreaToEdit.Description = Description;
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
