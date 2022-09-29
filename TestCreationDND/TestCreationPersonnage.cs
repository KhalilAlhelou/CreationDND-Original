using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace TestCreationDND
{
    public class TestCreationPersonnage
    {
        private Models model;

        [SetUp]
        public void Setup()
        {
            model = new Models();
        }

        [Test]
        public void CreationDUnPersonnageAPartirDUneRaceEtCalculerLesModificateurs()
        {
            Race race = new Race(new RaceDTO(1, "test", "descTest", 10, 10, 10, 10, 10, 10));
            Personnage perso = new Personnage(race);
            Assert.AreEqual(0, perso.modCharisme);
        }

        
    }
}
