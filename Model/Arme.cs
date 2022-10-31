using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Arme : Equipement
    {
        public string deDeDegats { get; private set; }

        public Arme(string nom, string deDeDegats) : base(nom)
        {
            this.deDeDegats = deDeDegats;
        }

        public Arme(ArmeDTO armeDTO) : base(armeDTO.nom)
        {
            this.deDeDegats = armeDTO.deDeDegats;
        }
    }
}
