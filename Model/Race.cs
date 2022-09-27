using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Race
    {
        public string nom { get; private set; }
        public string description { get; private set; }
        public int bForce { get; private set; }
        public int bDex { get; private set; }
        public int bConst { get; private set; }
        public int bInt { get; private set; }
        public int bSage { get; private set; }
        public int bChar { get; private set; }

        public Race(RaceDTO _race)
        {
            this.nom = _race.NameRace;
            this.description = _race.DescRace;
            this.bForce = _race.BonusForce;
            this.bDex = _race.BonusDex;
            this.bConst = _race.BonusConst;
            this.bInt = _race.BonusInt;
            this.bSage = _race.BonusSage;
            this.bChar = _race.BonusChar;
        }



        internal bool? comparerARaceDTO(RaceDTO raceDTO)
        {
            if (nom != raceDTO.NameRace || description != raceDTO.DescRace || bForce != raceDTO.BonusForce || bDex != raceDTO.BonusDex || bConst != raceDTO.BonusConst || bInt != raceDTO.BonusInt || bSage != raceDTO.BonusSage || bChar != raceDTO.BonusChar)
            {
                return false;
            }

            return true;
        }
    }
}
