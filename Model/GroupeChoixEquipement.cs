using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupeChoixEquipement
    {
        public List<ChoixEquipement> tousLesChoix { get; set; }

        public GroupeChoixEquipement()
        {
            tousLesChoix = new List<ChoixEquipement>();
        }

    }
}
