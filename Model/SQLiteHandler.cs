
using System.Data.SQLite;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;

namespace Model
{
    public class SQLiteHandler
    {
        string SQLpath;
        public SQLiteHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
            //string path = "Data/dbCharacter.sqlite";
            SQLpath = "Data Source=" + path + ";Version=3;";
            initializeDB(path);

    }
        public void initializeDB(string path)
        {
        
            if (!File.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                Debug.WriteLine("DB is being created");
                SQLiteConnection.CreateFile(path);

                SQLiteConnection m_dbConnection = new SQLiteConnection(SQLpath);

                string insertionRaceContents = File.ReadAllText("insertionRace.sql");

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

        public RaceDTO getRace(string raceName)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE nameR ='" + raceName + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.GetString(1).ToLower() == raceName.ToLower())
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRace(int raceId)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE idR ='" + raceId + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(0) == raceId)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }


        public RaceDTO getRaceBonusForce(int bonusForce)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bForceR ='" + bonusForce + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(3) == bonusForce)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRaceBonusDex(int bonusDex)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bDexR ='" + bonusDex + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(4) == bonusDex)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRaceBonusConst(int bonusConst)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bConstR ='" + bonusConst + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(5) == bonusConst)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRaceBonusInt(int bonusInt)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bIntR ='" + bonusInt + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(6) == bonusInt)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRaceBonusSage(int bonusSage)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bSageR ='" + bonusSage + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(7) == bonusSage)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public RaceDTO getRaceBonusChar(int bonusChar)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race WHERE bCharR ='" + bonusChar + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                if (rdr.GetInt32(8) == bonusChar)
                {

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                }
            }

            return null;
        }

        public List<RaceDTO> getAllRace()
        {
            List<RaceDTO> listRace = new List<RaceDTO>();
            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM race";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                    listRace.Add(new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8)));
            
            }

            return listRace;
        }
    }

}
