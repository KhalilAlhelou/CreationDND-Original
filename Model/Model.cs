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
        private readonly ObservableCollection<int> VALEURS_DE_STATISTIQUES_FIXES = new ObservableCollection<int> { 15, 14, 13, 12, 10, 8 };

        public Models()
        {
            personnagesExistants = new ObservableCollection<Personnage>();
            fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/personnages.xml";
            bd = new dbHandler();
            generateurPDF = new GenerateurPDF();
            if (File.Exists(fichierXML))
            {
                chargerXML();
            }
            
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
            List<ClasseDTO> listeDTO = bd.getAllClasse();

            ObservableCollection<Classe> listeClasses = new ObservableCollection<Classe>();

            foreach (ClasseDTO classeDTO in listeDTO)
            {
                listeClasses.Add(new Classe(classeDTO));
            }

            return listeClasses;

        }

        public ObservableCollection<int> obtenirValeursDeStatistiquesFixes()
        {
            return VALEURS_DE_STATISTIQUES_FIXES;
        }

        public ObservableCollection<Personnage> obtenirPersonnagesExistants()
        {
            return personnagesExistants;
        }

        public int obtenirNombreCompetencesMatrisable()
        {
            return personnageEnCreation.classe.nombreDeCompetencesMaitrisable;
        }

        public ObservableCollection<Competence> obtenirCompetencesMaitrisables()
        {
            ObservableCollection<Competence> listeCompetencesMaitrisables = new ObservableCollection<Competence>();
            foreach (Competence competence in personnageEnCreation.classe.competencesMaitrisable)
            {
                listeCompetencesMaitrisables.Add(competence);
            }

            return listeCompetencesMaitrisables;
        }

        public ObservableCollection<ObservableCollection<Equipement>> obtenirEquipements()
        {
            ObservableCollection<ObservableCollection<Equipement>> list = new ObservableCollection<ObservableCollection<Equipement>>();

            foreach (List<Equipement> choix in personnageEnCreation.classe.choixEquipements)
            {
                list.Add(new ObservableCollection<Equipement>(choix));
            }

            return list;
            
        }

        public void ajouterLaRace(Race race)
        {
            personnageEnCreation = new Personnage(race);
           
        }

        public void ajouterLaClasse(Classe classe)
        {
            personnageEnCreation.ajouterClasse(classe);
            
        }

        public void ajouterLesCompetencesMaitrises(List<Competence> competences)
        {
            personnageEnCreation.ajouterCompetenceMaitrise(competences);
            
        } 
        public void ajouterEquipements(List<Equipement> listeEquipements)
        {
            foreach (Equipement equipement in listeEquipements)
            {
                personnageEnCreation.ajouterEquipement(equipement);
            }
            
        }

        public void attribuerLesStatistiques(List<int> statistiques)
        {
            personnageEnCreation.attribuerStatistique(statistiques);
            SauvegardeXml();
            chargerXML();
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

        public string obtenirDescriptionClasse(Classe classe)
        {
            string texte = classe.description + "\n\n";

            foreach (Attribut attribut in classe.listeAttributs)
            {
                texte += attribut.nom + "\n" + attribut.description + "\n\n";
            }

            return texte;
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