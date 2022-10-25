using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    public class Models
    {
        private dbHandler bd;
        private Personnage personnageEnCreation;
        private ObservableCollection<Personnage> personnagesExistants;
        private XmlDocument document;
        private string fichierXML;
        private GenerateurPDF generateurPDF;

        public Models()
        {
            personnagesExistants = new ObservableCollection<Personnage>();
            fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/personnages.xml";
            bd = new dbHandler();
            generateurPDF = new GenerateurPDF();
            chargerXML();
        }

        public ObservableCollection<Race> obtenirRaces()
        {
            List<RaceDTO> listeDTO = bd.getAllRace();
            ObservableCollection<Race> listeRaces = new ObservableCollection<Race>();

            foreach (RaceDTO raceDTO in listeDTO)
            {
                listeRaces.Add(new Race(raceDTO));
            }

            return listeRaces;
        }

        public ObservableCollection<Classe> obtenirClasse()
        {
            List<ClassDTO> listeDTO = bd.getAllClasse();

            ObservableCollection<Classe> listeClasses = new ObservableCollection<Classe>();

            foreach (ClassDTO classeDTO in listeDTO)
            {
                listeClasses.Add(new Classe(classeDTO));
            }

            return listeClasses;

        }

        public ObservableCollection<Personnage> obtenirPersonnagesExistants()
        {
            return personnagesExistants;
        }

        public void ajouterLaRace(Race race)
        {
            personnageEnCreation = new Personnage(race);
            
        }

        public void ajouterLaClasse(Classe classe)
        {
            personnageEnCreation.ajouterClasse(classe);
            SauvegardeXml();
            chargerXML();
        }

        public void ajouterEquipements(List<Equipement> listeEquipements)
        {
            foreach (Equipement equipement in listeEquipements)
            {
                personnageEnCreation.ajouterEquipement(equipement);
            }
        }

        public void ajouterLesCompetencesMaitrises(List<Competence> competences)
        {
            personnageEnCreation.ajouterCompetenceMaitrise(competences);
        }

        public void GenererFichePersonnagePDF(Personnage personnage, bool estTest)
        {
            generateurPDF.GenererLePDFDuPersonnage(personnage, estTest);
        }


        private void SauvegardeXml()
        {
            document = new XmlDocument();
            XmlElement root = document.CreateElement("Personnages");
            document.AppendChild(root);
            
            foreach (Personnage personnage in personnagesExistants)
            {
                root.AppendChild(personnage.toXMl(document));
            }

            root.AppendChild(personnageEnCreation.toXMl(document));

            document.Save(fichierXML);
        }

        private void chargerXML()
        {
            document = new XmlDocument();
            if (File.Exists(fichierXML))
            {
                document.Load(fichierXML); 
                XmlElement? root = document.DocumentElement;
                if (root != null)
                {
                    XmlNodeList listePersonnages = root.GetElementsByTagName("Personnage");
                    foreach (XmlElement elementPersonnage in listePersonnages)
                    {
                        personnagesExistants.Add(new Personnage(elementPersonnage));
                    }

                }
                
            }
        }
    }
}