using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private void btnRetourDePageStats_Click(object sender, RoutedEventArgs e)
        {
            InterfaceEquipements retour_a_equipements = new InterfaceEquipements();
            retour_a_equipements.Show();
            this.Close();
        }

        private void btnTerminerDePageStats_Click(object sender, RoutedEventArgs e)
        {
            List<int> stats = new List<int>();
            stats.Add((int)CBStat1.SelectedItem);
            stats.Add((int)CBStat2.SelectedItem);
            stats.Add((int)CBStat3.SelectedItem);
            stats.Add((int)CBStat4.SelectedItem);
            stats.Add((int)CBStat5.SelectedItem);
            stats.Add((int)CBStat6.SelectedItem);
            _viewModel.ajouterLesStatistiques(stats);
            MainWindow retour_a_page_principale = new MainWindow();
            retour_a_page_principale.Show();
            this.Close();
        }

        private void btnRoulerStats(object sender, RoutedEventArgs e)
        {
            ObservableCollection<int> newStat = new ObservableCollection<int>();

            Random randomStats = new Random();

            for (int i = 0; i < 6; i++)
            {

                List<int> diceList = new List<int>();

                int statResultat = 0;

                for (int j = 0; j < 4; j++)
                {
                    diceList.Add(randomStats.Next(1, 7));
                }
                diceList.Sort();
                diceList.Reverse();

                for (int l = 0; l < 3; l++)
                {
                    statResultat += diceList[l];
                }

                newStat.Add(statResultat);
            }

            _viewModel.assignerNouvelleStat(newStat);
            
        }

       

    }
}
