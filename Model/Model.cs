using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    class Models
    {
        public Models()
        {

        }

        public ObservableCollection<Race> obtenirRaces()
        {
            List<RaceDTO> listeDTO = new List<RaceDTO>(); // Sera remplacer par méthode façade
            listeDTO.Add(new RaceDTO(1, "1", "1", 1, 1, 1, 1, 1, 1));

            ObservableCollection<Race> listeRaces = new ObservableCollection<Race>();

            foreach (RaceDTO raceDTO in listeDTO)
            {
                listeRaces.Add(new Race(raceDTO));
            }

            return listeRaces;
        }

    }
}