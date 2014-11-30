using SUR_CSTG.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SUR_CSTG.Views.PersonViews
{
    /// <summary>
    /// Interaction logic for DeletePersonWindowView.xaml
    /// </summary>
    public partial class DeletePersonWindowView : Window
    {
        public DeletePersonWindowView()
        {
            InitializeComponent();
            DataContext = new AddPersonWindowViewModel();

        }
    }
}
