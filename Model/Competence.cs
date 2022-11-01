using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Competence
    {
        public int id { get; private set; }
        public string nom { get; private set; }

        public Competence(CompetenceDTO proficiencyDTO)
        {
            id = proficiencyDTO.id;
            nom = proficiencyDTO.nom;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
