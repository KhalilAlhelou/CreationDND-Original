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
        public int classeDArmure { get; private set; } = 0;
        public Armure armurePortee { get; private set; } = null;
        public int bonusMaitrise { get; private set; } = 0;
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
        public int pvMax { get; private set; } = 0;
        public List<Competence> competencesMaitrises { get; private set; } = null;
        public List<Equipement> inventaire { get; private set; } = null;


        public Personnage(Race _race)
        {
            race = _race;
            force += race.bForce;
            dexterite += race.bDex;
            constitution += race.bConst;
            intelligence += race.bInt;
            sagesse += race.bSage;
            charisme += race.bChar;
            calculerTousLesModificateurs(false);
            inventaire = new List<Equipement>();

        }

        public Personnage(XmlElement element)
        {
            force = Int32.Parse(element.GetAttribute("force"));
            dexterite = Int32.Parse(element.GetAttribute("dexterite"));
            constitution = Int32.Parse(element.GetAttribute("constitution"));
            intelligence = Int32.Parse(element.GetAttribute("intelligence"));
            sagesse = Int32.Parse(element.GetAttribute("sagesse"));
            charisme = Int32.Parse(element.GetAttribute("charisme"));
            bonusMaitrise = Int32.Parse(element.GetAttribute("bonusMaitrise"));

            race = new Race(element.GetElementsByTagName("Race")[0] as XmlElement);
            classe = new Classe(element.GetElementsByTagName("Classe")[0] as XmlElement);

            XmlNodeList competencesMaitriseesXml = element.GetElementsByTagName("Competence");

            competencesMaitrises = new List<Competence>();

            foreach(XmlElement competence in competencesMaitriseesXml)
            {
                competencesMaitrises.Add(new Competence(competence));
            }

            inventaire = new List<Equipement>();

            XmlNodeList armureXML = element.GetElementsByTagName("Armure");

            if(armureXML != null)
            {
                foreach(XmlElement armure in armureXML)
                {
                    inventaire.Add(new Armure(armure));
                }
            }

            XmlNodeList armeXML = element.GetElementsByTagName("Arme");

            if (armeXML != null)
            {
                foreach (XmlElement arme in armeXML)
                {
                    inventaire.Add(new Arme(arme));
                }
            }

            XmlNodeList equipementXML = element.GetElementsByTagName("Equipement");

            if (equipementXML != null)
            {
                foreach (XmlElement equipement in equipementXML)
                {
                    inventaire.Add(new Equipement(equipement));
                }
            }


            calculerTousLesModificateurs(true);
        }

        public Personnage(string nom, Race race, Classe classe, int force, int dexterite, int constitution, int intelligence, int sagesse, int charisme, List<Competence> competencesMaitrises)
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
            inventaire = new List<Equipement>();
            this.competencesMaitrises = competencesMaitrises;
            calculerTousLesModificateurs(true);
        }

        public void ajouterClasse(Classe classe)
        {
            this.classe = classe;
            this.bonusMaitrise = 2;
        }

        public void ajouterEquipement(Equipement equipement)
        {   
            if(equipement is Groupe)
            {
                return;
            }    

            if(equipement is Armure && armurePortee == null)
            {
                armurePortee = (Armure)equipement;
                calculerLaClasseArmure();
                inventaire.Add((Armure)equipement);

            } else if(equipement is Arme)
            {
                inventaire.Add((Arme)equipement);

            } else
            {
                inventaire.Add(equipement);
            }

           
        }

        public void attribuerStatistique(List<int> statistiques)
        {
            force += statistiques[0];
            dexterite += statistiques[1];
            constitution += statistiques[2];
            intelligence += statistiques[3];
            sagesse += statistiques[4];
            charisme += statistiques[5];
            calculerTousLesModificateurs(true);
            calculerLaClasseArmure();
        }

        public void ajouterCompetenceMaitrise(List<Competence> listeCompetencesMaitrises)
        {
            competencesMaitrises = new List<Competence>();
            foreach (Competence competence in listeCompetencesMaitrises)
            {
                competencesMaitrises.Add(competence);
            }
        }

        private void calculerTousLesModificateurs(bool aUneClasse)
        {
            modForce = calculerUnModificateur(force);
            modDexterite = calculerUnModificateur(dexterite);
            modConstitution = calculerUnModificateur(constitution);
            modIntelligence = calculerUnModificateur(intelligence);
            modSagesse = calculerUnModificateur(sagesse);
            modCharisme = calculerUnModificateur(charisme);
            if (aUneClasse)
            {
                pvMax = classe.calculerPvAuNiv1(modConstitution);
            }
            

        }

        private int calculerUnModificateur(int capacite)
        {
            double modNonArrondi = (capacite - 10) / 2;
            return (int)Math.Floor(modNonArrondi);
        }

        private void calculerLaClasseArmure()
        {
            foreach(Attribut attribut in classe.listeAttributs)
            {
                if(attribut.nom.Equals("Défense sans armure (Moine)"))
                {
                    classeDArmure = 10 + modDexterite + modSagesse;
                    return;
                }

                if(attribut.nom.Equals("Défense sans armure (Barbare)"))
                {
                    classeDArmure = 10 + modDexterite + modConstitution;
                    return;
                }
            }
            if(armurePortee != null)
            {
                classeDArmure = armurePortee.calculerClasseArmure(modDexterite);
            }
            
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
            elementPersonnage.SetAttribute("bonusMaitrise", bonusMaitrise.ToString());

            elementPersonnage.AppendChild(race.toXMl(doc));

            elementPersonnage.AppendChild(classe.toXMl(doc));

            XmlElement elementPersonnageCompetencesMatrisees = doc.CreateElement("CompetencesMaitrise");
            foreach(Competence competence in competencesMaitrises)
            {
                elementPersonnageCompetencesMatrisees.AppendChild(competence.toXMl(doc));
            }

            elementPersonnage.AppendChild(elementPersonnageCompetencesMatrisees);

            XmlElement elementInventaire = doc.CreateElement("Inventaire");
            foreach (Equipement equipement in inventaire)
            {
                if(equipement is Armure)
                {   
                    Armure armure = (Armure)equipement;
                    elementInventaire.AppendChild(armure.toXMl(doc));

                }else if(equipement is Arme)
                {
                    Arme arme = (Arme)equipement;
                    elementInventaire.AppendChild(arme.toXMl(doc));
                }
                else
                {
                    elementInventaire.AppendChild(equipement.toXMl(doc));
                }
            }

            elementPersonnage.AppendChild(elementInventaire);

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
