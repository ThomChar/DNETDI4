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
    public partial class FormGestionAjouter : Form
    {
        private MagasinDAO magasin;

        public FormGestionAjouter()
        {
            InitializeComponent();
        }

        public FormGestionAjouter(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (objectComboBox.Text == "Article"){
                //this.Close();

                FormAjoutArticle formAjoutArticle = new FormAjoutArticle(magasin);
                formAjoutArticle.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Sous-Famille")
            {
                FormAjoutSousFamille formAjoutSousFamille = new FormAjoutSousFamille(magasin);
                formAjoutSousFamille.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Famille")
            {
                FormAjoutFamille formAjoutFamille = new FormAjoutFamille(magasin);
                formAjoutFamille.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Marque")
            {
                FormAjoutMarque formAjoutMarque = new FormAjoutMarque(magasin);
                formAjoutMarque.ShowDialog();
                Close();
            }
            else {
                MessageBox.Show("Veuillez selectionner un objet à ajouter avant d'appuyer sur le bouton Ajouter", "Erreur Gestionnaire Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
