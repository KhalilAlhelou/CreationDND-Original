using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Classe
    {
        public string nom { get; private set; }
        public string description { get; private set; }
        public int pvNiveau1 { get; private set; }
        public bool estLanceurSort { get; private set; }
        public List<Attribut> listeAttributs { get; private set; }
        public List<Competence> competencesMaitrisable { get; private set; }
        public int nombreDeCompetencesMaitrisable { get; private set; }


        public Classe (ClassDTO classeDTO)
        {
            this.nom = classeDTO.Nom;
            this.description = classeDTO.Description;
            this.pvNiveau1 = classeDTO.HpLvl1;
            this.estLanceurSort = classeDTO.SpellCaster;
            this.listeAttributs = creerListeAttributs(classeDTO.ListeAttributs);
            this.competencesMaitrisable = creerListeComptepenceMaitrisable(classeDTO.competencesMaitrisable);
            this.nombreDeCompetencesMaitrisable = classeDTO.nombreDeCompetencesMaitrisable;
            
        }

        private List<Competence> creerListeComptepenceMaitrisable(List<ProficiencyDTO> competencesMaitrisable)
        {
            List<Competence> result = new List<Competence>();
            foreach (ProficiencyDTO proficiencyDTO in competencesMaitrisable)
            {
                result.Add(new Competence(proficiencyDTO));
            }

            return result;
        }

        private List<Attribut> creerListeAttributs(List<AttributDTO> listeAttributs)
        {
            List<Attribut> result = new List<Attribut>();
            foreach (AttributDTO attributDTO in listeAttributs)
            {
                result.Add(new Attribut(attributDTO));
            }

            return result;
        }

        public Classe(string nom, string description, int pvNiveau1, bool estLanceurSort, List<Attribut> listeAttributs)
        {
            this.nom = nom;
            this.description = description;
            this.pvNiveau1 = pvNiveau1;
            this.estLanceurSort = estLanceurSort;
            this.listeAttributs = listeAttributs;
        }

        public int calculerPvAuNiv1(int modConstitution)
        {
            return modConstitution + this.pvNiveau1;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
