using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class raceCharacter
{
    int idRace;
    string nameRace;
    string descRace;
    public raceCharacter(int idTmp, string nameTmp, string descTmp)
    {
        this.idRace = idTmp;
        this.nameRace = nameTmp;
        this.descRace = descTmp;
    }


    public int getIdRace()
    {

        return this.idRace;
    }

    public string getNameRace()
    {
        return this.nameRace;
    }

    public string getDescRace()
    {
        return this.descRace;
    }

    public override string? ToString()
    {
        return this.idRace +" "+ this.nameRace + " " + this.descRace;
    }
}

