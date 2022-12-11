using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class ArmureDTO : EquipementDTO, IEquatable<ArmureDTO?>
    {
        public int classeArmure { get; private set; }
        public bool obtientBonusModDex { get; private set; }
        public bool bonusModDexEstLimite { get; private set; }

        public bool estBouclier { get; private set; }

        public ArmureDTO(string nom, int classeArmure, bool obtientBonusModDex, bool bonusModDexEstLimite, bool estBouclier) : base(nom)
        {
            this.classeArmure = classeArmure;
            this.obtientBonusModDex = obtientBonusModDex;
            this.bonusModDexEstLimite = bonusModDexEstLimite;
            this.estBouclier = estBouclier;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ArmureDTO);
        }

        public bool Equals(ArmureDTO? other)
        {
            return other is not null &&
                   nom == other.nom &&
                   classeArmure == other.classeArmure &&
                   obtientBonusModDex == other.obtientBonusModDex &&
                   estBouclier == other.estBouclier &&
                   bonusModDexEstLimite == other.bonusModDexEstLimite;
        }

        public static bool operator ==(ArmureDTO? left, ArmureDTO? right)
        {
            return EqualityComparer<ArmureDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(ArmureDTO? left, ArmureDTO? right)
        {
            return !(left == right);
        }
    }
}
