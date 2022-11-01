using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class EquipementDTO
    {
        public string nom { get; set; }

        public EquipementDTO(string nom)
        {
            this.nom = nom;
        }
    }
}
