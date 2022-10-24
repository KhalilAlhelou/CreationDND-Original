using System.Xml;

namespace Model
{
    public class Attribut : ISauvergardeXML
    {
        public string nom { get; private set; }
        public string description { get; private set; }

        public Attribut (AttributDTO attributDTO)
        {
            this.nom = attributDTO.NomAttribut;
            this.description = attributDTO.DescriptionAttribut;
        }

        public Attribut(string nom, string description)
        {
            this.nom = nom;
            this.description = description;
        }

        public Attribut (XmlElement element)
        {
            nom = element.GetAttribute("Nom");
            description = element.GetAttribute("Description");
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementAttribut = doc.CreateElement("Attribut");
            elementAttribut.SetAttribute("Nom", nom);
            elementAttribut.SetAttribute("Description", description);

            return elementAttribut;
        }
    }
}