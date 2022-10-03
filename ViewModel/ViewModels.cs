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

        private static ViewModels _instance = new ViewModels();

        public static ViewModels Instance { get { return _instance; } }

        public Models models;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Race> listeRaces { get; set; }
        public string descriptionRaceSelectionnee { get; set; }

        private ViewModels()
        {
            models = new Models();
            listeRaces = models.obtenirRaces();
        }

        public void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void afficherRace(object raceSelectionnee)
        {
            Race race = raceSelectionnee as Race;
            descriptionRaceSelectionnee = race.description;

            OnPropertyChange("descriptionRaceSelectionnee");

        }
    }
}
