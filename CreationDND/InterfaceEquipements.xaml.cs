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
    /// Lógica interna para InterfaceEquipements.xaml
    /// </summary>
    public partial class InterfaceEquipements : Window
    {
        public static RoutedCommand cmdChoisirEquipement = new RoutedCommand();

        private ViewModels _viewModel;
        List<ComboBox> comboBoxesEquipements = new List<ComboBox>();

        public InterfaceEquipements()
        {
            InitializeComponent();

            _viewModel = ViewModels.getInstance;
            
        }
    }
}
