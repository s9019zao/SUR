using SUR_CSTG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SUR_CSTG.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        
        ICommand _openGeneralWindow;

        public ICommand OpenGeneralWindowCommand 
        { 
            get { return _openGeneralWindow ?? (_openGeneralWindow = new RelayCommand(OpenGeneralWindow)); } 
        }

        private void OpenGeneralWindow(object obj)
        {
            var window = new GeneralWindowView();
            window.Show();
        }
    }
}