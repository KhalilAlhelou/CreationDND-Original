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
            descriptionClasseSelectionne = classe.description;

            OnPropertyChange("descriptionClasseSelectionne");

        }

        public int nombreCompetencesMaitrisables()
        {
            return models.obtenirNombreCompetencesMatrisable();
        }

        public ObservableCollection<Competence> competencesMaitrisables()
        {
            return models.obtenirCompetencesMaitrisables();
        }

        public void insererCompetencesComboBox()
        {
            listeCompetences = models.obtenirCompetencesMaitrisables();
        }

    }   
}

