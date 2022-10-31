using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class ArmureDTO : EquipementDTO
    {
        public int classeArmure { get; private set; }
        public bool obtientBonusModDex { get; private set; }
        public bool bonusModDexEstLimite { get; private set; }

        public ArmureDTO(string nom, int classeArmure, bool obtientBonusModDex, bool bonusModDexEstLimite) : base(nom)
        {
            this.classeArmure = classeArmure;
            this.obtientBonusModDex = obtientBonusModDex;
            this.bonusModDexEstLimite = bonusModDexEstLimite;
        }
    }
}
