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
    public class Personnage : ISauvergardeXML
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

        public List<Competence> competencesMaitrises { get; private set; } = null;

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

        public Personnage(XmlElement element)
        {
            force = Int32.Parse(element.GetAttribute("force"));
            dexterite = Int32.Parse(element.GetAttribute("dexterite"));
            constitution = Int32.Parse(element.GetAttribute("constitution"));
            intelligence = Int32.Parse(element.GetAttribute("intelligence"));
            sagesse = Int32.Parse(element.GetAttribute("sagesse"));
            charisme = Int32.Parse(element.GetAttribute("charisme"));

            race = new Race(element.GetElementsByTagName("Race")[0] as XmlElement);
            classe = new Classe(element.GetElementsByTagName("Classe")[0] as XmlElement);

            calculerTousLesModificateurs();
        }

        public Personnage(string nom, Race race, Classe classe, int force, int dexterite, int constitution, int intelligence, int sagesse, int charisme)
        {
            this.nom = nom;
            this.race = race;
            this.classe = classe;
            this.force = force;
            this.dexterite = dexterite;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.sagesse = sagesse;
            this.charisme = charisme;
            calculerTousLesModificateurs();
        }

        public void ajouterClasse(Classe classe)
        {
            this.classe = classe;
            
        }

        public void ajouterCompetenceMaitrise(List<Competence> listeCompetencesMaitrises)
        {
            competencesMaitrises = new List<Competence>();
            foreach (Competence competence in listeCompetencesMaitrises)
            {
                competencesMaitrises.Add(competence);
            }
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
            double modNonArrondi = (capacite - 10) / 2;
            return (int)Math.Floor(modNonArrondi);
        }

        public XmlNode toXMl(XmlDocument doc)
        {
            XmlElement elementPersonnage = doc.CreateElement("Personnage");
            elementPersonnage.SetAttribute("force", force.ToString());
            elementPersonnage.SetAttribute("dexterite", dexterite.ToString());
            elementPersonnage.SetAttribute("constitution", constitution.ToString());
            elementPersonnage.SetAttribute("intelligence", intelligence.ToString());
            elementPersonnage.SetAttribute("sagesse", sagesse.ToString());
            elementPersonnage.SetAttribute("charisme", charisme.ToString());

            elementPersonnage.AppendChild(race.toXMl(doc));

            if(classe != null)
            {
                elementPersonnage.AppendChild(classe.toXMl(doc));
            }

            return elementPersonnage;
        }

        public override string ToString()
        {
            if(nom == "")
            {
                return "Personnage";
            }

            return nom;
        }
    }
}
