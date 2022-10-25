using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Model
{
    public class Competence : ISauvergardeXML
    {
        public int id { get; private set; }
        public string nom { get; private set; }

        public Competence(ProficiencyDTO proficiencyDTO)
        {
            id = proficiencyDTO.id;
            nom = proficiencyDTO.nom;
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementCompetence = doc.CreateElement("Competence");
            elementCompetence.SetAttribute("Id", id.ToString());
            elementCompetence.SetAttribute("Nom", nom);
            

            return elementCompetence;
        }
    }
}
