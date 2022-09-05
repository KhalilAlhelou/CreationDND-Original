using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static raceCharacter;
using static SQLiteHandler;
public class dbHandler
{
    public dbHandler()
    {

    }

    public void InitializeDB() {
        SQLiteHandler sqlHandler = new SQLiteHandler();
        sqlHandler.initializeDB();
    }
    public void showTable(string tableName)
    {
        SQLiteHandler sqlHandler = new SQLiteHandler();
        sqlHandler.showTable(tableName);
    }

}

