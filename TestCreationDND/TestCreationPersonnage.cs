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
            Race race = new Race(new RaceDTO(1, "test", "descTest", 12, 12, 12, 12, 12, 12));
            Personnage perso = new Personnage(race);
            Assert.AreEqual(1, perso.modCharisme);
        }

        
    }
}
