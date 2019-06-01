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
    public partial class FormAjoutMarque : Form
    {

        private MagasinDAO magasin;
        private FormMain formMain;

        public FormAjoutMarque()
        {
            InitializeComponent();
        }

        public FormAjoutMarque(MagasinDAO magasin, FormMain formMain)
        {
            this.magasin = magasin;
            this.formMain = formMain;
            InitializeComponent();

            // freeze the size of the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // center form
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex("[À-ŸA-Zà-ÿa-z]{1,50}");
            Regex rx1 = new Regex("[0-9]");

            try
            {
                if (nomTextBox.Text == "ex : Marque ..." || nomTextBox.Text == "")
                    throw new Exception("Veuillez inscrire un nom valide avant de valider le formulaire de création");

                if (!rx.IsMatch(nomTextBox.Text) && !rx1.IsMatch(nomTextBox.Text))
                    throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");

                //Création de l'objet Marque en Local
                Marque marque = new Marque();
                marque.Nom = nomTextBox.Text;

                //Ajout de la marque dans la Base de donnée
                this.magasin.MarqueDao.addMarque(marque);

                // show that the adding was successful
                Console.WriteLine(this.magasin.ListeMarques.Find(x => x.Nom == marque.Nom));
                formMain.refreshStatusStrip("La marque " + marque.RefMarque + " : " + marque.Nom + " a été ajoutée.");

                formMain.refresh();
                this.Close();

            }
            catch (Exception ex)
            {
                // show error
                formMain.refreshStatusStrip("Erreur : " + ex.Message);
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(ex.Message, "Impossible d'ajouter la marque !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nomTextBox_Enter(object sender, EventArgs e)
        {
            if(nomTextBox.Text == "ex : Marque ...")
            {
                nomTextBox.Text = "";
                nomTextBox.ForeColor = Color.Black;
                nomTextBox.Font = new Font(nomTextBox.Font, FontStyle.Regular);
            }
        }
    }
}
