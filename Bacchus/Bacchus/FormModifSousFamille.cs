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
    public partial class FormModifSousFamille : Form
    {
        private MagasinDAO magasin;
        private SousFamille sousFamille;

        public FormModifSousFamille()
        {
            InitializeComponent();
        }

        public FormModifSousFamille(MagasinDAO magasin, SousFamille sousFamille )
        {
            this.magasin = magasin;
            this.sousFamille = sousFamille;
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
                //familleComboBox.Items.Add(fm.Nom);
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
                            Famille stmp = (familleComboBox.SelectedItem as dynamic).Value;
                            if (this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(stmp.RefFamille, nomTextBox.Text) == null)
                            {
                                //Récupération de l'objet Sous-Famille en Local
                                //SousFamille sousFamille = new SousFamille();
                                this.sousFamille.Nom = nomTextBox.Text;
                                this.sousFamille.RefFamille = (familleComboBox.SelectedItem as dynamic).Value;

                                //Modification de la SousFamille dans la Base de donnée
                                this.magasin.SousFamilleDao.updateSousFamille(this.sousFamille);

                                Console.WriteLine(this.magasin.ListeSousFamilles.Find(x => x.Nom == sousFamille.Nom && x.RefFamille.Nom == sousFamille.RefFamille.Nom));
                                MessageBox.Show("Sous-famille " + sousFamille.ToString() + " a été ajouté", "Succès Création Sous-famille", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                throw new Exception("Ce nom existe déjà pour cette Famille, veuillez sélectionner un autre coup Nom/Famille valide");
                            }
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
    }
}
