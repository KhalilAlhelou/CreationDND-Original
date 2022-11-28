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
    public class Arme : Equipement, ISauvergardeXML
    {
        public string deDeDegats { get; private set; }

        public Arme(string nom, string deDeDegats) : base(nom)
        {
            this.deDeDegats = deDeDegats;
        }

        public Arme(ArmeDTO armeDTO) : base(armeDTO.nom)
        {
            this.deDeDegats = armeDTO.deDeDegats;
        }

        public Arme(XmlElement element) : base(element)
        {
            deDeDegats = element.GetAttribute("Degats");
        }

        public new XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementArme = doc.CreateElement("Arme");
            elementArme.SetAttribute("Nom", nom);
            elementArme.SetAttribute("Degats", deDeDegats);

            return elementArme;
        }
    }
}
