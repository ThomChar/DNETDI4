using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;

namespace Bacchus
{
    public partial class FormModifArticle : Form
    {
        private MagasinDAO magasin;

        public FormModifArticle()
        {
            InitializeComponent();
        }

        public FormModifArticle(MagasinDAO magasin, string nomArticle)
        {
            this.magasin = magasin;
            InitializeComponent();

            // Remplir la combo box avec la liste des Sous-Familles
            foreach (SousFamille sfm in this.magasin.ListeSousFamilles)
            {
                sousFamilleComboBox.Items.Add(sfm.Nom + "(" + sfm.RefFamille.Nom + ")");
            }
            
            // Remplir la combo box avec la liste des Marques
            foreach (Marque mq in this.magasin.ListeMarques)
            {
                marqueComboBox.Items.Add(mq.Nom);
            }
            
            //obtenir la RefArticle
            char[] delimiterChars = { '#' };
            string[] articleBoxContent = nomArticle.Split(delimiterChars);
            string refArticle = articleBoxContent[0];
            //Recontruire objet  de RefArticle
            nomArticleOriginLabel.Text = articleBoxContent[0] + "# " + articleBoxContent[1];
            Article article = this.magasin.ArticleDao.getArticle(refArticle);
            referenceTextBox.Text = article.RefArticle;
            descriptionTextBox.Text = article.Description;
            sousFamilleComboBox.SelectedItem = article.RefSousFamille.Nom + "("+ article.RefSousFamille.RefFamille.Nom + ")";
            marqueComboBox.SelectedItem = article.RefMarque.Nom;
            prixNumericUpDown.Value = Convert.ToDecimal(article.PrixHT);
            quantiteNumericUpDown.Value = article.Quantite;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

       
    }
}
