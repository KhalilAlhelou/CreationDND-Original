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

        public Classe (ClassDTO classeDTO)
        {
            this.nom = classeDTO.Nom;
            this.description = classeDTO.Description;
            this.pvNiveau1 = classeDTO.HpLvl1;
            this.estLanceurSort = classeDTO.SpellCaster;
            this.listeAttributs = new List<Attribut>();
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
