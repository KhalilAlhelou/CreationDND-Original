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
            List<Attribut> attributs = new List<Attribut>();

            attributs.Add(new Attribut("A1", "Desc1"));
            attributs.Add(new Attribut("A2", "Desc2"));

            Race race = new Race("Elfe", "test", 1, 1, 1, 1, 1, 1);
            Classe classe = new Classe("Mage", "Test", 4, true, attributs);
            List<Competence> competence = new List<Competence>();
            competence.Add(new Competence(1, "Test"));

            model.ajouterLaRace(race);
            model.ajouterLaClasse(classe);
            model.ajouterLesCompetencesMaitrises(competence);

            ObservableCollection<Personnage> personnages = model.obtenirPersonnagesExistants();

            Assert.AreEqual(race.nom, personnages[personnages.Count - 1].race.nom);


        }
    }
}
