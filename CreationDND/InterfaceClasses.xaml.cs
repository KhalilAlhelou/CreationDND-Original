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
    /// Lógica interna para InterfaceClasses.xaml
    /// </summary>
    public partial class InterfaceClasses : Window
    {
        public static RoutedCommand cmdRedirectionnerPage = new RoutedCommand();

        private ViewModels _viewModel;

        public InterfaceClasses()
        {
            InitializeComponent();
            _viewModel = ViewModels.getInstance;
            DataContext = _viewModel;
        }

        /*private void comboBoxRaces_ChangerImage()
        {

        }*/

        private void comboBox_AfficherClasses(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxClasses.SelectedItem != null)
            {
                _viewModel.afficherClasse(ComboBoxClasses.SelectedItem);
            }
            //comboBoxRaces_ChangerImage();
        }
        public void redirectionnerPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            InterfaceChoisirCompetence pageCompetences = new InterfaceChoisirCompetence();
            pageCompetences.Show();
            this.Close();
        }

        public void redirectionnerPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ComboBoxClasses.SelectedItem == null)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
    }
}
