using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Personnage
    {
        public string nom { get; private set; } = "";
        public Race race { get; private set; }
        public Classe classe { get; private set; } = null;
        public int force { get; private set; } = 0;
        public int dexterite { get; private set; } = 0;
        public int constitution { get; private set; } = 0;
        public int intelligence { get; private set; } = 0;
        public int sagesse { get; private set; } = 0;
        public int charisme { get; private set; } = 0;
        public int modForce { get; private set; } = 0;
        public int modDexterite { get; private set; } = 0;
        public int modConstitution { get; private set; } = 0;
        public int modIntelligence { get; private set; } = 0;
        public int modSagesse { get; private set; } = 0;
        public int modCharisme { get; private set; } = 0;

        public Personnage(Race _race)
        {
            race = _race;
            force += race.bForce;
            dexterite += race.bDex;
            constitution += race.bConst;
            intelligence += race.bInt;
            sagesse += race.bSage;
            charisme += race.bChar;
            calculerTousLesModificateurs();

        }

        private void calculerTousLesModificateurs()
        {
            modForce = calculerUnModificateur(force);
            modDexterite = calculerUnModificateur(dexterite);
            modConstitution = calculerUnModificateur(constitution);
            modIntelligence = calculerUnModificateur(intelligence);
            modSagesse = calculerUnModificateur(sagesse);
            modCharisme = calculerUnModificateur(charisme);

        }

        private int calculerUnModificateur(int capacite)
        {
            switch (capacite)
            {
                case 1:
                    return -5; 
                case 2: case 3:
                    return -4; 
                case 4: case 5:
                    return -3; 
                case 6: case 7:
                    return -2; 
                case 8: case 9:
                    return -1; 
                case 10: case 11:
                    return 0; 
                case 12: case 13:
                    return 1; 
                case 14: case 15:
                    return 2; 
                case 16: case 17:
                    return 3; 
                case 18: case 19:
                    return 4; 
                case 20: case 21:
                    return 5; 
                case 22: case 23:
                    return 6; 
                case 24: case 25:
                    return 7; 
                case 26: case 27:
                    return 8; 
                case 28: case 29:
                    return 9;
                case 30: 
                    return 10; 
                default: 
                    return 0;
            }
        }
    }
}
