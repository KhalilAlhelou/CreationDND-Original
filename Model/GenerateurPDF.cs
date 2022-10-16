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
        const int TAILLE_POLICE_NORMAL = 14;
        const int TAILLE_POLICE_TITRE = 20;

        public void GenererLePDFDuPersonnage(Personnage personnage, bool estTest)
        {
            string texte;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Document document = new Document();
            Section section = document.AddSection();

            AjouterParagraphe(section, personnage.nom, TAILLE_POLICE_TITRE);

            section.AddParagraph();

            texte = "Race : " + personnage.race.ToString();
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Classe : " + personnage.classe.ToString();
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            section.AddParagraph();

            texte = "Force = " + personnage.force.ToString() + " (" + personnage.modForce.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Dextérité = " + personnage.dexterite.ToString() + " (" + personnage.modDexterite.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Constitution = " + personnage.constitution.ToString() + " (" + personnage.modConstitution.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Intelligence = " + personnage.intelligence.ToString() + " (" + personnage.modIntelligence.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Sagesse = " + personnage.sagesse.ToString() + " (" + personnage.modSagesse.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);

            texte = "Charisme = " + personnage.charisme.ToString() + " (" + personnage.modCharisme.ToString() + ")";
            AjouterParagraphe(section, texte, TAILLE_POLICE_NORMAL);



            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/";

            if (!estTest)
            {    
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Custom Description";
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath + "/";
                }
               
                
            }

            string nom = personnage.nom;

            if (nom.Equals(""))
            {
                nom = "personnage";
            }
            string filename = nom + ".pdf";
            
            pdfRenderer.PdfDocument.Save(path + filename);



        }

        private void AjouterParagraphe(Section section, string texte, int tailleDePolice)
        {
            Paragraph paragraph = section.AddParagraph();
            FormattedText ft = paragraph.AddFormattedText(texte);
            ft.Font.Size = tailleDePolice;
        }
    }
}
