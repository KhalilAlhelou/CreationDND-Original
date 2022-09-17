using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static raceCharacter;
//using static SQLiteHandler;

namespace Model
{
public class dbHandler
{
    SQLiteHandler sqlHandler = new SQLiteHandler();
    public dbHandler()
    {

    }

    public void showTable(string tableName)
    {

        sqlHandler.showTable(tableName);
    }
    public List<RaceDTO> getAllRace()
    {
        return sqlHandler.getAllRace();
    }

    public RaceDTO getRace(int raceId)
    {
        return sqlHandler.getRace(raceId);
    }
    public RaceDTO getRace(string raceName)
    {
        return sqlHandler.getRace(raceName);
    }

    public RaceDTO getRaceBonusForce(int bonusForce)
    {
        return sqlHandler.getRaceBonusForce(bonusForce);
    }

    public RaceDTO getRaceBonusDex(int bonusDex)
    {
        return sqlHandler.getRaceBonusDex(bonusDex);
    }

   public RaceDTO getRaceBonusConst(int bonusConst)
   {
        return sqlHandler.getRaceBonusConst(bonusConst);
   }

   public RaceDTO getRaceBonusInt(int bonusInt)
   {
        return sqlHandler.getRaceBonusInt(bonusInt);
   }
   public RaceDTO getRaceBonusSage(int bonusSage)
   {
        return sqlHandler.getRaceBonusSage(bonusSage);
   }
   public RaceDTO getRaceBonusChar(int bonusChar)
   {
        return sqlHandler.getRaceBonusChar(bonusChar);
   }


    }



}


