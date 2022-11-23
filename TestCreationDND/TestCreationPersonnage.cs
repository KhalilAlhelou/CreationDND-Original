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

        [Test]
        public void AjouterUneArmureDansInventaireEtEquiperArmure()
        {
            Armure armure = new Armure("Armure de cuir", 11, true, false); 
            Race race = new Race("Elfe", "test", 1, 1, 1, 1, 1, 1);
            Classe classe = new Classe("Mage", "Test", 4, true, null);
            Personnage personnage = new Personnage("Bobby", race, classe, 15, 10, 12, 18, 8, 17, null);
            personnage.ajouterEquipement(armure);
            Assert.AreEqual(armure, personnage.armurePortee);

        }

    }
}
