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
using ViewModel;

namespace CreationDND
{
    /// <summary>
    /// Lógica interna para InterfaceStats.xaml
    /// </summary>
    public partial class InterfaceStats : Window
    {
        private ViewModels _viewModel;
        public InterfaceStats()
        {
            InitializeComponent();
            _viewModel = ViewModels.getInstance;
            _viewModel.inserserStats();
            DataContext = _viewModel;
        }
    }
}
