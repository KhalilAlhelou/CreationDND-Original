using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    class Models
    {
        public dbHandler db;
        public Models()
        {
            db = new dbHandler();
            //db.showTable("race");
            List<RaceDTO> listTmp = db.getAllRace();
            //Debug.WriteLine(raceTmp2);
        }

        public ObservableCollection<Race> obtenirRaces()
        {
            List<RaceDTO> listeDTO = db.getAllRace();
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