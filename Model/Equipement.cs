using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Equipement
    {
        public string nom { get; set; }

        public Equipement(string nom)
        {
            this.nom = nom;
        }
    }
}
