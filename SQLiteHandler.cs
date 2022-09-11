
using System.Data.SQLite;
using System.Diagnostics;

using System.Collections.Generic;

using System.IO;
using System.Windows.Shapes;


public class SQLiteHandler
{
    string SQLpath;
    public SQLiteHandler()
    {
        string path = "../../Data/dbCharacter.sqlite";
        SQLpath = "Data Source=" + path + ";Version=3;";
        initializeDB(path);

}
    public void initializeDB(string path)
    {

        if (!File.Exists(path))
        {
            Debug.WriteLine("DB is being created");
            SQLiteConnection.CreateFile(path);

            SQLiteConnection m_dbConnection = new SQLiteConnection(SQLpath);
            string insertionRacePath = "../../Data/insertionRace.sql";
            string insertionRaceContents = File.ReadAllText(insertionRacePath);

            m_dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(insertionRaceContents, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

        }
        else {
            Debug.WriteLine("DB is being read");  
            }

       

       
    }

    public void showTable(string tableName)
    {

        using var con = new SQLiteConnection(SQLpath);
        con.Open();

        string stm = "SELECT * FROM " + tableName;

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        switch (tableName)
        {
            case "race":
                while (rdr.Read())
                {
                    Debug.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
                }
                break;
        }
    }

    public raceCharacter getRace(string raceName)
    {

        using var con = new SQLiteConnection(SQLpath);
        con.Open();

        string stm = "SELECT * FROM race WHERE name ='" + raceName + "'";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            if (rdr.GetString(1).ToLower() == raceName.ToLower())
            {

                return new raceCharacter(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }
        }

        return null;
    }

    public raceCharacter getRace(int raceId)
    {

        using var con = new SQLiteConnection(SQLpath);
        con.Open();

        string stm = "SELECT * FROM race WHERE id ='" + raceId + "'";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {


            if (rdr.GetInt32(0) == raceId)
            {

                return new raceCharacter(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }
        }

        return null;
    }

    public List<raceCharacter> getAllRace()
    {
        List<raceCharacter> listRace = new List<raceCharacter>();
        using var con = new SQLiteConnection(SQLpath);
        con.Open();

        string stm = "SELECT * FROM race";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {


                listRace.Add(new raceCharacter(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
            
        }

        return listRace;
    }
}
