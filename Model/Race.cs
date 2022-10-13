using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

[assembly:InternalsVisibleTo("TestCreationDND")]

namespace Model
{
    public class Race : ISauvergardeXML
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

        public Race(string nom, string description, int bForce, int bDex, int bConst, int bInt, int bSage, int bChar)
        {
            this.nom = nom;
            this.description = description;
            this.bForce = bForce;
            this.bDex = bDex;
            this.bConst = bConst;
            this.bInt = bInt;
            this.bSage = bSage;
            this.bChar = bChar;
        }

        public Race(XmlElement element)
        {
            bForce = Int32.Parse(element.GetAttribute("bForce"));
            bDex = Int32.Parse(element.GetAttribute("bDex"));
            bConst = Int32.Parse(element.GetAttribute("bConst"));
            bInt = Int32.Parse(element.GetAttribute("bInt"));
            bSage = Int32.Parse(element.GetAttribute("bSage"));
            bChar = Int32.Parse(element.GetAttribute("bChar"));

            nom = element.GetElementsByTagName("NomRace").Item(0).InnerText;
            description = element.GetElementsByTagName("DescriptionRace").Item(0).InnerText;

        }

        internal bool? comparerARaceDTO(RaceDTO raceDTO)
        {
            if (nom != raceDTO.NameRace || description != raceDTO.DescRace || bForce != raceDTO.BonusForce || bDex != raceDTO.BonusDex || bConst != raceDTO.BonusConst || bInt != raceDTO.BonusInt || bSage != raceDTO.BonusSage || bChar != raceDTO.BonusChar)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return nom;

        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementRace = doc.CreateElement("Race");
            elementRace.SetAttribute("bForce", bForce.ToString());
            elementRace.SetAttribute("bDex", bDex.ToString());
            elementRace.SetAttribute("bConst", bConst.ToString());
            elementRace.SetAttribute("bInt", bInt.ToString());
            elementRace.SetAttribute("bSage", bSage.ToString());
            elementRace.SetAttribute("bChar", bChar.ToString());
            
            XmlElement elementRaceNom = doc.CreateElement("NomRace");
            elementRaceNom.InnerText = nom;
            elementRace.AppendChild(elementRaceNom);

            XmlElement elementRaceDescription = doc.CreateElement("DescriptionRace");
            elementRaceDescription.InnerText = description;
            elementRace.AppendChild(elementRaceDescription);

            return elementRace;
        }
    }
}
