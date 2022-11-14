using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class ClasseDTO
    {
        public ClasseDTO(string nom, string description, int hpLvl1, bool estSpellCaster, int bonusMaitrise, List<AttributDTO> attributs,
            List<CompetenceDTO> competencesMaitrisable, int nombreDeCompetencesMaitrisable, int nombreDeChoixEquipement, List<List<List<EquipementDTO>>> choixEquipements)
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

        public List<CompetenceDTO> competencesMaitrisable
        {
            get;
            private set;
        }

        public int nombreDeCompetencesMaitrisable
        {
            get;
            private set;
        }

        public List<List<List<EquipementDTO>>> choixEquipements
        {
            get;
            private set;
        }

        public int nombreDeChoixEquipement
        {
            get;
            private set;
        }

        public override bool Equals(object? obj)
        {
            return obj is ClasseDTO dTO &&
                   Nom == dTO.Nom &&
                   Description == dTO.Description &&
                   HpLvl1 == dTO.HpLvl1 &&
                   SpellCaster == dTO.SpellCaster &&
                   BonusMaitrise == dTO.BonusMaitrise &&
                   EqualityComparer<List<AttributDTO>>.Default.Equals(ListeAttributs, dTO.ListeAttributs) &&
                   EqualityComparer<List<CompetenceDTO>>.Default.Equals(competencesMaitrisable, dTO.competencesMaitrisable) &&
                   nombreDeCompetencesMaitrisable == dTO.nombreDeCompetencesMaitrisable;
        }
    }
}
