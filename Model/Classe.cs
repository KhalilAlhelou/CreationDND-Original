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
        public List<Competence> competencesMaitrisable { get; private set; }
        public int nombreDeCompetencesMaitrisable { get; private set; }
        public int nombreDeChoixEquipement { get; private set; }
        public List<List<Equipement>> choixEquipements { get; private set; }


        public Classe (ClasseDTO classeDTO)
        {
            this.nom = classeDTO.Nom;
            this.description = classeDTO.Description;
            this.pvNiveau1 = classeDTO.HpLvl1;
            this.estLanceurSort = classeDTO.SpellCaster;
            this.listeAttributs = creerListeAttributs(classeDTO.ListeAttributs);
            this.competencesMaitrisable = creerListeComptepenceMaitrisable(classeDTO.competencesMaitrisable);
            this.nombreDeCompetencesMaitrisable = classeDTO.nombreDeCompetencesMaitrisable;

            this.choixEquipements = new List<List<Equipement>>();


            
            foreach (List<List<EquipementDTO>> choixEquipements in classeDTO.choixEquipements)
            {   
                List<Equipement> equipements = new List<Equipement>();

                foreach(List<EquipementDTO> equipementChoix in choixEquipements)
                {
                    foreach(EquipementDTO equipementDTO in equipementChoix)
                    {
                        if(equipementDTO is ArmeDTO)
                        {
                            equipements.Add(new Arme((ArmeDTO)equipementDTO));
                        }
                        else if(equipementDTO is ArmureDTO)
                        {
                            equipements.Add(new Armure((ArmureDTO)equipementDTO));
                        }
                        else
                        {
                            equipements.Add(new Equipement(equipementDTO));
                        }
                    }

                }

                this.choixEquipements.Add(equipements);
            }
            
        }

        private List<Competence> creerListeComptepenceMaitrisable(List<CompetenceDTO> competencesMaitrisable)
        {
            List<Competence> result = new List<Competence>();
            foreach (CompetenceDTO proficiencyDTO in competencesMaitrisable)
            {
                result.Add(new Competence(proficiencyDTO));
            }

            return result;
        }

        private List<Attribut> creerListeAttributs(List<AttributDTO> listeAttributs)
        {
            List<Attribut> result = new List<Attribut>();
            foreach (AttributDTO attributDTO in listeAttributs)
            {
                result.Add(new Attribut(attributDTO));
            }

            return result;
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
            pvNiveau1 = Int32.Parse(element.GetAttribute("pvNiv1"));

            if (element.GetAttribute("estLanceurSort").Equals("TRUE"))
            {
                estLanceurSort = true;
            }
            else
            {
                estLanceurSort = false;
            }

            nom = element.GetElementsByTagName("NomClasse").Item(0).InnerText;
            description = element.GetElementsByTagName("DescriptionClasse").Item(0).InnerText;

            XmlNodeList attributs = element.GetElementsByTagName("Attribut");

            listeAttributs = new List<Attribut>();

            foreach (XmlElement attribut in attributs)
            {
                listeAttributs.Add(new Attribut(attribut));
            }

            
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


            foreach(Attribut attribut in listeAttributs)
            {
                elementClasse.AppendChild(attribut.toXMl(doc));
            }

            return elementClasse;
        }
    }
}
