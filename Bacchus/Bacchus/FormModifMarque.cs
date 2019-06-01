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
    public partial class FormModifMarque : Form
    {
        private MagasinDAO magasin;
        private Marque marque;

        public FormModifMarque()
        {
            InitializeComponent();
        }

        public FormModifMarque(MagasinDAO magasin, Marque marque)
        {
            this.magasin = magasin;
            this.marque = marque;
            InitializeComponent();
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
            if (nomTextBox.Text == "ex : Marque ..." || nomTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire un nom valide avant de valider le formulaire de création", "Erreur Générée lors de Création Marque", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        //recuperation de l'ancienne Marque
                        //Marque originMarque = this.magasin.MarqueDao.getMarqueByName(nomMarqueOriginLabel.Text);
                        /*Marque m = this.magasin.MarqueDao.getMarqueByName(nomTextBox.Text);
                        Console.WriteLine(m.ToString());*/
                        if (this.magasin.MarqueDao.getMarqueByName(nomTextBox.Text)== null)
                        {
                            //mise à jour de l'objet Marque en Local
                            marque.Nom = nomTextBox.Text;
                            //Modification de la marque dans la Base de donnée
                            this.magasin.MarqueDao.updateMarque(marque);

                            Console.WriteLine(this.magasin.ListeMarques.Find(x => x.RefMarque == marque.RefMarque));
                            MessageBox.Show("Marque " + nomMarqueOriginLabel.ToString() + " a été modifié, son nouveau nom est "+marque.Nom, "Succès Création Marque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
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
                    MessageBox.Show(ex.Message, "Erreur Création Marque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
