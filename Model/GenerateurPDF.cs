using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class GenerateurPDF
    {
        private const int TAILLE_POLICE_NORMAL = 14;
        private const int TAILLE_POLICE_TITRE = 20;

        public string GenererLePDFDuPersonnage(Personnage personnage, bool estTest)
        {
            List<string> competencesMatriseString = new List<string>();
            string texte;
            string nom = personnage.nom;

            if (nom.Equals(""))
            {
                nom = "Personnage";
            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Document document = new Document();
            Section section = document.AddSection();

            // Page 1

            AjouterParagraphe(section, nom, TAILLE_POLICE_TITRE, true);

            section.AddParagraph();

            texte = "Race : " + personnage.race.ToString();
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Classe : " + personnage.classe.ToString();
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "PV maximum : " + personnage.pvMax.ToString() + " PV";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            section.AddParagraph();

            texte = "PV actuels : ___________";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            section.AddParagraph();
                
            texte = "Force = " + personnage.force.ToString() + " (" + personnage.modForce.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Dextérité = " + personnage.dexterite.ToString() + " (" + personnage.modDexterite.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Constitution = " + personnage.constitution.ToString() + " (" + personnage.modConstitution.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Intelligence = " + personnage.intelligence.ToString() + " (" + personnage.modIntelligence.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Sagesse = " + personnage.sagesse.ToString() + " (" + personnage.modSagesse.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            texte = "Charisme = " + personnage.charisme.ToString() + " (" + personnage.modCharisme.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            section.AddParagraph();

            texte = "Bonus de maitrise (+" + personnage.bonusMaitrise.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);
            texte = "Bonus d'initiative (" + personnage.modDexterite.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            section.AddParagraph();

            texte = "Compétences maitrisées : ";

            foreach (Competence competence in personnage.competencesMaitrises)
            {
                if(personnage.competencesMaitrises[personnage.competencesMaitrises.Count - 1] == competence)
                {
                    texte += competence + ".";
                }
                else
                {
                    texte += competence + ", ";
                }

                competencesMatriseString.Add(competence.ToString());
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, true);

            section.AddParagraph();

            if (competencesMatriseString.Contains("Acrobaties"))
            {
                texte = "Acrobaties = " + (personnage.modDexterite + personnage.bonusMaitrise);

            } else
            {
                texte = "Acrobaties = " + (personnage.modDexterite);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Arcanes"))
            {
                texte = "Arcanes = " + (personnage.modIntelligence + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Arcanes = " + (personnage.modIntelligence);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Athlétisme"))
            {
                texte = "Athlétisme = " + (personnage.modForce + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Athlétisme = " + (personnage.modForce);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Discrétion"))
            {
                texte = "Discrétion = " + (personnage.modDexterite + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Discrétion = " + (personnage.modDexterite);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Dressage"))
            {
                texte = "Dressage = " + (personnage.modSagesse + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Dressage = " + (personnage.modSagesse);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Escamotage"))
            {
                texte = "Escamotage = " + (personnage.modDexterite + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Escamotage = " + (personnage.modDexterite);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Histoire"))
            {
                texte = "Histoire = " + (personnage.modIntelligence + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Histoire = " + (personnage.modIntelligence);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Intimidation"))
            {
                texte = "Intimidation = " + (personnage.modCharisme + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Intimidation = " + (personnage.modCharisme);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Investigation"))
            {
                texte = "Investigation = " + (personnage.modIntelligence + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Investigation = " + (personnage.modIntelligence);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Médecine"))
            {
                texte = "Médecine = " + (personnage.modSagesse + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Médecine = " + (personnage.modSagesse);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Nature"))
            {
                texte = "Nature = " + (personnage.modIntelligence + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Nature = " + (personnage.modIntelligence);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Perception"))
            {
                texte = "Perception = " + (personnage.modSagesse + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Perception = " + (personnage.modSagesse);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Perspicacité"))
            {
                texte = "Perspicacité = " + (personnage.modSagesse + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Perspicacité = " + (personnage.modSagesse);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Persuasion"))
            {
                texte = "Persuasion = " + (personnage.modCharisme + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Persuasion = " + (personnage.modCharisme);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Religion"))
            {
                texte = "Religion = " + (personnage.modIntelligence + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Religion = " + (personnage.modIntelligence);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Representation"))
            {
                texte = "Representation = " + (personnage.modCharisme + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Representation = " + (personnage.modCharisme);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Survie"))
            {
                texte = "Survie = " + (personnage.modSagesse + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Survie = " + (personnage.modSagesse);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

            if (competencesMatriseString.Contains("Tromperie"))
            {
                texte = "Tromperie = " + (personnage.modCharisme + personnage.bonusMaitrise);

            }
            else
            {
                texte = "Tromperie = " + (personnage.modCharisme);
            }
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);



            section.AddPageBreak();


            // Page 2

            texte = "Inventaire";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, true);

            foreach(Equipement equipement in personnage.inventaire)
            {
                if(equipement is Arme)
                {
                    Arme arme = (Arme)equipement;

                    texte = "- " + arme.nom + " -> " + arme.deDeDegats + " de dégats";
                    AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);
                    continue;
                }

                if(equipement is Armure)
                {
                    Armure armure = (Armure)equipement;

                    texte = "- " + armure.nom + " -> Classe d'armure : " + armure.classeArmure;

                    if (armure.obtientBonusModDex)
                    {
                        texte += " + modificateur de dextérité";
                        if (armure.bonusModDexEstLimite)
                        {
                            texte += "(maximum de +2)"; 
                        }
                    }

                    AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);
                    continue;
                }

                texte = "- " + equipement.nom;
                AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);
            }


            section.AddPageBreak();

            // Page 3

            foreach (Attribut attribut in personnage.classe.listeAttributs)
            {
                texte = attribut.nom;
                AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, true);

                texte = attribut.description;
                AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, false);

                section.AddParagraph();
            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";

            if (!estTest)
            {    
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath + "\\";
                }
            }

            string filename = nom + ".pdf";
            
            pdfRenderer.PdfDocument.Save(path + filename);

            return (path + filename);

        }

        private void AjouterParagraphe(Section section, string texte, int tailleDePolice, bool enGras)
        {
            Paragraph paragraph = section.AddParagraph();
            FormattedText ft = paragraph.AddFormattedText(texte);
            ft.Font.Size = tailleDePolice;
            ft.Font.Bold = enGras;
            
        }
    }
}
