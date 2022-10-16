using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    public class Models
    {
        private dbHandler db;
        private Personnage personnageEnCreation;
        private ObservableCollection<Personnage> personnagesExistants;
        private XmlDocument document;
        private string fichierXML;
        private GenerateurPDF generateurPDF;

        public Models()
        {
            personnagesExistants = new ObservableCollection<Personnage>();
            fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/personnages.xml";
            db = new dbHandler();
            generateurPDF = new GenerateurPDF();
            chargerXML();
        }

        public ObservableCollection<Race> obtenirRaces()
        {
            List<RaceDTO> listeDTO = db.getAllRace();
            ObservableCollection<Race> listeRaces = new ObservableCollection<Race>();

            foreach (RaceDTO raceDTO in listeDTO)
            {
                listeRaces.Add(new Race(raceDTO));
            }

            return listeRaces;
        }

        public ObservableCollection<Classe> obtenirClasse()
        {
            List<ClassDTO> listeDTO = db.getAllClasse();

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

        public void GenererFichePersonnagePDF(Personnage personnage, bool estTest)
        {
            generateurPDF.GenererLePDFDuPersonnage(personnage, estTest);
        }

        public void testPdf()
        {
            generateurPDF.GenererLePDFDuPersonnage(personnagesExistants[0], false);
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