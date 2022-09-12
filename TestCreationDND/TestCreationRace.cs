using NUnit.Framework;
using CreationDND;

namespace TestCreationDND
{
    public class Tests
    {
        
        private RaceDTO raceDTO;
        private Race race;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestCreationObjetRaceDTO()
        {
            raceDTO = new RaceDTO(1,"Test", "DescTest", 1, 1, 1, 1, 1, 1);
            Assert.IsNotNull(raceDTO);
        }

        [Test]
        public void TestCreationObjectRaceAPartirDeRaceDTO()
        {
            raceDTO = new RaceDTO(1, "Test", "DescTest", 1, 1, 1, 1, 1, 1);
            race = new Race(raceDTO);
            Assert.IsTrue(race.comparerRaceARaceDTO(raceDTO));
        }
    }
}