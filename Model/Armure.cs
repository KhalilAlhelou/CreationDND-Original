using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Armure : Equipement, ISauvergardeXML
    {
        public int classeArmure { get; private set; }
        public bool obtientBonusModDex { get; private set; }
        public bool bonusModDexEstLimite { get; private set; }

        public bool estBouclier { get; private set; }
        public Armure(string nom, int classeArmure, bool obtientBonusModDex, bool bonusModDexEstLimite) : base(nom)
        {
            this.classeArmure = classeArmure;
            this.obtientBonusModDex = obtientBonusModDex;
            this.bonusModDexEstLimite = bonusModDexEstLimite;
            this.estBouclier = estBouclier;
        }

        public Armure(ArmureDTO armureDTO) : base(armureDTO.nom)
        {
            this.classeArmure = armureDTO.classeArmure;
            this.obtientBonusModDex = armureDTO.obtientBonusModDex;
            this.bonusModDexEstLimite = armureDTO.bonusModDexEstLimite;
            this.estBouclier = armureDTO.estBouclier;
        }

        public Armure(XmlElement element) : base(element)
        {
            classeArmure = Int32.Parse(element.GetAttribute("ClasseArmure"));

            if (element.GetAttribute("ObtientBonusDex").Equals("TRUE"))
            {
                obtientBonusModDex = true;
            }
            else
            {
                obtientBonusModDex = false;
            }

            if (element.GetAttribute("bonusModDexEstLimite").Equals("TRUE"))
            {
                bonusModDexEstLimite = true;
            }
            else
            {
                bonusModDexEstLimite = false;
            }


        }

        public int calculerClasseArmure(int modDex)
        {
            if (obtientBonusModDex)
            {
                if (bonusModDexEstLimite && modDex >= 2)
                {
                    return classeArmure + 2;
                }
                
                return classeArmure + modDex;
            }

            return classeArmure;
        }

        public new XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementArmure = doc.CreateElement("Armure");
            elementArmure.SetAttribute("Nom", nom);
            elementArmure.SetAttribute("ClasseArmure", classeArmure.ToString());

            if (obtientBonusModDex)
            {
                elementArmure.SetAttribute("ObtientBonusDex", "TRUE");
            }
            else
            {
                elementArmure.SetAttribute("ObtientBonusDex", "FALSE");
            }

            if (bonusModDexEstLimite)
            {
                elementArmure.SetAttribute("bonusModDexEstLimite", "TRUE");
            }
            else
            {
                elementArmure.SetAttribute("bonusModDexEstLimite", "FALSE");
            }
            

            return elementArmure;
        }
    }
}
