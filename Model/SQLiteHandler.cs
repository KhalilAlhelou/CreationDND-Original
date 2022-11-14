
using System.Data.SQLite;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class SQLiteHandler
    {
        string pathScriptSQL;
        string pathSQLite;
        public SQLiteHandler()
        {
            pathSQLite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
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
        public void createFileDirectory()
        {
            DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/");
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            //Debug.WriteLine("DB is being created");
            SQLiteConnection.CreateFile(pathSQLite);
        }
        public int executeInsertionSQL()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(pathScriptSQL);
            string insertionRaceContents = File.ReadAllText("insertionScript.sql");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(insertionRaceContents, m_dbConnection);
            int rowsAffected = command.ExecuteNonQuery();
            Debug.WriteLine(rowsAffected);
            m_dbConnection.Close();
            return rowsAffected;
        }


/** -- DEPRICATED -- USE FOR TESTING ONLY --
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
**/
        public RaceDTO getRace(int raceID)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM race WHERE idR ='" + raceID + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
               

                    return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
                
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
        
        public List<ClasseDTO> getAllClasse()
        {
            List<ClasseDTO> listClasse = new List<ClasseDTO>();
           
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM class";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                List<AttributDTO> listAttribut = getClassAttributes(rdr.GetInt32(0));
                
                List<CompetenceDTO> listProficiencies = getClassCompetences(rdr.GetInt32(0));
                List<List<List<EquipementDTO>>> listChoice = getClassChoices(rdr.GetInt32(0));
   

                listClasse.Add(new ClasseDTO(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetBoolean(4), rdr.GetInt32(5), listAttribut, listProficiencies, rdr.GetInt32(6), 0, listChoice));

            }
            con.Close();
            return listClasse;
        }

        private List<List<List<EquipementDTO>>> getClassChoices(int v)
        {
            List<List<List<EquipementDTO>>> listChoiceCollection = new List<List<List<EquipementDTO>>>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceCollectionID FROM class_choiceCollection WHERE idC ='" + v + "'";
            
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoiceCollection.Add(getClassOptionChoices(rdr.GetInt32(0)));
            }
            con.Close();

            return listChoiceCollection;
        }

        private List<List<EquipementDTO>> getClassOptionChoices(int v)
        {

            List<List<EquipementDTO>> listChoiceCollection = new List<List<EquipementDTO>>();
            
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceID FROM choice_choiceCollection WHERE choiceCollectionID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                List<EquipementDTO> listChoice = new List<EquipementDTO>();
                listChoice.AddRange(getWeaponChoice(rdr.GetInt32(0)));
                listChoice.AddRange(getEquipmentChoice(rdr.GetInt32(0)));
                listChoice.AddRange(getInstrumentChoice(rdr.GetInt32(0)));
                //listChoice.AddRange(getArmorChoice(rdr.GetInt32(0)));
                listChoiceCollection.Add(listChoice);
            }
            con.Close();
            return listChoiceCollection;
        }

        public List<EquipementDTO> getInstrumentChoice(int v)
        {
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT instrumentID FROM choice_instrument WHERE choiceID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoice.Add(getInstrumentFromID(rdr.GetInt32(0)));
            }
            con.Close();

            return listChoice;


        }

        //INSTRUMENTDTO?
        private EquipementDTO getInstrumentFromID(int v)
        {
            EquipementDTO equipementDTO;

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT instrumentName FROM instrument WHERE instrumentID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                equipementDTO = new EquipementDTO(rdr.GetString(0));
                return equipementDTO;
            }
            con.Close();
            return null;
        }
        public List<EquipementDTO> getEquipmentChoice(int v)
        {
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT equipmentID FROM choice_equipment WHERE choiceID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoice.Add(getEquipmentFromID(rdr.GetInt32(0)));
            }
            con.Close();

            return listChoice;


        }

        private EquipementDTO getEquipmentFromID(int v)
        {
            EquipementDTO equipementDTO;

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT equipmentName FROM equipment WHERE equipmentID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                equipementDTO = new EquipementDTO(rdr.GetString(0));
                return equipementDTO;
            }
            con.Close();
            return null;
        }







        public List<ArmeDTO> getWeaponChoice(int v)
        {
            List<ArmeDTO> listChoice = new List<ArmeDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT weaponID FROM choice_weapon WHERE choiceID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoice.Add(getWeaponFromID(rdr.GetInt32(0))); 
            }
            con.Close();

            return listChoice;


        }

        private ArmeDTO getWeaponFromID(int v)
        {
            ArmeDTO armeDTO;

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM weapon WHERE weaponID ='" + v + "'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                armeDTO = new ArmeDTO(rdr.GetString(1),rdr.GetString(2));
                return armeDTO;
            }
            con.Close();
            return null;
        }

        public List<CompetenceDTO> getClassCompetences(int classID)
        {
            List<CompetenceDTO> listProficiencies = new List<CompetenceDTO>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT a.pID, a.pName FROM proficiency a, class_proficiency b WHERE b.idC =" + classID + " AND b.pID = a.pID ORDER BY a.pName ASC";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listProficiencies.Add(new CompetenceDTO(rdr.GetInt32(0), rdr.GetString(1)));

            }
            con.Close();


            return listProficiencies;
        }

        public List<AttributDTO> getClassAttributes(int classID)
        {
            List<AttributDTO> listAttribut = new List<AttributDTO>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT a.nameAttr, a.descAttr FROM attribute a, class_attribute b WHERE b.idC =" + classID + " AND b.idAttr = a.idAttr ORDER BY a.nameAttr ASC";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listAttribut.Add(new AttributDTO(rdr.GetString(0), rdr.GetString(1)));
            }
            con.Close();

            return listAttribut;
        }

        public AttributDTO getAttribut(int attrID)
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
     
        public CompetenceDTO getCompetence(int pID)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency WHERE pID ='" + pID + "'";

            using var cmd = new SQLiteCommand(stm, con); 
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new CompetenceDTO(rdr.GetInt32(0), rdr.GetString(1));

            }

            return null;
        }

        
        public List<CompetenceDTO> getAllCompetences()
        {
            List<CompetenceDTO> listProficiencies = new List<CompetenceDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                listProficiencies.Add(new CompetenceDTO(rdr.GetInt32(0), rdr.GetString(1)));

            }
            con.Close();
            return listProficiencies;
        }
       
    }

}
