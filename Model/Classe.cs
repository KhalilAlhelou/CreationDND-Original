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
    public class Classe : ISauvergardeXML
    {
        public string nom { get; private set; }
        public string description { get; private set; }
        public int pvNiveau1 { get; private set; }
        public bool estLanceurSort { get; private set; }
        public List<Attribut> listeAttributs { get; private set; }

        public Classe (ClassDTO classeDTO)
        {
            this.nom = classeDTO.Nom;
            this.description = classeDTO.Description;
            this.pvNiveau1 = classeDTO.HpLvl1;
            this.estLanceurSort = classeDTO.SpellCaster;
            this.listeAttributs = new List<Attribut>();
        }

        public Classe(string nom, string description, int pvNiveau1, bool estLanceurSort, List<Attribut> listeAttributs)
        {
            this.nom = nom;
            this.description = description;
            this.pvNiveau1 = pvNiveau1;
            this.estLanceurSort = estLanceurSort;
            this.listeAttributs = listeAttributs;
        }

        public Classe(XmlElement element)
        {

        }

        public int calculerPvAuNiv1(int modConstitution)
        {
            return modConstitution + this.pvNiveau1;
        }

        public override string ToString()
        {
            return nom;
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementClasse = doc.CreateElement("Classe");
            elementClasse.SetAttribute("pvNiv1", pvNiveau1.ToString());

            if (estLanceurSort)
            {
                elementClasse.SetAttribute("estLanceurSort", "TRUE");
            }
            else
            {
                elementClasse.SetAttribute("estLanceurSort", "FALSE");
            }

            XmlElement elementClasseNom = doc.CreateElement("NomClasse");
            elementClasseNom.InnerText = nom;
            elementClasse.AppendChild(elementClasseNom);

            XmlElement elementClasseDescription = doc.CreateElement("DescriptionClasse");
            elementClasseDescription.InnerText = description;
            elementClasse.AppendChild(elementClasseDescription);

            return elementClasse;
        }
    }
}
