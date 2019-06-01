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
    public partial class FormModifSousFamille : Form
    {
        private MagasinDAO magasin;
        private SousFamille sousFamille;
        private FormMain formMain;

        public FormModifSousFamille()
        {
            InitializeComponent();
        }

        public FormModifSousFamille(MagasinDAO magasin, SousFamille sousFamille, FormMain formMain)
        {
            this.magasin = magasin;
            this.sousFamille = sousFamille;
            this.formMain = formMain;
            InitializeComponent();
            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            familleComboBox.DisplayMember = "Text";
            familleComboBox.ValueMember = "Value";
            //nomSousFamilleOriginLabel.Text = sousFamille.Nom +" ("+ sousFamille.RefFamille.Nom +")";

            // Remplir la combo box avec la liste des Familles
            foreach (Famille fm in this.magasin.ListeFamilles)
            {
                familleComboBox.Items.Add(new { Text = fm.Nom, Value = fm});
            }

            //Recontruire objet de sousFamille
            nomSousFamilleOriginLabel.Text = sousFamille.Nom+ " (" + sousFamille.RefFamille.Nom + ")";
            nomTextBox.Text = sousFamille.Nom;
            familleComboBox.SelectedItem = new{ Text = sousFamille.RefFamille.Nom, Value = sousFamille.RefFamille};
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (nomTextBox.Text == "ex : Sous-Famille ..." || nomTextBox.Text == "")
                    throw new Exception("Veuillez inscrire un nom valide avant de valider le formulaire de création");

                if (!rx.IsMatch(nomTextBox.Text) && !rx1.IsMatch(nomTextBox.Text))
                    throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");

                if ((familleComboBox.Text == "ex : nomFamille ...") || (familleComboBox.Text == ""))
                    throw new Exception("Veuillez sélectionner un Famille valide dans la combo box (autre que ex : nomFamille ... ou vide)");

                Famille stmp = (familleComboBox.SelectedItem as dynamic).Value;
                SousFamille subFamilyAlreadyExists = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(stmp.RefFamille, nomTextBox.Text);
                if (subFamilyAlreadyExists != null && subFamilyAlreadyExists.RefSousFamille != sousFamille.RefSousFamille)
                    throw new Exception("Ce nom existe déjà pour cette Famille, veuillez sélectionner un autre coup Nom/Famille valide");

                //Récupération de l'objet Sous-Famille en Local
                this.sousFamille.Nom = nomTextBox.Text;
                this.sousFamille.RefFamille = (familleComboBox.SelectedItem as dynamic).Value;

                //Modification de la SousFamille dans la Base de donnée
                this.magasin.SousFamilleDao.updateSousFamille(this.sousFamille);

                // show that the change was successful
                Console.WriteLine(this.magasin.ListeSousFamilles.Find(x => x.Nom == sousFamille.Nom && x.RefFamille.Nom == sousFamille.RefFamille.Nom));
                formMain.refreshStatusStrip("La sous-famille " + sousFamille.RefSousFamille + " : " + sousFamille.Nom + " a été modifiée.");

                formMain.refresh();
                this.Close();
                  

            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible de modifier la sous-famille !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
