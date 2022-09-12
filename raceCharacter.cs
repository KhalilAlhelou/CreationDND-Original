using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class raceCharacter
{

    public raceCharacter(int idTmp, string nameTmp, string descTmp, int bForce, int bDex, int bConst, int bInt, int bSage, int bChar)
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

}

