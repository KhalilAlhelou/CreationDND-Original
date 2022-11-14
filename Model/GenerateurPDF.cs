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

        public void GenererLePDFDuPersonnage(Personnage personnage, bool estTest)
        {
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
                
            }

            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL, true);

            section.AddPageBreak();


            // Page 2

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
            System.Diagnostics.Process.Start(@path + filename);

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
