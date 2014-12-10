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
using SUR_CSTG.ViewModels.PartViewModels;

namespace SUR_CSTG.Views.PartViews
{
    /// <summary>
    /// Interaction logic for AddPartWindowView.xaml
    /// </summary>
    public partial class AddPartWindowView : Window
    {
        public AddPartWindowView()
        {
            InitializeComponent();
            DataContext = new AddPartWindowViewModel();
        }
    }
}
