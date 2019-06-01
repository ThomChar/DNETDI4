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
using Bacchus.Model;

namespace Bacchus
{
    public partial class FormModifFamille : Form
    {
        private MagasinDAO magasin;
        private Famille famille;

        public FormModifFamille()
        {
            InitializeComponent();
        }

        public FormModifFamille(MagasinDAO magasin, Famille famille)
        {
            this.magasin = magasin;
            this.famille = famille;
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
            if (nomTextBox.Text == "ex : Famille ..." || nomTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire un nom valide avant de valider le formulaire de création", "Erreur Générée lors de Création Famille", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Regex rx = new Regex("[À-ŸA-Z]{1}[à-ÿa-z]{0,39}");
                    Regex rx = new Regex("[a-z]");
                    Regex rx1 = new Regex("[0-9]");
                    if (rx.IsMatch(nomTextBox.Text) || rx1.IsMatch(nomTextBox.Text))
                    {
                        if (this.magasin.FamilleDao.getFamilleByName(nomTextBox.Text) == null)
                        {
                            //Création de l'objet Famille en Local
                            //Famille famille = new Famille();
                            famille.Nom = nomTextBox.Text;
                            //Ajout de la famille dans la Base de donnée
                            this.magasin.FamilleDao.updateFamille(famille);

                            Console.WriteLine(this.magasin.ListeFamilles.Find(x => x.Nom == famille.Nom));
                            MessageBox.Show("Famille " + nomFamilleOriginLabel.Text.ToString() + " a été modifié, son nouveau nom est " + famille.Nom, "Succès Création Famille", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else {
                            throw new Exception("Une marque possède déjà ce nom, veuillez en chosir un autre (au moins un caractere ou nombre)");
                        }
                    }
                    else
                    {
                        throw new Exception("Le format du Champ nom est incorrect (au moins un caractere ou nombre)");
                    }
                }
                catch (Exception ex)
                {
                    //ex.GetBaseException();
                    MessageBox.Show(ex.Message, "Erreur Création Famille", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
