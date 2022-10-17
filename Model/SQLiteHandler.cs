
using System.Data.SQLite;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Cryptography;

namespace Model
{
    public class SQLiteHandler
    {
        string pathScriptSQL;
        string pathSQLite;
        public SQLiteHandler()
        {
            pathSQLite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
            //string path = "Data/dbCharacter.sqlite";
            pathScriptSQL = "Data Source=" + pathSQLite + ";Version=3;";
            initializeDB();

        }
        public void initializeDB()
        {
            if (!File.Exists(pathSQLite))
            {
                createFileDirectory();
            }
            executeInsertionSQL();
        }
        private void createFileDirectory()
        {
            DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/");
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            Debug.WriteLine("DB is being created");
            SQLiteConnection.CreateFile(pathSQLite);
        }
        private void executeInsertionSQL()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(pathScriptSQL);
            string insertionRaceContents = File.ReadAllText("insertionScript.sql");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(insertionRaceContents, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }



        public void showTable(string tableName)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM " + tableName;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            switch (tableName)
            {
                case "race":
                    while (rdr.Read())
                    {
                        Debug.WriteLine(rdr);
                    }
                    break;
            }
        }

        public RaceDTO getRace(string raceName)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
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


        public List<RaceDTO> getAllRace()
        {
            List<RaceDTO> listRace = new List<RaceDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
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
            List<ProficiencyDTO> listProficiencies = new List<ProficiencyDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM class";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                List<AttributDTO> listAttribut = new List<AttributDTO>();

                string[] attributTmp = rdr.GetString(6).Split(';');

                foreach (var attribut in attributTmp)
                {
                    listAttribut.Add(getAttribut(attribut));
                }

                string[] proficiencyTmp = rdr.GetString(7).Split(':');
                int profficiencyAmount = Int32.Parse(proficiencyTmp[0]);

                string[] proficiencyList = proficiencyTmp[1].Split(';');
                if (proficiencyList[0] == "0") {
                    listProficiencies = getAllProficiencies();
                }
                else {
                    foreach (var proficiency in proficiencyList)
                    {
                        listProficiencies.Add(getProficiency(proficiency));
                    }
                }
                listClasse.Add(new ClassDTO(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetBoolean(4), rdr.GetInt32(5), listAttribut, listProficiencies, profficiencyAmount));

            }
            con.Close();
            return listClasse;
        }
        public AttributDTO getAttribut(string attrID)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM attribute WHERE idAttr ='" + attrID + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new AttributDTO(rdr.GetString(1), rdr.GetString(2));

            }

            return null;
        }
       
        public ProficiencyDTO getProficiency(string pID)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency WHERE pID ='" + pID + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new ProficiencyDTO(rdr.GetInt32(0), rdr.GetString(1));

            }

            return null;
        }

        
        public List<ProficiencyDTO> getAllProficiencies()
        {
            List<ProficiencyDTO> listProficiencies = new List<ProficiencyDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                listProficiencies.Add(new ProficiencyDTO(rdr.GetInt32(0), rdr.GetString(1));

            }
            con.Close();
            return listProficiencies;
        }
       
    }

}
