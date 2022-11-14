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
    public class Competence : ISauvergardeXML
    {
        public int id { get; private set; }
        public string nom { get; private set; }

        public Competence(CompetenceDTO proficiencyDTO)
        {
            id = proficiencyDTO.id;
            nom = proficiencyDTO.nom;
        }

        public Competence(XmlElement element)
        {
            id = Int32.Parse(element.GetAttribute("Id"));
            nom = element.GetAttribute("Nom");
        }

        public Competence(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementCompetence = doc.CreateElement("Competence");
            elementCompetence.SetAttribute("Id", id.ToString());
            elementCompetence.SetAttribute("Nom", nom);


            return elementCompetence;
        }

        public override string ToString()
        {
            return nom;
        }
    }   
}
