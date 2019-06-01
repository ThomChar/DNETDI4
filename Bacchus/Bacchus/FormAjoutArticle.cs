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
    public partial class FormAjoutArticle : Form
    {
        private MagasinDAO magasin;

        public FormAjoutArticle()
        {
            InitializeComponent();
        }

        public FormAjoutArticle(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            // Affectation d'un élément de la combo box à ex : nomSousFamille ... permettant la detection de cette box comme vide
            sousFamilleComboBox.Items.Add("ex : nomSousFamille ...");
            // Remplir la combo box avec la liste des Sous-Familles
            foreach (SousFamille sfm in this.magasin.ListeSousFamilles)
            {
                sousFamilleComboBox.Items.Add(sfm.Nom + "("+ sfm.RefFamille.Nom + ")");
            }

            // Affectation d'un élément de la combo box à ex : NomMarque ... permettant la detection de cette box comme vide
            marqueComboBox.Items.Add("ex : nomMarque ...");
            // Remplir la combo box avec la liste des Marques
            foreach (Marque mq in this.magasin.ListeMarques)
            {
                marqueComboBox.Items.Add(mq.Nom);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (referenceTextBox.Text == "ex : refArticle ..." || referenceTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire une reference d'article valide avant de valider le formulaire de création", "Erreur Générée lors de Création Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (descriptionTextBox.Text == "ex : descriptionArticle ..." || descriptionTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire une description valide avant de valider le formulaire de création", "Erreur Générée lors de Création Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Regex rx = new Regex("[À-ŸA-Z]{1}[à-ÿa-z]{0,39}");
                    Regex rx = new Regex("[a-z]");
                    Regex rx1 = new Regex("[0-9]");
                    if (rx.IsMatch(referenceTextBox.Text) || rx1.IsMatch(referenceTextBox.Text))
                    {
                        if (rx.IsMatch(descriptionTextBox.Text) || rx1.IsMatch(descriptionTextBox.Text))
                        {
                            if (!(sousFamilleComboBox.Text == "ex : nomSousFamille ...") && !(sousFamilleComboBox.Text == ""))
                            {
                                if (!(marqueComboBox.Text == "ex : nomMarque ...") && !(marqueComboBox.Text == ""))
                                {
                                    //Création de l'objet Article en Local
                                    Article article = new Article();
                                    article.RefArticle = referenceTextBox.Text;
                                    article.Description = descriptionTextBox.Text;
                                    //Console.WriteLine("hello");
                                    //Console.WriteLine(Convert.ToDouble(prixNumericUpDown.Value));
                                    article.PrixHT = Convert.ToDouble(prixNumericUpDown.Value);
                                    article.Quantite = Convert.ToInt32(Math.Round(quantiteNumericUpDown.Value, 0));
                                    article.RefMarque = this.magasin.MarqueDao.getMarqueByName(marqueComboBox.Text);

                                    //retrouver la sous famille exact à partir de ce qui est dans sousFamilleComboBox
                                    char[] delimiterChars = { '(', ')' };
                                    string[] sousFamilleBoxContent = sousFamilleComboBox.Text.Split(delimiterChars);
                                    int refFamille = this.magasin.FamilleDao.getFamilleByName(sousFamilleBoxContent[1]).RefFamille;
                                    article.RefSousFamille = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(refFamille, sousFamilleBoxContent[0]);
                                    //Ajout de la Article dans la Base de donnée
                                    this.magasin.ArticleDao.addArticle(article);

                                    Console.WriteLine(this.magasin.ListeArticles.Find(x => x.Description == article.Description && x.RefSousFamille.Nom == article.RefSousFamille.Nom && x.RefSousFamille.RefFamille.RefFamille == article.RefSousFamille.RefFamille.RefFamille && x.RefMarque.Nom == article.RefMarque.Nom));
                                    //MessageBox.Show("Article " + article.ToString() + " a été ajouté", "Succès Création Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    throw new Exception("Veuillez sélectionner une Marque valide dans la combo box (autre que ex : nomMarque ... ou vide)");
                                }
                            }
                            else
                            {
                                throw new Exception("Veuillez sélectionner une Sous-Famille valide dans la combo box (autre que ex : nomSousFamille ... ou vide)");
                            }
                        }
                        else
                        {
                            throw new Exception("Le format du Champ description est incorrect (au moins un caractere ou nombre)");
                        }
                    }
                    else
                    {
                        throw new Exception("Le format du Champ reference est incorrect (au moins un caractere ou nombre)");
                    }
                }
                catch (Exception ex)
                {
                    //ex.GetBaseException();
                    MessageBox.Show(ex.Message, "Erreur Création Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void referenceTextBox_Enter(object sender, EventArgs e)
        {
            if (referenceTextBox.Text == "ex : refArticle ...")
            {
                referenceTextBox.Text = "";
                referenceTextBox.ForeColor = Color.Black;
                referenceTextBox.Font = new Font(referenceTextBox.Font, FontStyle.Regular);
            }
        }

        private void descriptionTextBox_Enter(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text == "ex : descriptionArticle ...")
            {
                descriptionTextBox.Text = "";
                descriptionTextBox.ForeColor = Color.Black;
                descriptionTextBox.Font = new Font(descriptionTextBox.Font, FontStyle.Regular);
            }
        }
        
    }
}
