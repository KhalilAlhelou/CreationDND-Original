using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class ArmeDTO : EquipementDTO
    {
        public string deDeDegats { get; private set; }
        public ArmeDTO(string nom, string deDeDegats) : base(nom)
        {
            this.deDeDegats = deDeDegats;
        }
    }
}
