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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace CreationDND
{
    /// <summary>
    /// Logique d'interaction pour InterfacePersonnagesDescription.xaml
    /// </summary>
    public partial class InterfacePersonnagesDescription : Window
    {
        private ViewModels _viewModel;

        public InterfacePersonnagesDescription()
        {
            InitializeComponent();
            _viewModel = ViewModels.getInstance;
            DataContext = _viewModel;
        }
        private void btnRetourDeDescriptinPersonnage_Click(object sender, RoutedEventArgs e)
        {
            Personnages pagePersonnages = new Personnages();
            pagePersonnages.Show();
            this.Close();
        }
    }
}
