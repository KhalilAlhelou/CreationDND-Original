using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
//using static raceCharacter;
//using static SQLiteHandler;


public class dbHandler
{
    SQLiteHandler sqlHandler = new SQLiteHandler();
    public dbHandler()
    {

    }

    public void InitializeDB()
    {
        sqlHandler.initializeDB();
    }
    public void showTable(string tableName)
    {

        sqlHandler.showTable(tableName);
    }
    public List<raceCharacter> getAllRace()
    {
        return sqlHandler.getAllRace();
    }

    public raceCharacter getRace(int raceId)
    {
        return sqlHandler.getRace(raceId);
    }
    public raceCharacter getRace(string raceName)
    {
        return sqlHandler.getRace(raceName);
    }


}


