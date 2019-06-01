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
    public partial class FormAjoutSousFamille : Form
    {
        private MagasinDAO magasin;
        private FormMain formMain;

        public FormAjoutSousFamille()
        {
            InitializeComponent();
        }

        public FormAjoutSousFamille(MagasinDAO magasin, FormMain formMain)
        {
            this.magasin = magasin;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            familleComboBox.DisplayMember = "Text";
            familleComboBox.ValueMember = "Value";

            // Remplir la combo box avec la liste des Familles
            foreach (Famille fm in this.magasin.ListeFamilles)
            {
                familleComboBox.Items.Add(new { Text = fm.Nom, Value = fm });
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (nomTextBox.Text == "ex : Sous-Famille ..." || nomTextBox.Text == "")
                    throw new Exception("Veuillez inscrire un nom valide avant de valider le formulaire de création");
                
                if (!rx.IsMatch(nomTextBox.Text) && !rx1.IsMatch(nomTextBox.Text))
                    throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");

                if (familleComboBox.SelectedIndex == -1)
                    throw new Exception("Veuillez sélectionner une famille valide dans la combo box");

                Famille stmp = (familleComboBox.SelectedItem as dynamic).Value;

                //Création de l'objet Sous-Famille en Local
                SousFamille sousFamille = new SousFamille();
                sousFamille.Nom = nomTextBox.Text;
                sousFamille.RefFamille = stmp;

                //Ajout de la SousFamille dans la Base de donnée
                this.magasin.SousFamilleDao.addSousFamille(sousFamille);

                // show that the change was successful
                Console.WriteLine(this.magasin.ListeSousFamilles.Find(x => x.Nom == sousFamille.Nom && x.RefFamille.Nom == sousFamille.RefFamille.Nom));
                formMain.refreshStatusStrip("La sous-famille " + sousFamille.RefSousFamille + " : " + sousFamille.Nom + " a été ajoutée.");

                formMain.refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible d'ajouter la sous-famille !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nomTextBox_Enter(object sender, EventArgs e)
        {
            if (nomTextBox.Text == "ex : Sous-Famille ...")
            {
                nomTextBox.Text = "";
                nomTextBox.ForeColor = Color.Black;
                nomTextBox.Font = new Font(nomTextBox.Font, FontStyle.Regular);
            }
        }
    }
}
