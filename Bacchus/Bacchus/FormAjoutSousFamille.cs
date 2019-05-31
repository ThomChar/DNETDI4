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

        public FormAjoutSousFamille()
        {
            InitializeComponent();
        }

        public FormAjoutSousFamille(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            // Affectation d'u élément de la combo box à ex : NomFamille ... permettant la detection de cette box comme vide
                familleComboBox.Items.Add("ex : nomFamille ...");
            // Remplir la combo box avec la liste des Familles
            foreach (Famille fm in this.magasin.ListeFamilles)
            {
                familleComboBox.Items.Add(fm.Nom);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nomTextBox.Text == "ex : Sous-Famille ..." || nomTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire un nom valide avant de valider le formulaire de création", "Erreur Générée lors de Création Sous-Famille", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (!(familleComboBox.Text == "ex : nomFamille ...") && !(familleComboBox.Text == ""))
                        {
                            //Création de l'objet Sous-Famille en Local
                            SousFamille sousFamille = new SousFamille();
                            sousFamille.Nom = nomTextBox.Text;
                            sousFamille.RefFamille = this.magasin.FamilleDao.getFamilleByName(familleComboBox.Text);

                            //Ajout de la SousFamille dans la Base de donnée
                            this.magasin.SousFamilleDao.addSousFamille(sousFamille);
                            Console.WriteLine(this.magasin.ListeSousFamilles.Find(x => x.Nom == sousFamille.Nom && x.RefFamille.Nom == sousFamille.RefFamille.Nom));
                            //MessageBox.Show("Sous-famille " + sousFamille.ToString() + " a été ajouté", "Succès Création Sous-famille", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Veuillez sélectionner un Famille valide dans la combo box (autre que ex : nomFamille ... ou vide)");
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
