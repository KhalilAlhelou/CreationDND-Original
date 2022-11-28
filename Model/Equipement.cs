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
    public class Equipement : ISauvergardeXML
    {
        public string nom { get; set; }

        public Equipement(string nom)
        {
            this.nom = nom;
        }

        public Equipement(EquipementDTO equipementDTO)
        {
            this.nom = equipementDTO.nom;
        }

        public Equipement(XmlElement element)
        {
            nom = element.GetAttribute("Nom");
        }

        public override string ToString()
        {
            return nom;
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementEquipement = doc.CreateElement("Equipement");
            elementEquipement.SetAttribute("Nom", nom);

            return elementEquipement;
        }
    }
}
