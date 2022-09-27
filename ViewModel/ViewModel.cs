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

namespace ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public Models models;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Race> listeRaces { get; set; }

        public ViewModel()
        {
            models = new Models();
            listeRaces = new ObservableCollection<Race>();
        }

        public void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void afficherRace(Race raceSelectionnee)
        {
            descriptionRaceSelectionnee = raceSelectionnee.
        }
    }
}
