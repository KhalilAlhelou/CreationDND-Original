using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System;
using System.Linq;

namespace TestCreationDND
{
    public class TestSQLiteHandler
    {
        SQLiteHandler sqliteHandler;

        [SetUp]
        public void Setup()
        {
            sqliteHandler = new SQLiteHandler();
        }

        [Test]
        public void verifierFichierSQLiteCreer()
        {
            string pathSQLite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.CreationDND/dbCharacter.sqlite";
            Assert.IsTrue(File.Exists(pathSQLite));
        }

        [Test]
        public void verifierFichierInsertionSQLAffecteLaBD()
        {
            int rowsAffected = sqliteHandler.executeInsertionSQL();
            Assert.IsTrue(rowsAffected > 0);
        }

        [Test]
        public void requeteEtRetourAttributDTOParID()
        {
            AttributDTO attributDTO = new AttributDTO("Expertise", "Au 1er niveau, choisissez deux de vos compétences, ou une de vos compétences et votre compétence en outils de voleur. Votre bonus de compétence est doublé pour tout test d'aptitude que vous effectuez et qui utilise l'une ou l'autre des compétences choisies.");
            AttributDTO attributDTOSQL = sqliteHandler.getAttribut(214);
            Assert.AreEqual(attributDTO, attributDTOSQL);
        }

        [Test]
        public void requeteEtRetourCompetenceDTOParID()
        {
            CompetenceDTO competenceDTO = new CompetenceDTO(401,"Acrobatie");
            CompetenceDTO competenceDTOSQL = sqliteHandler.getCompetence(401);
            Assert.AreEqual(competenceDTO, competenceDTOSQL);

        }

        [Test]
        public void requeteEtRetourRaceDTOParID()
        {
            RaceDTO raceDTO = new RaceDTO(110, "Sangdragon", "Les Draconiques ressemblent beaucoup à des dragons se tenant debout sous une forme humanoïde, bien qu'ils n'aient ni ailes ni queue.", 2, 0, 0, 0, 0, 1);
            RaceDTO raceDTOSQL = sqliteHandler.getRace(110);
            Assert.AreEqual(raceDTO, raceDTOSQL);
        }

        [Test]
        public void verifierTailleDeListeRequeteGetAllRaceDTO()
        {
            List<RaceDTO> listRace = sqliteHandler.getAllRace();
            Assert.AreEqual(14, listRace.Count);
        }

        [Test]
        public void verifierTailleDeListeRequeteGetAllCompetenceDTO()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getAllCompetences();
            Assert.AreEqual(18, listCompetence.Count);
        }

        [Test]
        public void verifierTailleDeListeRequeteGetAllClasseDTO()
        {
            List<ClasseDTO> listClasse = sqliteHandler.getAllClasse();
            Assert.AreEqual(12, listClasse.Count);
        }

        [Test]
        public void verifierTailleDeListeRequeteGetAllCompetenceDTOPourClassID()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(18, listCompetence.Count);
        }

        [Test]
        public void verifierCompetencDTOeDeListeRequeteGetAllCompetenceDTOPourClassID()
        {
            CompetenceDTO competenceDTO = new CompetenceDTO(401, "Acrobatie");
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(competenceDTO, listCompetence[0]);
        }
        [Test]
        public void verifierTailleDeListeRequeteGetAllAttributDTOPourClassID()
        {
            List<AttributDTO> listCompetence = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(2, listCompetence.Count);
        }
        [Test]
        public void verifierAttributDTODeListeRequeteGetAllAttributDTOPourClassID()
        {
            AttributDTO attributDTO = new AttributDTO("Inspiration bardique", "Vous pouvez inspirer les autres par des paroles ou de la musique émouvantes. Pour ce faire, vous utilisez une action bonus à votre tour pour choisir une créature autre que vous-même dans un rayon de 60 pieds de vous et qui peut vous entendre. Cette créature gagne un dé d'inspiration bardique, un d6.");
            List <AttributDTO> listAttribut = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(attributDTO, listAttribut[0]);
        }

        [Test]
        public void verifierZeroDuplicationListeAttributsDeRaces()
        {
            List<AttributDTO> listAttribut = sqliteHandler.getClassAttributes(302);
            Assert.AreEqual(listAttribut.Count, listAttribut.Distinct().Count());
            listAttribut[0] = listAttribut[1];
            Assert.AreNotEqual(listAttribut.Count, listAttribut.Distinct().Count());
        }
        [Test]
        public void verifierZeroDuplicationListeCompetencesDeRaces()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getClassCompetences(302);
            Assert.AreEqual(listCompetence.Count, listCompetence.Distinct().Count());
            listCompetence[0] = listCompetence[1];
            Assert.AreNotEqual(listCompetence.Count, listCompetence.Distinct().Count());
        }

        [Test]
        public void verifierZeroDuplicationListeDeCompetences()
        {
            List<CompetenceDTO> listCompetence = sqliteHandler.getAllCompetences();
            Assert.AreEqual(listCompetence.Count, listCompetence.Distinct().Count());
            listCompetence[0] = listCompetence[1];
            Assert.AreNotEqual(listCompetence.Count, listCompetence.Distinct().Count());
        }

        [Test]
        public void verifierZeroDuplicationListeDeRaces()
        {
            List<RaceDTO> listRace = sqliteHandler.getAllRace();
            Assert.AreEqual(listRace.Count, listRace.Distinct().Count());
            listRace[0] = listRace[1];
            Assert.AreNotEqual(listRace.Count, listRace.Distinct().Count());
        }

        [Test]
        public void verifierZeroDuplicationListeDeClasses()
        {
            List<ClasseDTO> listClasse= sqliteHandler.getAllClasse();
            Assert.AreEqual(listClasse.Count, listClasse.Distinct().Count());
            listClasse[0] = listClasse[1];
            Assert.AreNotEqual(listClasse.Count, listClasse.Distinct().Count());
        }
    }
}
