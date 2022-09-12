using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CreationDND
{
    class Race
    {
        private String nom;
        private String description;
        private int bForce;
        private int bDex;
        private int bConst;
        private int bInt;
        private int bSage;
        private int bChar;

        public Race(RaceDTO _race)
        {
            this.nom = _race.nom;
            this.description = _race.description;
            this.bForce = _race.bForce;
            this.bDex = _race.bDex;
            this.bConst = _race.bConst;
            this.bInt = _race.bInt;
            this.bSage = _race.bSage;
            this.bChar = _race.bChar;
        }
    }
}
