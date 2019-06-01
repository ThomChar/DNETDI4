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
    public partial class FormModifFamille : Form
    {
        private MagasinDAO magasin;
        private Famille famille;
        private FormMain formMain;

        public FormModifFamille()
        {
            InitializeComponent();
        }

        public FormModifFamille(MagasinDAO magasin, Famille famille, FormMain formMain)
        {
            this.magasin = magasin;
            this.famille = famille;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            nomFamilleOriginLabel.Text = famille.Nom;
            this.nomTextBox.Text = famille.Nom;
        }

        
        private void nomTextBox_Enter(object sender, EventArgs e)
        {
            if (nomTextBox.Text == "ex : Famille ...")
            {
                nomTextBox.Text = "";
                nomTextBox.ForeColor = Color.Black;
                nomTextBox.Font = new Font(nomTextBox.Font, FontStyle.Regular);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (nomTextBox.Text == "ex : Famille ..." || nomTextBox.Text == "")
                    throw new Exception("Veuillez inscrire un nom valide avant de valider le formulaire de création");
                    
                if (!rx.IsMatch(nomTextBox.Text) && !rx1.IsMatch(nomTextBox.Text))
                    throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");

                Famille familyAlreadyExists =this.magasin.FamilleDao.getFamilleByName(nomTextBox.Text);
                if (familyAlreadyExists != null && familyAlreadyExists.RefFamille != famille.RefFamille)
                    throw new Exception("Une marque possède déjà ce nom, veuillez en chosir un autre (au moins un caractere ou nombre)");

                //Création de l'objet Famille en Local
                famille.Nom = nomTextBox.Text;
                //Ajout de la famille dans la Base de donnée
                this.magasin.FamilleDao.updateFamille(famille);

                // show that the change was successful
                Console.WriteLine(this.magasin.ListeFamilles.Find(x => x.Nom == famille.Nom));
                formMain.refreshStatusStrip("La famille " + famille.RefFamille + " : " + famille.Nom + " a été modifiée.");

                formMain.refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible de modifier la famille !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
