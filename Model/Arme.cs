using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Arme : Equipement
    {
        public string deDeDegats { get; private set; }
        public Arme(string nom, string deDeDegats) : base(nom)
        {
            this.deDeDegats = deDeDegats;
        }
    }
}
