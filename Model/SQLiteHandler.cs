///
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class SQLiteHandler
    {
        string pathScriptSQL;
        string pathSQLite;

        /// <summary>
        /// Constructeur de la classe SQLiteHandler qui initialise les variables globales et commence l'initialisation de la BD.
        /// </summary>
        public SQLiteHandler()
        {
            pathSQLite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
            pathScriptSQL = "Data Source=" + pathSQLite + ";Version=3;";
            initializeDB();
        }

        /// <summary>
        /// Fonction pour initialiser la BD. Verifie si elle existe, si oui, elle execute le script d'insertion.
        /// Si le fichier/repertoire n'existe pas, elle creer le repertoire (.../My Documents/.CreationDND/) et le fichier (dbCharacter.sqlite) pour ensuite rouler le script d'insertion.
        /// </summary>
        public void initializeDB()
        {
            if (!File.Exists(pathSQLite))
            {
                createFileDirectory();
            }
            executeInsertionSQL();
        }

        /// <summary>
        /// Fonction qui creer le repertoire et le fichier dbCharacter.sqlite.
        /// </summary>
        public void createFileDirectory()
        {
            DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/");
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            SQLiteConnection.CreateFile(pathSQLite);
        }

        /// <summary>
        /// Fonction pour lire et executer le script d'insertion SQL.
        /// </summary>
        /// <returns>int: Number of rows affected by sql insertion (utiliser pour les tests seulement)</returns>
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

        /** -- DEPRICATED -- USE FOR TESTING ONLY -- INSECURE
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

        /// <summary>
        /// Retourne un objet RaceDTO selon le ID d'une race.
        /// </summary>
        /// <param name="raceID"></param>
        /// <returns>RaceDTO: Objet RaceDTO</returns>
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

                return new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3),
                    rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8));
            }

            return null;
        }

        /// <summary>
        /// Retourne une liste de toutes les races en objet RaceDTO.
        /// </summary>
        /// <returns>List<RaceDTO>: Liste de RaceDTO</returns>
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
                listRace.Add(new RaceDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3),
                    rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8)));
            }

            con.Close();
            return listRace;
        }

        /// <summary>
        /// Retourne une liste de toutes les classes en objet ClasseDTO.
        /// </summary>
        /// <returns>List<ClasseDTO>: Liste de ClassDTO</returns>
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
                listClasse.Add(new ClasseDTO(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetBoolean(4),
                    rdr.GetInt32(5), listAttribut, listProficiencies, rdr.GetInt32(6), 0, listChoice));

            }

            con.Close();
            return listClasse;
        }

        /// <summary>
        /// Retourne une liste de CompetenceDTO pour une classe selon son ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns>List<CompetenceDTO>: Liste d'objet CompetenceDTO</returns>
        public List<CompetenceDTO> getClassCompetences(int classID)
        {
            List<CompetenceDTO> listProficiencies = new List<CompetenceDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT a.pID, a.pName FROM proficiency a, class_proficiency b WHERE b.idC = @classID AND b.pID = a.pID ORDER BY a.pName ASC";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@classID", classID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listProficiencies.Add(new CompetenceDTO(rdr.GetInt32(0), rdr.GetString(1)));
            }

            con.Close();
            return listProficiencies;
        }

        /// <summary>
        /// Retourne une liste d'AttributDTO pour une classe selon son ID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns>List<AttributDTO>: List d'object AttributDTO</returns>
        public List<AttributDTO> getClassAttributes(int classID)
        {
            List<AttributDTO> listAttribut = new List<AttributDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT a.nameAttr, a.descAttr FROM attribute a, class_attribute b WHERE b.idC = @classID AND b.idAttr = a.idAttr ORDER BY a.nameAttr ASC";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@classID", classID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listAttribut.Add(new AttributDTO(rdr.GetString(0), rdr.GetString(1)));
            }

            con.Close();
            return listAttribut;
        }

        /// <summary>
        /// Retourne un object AttributDTO selon son ID
        /// </summary>
        /// <param name="attrID"></param>
        /// <returns>AttributDTO: Object AttributDTO</returns>
        public AttributDTO getAttribut(int attrID)
        {
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM attribute WHERE idAttr = @attrID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@attrID", attrID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new AttributDTO(rdr.GetString(1), rdr.GetString(2));
            }

            return null;
        }

        /// <summary>
        /// Retourne une competence selon son ID.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns>CompetenceDTO: Objet CompetenceDTO</returns>
        public CompetenceDTO getCompetence(int pID)
        {
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT * FROM proficiency WHERE pID = @pID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@pID", pID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return new CompetenceDTO(rdr.GetInt32(0), rdr.GetString(1));
            }

            return null;
        }

        /// <summary>
        /// Retourne une liste de toutes les competences.
        /// </summary>
        /// <returns>List<CompetenceDTO>: Liste d'objet CompetenceDTO</returns>
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

        /// <summary>
        /// Retourne une liste d'options qui a plusieurs listes de choix de plusieurs liste d'equipement pour une classe.
        /// Par exemple, Choix 1 =  A), B) et C), Choix 2 = A) et B).
        /// Un choix peut avoir plusieurs options. Une option peut avoir plusieurs choix elle-meme.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns>List<List<List<EquipementDTO>>>: Une liste d'option qui elle contient plusieurs choix</returns>
        public List<List<List<EquipementDTO>>> getClassChoices(int classID)
        {
            List<List<List<EquipementDTO>>> listChoiceCollection = new List<List<List<EquipementDTO>>>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceCollectionID FROM class_choiceCollection WHERE idC = @classID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@classID", classID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoiceCollection.Add(getClassOptionChoices(rdr.GetInt32(0)));
            }

            con.Close();
            return listChoiceCollection;
        }

        /// <summary>
        /// Retourne une liste de plusieurs liste d'equipement pour une collection de choix.
        /// Par exemple, les options A), B) et C) d'un choix a faire.
        /// Une option peut avoir plusieurs choix elle-meme.
        /// </summary>
        /// <param name="choiceCollectionID"></param>
        /// <returns>List<List<EquipementDTO>>: Une liste de plusieurs liste d'equipement</returns>
        public List<List<EquipementDTO>> getClassOptionChoices(int choiceCollectionID)
        {
            List<List<EquipementDTO>> listChoiceCollection = new List<List<EquipementDTO>>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = "SELECT choiceID FROM choice_choiceCollection WHERE choiceCollectionID = @choiceCollectionID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@choiceCollectionID", choiceCollectionID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoiceCollection.Add(getAllFromChoiceCollection(rdr.GetInt32(0)));
            }

            con.Close();
            return listChoiceCollection;
        }

        /// <summary>
        /// Retourne une liste d'equipement selon tout les types pour un choix.
        /// </summary>
        /// <param name="choiceID"></param>
        /// <returns>List<EquipementDTO>: List d'equipement</returns>
        public List<EquipementDTO> getAllFromChoiceCollection(int choiceID)
        {
            List<string> equipmentTypes = new List<string> {"armor", "instrument", "equipment", "weapon","weapontype","armortype","instrumenttype"};
            List<EquipementDTO> listChoice = new List<EquipementDTO>();

            foreach (string type in equipmentTypes)
            {
                listChoice.AddRange(getEquipmentChoice(choiceID, type));
            }
            return listChoice;
        }

        /// <summary>
        /// Retourne une liste d'equipement selon un type et un choiceID.
        /// </summary>
        /// <param name="choiceID"></param>
        /// <param name="type"></param>
        /// <returns>List<EquipementDTO>: List d'equipement</returns>
        public List<EquipementDTO> getEquipmentChoice(int choiceID, string type)
        {
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = getCorrectEquipmentQuery(type, false);
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@temp", choiceID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listChoice.Add(getEquipmentFromID(rdr.GetInt32(1), type));
            }

            con.Close();
            return listChoice;
        }

        /// <summary>
        /// FONCTION NECESSAIRE. NE PAS MODIFIER. Elle sert a retourner les querys necessaires tout en restant proteger aux
        /// attaques SQL injections. Type fait reference au type d'equipement rechercher, et fromID veut dire que l'on cherche un equipement selon son ID.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fromID"></param>
        /// <returns>string: SQL Query</returns>
        public string getCorrectEquipmentQuery(string type,bool fromID)
        {
            if (type == "armor")
            {
                if (fromID)
                {
                    return "SELECT * FROM armor WHERE armorID = @temp"; ;
                }
                else {
                    return "SELECT * FROM choice_armor WHERE choiceID = @temp";
                }
            }
            else if (type == "weapon")
            {
                if (fromID)
                {
                    return "SELECT * FROM weapon WHERE weaponID = @temp"; 
                }
                else {
                    return "SELECT * FROM choice_weapon WHERE choiceID = @temp";
                }
            }
            else if (type == "instrument")
            {
                if (fromID)
                {
                    return "SELECT * FROM instrument WHERE instrumentID = @temp"; ;
                }
                else {
                    return "SELECT * FROM choice_instrument WHERE choiceID = @temp";
                }
            }
            else if (type == "equipment")
            {
                if (fromID)
                {
                    return "SELECT * FROM equipment WHERE equipmentID = @temp"; ;
                }
                else { 
                    return "SELECT * FROM choice_equipment WHERE choiceID = @temp";
                }
            }
            else if (type == "weapontype")
            {
                if (fromID)
                {
                    return "SELECT * FROM weapontype WHERE wtID = @temp"; ;
                }
                else
                {
                    return "SELECT * FROM choice_weapontype WHERE choiceID = @temp";
                }
            }
            else if (type == "armortype")
            {
                if (fromID)
                {
                    return "SELECT * FROM armortype WHERE atID = @temp"; 
                }
                else
                {
                    return "SELECT * FROM choice_armortype WHERE choiceID = @temp";
                }
            }
            else if (type == "instrumenttype")
            {
                if (fromID)
                {
                    return "SELECT * FROM instrumenttype WHERE itID = @temp"; 
                }
                else
                {
                    return "SELECT * FROM choice_instrumenttype WHERE choiceID = @temp";
                }
            }
            return null;
        }

        /// <summary>
        /// Methode qui retourne un objet du bon type selon le equipementID et son type.
        /// </summary>
        /// <param name="equipmentID"></param>
        /// <param name="type"></param>
        /// <returns>EquipementDTO: Objet equipement necessaire</returns>
        public EquipementDTO getEquipmentFromID(int equipmentID, string type)
        {
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = getCorrectEquipmentQuery(type, true);
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@temp", equipmentID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return getCorrectEquipment(rdr, type);
            }

            con.Close();
            return null;
        }
        /// <summary>
        /// Methode qui prend une ligne SQL et un type pour creer un equipement du bon type. 
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="type"></param>
        /// <returns>EquipementDTO: Objet Equipement necessaire</returns>
        public EquipementDTO getCorrectEquipment(SQLiteDataReader rdr, string type)
        {
            if (type == "armor")
            {
                bool limitedDex = false;
                if (rdr.GetInt32(3) >= 2)
                {
                    limitedDex = true;
                }

                return new ArmureDTO(rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetInt32(3)),
                    limitedDex, Convert.ToBoolean(rdr.GetInt32(6)));
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
            else if (type == "armortype" || type == "weapontype"|| type == "instrumenttype")
            {
                return new GroupeDTO(rdr.GetString(1), type.Remove(type.Length - 4, 4) , rdr.GetInt32(0));
            }
            return null;
        }

        /// <summary>
        /// Methode qui retourne une liste EquipementDTO d'un groupe selon le groupID et son type d'equipement.
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="type"></param>
        /// <returns>List<EquipementDTO>: Une liste d'equipment d'un groupe</returns>
        public List<EquipementDTO> getItemFromGroup(int groupID, string type)
        {
            List<EquipementDTO> listItem = new List<EquipementDTO>();
            using var con = new SQLiteConnection(pathScriptSQL);
            con.Open();

            string stm = getGroupQuery(type);
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@temp", groupID);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listItem.Add(getCorrectEquipment(rdr, type));
            }

            con.Close();
            return listItem;
        }

        /// <summary>
        ///  Methode qui retourne un "query" SQL pour un select multiple selon le type donner.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>string: query SQL</returns>
        public string getGroupQuery(string type)
        {
            if (type == "armor")
            {
                return "SELECT a.* FROM armor a, armor_armortype b WHERE b.atID = @temp AND a.armorID = b.armorID ORDER BY a.armorName ASC";
            
            }
            else if (type == "weapon")
            {
                return "SELECT a.* FROM weapon a, weapon_weapontype b WHERE b.wtID = @temp AND a.weaponID = b.weaponID ORDER BY a.weaponName ASC";
            }
            else if (type == "instrument")
            {
                return "SELECT a.* FROM instrument a, instrument_instrumenttype b WHERE b.itID = @temp AND a.instrumentID = b.instrumentID ORDER BY a.instrumentName ASC";
            }
            return null;
        }
    }
}
