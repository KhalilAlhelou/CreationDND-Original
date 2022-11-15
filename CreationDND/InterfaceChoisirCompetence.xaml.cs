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
    /// Lógica interna para InterfaceChoisirCompetence.xaml
    /// </summary>
    public partial class InterfaceChoisirCompetence : Window
    {
        public static RoutedCommand cdmChoisirCompetence = new RoutedCommand();

        private ViewModels _viewModel;
        List<ComboBox> comboBoxes = new List<ComboBox>();
        public InterfaceChoisirCompetence()
        {
            InitializeComponent();
            
            _viewModel = ViewModels.getInstance;
            _viewModel.insererCompetencesComboBox();
            DataContext = _viewModel;
            comboBoxes.Add(Competence1);
            comboBoxes.Add(Competence2);
            comboBoxes.Add(Competence3);
            comboBoxes.Add(Competence4);
            activerComboBox(_viewModel.nombreCompetencesMaitrisables());

        }

        public void activerComboBox(int nombreCompetencesMaitrisables = 4)
        {
            for (int i = 0; i < nombreCompetencesMaitrisables; i++)
            {
                comboBoxes[i].IsEnabled = true;
            }
        }
        public void choisirCompetences_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            List<object> competencesSelectionnees = new List<object>();

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.IsEnabled)
                {
                    competencesSelectionnees.Add(comboBox.SelectedItem);
                }
            }

            InterfaceEquipements pageEquipements = new InterfaceEquipements();
            _viewModel.ajouterCompetencesMaitrises(competencesSelectionnees);
            pageEquipements.Show();
            this.Close();
        }


        private void btnRetourDePageCompetences_Click(object sender, RoutedEventArgs e)
        {
            InterfaceClasses classes = new InterfaceClasses();
            classes.Show();
            this.Close();
        }

        public void choisirCompetences_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool estSelectionne = false;

            bool itemSelectionne = false;

            for (int i = 0; i < comboBoxes.Count; i++)
            {
                for (int j = 0; j < comboBoxes.Count; j++)
                {
                    if(i != j)
                    {
                        if(comboBoxes[i].IsEnabled && comboBoxes[j].IsEnabled)
                        {
                            if(comboBoxes[i].SelectedItem == comboBoxes[j].SelectedItem)
                            {
                                    estSelectionne = false;
                                    break;
                            }
                            else
                            {
                                estSelectionne = true;
                            }
                        }
                        
                    }
                }
                if (!estSelectionne)
                {
                    break;
                }
            }


            for (int i = 0; i < comboBoxes.Count; i++)
            {
                if (comboBoxes[i].IsEnabled)
                {
                    if(comboBoxes[i].SelectedItem == null)
                    {
                        itemSelectionne = false;
                        break;
                    }
                    else
                    {
                        itemSelectionne = true;
                    }
                    
                }
                
            }

            if(!estSelectionne || !itemSelectionne)
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
