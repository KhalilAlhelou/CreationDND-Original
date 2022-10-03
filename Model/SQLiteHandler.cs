
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

                string insertionRaceContents = File.ReadAllText("insertionScript.sql");

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
/**
        public RaceDTO getClass(string className)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM class WHERE nameC ='" + className + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //for each attribute, add to list, getClass -> ID using an array of split on ";"
                    return null; //todo
                
            }

            return null;
        }

        public RaceDTO getClass(int classID)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM class WHERE idC ='" + classID + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                return null; //todo

            }

            return null;
        }

        public RaceDTO getAttribute(string attributeName)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM attribute WHERE nameAttr ='" + attributeName + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
      

                    return null; //todo
                
            }

            return null;
        }

        public RaceDTO getAttribute(int attributeID)
        {

            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM attribute WHERE idAttr ='" + attributeID + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {


                return null; //todo

            }

            return null;
        }
**/
        

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

            con.Close();
            return listRace;
        }

        public List<ClassDTO> getAllClasse()
        {
            List<ClassDTO> listClasse = new List<ClassDTO>();
            using var con = new SQLiteConnection(SQLpath);
            con.Open();

            string stm = "SELECT * FROM class";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                //int id = rdr.GetInt32(0);
                //listClasse.Add(new ClassDTO(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetBoolean(4), rdr.GetInt32(5), null));

                listClasse.Add(new ClassDTO("Test", "Ceci est le test de la description", 12, false, 2, null));

            }
            con.Close();
            return listClasse;
        }
    }

}
