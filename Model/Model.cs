using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    public class Models
    {
        public dbHandler db;
        public Models()
        {
            db = new dbHandler();
        }

        public ObservableCollection<Race> obtenirRaces()
        {
            List<RaceDTO> listeDTO = db.getAllRace();
            ObservableCollection<Race> listeRaces = new ObservableCollection<Race>();

            foreach (RaceDTO raceDTO in listeDTO)
            {
                listeRaces.Add(new Race(raceDTO));
            }

            return listeRaces;
        }

        public ObservableCollection<Classe> obtenirClasse()
        {
            List<ClasseDTO> listeDTO = new List<ClasseDTO>();

            ObservableCollection<Classe> listeClasses = new ObservableCollection<Classe>();

            foreach (ClasseDTO classeDTO in listeDTO)
            {
                listeClasses.Add(new Classe(classeDTO));
            }

            return listeClasses;

        }


    }
}