
using System.Data.SQLite;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.CompilerServices;
using System.Data;

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


            SQLiteConnection.CreateFile(pathSQLite);
        }
        public int executeInsertionSQL()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(pathScriptSQL);
            string insertionRaceContents = File.ReadAllText("insertionScript.sql");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(insertionRaceContents, m_dbConnection);
            int rowsAffected = command.ExecuteNonQuery();

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

            string stm = "SELECT * FROM race WHERE idR = @raceid";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@raceid", raceID);
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

        public List<CompetenceDTO> getClassCompetences(int classID)
        {
            List<CompetenceDTO> listProficiencies = new List<CompetenceDTO>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT a.pID, a.pName FROM proficiency a, class_proficiency b WHERE b.idC = @v AND b.pID = a.pID ORDER BY a.pName ASC";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", classID);
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

            string stm = "SELECT a.nameAttr, a.descAttr FROM attribute a, class_attribute b WHERE b.idC = @v AND b.idAttr = a.idAttr ORDER BY a.nameAttr ASC";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", classID);
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

            string stm = "SELECT * FROM attribute WHERE idAttr = @v";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", attrID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new AttributDTO(rdr.GetString(1), rdr.GetString(2));

            }

            return null;
        }

        // refractor this //
        public CompetenceDTO getCompetence(int pID)
        {

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency WHERE pID = @v";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", pID);
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

        public List<List<List<EquipementDTO>>> getClassChoices(int classID)
        {
            List<List<List<EquipementDTO>>> listChoiceCollection = new List<List<List<EquipementDTO>>>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceCollectionID FROM class_choiceCollection WHERE idC = @idC";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@idC", classID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listChoiceCollection.Add(getClassOptionChoices(rdr.GetInt32(0)));
            }
            con.Close();

            return listChoiceCollection;
        }

        public List<List<EquipementDTO>> getClassOptionChoices(int choiceCollectionID)
        {

            List<List<EquipementDTO>> listChoiceCollection = new List<List<EquipementDTO>>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceID FROM choice_choiceCollection WHERE choiceCollectionID = @v";

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", choiceCollectionID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoiceCollection.Add(getAllFromChoiceCollection(rdr.GetInt32(0)));
            }
            con.Close();
            return listChoiceCollection;
        }

        public List<EquipementDTO> getAllFromChoiceCollection(int choiceID)
        {
            List<string> equipmentTypes = new List<string> { "armor", "instrument", "equipment", "weapon","weapontype","armortype"};
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            foreach (string type in equipmentTypes)
            {
                listChoice.AddRange(getEquipmentChoice(choiceID, type));
            }
            return listChoice;
        }

        public List<EquipementDTO> getEquipmentChoice(int choiceID, string type)
        {
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = getCorrectEquipmentQuery(type, false);
            using var cmd = new SQLiteCommand(stm, con);

            cmd.Parameters.AddWithValue("@v", choiceID);


            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoice.Add(getEquipmentFromID(rdr.GetInt32(1), type));
            }
            con.Close();

            return listChoice;


        }

        public string getCorrectEquipmentQuery(string type,bool fromID)
        {
            if (type == "armor")
            {
                if (fromID)
                {
                    return "SELECT * FROM armor WHERE armorID = @v"; ;
                }
                else {
                    return "SELECT * FROM choice_armor WHERE choiceID = @v";
                }
              
            }
            else if (type == "weapon")
            {
                if (fromID)
                {
                    return "SELECT * FROM weapon WHERE weaponID = @v"; 
                }
                else {
                    return "SELECT * FROM choice_weapon WHERE choiceID = @v";
                }
                
            }
            else if (type == "instrument")
            {
                if (fromID)
                {
                    return "SELECT * FROM instrument WHERE instrumentID = @v"; ;
                }
                else {
                    return "SELECT * FROM choice_instrument WHERE choiceID = @v";
                }
            }
            else if (type == "equipment")
            {
                if (fromID)
                {
                    return "SELECT * FROM equipment WHERE equipmentID = @v"; ;
                }
                else { 
                    return "SELECT * FROM choice_equipment WHERE choiceID = @v";
                }

            }
            else if (type == "weapontype")
            {
                if (fromID)
                {
                    return "SELECT * FROM weapontype WHERE wtID = @v"; ;
                }
                else
                {
                    return "SELECT * FROM choice_weapontype WHERE choiceID = @v";
                }

            }
            else if (type == "armortype")
            {
                if (fromID)
                {
                    return "SELECT * FROM armortype WHERE atID = @v"; 
                }
                else
                {
                    return "SELECT * FROM choice_armortype WHERE choiceID = @v";
                }
            }
            return null;
        }

        public EquipementDTO getEquipmentFromID(int equipmentID, string type)
        { 
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = getCorrectEquipmentQuery(type, true); 

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", equipmentID);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return getCorrectEquipment(rdr, type);
            }
            con.Close();
            return null;
        }

        public EquipementDTO getCorrectEquipment(SQLiteDataReader rdr, string type)
        {
            if (type == "armor")
            {
                bool limitedDex = false;
                if (rdr.GetInt32(3) >= 2)
                {
                    limitedDex = true;
                }
                return new ArmureDTO(rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetInt32(3)), limitedDex);
            }
            else if (type == "weapon")
            {
                return new ArmeDTO(rdr.GetString(1), rdr.GetString(2));
            }
            else if (type == "instrument")
            {
                return new EquipementDTO(rdr.GetString(1));
            }
            else if (type == "equipment")
            {
                return new EquipementDTO(rdr.GetString(1));
            }
            else if (type == "armortype" || type == "weapontype")
            {
                return new GroupeDTO(rdr.GetString(1), type, rdr.GetInt32(0));
            }
            return null;
        }

        public List<EquipementDTO> getItemFromGroup(int groupID, string type)
        {
            List<EquipementDTO> listItem = new List<EquipementDTO>();

            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();
            string stm = getGroupQuery(type);

            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@v", groupID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listItem.Add(getCorrectEquipment(rdr, type));
            }
            con.Close();


            return listItem;
        }

        private string getGroupQuery(string type)
        {
          
            if (type == "armortype")
            {
                return "SELECT a.armorName, a.armorClass, a.armorDexState FROM armor a, armor_armortype b WHERE b.atID = @v AND a.armorID = b.armorID ORDER BY a.armorName ASC";
            
            }
            else if (type == "weapontype")
            {
                return "SELECT a.weaponName, a.weaponDice FROM weapon a, weapon_weapontype b WHERE b.wtID = @v AND a.weaponID = b.weaponID ORDER BY a.weaponName ASC";
            }

            return null;
        }
    }
}
