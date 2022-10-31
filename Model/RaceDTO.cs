using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model {
    public class RaceDTO
    {

        public RaceDTO(int idTmp, string nameTmp, string descTmp, int bForce, int bDex, int bConst, int bInt, int bSage, int bChar)
        {
            IDRace = idTmp;
            NameRace = nameTmp;
            DescRace = descTmp;
            BonusForce = bForce;
            BonusDex = bDex;
            BonusConst = bConst;
            BonusInt = bInt;
            BonusSage = bSage;
            BonusChar = bChar;
        }
    
        public int IDRace
        {
            get;
            private set;
        }

        public string NameRace
        {
            get;
            private set;
        }

        public string DescRace
        {
            get;
            private set;
        }

        public int BonusForce
        {
            get;
            private set;
        }

        public int BonusDex
        {
            get;
            private set;
        }

        public int BonusConst
        {
            get;
            private set;
        }

        public int BonusInt
        {
            get;
            private set;
        }

        public int BonusSage
        {
            get;
            private set;
        }

        public int BonusChar
        {
            get;
            private set;
        }

        public override bool Equals(object? obj)
        {
            return obj is RaceDTO dTO &&
                   IDRace == dTO.IDRace &&
                   NameRace == dTO.NameRace &&
                   DescRace == dTO.DescRace &&
                   BonusForce == dTO.BonusForce &&
                   BonusDex == dTO.BonusDex &&
                   BonusConst == dTO.BonusConst &&
                   BonusInt == dTO.BonusInt &&
                   BonusSage == dTO.BonusSage &&
                   BonusChar == dTO.BonusChar;
        }
    }


}

