using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class ClassDTO
    {
        public ClassDTO (string nom, string description, int hpLvl1, bool estSpellCaster, int bonusMaitrise, List<AttributDTO> attributs, 
            List<ProficiencyDTO> competencesMaitrisable, int nombreDeCompetencesMaitrisable, int nombreDeChoixEquipement, List<List<Equipement>> choixEquipements)
        {
            Nom = nom;
            Description = description;
            HpLvl1 = hpLvl1;
            SpellCaster = estSpellCaster;
            BonusMaitrise = bonusMaitrise;
            ListeAttributs = attributs;
            this.competencesMaitrisable = competencesMaitrisable;
            this.nombreDeCompetencesMaitrisable = nombreDeCompetencesMaitrisable;
            this.nombreDeChoixEquipement = nombreDeChoixEquipement;
            this.choixEquipements = choixEquipements;
        }
        public string Nom
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public int HpLvl1
        {
            get;
            private set;
        }

        public bool SpellCaster
        {
            get;
            private set;
        }

        public int BonusMaitrise
        {
            get;
            private set;
        }

        public List<AttributDTO> ListeAttributs
        {
            get;
            private set;
        }

        public List<ProficiencyDTO> competencesMaitrisable
        {
            get;
            private set;
        }

        public int nombreDeCompetencesMaitrisable
        {
            get;
            private set;
        }

        public List<List<Equipement>> choixEquipements 
        { 
            get; 
            private set; 
        }

        public int nombreDeChoixEquipement 
        { 
            get; 
            private set; 
        }
    }
}
