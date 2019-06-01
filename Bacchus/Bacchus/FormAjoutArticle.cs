using Bacchus.Controller;
using Bacchus.Model;
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

namespace Bacchus
{
    public partial class FormAjoutArticle : Form
    {
        private MagasinDAO magasin;
        private FormMain formMain;

        public FormAjoutArticle()
        {
            InitializeComponent();
        }

        public FormAjoutArticle(MagasinDAO magasin, FormMain formMain)
        {
            this.magasin = magasin;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

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
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (descriptionTextBox.Text == "ex : descriptionArticle ..." || descriptionTextBox.Text == "")
                    throw new Exception("Veuillez inscrire une description valide avant de valider le formulaire de création");

                if (!rx.IsMatch(referenceTextBox.Text) && !rx1.IsMatch(referenceTextBox.Text) || referenceTextBox.Text.Length != 8)
                    throw new Exception("La référence doit être composé de 8 caractères.");

                if (rx.IsMatch(descriptionTextBox.Text) && rx1.IsMatch(descriptionTextBox.Text))
                    throw new Exception("Le format du Champ description est incorrect (au moins un caractere ou nombre)");

                if (sousFamilleComboBox.SelectedIndex == -1)
                    throw new Exception("Veuillez sélectionner une Sous-Famille valide dans la combo box");

                if (marqueComboBox.SelectedIndex == -1)
                    throw new Exception("Veuillez sélectionner une Marque valide dans la combo box");

                //Création de l'objet Article en Local
                Article article = new Article();
                article.RefArticle = referenceTextBox.Text;
                article.Description = descriptionTextBox.Text;

                article.PrixHT = Convert.ToDouble(prixNumericUpDown.Value);
                article.Quantite = Convert.ToInt32(Math.Round(quantiteNumericUpDown.Value, 0));
                article.RefMarque = this.magasin.MarqueDao.getMarqueByName(marqueComboBox.Text);

                //retrouver la sous famille exact à partir de ce qui est dans sousFamilleComboBox
                char[] delimiterChars = { '(', ')' };
                string[] sousFamilleBoxContent = sousFamilleComboBox.Text.Split(delimiterChars);
                int refFamille = this.magasin.FamilleDao.getFamilleByName(sousFamilleBoxContent[1]).RefFamille;
                article.RefSousFamille = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(refFamille, sousFamilleBoxContent[0]);
                //Ajout de la Article dans la Base de donnée
                this.magasin.ArticleDao.addArticle(article);

                // show that the adding was successful
                Console.WriteLine(this.magasin.ListeArticles.Find(x => x.Description == article.Description && x.RefSousFamille.Nom == article.RefSousFamille.Nom && x.RefSousFamille.RefFamille.RefFamille == article.RefSousFamille.RefFamille.RefFamille && x.RefMarque.Nom == article.RefMarque.Nom));
                formMain.refreshStatusStrip("L'article " + article.RefArticle + " : " + article.Description + " a été ajouté.");

                formMain.refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible d'ajouter l'article !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void referenceTextBox_Enter(object sender, EventArgs e)
        {
            if (referenceTextBox.Text == "ex : refArticle ...")
            {
                referenceTextBox.Text = "";
                referenceTextBox.ForeColor = Color.Black;
                referenceTextBox.Font = new Font(referenceTextBox.Font, FontStyle.Regular);
            }
        }

        private void descriptionTextBox_Enter(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text == "ex : descriptionArticle ...")
            {
                descriptionTextBox.Text = "";
                descriptionTextBox.ForeColor = Color.Black;
                descriptionTextBox.Font = new Font(descriptionTextBox.Font, FontStyle.Regular);
            }
        }
        
    }
}
