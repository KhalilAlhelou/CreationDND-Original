using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class EquipementDTO : IEquatable<EquipementDTO?>
    {
        public string nom { get; set; }

        public EquipementDTO(string nom)
        {
            this.nom = nom;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as EquipementDTO);
        }

        public bool Equals(EquipementDTO? other)
        {
            return other is not null &&
                   nom == other.nom;
        }

        public static bool operator ==(EquipementDTO? left, EquipementDTO? right)
        {
            return EqualityComparer<EquipementDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(EquipementDTO? left, EquipementDTO? right)
        {
            return !(left == right);
        }
    }
}
