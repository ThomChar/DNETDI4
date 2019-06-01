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
    public partial class FormModifMarque : Form
    {
        private MagasinDAO magasin;
        private Marque marque;
        private FormMain formMain;

        public FormModifMarque()
        {
            InitializeComponent();
        }

        public FormModifMarque(MagasinDAO magasin, Marque marque, FormMain formMain)
        {
            this.magasin = magasin;
            this.marque = marque;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;

            this.nomMarqueOriginLabel.Text = marque.Nom;
            this.nomTextBox.Text = marque.Nom;
        }

        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nomTextBox_Enter(object sender, EventArgs e)
        {
            if (nomTextBox.Text == "ex : Marque ...")
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
                if (nomTextBox.Text == "ex : Marque ..." || nomTextBox.Text == "")
                    throw new Exception("Veuillez inscrire un nom valide avant de valider le formulaire de création.");
 
                if (!rx.IsMatch(nomTextBox.Text) && !rx1.IsMatch(nomTextBox.Text))
                    throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");

                //recuperation de l'ancienne Marque
                Marque brandAlreadyExists = this.magasin.MarqueDao.getMarqueByName(nomTextBox.Text);
                if (brandAlreadyExists != null && brandAlreadyExists.RefMarque != marque.RefMarque)
                    throw new Exception("Une marque possède déjà ce nom, veuillez en chosir un autre (au moins un caractere ou nombre)");

                //mise à jour de l'objet Marque en Local
                marque.Nom = nomTextBox.Text;
                //Modification de la marque dans la Base de donnée
                this.magasin.MarqueDao.updateMarque(marque);

                // show that the change was successful
                Console.WriteLine(this.magasin.ListeMarques.Find(x => x.RefMarque == marque.RefMarque));
                formMain.refreshStatusStrip("La marque " + marque.RefMarque + " : " + marque.Nom + " a été modifiée.");

                formMain.refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible de modifier la marque !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
