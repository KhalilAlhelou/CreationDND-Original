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
              if (ComboBox2.SelectedItem != null)
              {
                 _viewModel.afficherClasse(ComboBox2.SelectedItem);
              }
              //comboBoxRaces_ChangerImage();
          }
    }
}
