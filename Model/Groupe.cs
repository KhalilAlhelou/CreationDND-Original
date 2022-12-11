using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Groupe : Equipement
    {
        public int groupType { get; private set; }
        public int groupId { get; private set; }

        public Groupe(string nom, int groupType, int groupId) : base(nom)
        {
            this.groupType = groupType;
            this.groupId = groupId;
        }

        public Groupe(GroupeDTO groupeDTO) : base(groupeDTO.nom)
        {
            this.groupType = groupeDTO.groupType;
            this.groupId = groupeDTO.groupId;
        }
    }
}
