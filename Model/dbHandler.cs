using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static raceCharacter;
//using static SQLiteHandler;

namespace Model
{
    public class dbHandler
    {
        SQLiteHandler sqlHandler = new SQLiteHandler();
        public dbHandler()
        {

        }
        /** -- DEPRICATED -- USE FOR TESTING ONLY --
        public void showTable(string tableName)
        {

            sqlHandler.showTable(tableName);
        }**/
        public List<RaceDTO> getAllRace()
        {
            return sqlHandler.getAllRace();
        }

        public List<ClasseDTO> getAllClasse()
        {
            return sqlHandler.getAllClasse();
        }
        
        public CompetenceDTO getCompetence(int id)
        {
            return sqlHandler.getCompetence(id);
        }



    }



}


