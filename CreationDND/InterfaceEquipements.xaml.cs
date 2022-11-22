using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _viewModel.insererEquipements();
            
            for(int i = 0; i < _viewModel.listeEquipementsChoix.Count; i++)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Width = 400;
                comboBox.Margin = new Thickness(5);
                comboBox.ItemsSource = _viewModel.listeEquipementsChoix[i];
                Stack.Children.Add(comboBox);
                comboBoxesEquipements.Add(comboBox);
            }
        }

        public void onClickBtn(object sender, RoutedEventArgs e)
        {
            InterfaceStats pageStats = new InterfaceStats();
            pageStats.Show();
            this.Close();
        }
    }
}
