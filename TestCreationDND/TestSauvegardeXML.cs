using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCreationDND
{
    public class TestSauvegardeXML
    {
        private Models model;

        [SetUp]
        public void Setup()
        {
            model = new Models();
        }

        [Test]
        public void SauvergarderEtChargerUnPersonnage()
        {
            Race race = new Race("Elfe", "test", 1, 1, 1, 1, 1, 1);
            Classe classe = new Classe("Mage", "Test", 4, true, null);

            model.ajouterLaRace(race);
            model.ajouterLaClasse(classe);

            ObservableCollection<Personnage> personnages = model.obtenirPersonnagesExistants();

            Assert.AreEqual(race.nom, personnages[personnages.Count - 1].race.nom);


        }
    }
}
