using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCreationDND
{

    public class Tests
    {
        private Models model;
        private RaceDTO raceDTO;
        private Race race;

        [SetUp]
        public void Setup()
        {
            model = new Models();
        }

        [Test]
        public void TestCreationObjetRaceDTO()
        {
            raceDTO = new RaceDTO(1, "Test", "DescTest", 1, 1, 1, 1, 1, 1);
            Assert.IsNotNull(raceDTO);
        }

        [Test]
        public void TestCreationObjectRaceAPartirDeRaceDTO()
        {
            raceDTO = new RaceDTO(1, "Test", "DescTest", 1, 1, 1, 1, 1, 1);
            race = new Race(raceDTO);
            Assert.IsTrue(race.comparerARaceDTO(raceDTO));
        }

        [Test]
        public void TestCreationListeAPartirDeBD()
        {
            ObservableCollection<Race> listeRaces = model.obtenirRaces();
            Assert.IsNotNull(listeRaces);
        }
    }
}