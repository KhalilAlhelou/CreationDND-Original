using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCreationDND
{
    public class TestGenerateurPDF
    {
        private Models models;

        [SetUp]
        public void Setup()
        {
            models = new Models();
        }

        [Test]
        public void TestGenerationFicheDePersonnagePDF()
        {
            List<Attribut> attributs = new List<Attribut>();

            attributs.Add(new Attribut("A1", "Desc1"));
            attributs.Add(new Attribut("A2", "Desc2"));            

            List<Competence> competence = new List<Competence>();
            competence.Add(new Competence(1, "Test"));

            Race race = new Race("Elfe", "test", 1, 1, 1, 1, 1, 1);
            Classe classe = new Classe("Mage", "Test", 4, true, attributs);
            Personnage personnage = new Personnage("Bobby", race, classe, 15, 10, 12, 18, 8, 17, competence);


            models.GenererFichePersonnagePDF(personnage, true);
            Assert.Pass();
        }
    }
}
