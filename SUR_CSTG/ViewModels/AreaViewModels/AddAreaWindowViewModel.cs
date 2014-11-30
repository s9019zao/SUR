using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SUR_CSTG.Data;
using SUR_CSTG.Views;
using SUR_CSTG.Views.AreaViews;

namespace SUR_CSTG.ViewModels.AreaViewModels
{
    public class AddAreaWindowViewModel : ViewModel
    {
        #region Fields

        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _addAreaCommand;
        ICommand _closeWinndow;
        string _name;
        string _description;

        #endregion

        #region Properities

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        #endregion

        #region Command

        public ICommand AddAreaCommand
        {
            get { return _addAreaCommand ?? (_addAreaCommand = new RelayCommand(Add, CanAdd)); }
        }

        private void Add(object obj)
        {
            string message = "Dodano rejon\n";
            string titel = "Informacja o dodaniu rejonu";
            _ctx.Areas.Add(new Area { Name = Name, Description = Description });
            _ctx.SaveChanges();
            var result = MessageBox.Show(message + "O nazwie: " + Name, titel);
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
