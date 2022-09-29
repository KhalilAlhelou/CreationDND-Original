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
        private string nom;
        private string description;
        private int pvNiveau1;
        private bool estLanceurSort;
        private List<Attribut> listeAttributs;

        public Classe (ClasseDTO classeDTO)
        {
            
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
