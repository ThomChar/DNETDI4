using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Controller;
using Bacchus.Model;

namespace Bacchus
{
    public partial class FormModifArticle : Form
    {
        private MagasinDAO magasin;
        private FormMain formMain;

        public FormModifArticle()
        {
            InitializeComponent();
        }

        public FormModifArticle(MagasinDAO magasin, string refArticle, FormMain formMain)
        {
            this.magasin = magasin;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            sousFamilleComboBox.DisplayMember = "Text";
            sousFamilleComboBox.ValueMember = "Value";
            marqueComboBox.DisplayMember = "Text";
            marqueComboBox.ValueMember = "Value";

            // Remplir la combo box avec la liste des Sous-Familles
            
            foreach (SousFamille sfm in this.magasin.ListeSousFamilles)
            {
                sousFamilleComboBox.Items.Add(sfm.Nom + "(" + sfm.RefFamille.Nom + ")");
                //sousFamilleComboBox.Items.Add(new { Text = sfm.Nom /*+ "(" + sfm.RefFamille.Nom + ")"*/, Value = sfm });
            }
            
            // Remplir la combo box avec la liste des Marques
            foreach (Marque mq in this.magasin.ListeMarques)
            {
                //marqueComboBox.Items.Add(mq.Nom);
                marqueComboBox.Items.Add(new { Text = mq.Nom, Value = mq });
            }

            //Recontruire objet  de RefArticle
            
            Article article = this.magasin.ArticleDao.getArticle(refArticle);
            nomArticleOriginLabel.Text = article.RefArticle + "# " + article.Description;
            referenceTextBox.Text = article.RefArticle;
            descriptionTextBox.Text = article.Description;
            
            sousFamilleComboBox.SelectedItem =  article.RefSousFamille.Nom + "(" + article.RefSousFamille.RefFamille.Nom + ")";
            //sousFamilleComboBox.SelectedItem = new { Text = article.RefSousFamille.Nom, Value = article.RefSousFamille };
            marqueComboBox.SelectedItem = new { Text = article.RefMarque.Nom, Value = article.RefMarque };
            
            prixNumericUpDown.Value = Convert.ToDecimal(article.PrixHT);
            quantiteNumericUpDown.Value = article.Quantite;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (referenceTextBox.Text == "ex : refArticle ..." || referenceTextBox.Text == "")
                    throw new Exception("Veuillez inscrire une reference d'article valide avant de valider le formulaire de modification");

                if (descriptionTextBox.Text == "ex : descriptionArticle ..." || descriptionTextBox.Text == "")
                    throw new Exception("Veuillez inscrire une description valide avant de valider le formulaire de modification");

                    
                if (!rx.IsMatch(referenceTextBox.Text) && !rx1.IsMatch(referenceTextBox.Text))
                    throw new Exception("Le format du Champ reference est incorrect (au moins un caractere ou nombre)");

                if (!rx.IsMatch(descriptionTextBox.Text) && !rx1.IsMatch(descriptionTextBox.Text))
                    throw new Exception("Le format du Champ description est incorrect (au moins un caractere ou nombre)");

                if ((sousFamilleComboBox.Text == "ex : nomSousFamille ...") || (sousFamilleComboBox.Text == ""))
                    throw new Exception("Veuillez sélectionner une Sous-Famille valide dans la combo box (autre que ex : nomSousFamille ... ou vide)");


                if ((marqueComboBox.Text == "ex : nomMarque ...") || (marqueComboBox.Text == ""))
                    throw new Exception("Veuillez sélectionner une Marque valide dans la combo box (autre que ex : nomMarque ... ou vide)");

                //Reconstruction de l'objet Article en Local avec les modifications
                Article article = new Article();
                article.RefArticle = referenceTextBox.Text;
                article.Description = descriptionTextBox.Text;
                article.PrixHT = Convert.ToDouble(prixNumericUpDown.Value);
                article.Quantite = Convert.ToInt32(Math.Round(quantiteNumericUpDown.Value, 0));
                article.RefMarque = (marqueComboBox.SelectedItem as dynamic).Value;

                //retrouver la sous famille exact à partir de ce qui est dans sousFamilleComboBox
                char[] delimiterChars = { '(', ')' };
                string[] sousFamilleBoxContent = sousFamilleComboBox.Text.Split(delimiterChars);
                int refFamille = this.magasin.FamilleDao.getFamilleByName(sousFamilleBoxContent[1]).RefFamille;
                article.RefSousFamille = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(refFamille, sousFamilleBoxContent[0]);
                //article.RefSousFamille = (sousFamilleComboBox.SelectedItem as dynamic).Value;

                //Modification de l' Article dans la Base de donnée
                this.magasin.ArticleDao.updateArticle(article);

                // show that the change was successful
                Console.WriteLine(this.magasin.ListeArticles.Find(x => x.Description == article.Description && x.RefSousFamille.Nom == article.RefSousFamille.Nom && x.RefSousFamille.RefFamille.RefFamille == article.RefSousFamille.RefFamille.RefFamille && x.RefMarque.Nom == article.RefMarque.Nom));
                formMain.refreshStatusStrip("L'article " + article.RefArticle + " : " + article.Description + " a été modifié.");

                formMain.refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible de modifier l'article !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
