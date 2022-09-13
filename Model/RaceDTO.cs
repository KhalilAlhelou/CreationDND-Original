using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    class RaceDTO
    {
        public int idRace;
        public String nom;
        public String description;
        public int bForce;
        public int bDex;
        public int bConst;
        public int bInt;
        public int bSage;
        public int bChar;

        public RaceDTO(int idRace, string nom, string description, int bForce, int bDex, int bConst, int bInt, int bSage, int bChar)
        {
            this.idRace = idRace;
            this.nom = nom;
            this.description = description;
            this.bForce = bForce;
            this.bDex = bDex;
            this.bConst = bConst;
            this.bInt = bInt;
            this.bSage = bSage;
            this.bChar = bChar;
        }
    }
}
