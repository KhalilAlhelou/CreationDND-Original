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
        List<ComboBox> comboBoxesSousOption = new List<ComboBox>();
        

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
                comboBox.ItemsSource = _viewModel.listeEquipementsChoix[i].tousLesChoix;
                comboBox.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                Stack.Children.Add(comboBox);
                comboBoxesEquipements.Add(comboBox);
            }
            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxesSousOption.Count > 0)
            {
                foreach(ComboBox comboBox in comboBoxesSousOption)
                {
                  Stack.Children.Remove(comboBox);
                }
            }

            foreach(ComboBox comboBox in comboBoxesEquipements)
            {
                List<int> positionDesGroupes = _viewModel.determinerSiGroupe(comboBox.SelectedItem);
                if (positionDesGroupes.Count > 0)
                {
                    for (int i = 0; i < positionDesGroupes.Count; i++)
                    {
                        ComboBox comboBoxSousOption = new ComboBox();
                        comboBoxSousOption.Width = 400;
                        comboBoxSousOption.Margin = new Thickness(5);
                        comboBoxSousOption.ItemsSource = _viewModel.obtenirListeEquipementDeGroupe(comboBox.SelectedItem, positionDesGroupes[i]);
                        Stack.Children.Add(comboBoxSousOption);
                        comboBoxesSousOption.Add(comboBoxSousOption);
                    }
                }
            }
        }

        private void ajouterEquipement()
        {
            List<object> listeEquipementsChoisis = new List<object>();
            foreach(ComboBox comboBox in comboBoxesEquipements)
            {
                listeEquipementsChoisis.Add(comboBox.SelectedItem);
            }

            _viewModel.ajouterLesEquipements(listeEquipementsChoisis);
        }

        public void choisirEquipement_canExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool equipSelect = false;

            for (int i = 0; i < comboBoxesEquipements.Count; i++)
            {
                if (comboBoxesEquipements[i].IsEnabled)
                {
                    if (comboBoxesEquipements[i].SelectedItem == null)
                    {
                        equipSelect = false;
                        break;
                    }
                    else
                    {
                        equipSelect = true;
                    }
                }
            }

            if (!equipSelect)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        public void choisirEquip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            List<object> equipementsSelectionnes = new List<object>();

            foreach (ComboBox comboBox in comboBoxesEquipements)
            {
                if (comboBox.IsEnabled)
                {
                    equipementsSelectionnes.Add(comboBox.SelectedItem);
                }
            }

            InterfaceStats interfaceStats = new InterfaceStats();
            ajouterEquipement();
            interfaceStats.Show();
            this.Close();

        }

        private void btnRetourDePageEquipements_Click(object sender, RoutedEventArgs e)
        {
            InterfaceChoisirCompetence InterfaceCompetences = new InterfaceChoisirCompetence();
            InterfaceCompetences.Show();
            this.Close();
        }
    }
}
