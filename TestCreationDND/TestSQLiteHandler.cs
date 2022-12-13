using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System;
using System.Linq;
using System.Data.SQLite;

namespace TestCreationDND
{
    public class TestSQLiteHandler
    {
        SQLiteHandler sqliteHandler = new SQLiteHandler();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerifierFichierSQLiteCreer()
        {
            string pathSQLite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
            Assert.IsTrue(File.Exists(pathSQLite));
        }

        [Test]
        public void VerifierFichierInsertionSQLAffecteLaBD()
        {
            int rowsAffected = sqliteHandler.executeInsertionSQL();
            Assert.IsTrue(rowsAffected > 0);
        }

        [Test]
        public void RequeteEtRetourAttributDTOParID()
        {
            AttributDTO attributDTO = new AttributDTO("Expertise", "Au 1er niveau, choisissez deux de vos compétences, ou une de vos compétences et votre compétence en outils de voleur. Votre bonus de compétence est doublé pour tout test d'aptitude que vous effectuez et qui utilise l'une ou l'autre des compétences choisies.");
            AttributDTO attributDTOSQL = sqliteHandler.getAttribut(214);
            Assert.AreEqual(attributDTO, attributDTOSQL);
        }

        [Test]
        public void RequeteEtRetourCompetenceDTOParID()
        {
            CompetenceDTO competenceDTO = new CompetenceDTO(401,"Acrobatie");
            CompetenceDTO competenceDTOSQL = sqliteHandler.getCompetence(401);
            Assert.AreEqual(competenceDTO, competenceDTOSQL);

        }

        [Test]
        public void RequeteEtRetourRaceDTOParID()
        {
            RaceDTO raceDTO = new RaceDTO(110, "Sangdragon", "Les Draconiques ressemblent beaucoup à des dragons se tenant debout sous une forme humanoïde, bien qu'ils n'aient ni ailes ni queue.", 2, 0, 0, 0, 0, 1);
            RaceDTO raceDTOSQL = sqliteHandler.getRace(110);
            Assert.AreEqual(raceDTO, raceDTOSQL);
        }

        [Test]
        public void VerifierTailleDeListeRequeteGetAllRaceDTO()
        {
            List<RaceDTO> listRace = sqliteHandler.getAllRace();
            Assert.AreEqual(14, listRace.Count);
        }

        [Test]
        public void VerifierTailleDeListeRequeteGetAllCompetenceDTO()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getAllCompetences();
            Assert.AreEqual(18, listCompetence.Count);
        }

        [Test]
        public void VerifierTailleDeListeRequeteGetAllClasseDTO()
        {
            List<ClasseDTO> listClasse = sqliteHandler.getAllClasse();
            Assert.AreEqual(12, listClasse.Count);
        }

        [Test]
        public void VerifierTailleDeListeRequeteGetAllCompetenceDTOPourClassID()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(18, listCompetence.Count);
        }

        [Test]
        public void VerifierCompetencDTOeDeListeRequeteGetAllCompetenceDTOPourClassID()
        {
            CompetenceDTO competenceDTO = new CompetenceDTO(401, "Acrobatie");
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(competenceDTO, listCompetence[0]);
        }

        [Test]
        public void VerifierTailleDeListeRequeteGetAllAttributDTOPourClassID()
        {
            List<AttributDTO> listCompetence = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(2, listCompetence.Count);
        }
        [Test]
        public void VerifierAttributDTODeListeRequeteGetAllAttributDTOPourClassID()
        {
            AttributDTO attributDTO = new AttributDTO("Inspiration bardique", "Vous pouvez inspirer les autres par des paroles ou de la musique émouvantes. Pour ce faire, vous utilisez une action bonus à votre tour pour choisir une créature autre que vous-même dans un rayon de 60 pieds de vous et qui peut vous entendre. Cette créature gagne un dé d'inspiration bardique, un d6.");
            List <AttributDTO> listAttribut = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(attributDTO, listAttribut[1]);
        }

        [Test]
        public void VerifierZeroDuplicationListeAttributsDeRaces()
        {
            List<AttributDTO> listAttribut = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(listAttribut.Count, listAttribut.Distinct().Count());
            listAttribut[0] = listAttribut[1];
            Assert.AreNotEqual(listAttribut.Count, listAttribut.Distinct().Count());
        }

        [Test]
        public void VerifierZeroDuplicationListeCompetencesDeRaces()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(listCompetence.Count, listCompetence.Distinct().Count());
            listCompetence[0] = listCompetence[1];
            Assert.AreNotEqual(listCompetence.Count, listCompetence.Distinct().Count());
        }

        [Test]
        public void VerifierZeroDuplicationListeDeCompetences()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getAllCompetences();
            Assert.AreEqual(listCompetence.Count, listCompetence.Distinct().Count());
            listCompetence[0] = listCompetence[1];
            Assert.AreNotEqual(listCompetence.Count, listCompetence.Distinct().Count());
        }

        [Test]
        public void VerifierZeroDuplicationListeDeRaces()
        {
            List<RaceDTO> listRace = sqliteHandler.getAllRace();
            Assert.AreEqual(listRace.Count, listRace.Distinct().Count());
            listRace[0] = listRace[1];
            Assert.AreNotEqual(listRace.Count, listRace.Distinct().Count());
        }

        [Test]
        public void VerifierZeroDuplicationListeDeClasses()
        {
            List<ClasseDTO> listClasse= sqliteHandler.getAllClasse();
            Assert.AreEqual(listClasse.Count, listClasse.Distinct().Count());
            listClasse[0] = listClasse[1];
            Assert.AreNotEqual(listClasse.Count, listClasse.Distinct().Count());
        }

        [Test]
        public void VerifierGetEquipmentFromID()
        {
            ArmureDTO armureDTO = new ArmureDTO("Armure Matelassée", 11, true, false, false);
            Assert.AreEqual(armureDTO, sqliteHandler.getEquipmentFromID(601, "armor"));

            ArmeDTO armeDTO = new ArmeDTO("Bâton","1d6");
            Assert.AreEqual(armeDTO, sqliteHandler.getEquipmentFromID(701, "weapon"));

            EquipementDTO instrumentDTO = new EquipementDTO("Chalemie");
            Assert.AreEqual(instrumentDTO, sqliteHandler.getEquipmentFromID(1, "instrument"));

            EquipementDTO equipementDTO  = new EquipementDTO("Un paquetage d'explorateur");
            Assert.AreEqual(equipementDTO, sqliteHandler.getEquipmentFromID(101, "equipment"));
        }

        [Test]
        public void VerifierSQLQueryListEquipment()
        {
            string testQuery = "SELECT * FROM choice_weapon WHERE choiceID = @temp";
            Assert.AreEqual(testQuery, sqliteHandler.getCorrectEquipmentQuery("weapon",false));
        }

        [Test]
        public void VerifierGetEquipmentChoice()
        {
            List<EquipementDTO> listChoice = new List<EquipementDTO>();
            listChoice.Add(new ArmureDTO("Armure de Cuir", 11, true, false, false));
            Assert.AreEqual(listChoice, sqliteHandler.getEquipmentChoice(11,"armor"));
        }
        [Test]
        public void VerifierGetClassOptionChoices()
        {
            int testChoiceCollectionCount = 2;
            Assert.AreEqual(testChoiceCollectionCount, sqliteHandler.getClassOptionChoices(1).Count);
        }

        [Test]
        public void VerifierZeroDuplicationGetClassOptionChoices()
        {
            int testChoiceCollectionCount = 2;
            Assert.AreEqual(testChoiceCollectionCount, sqliteHandler.getClassOptionChoices(1).Count);
        }

        [Test]
        public void VerifierGetAllFromChoiceCollection()
        {
            int testChoiceCollectionCount = 1;
            Assert.AreEqual(testChoiceCollectionCount, sqliteHandler.getAllFromChoiceCollection(1).Count);
        }

        [Test]
        public void VerifierGetItemFromGroup()
        {
            int testChoiceCollectionCount = 10;
            Assert.AreEqual(testChoiceCollectionCount, sqliteHandler.getItemFromGroup(901,"weapon").Count);
        }

        [Test]
        public void VerifierZeroDuplicationGetItemFromGroup()
        {
            List<EquipementDTO> listEquipement = sqliteHandler.getItemFromGroup(901, "weapon");
            Assert.AreEqual(listEquipement.Count, listEquipement.Distinct().Count());
            listEquipement[0] = listEquipement[1];
            Assert.AreNotEqual(listEquipement.Count, listEquipement.Distinct().Count());
        }

        [Test]
        public void VerifierGetGroupQuery()
        {
            string testQuery = "SELECT a.* FROM armor a, armor_armortype b WHERE b.atID = @temp AND a.armorID = b.armorID ORDER BY a.armorName ASC";
            Assert.AreEqual(testQuery, sqliteHandler.getGroupQuery("armor"));
        }
    }
}
