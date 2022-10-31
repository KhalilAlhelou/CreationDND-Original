using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCreationDND
{
    public class TestCreationClasse
    {
        Models model;
        Classe classeTest;

        [SetUp]
        public void Setup()
        {
            model = new Models();
            classeTest = new Classe("ClasseTest", "Ceci est une classe test", 5, false, null);
        }

        [Test]
        public void CreationDuClasseAPartirDUneClasseDTO()
        {
            ClasseDTO classDTO = new ClasseDTO("Test", "Test", 1, false, 1, new List<AttributDTO>(), new List<CompetenceDTO>(), 0);
            Classe classe = new Classe(classDTO);

            Assert.AreEqual(classDTO.Nom, classe.nom);
        }

        [Test]
        public void CalculDesPointsDeVieAuNiveau1()
        {
            int modConstitution = 3;
            int pvNiv1 = classeTest.calculerPvAuNiv1(modConstitution);

            Assert.AreEqual(8, pvNiv1);
        }

        [Test]
        public void TestCreationListeAPartirDeBD()
        {
            ObservableCollection<Classe> listeRaces = model.obtenirClasse();
            Assert.IsNotNull(listeRaces);
        }
    }
}
