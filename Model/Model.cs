using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

[assembly: InternalsVisibleTo("TestCreationDND")]

namespace Model {

    public class Models
    {
        private dbHandler db;
        private Personnage personnage;
        private ObservableCollection<Personnage> personnagesExistants;
        private XmlDocument document;
        private string fichierXML;
        private GenerateurPDF generateurPDF;

        public Models()
        {
            personnagesExistants = new ObservableCollection<Personnage>();
            fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/personnages.xml";
            chargerXML();
            db = new dbHandler();
            generateurPDF = new GenerateurPDF();
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

        public void ajouterLaRace(Race race)
        {
            personnage = new Personnage(race);
            SauvegardeXml();
        }

        public void ajouterLaClasse(Classe classe)
        {
            personnage.ajouterClasse(classe);
            SauvegardeXml();
        }

        public void GenererFichePersonnagePDF(Personnage personnage)
        {
            generateurPDF.GenererLePDFDuPersonnage(personnage);
        }

        private void SauvegardeXml()
        {
            document = new XmlDocument();
            XmlElement root = document.CreateElement("Personnages");
            document.AppendChild(root);
            
            root.AppendChild(personnage.toXMl(document));

            document.Save(fichierXML);
        }

        private void chargerXML()
        {
            document = new XmlDocument();
            if (File.Exists(fichierXML))
            {
                document.Load(fichierXML);
            }

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