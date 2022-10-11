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

        public void GenererLePDFDuPersonnage(Personnage personnage)
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

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/";
            
            string filename = personnage.nom + ".pdf";
            
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
