using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel;

namespace CreationDND
{
    /// <summary>
    /// Logique d'interaction pour InterfacePersonnages.xaml
    /// </summary>
    public partial class Personnages : Window
    {
        private ViewModels _viewModel;

        public Personnages()
        {
            InitializeComponent();
            _viewModel = ViewModels.getInstance;
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void comboBox_AfficherPersonnage(object sender, SelectionChangedEventArgs e)
        {

            if (ComboBoxPersonnages.SelectedItem != null)
            {
              _viewModel.afficherRace(ComboBoxPersonnages.SelectedItem);
            }
            //comboBoxRaces_ChangerImage();
        }
    }
}
