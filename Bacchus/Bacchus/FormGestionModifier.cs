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
    public partial class FormGestionModifier : Form
    {
        private MagasinDAO magasin;

        public FormGestionModifier()
        {
            InitializeComponent();
        }

        public FormGestionModifier(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            /*if (objectComboBox.Text == "Article")
            {
                FormModifArticle formModifArticle = new FormModifArticle(magasin);
                formModifArticle.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Sous-Famille")
            {
                FormModifSousFamille formModifSousFamille = new FormModifSousFamille(magasin);
                formModifSousFamille.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Famille")
            {
                FormModifFamille formModifFamille = new FormModifFamille(magasin);
                formModifFamille.ShowDialog();
                Close();
            }
            else if (objectComboBox.Text == "Marque")
            {
                FormModifMarque formModifMarque = new FormModifMarque(magasin);
                formModifMarque.ShowDialog();
                Close();
            }*/
            if (objectComboBox.Text != "")
            {
                FormSelectionnerObjModif formSelectionnerObjModif = new FormSelectionnerObjModif(magasin, objectComboBox.Text);
                formSelectionnerObjModif.ShowDialog();
                Close();

            }
            else
            {
                MessageBox.Show("Veuillez selectionner un objet à modifier avant d'appuyer sur le bouton Modifier", "Erreur Gestionnaire Modifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
