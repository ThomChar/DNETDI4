using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormSelectionnerObjModif : Form
    {
        private MagasinDAO magasin;
        private FormMain formMain;
        private string typeObjet;  //Marque, Famille, Sous-Famille, Article,

        public FormSelectionnerObjModif()
        {
            InitializeComponent();
        }

        public FormSelectionnerObjModif(MagasinDAO magasin, string typeObjet, FormMain formMain)
        {
            this.magasin = magasin;
            this.formMain = formMain;
            InitializeComponent();
            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            ObjetComboBox.DisplayMember = "Text";
            ObjetComboBox.ValueMember = "Value";
            if (typeObjet == "Article")
            {
                this.typeObjet = typeObjet;
                title_label.Text = "Selectionner " + typeObjet  + " :";
                objetLabel.Text = typeObjet + " :";
                // Remplir la combo box avec la liste des Articles
                foreach (Article art in this.magasin.ListeArticles)
                {
                    ObjetComboBox.Items.Add(new { Text = art.RefArticle + "#" + art.Description, Value = art.RefArticle });
                }
            }
            else if (typeObjet == "Sous-Famille")
            {
                this.typeObjet = typeObjet;
                title_label.Text = "Selectionner " + typeObjet + " :";
                objetLabel.Text = typeObjet + " :";
                // Remplir la combo box avec la liste des Sous-Familles
                foreach (SousFamille sfm in this.magasin.ListeSousFamilles)
                {
                    ObjetComboBox.Items.Add(new { Text = sfm.Nom + "(" + sfm.RefFamille.Nom + ")", Value = sfm });
                }
            }
            else if (typeObjet == "Famille")
            {
                this.typeObjet = typeObjet;
                title_label.Text = "Selectionner " + typeObjet + " :";
                objetLabel.Text = typeObjet + " :";
                // Remplir la combo box avec la liste des Familles
                foreach (Famille fm in this.magasin.ListeFamilles)
                {
                    ObjetComboBox.Items.Add(new { Text = fm.Nom, Value = fm });
                }
            }
            else if (typeObjet == "Marque")
            {
                this.typeObjet = typeObjet;
                title_label.Text = "Selectionner " + typeObjet + " :";
                objetLabel.Text = typeObjet + " :";
                // Remplir la combo box avec la liste des Articles
                foreach (Marque mq in this.magasin.ListeMarques)
                {
                    ObjetComboBox.Items.Add(new { Text = mq.Nom, Value = mq });
                }
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (ObjetComboBox.Text != "")
            {
                if (typeObjet == "Article")
                {
                    FormModifArticle formModifArticle = new FormModifArticle(magasin, (ObjetComboBox.SelectedItem as dynamic).Value, formMain);
                    formModifArticle.ShowDialog();
                    Close();
                }
                else if (typeObjet == "Sous-Famille")
                {
                    FormModifSousFamille formModifSousFamille = new FormModifSousFamille(magasin, (ObjetComboBox.SelectedItem as dynamic).Value, formMain);
                    formModifSousFamille.ShowDialog();
                    Close();
                }
                else if (typeObjet == "Famille")
                {
                    FormModifFamille formModifFamille = new FormModifFamille(magasin, (ObjetComboBox.SelectedItem as dynamic).Value, formMain);
                    formModifFamille.ShowDialog();
                    Close();
                }
                else if (typeObjet == "Marque")
                {
                    FormModifMarque formModifMarque = new FormModifMarque(magasin, (ObjetComboBox.SelectedItem as dynamic).Value, formMain);
                    formModifMarque.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un objet à modifier avant d'appuyer sur le bouton Modifier", "Erreur Gestionnaire Modifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner un objet à modifier avant d'appuyer sur le bouton Modifier", "Erreur Gestionnaire Modifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
