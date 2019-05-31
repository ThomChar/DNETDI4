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
        private string typeObjet;  //Marque, Famille, Sous-Famille, Article,

        public FormSelectionnerObjModif()
        {
            InitializeComponent();
        }

        public FormSelectionnerObjModif(MagasinDAO magasin, string typeObjet)
        {
            this.magasin = magasin;
            InitializeComponent();
            if (typeObjet == "Article")
            {
                this.typeObjet = typeObjet;
                title_label.Text = "Selectionner " + typeObjet  + " :";
                objetLabel.Text = typeObjet + " :";
                // Remplir la combo box avec la liste des Articles
                foreach (Article art in this.magasin.ListeArticles)
                {
                    ObjetComboBox.Items.Add(art.RefArticle + "#" + art.Description);
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
                    ObjetComboBox.Items.Add(sfm.Nom + "(" + sfm.RefFamille.Nom + ")");
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
                    ObjetComboBox.Items.Add(fm.Nom);
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
                    ObjetComboBox.Items.Add(mq.Nom);
                }
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (typeObjet == "Article")
            {
                FormModifArticle formModifArticle = new FormModifArticle(magasin, ObjetComboBox.Text);
                formModifArticle.ShowDialog();
                Close();
            }
            else if (typeObjet == "Sous-Famille")
            {
                FormModifSousFamille formModifSousFamille = new FormModifSousFamille(magasin, ObjetComboBox.Text);
                formModifSousFamille.ShowDialog();
                Close();
            }
            else if (typeObjet == "Famille")
            {
                FormModifFamille formModifFamille = new FormModifFamille(magasin, ObjetComboBox.Text);
                formModifFamille.ShowDialog();
                Close();
            }
            else if (typeObjet == "Marque")
            {
                FormModifMarque formModifMarque = new FormModifMarque(magasin, ObjetComboBox.Text);
                formModifMarque.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un objet à modifier avant d'appuyer sur le bouton Modifier", "Erreur Gestionnaire Modifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
