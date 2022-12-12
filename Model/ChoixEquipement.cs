using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChoixEquipement
    {
        public ObservableCollection<Equipement> equipementsDeChoix {get; set; }

        public ChoixEquipement()
        {
            equipementsDeChoix = new ObservableCollection<Equipement>();   
        }

        public override string ToString()
        {
            string texte = "";

            for (int i = 0; i < equipementsDeChoix.Count; i++)
            {
                if(i == equipementsDeChoix.Count - 1)
                {
                    texte += equipementsDeChoix[i].ToString();
                }
                else
                {
                    texte += equipementsDeChoix[i].ToString() + ", ";
                }
            }

            return texte;
        }

    }
}
