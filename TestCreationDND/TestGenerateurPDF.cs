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
            Race race = new Race("Elfe", "test", 1, 1, 1, 1, 1, 1);
            Classe classe = new Classe("Mage", "Test", 4, true, null);
            Personnage personnage = new Personnage("Bobby", race, classe, 15, 10, 12, 18, 8, 17);
            
            models.GenererFichePersonnagePDF(personnage, true);
            Assert.Pass();
        }
    }
}
