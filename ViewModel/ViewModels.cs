using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting;

namespace ViewModel
{
    public class ViewModels : INotifyPropertyChanged
    {
        public Models models;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Race> listeRaces { get; set; }
        public ObservableCollection<Classe> listeClasses { get; set; }
        public ObservableCollection<Personnage> listePersonnages { get; set; }
        public ObservableCollection<Competence> listeCompetences { get; set; }
        public ObservableCollection<ObservableCollection<Equipement>> listeEquipementsChoix { get; set; }

        public string stat1 { get; set; }
        public string stat2 { get; set; }
        public string stat3 { get; set; }
        public string stat4 { get; set; }
        public string stat5 { get; set; }
        public string stat6 { get; set; }

        public ObservableCollection<int> listeStats { get; set; }

        public string choixEquipementUnique { get; set; }

        public string descriptionRaceSelectionnee { get; set; } 
        public string descriptionClasseSelectionne { get; set; }

        private ViewModels()
        {
            models = new Models();
            listeRaces = models.obtenirRaces();
            listeClasses = models.obtenirClasse();
            listePersonnages = models.obtenirPersonnagesExistants();
            

        }

        private static ViewModels _instance = new ViewModels();

        public static ViewModels getInstance
        {
            get { return _instance; }
        }

        public void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ajouterRace(object selectedItem)
        {
            Race race = (Race)selectedItem;
            models.ajouterLaRace(race);
        }

        public void ajouterClasse(object selectedItem)
        {
            Classe classe = (Classe)selectedItem;
            models.ajouterLaClasse(classe);
        }

        public void ajouterCompetencesMaitrises(List<object> competencesMaitrise)
        {
            List<Competence> competences = new List<Competence>();

            foreach (object competence in competencesMaitrise)
            {
                competences.Add((Competence)competence);
            }

            models.ajouterLesCompetencesMaitrises(competences);
        }

        public void ajouterLesEquipements(List<object> equipementsChoisisObject)
        {
            List<Equipement> equipementsChoisis = new List<Equipement>();
            foreach (object equipement in equipementsChoisisObject)
            {
                equipementsChoisis.Add((Equipement)equipement);
            }

            models.ajouterEquipements(equipementsChoisis);
        }

        public void afficherRace(object raceSelectionnee)
        {
            Race race = raceSelectionnee as Race;
            descriptionRaceSelectionnee = race.description;

            OnPropertyChange("descriptionRaceSelectionnee");

        }

        public void creerFichePersonnagePDF(object personnageSelectionne)
        {
            Personnage personnage = (Personnage)personnageSelectionne;
            models.GenererFichePersonnagePDF(personnage, false);


        }
        
        public void afficherClasse(object classeSelectionnee)
        {
            Classe classe = classeSelectionnee as Classe;
            descriptionClasseSelectionne = models.obtenirDescriptionClasse(classe);

            OnPropertyChange("descriptionClasseSelectionne");

        }

        public void ajouterLesStatistiques(int[] statistiques)
        {
            models.attribuerLesStatistiques(statistiques);
        }

        public int nombreCompetencesMaitrisables()
        {
            return models.obtenirNombreCompetencesMatrisable();
        }

        public void inserserStats()
        {
            listeStats = models.obtenirValeursDeStatistiquesFixes();

            stat1 = listeStats[0].ToString();
            stat2 = listeStats[1].ToString();
            stat3 = listeStats[2].ToString();
            stat4 = listeStats[3].ToString();
            stat5 = listeStats[4].ToString();
            stat6 = listeStats[5].ToString();
        }
        
        public void insererCompetencesComboBox()
        {
            listeCompetences = models.obtenirCompetencesMaitrisables();
        }

        public void insererEquipements()
        {
            listeEquipementsChoix = models.obtenirEquipements();
        }
    }   
}

