using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace TestCreationDND
{
    public class TestCreationCompetence
    {
        Models model;

        [SetUp]
        public void Setup()
        {
            model = new Models();
            
        }

        [Test]
        public void CreerCompetenceAPartirDeProficiencyDTO()
        {
            ProficiencyDTO proficiencyDTO = new ProficiencyDTO(1, "test");
            Competence competence = new Competence(proficiencyDTO);

            Assert.AreEqual(proficiencyDTO.nom, competence.nom);
        }
    }
}
