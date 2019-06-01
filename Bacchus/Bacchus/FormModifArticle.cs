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
    public partial class FormModifArticle : Form
    {
        private MagasinDAO magasin;

        public FormModifArticle()
        {
            InitializeComponent();
        }

        public FormModifArticle(MagasinDAO magasin, string refArticle)
        {
            this.magasin = magasin;
            InitializeComponent();
            sousFamilleComboBox.DisplayMember = "Text";
            sousFamilleComboBox.ValueMember = "Value";
            marqueComboBox.DisplayMember = "Text";
            marqueComboBox.ValueMember = "Value";

            // Remplir la combo box avec la liste des Sous-Familles
            
            foreach (SousFamille sfm in this.magasin.ListeSousFamilles)
            {
                sousFamilleComboBox.Items.Add(sfm.Nom + "(" + sfm.RefFamille.Nom + ")");
                //sousFamilleComboBox.Items.Add(new { Text = sfm.Nom /*+ "(" + sfm.RefFamille.Nom + ")"*/, Value = sfm });
            }
            
            // Remplir la combo box avec la liste des Marques
            foreach (Marque mq in this.magasin.ListeMarques)
            {
                //marqueComboBox.Items.Add(mq.Nom);
                marqueComboBox.Items.Add(new { Text = mq.Nom, Value = mq });
            }

            //Recontruire objet  de RefArticle
            
            Article article = this.magasin.ArticleDao.getArticle(refArticle);
            nomArticleOriginLabel.Text = article.RefArticle + "# " + article.Description;
            referenceTextBox.Text = article.RefArticle;
            descriptionTextBox.Text = article.Description;
            
            sousFamilleComboBox.SelectedItem =  article.RefSousFamille.Nom + "(" + article.RefSousFamille.RefFamille.Nom + ")";
            //sousFamilleComboBox.SelectedItem = new { Text = article.RefSousFamille.Nom, Value = article.RefSousFamille };
            marqueComboBox.SelectedItem = new { Text = article.RefMarque.Nom, Value = article.RefMarque };
            
            prixNumericUpDown.Value = Convert.ToDecimal(article.PrixHT);
            quantiteNumericUpDown.Value = article.Quantite;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (referenceTextBox.Text == "ex : refArticle ..." || referenceTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire une reference d'article valide avant de valider le formulaire de modification", "Erreur Générée lors de modification Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (descriptionTextBox.Text == "ex : descriptionArticle ..." || descriptionTextBox.Text == "")
            {
                MessageBox.Show("Veuillez inscrire une description valide avant de valider le formulaire de modification", "Erreur Générée lors de modification Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
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
                                    //Reconstruction de l'objet Article en Local avec les modifications
                                    Article article = new Article();
                                    article.RefArticle = referenceTextBox.Text;
                                    article.Description = descriptionTextBox.Text;
                                    article.PrixHT = Convert.ToDouble(prixNumericUpDown.Value);
                                    article.Quantite = Convert.ToInt32(Math.Round(quantiteNumericUpDown.Value, 0));
                                    article.RefMarque = (marqueComboBox.SelectedItem as dynamic).Value;

                                    //retrouver la sous famille exact à partir de ce qui est dans sousFamilleComboBox
                                    char[] delimiterChars = { '(', ')' };
                                    string[] sousFamilleBoxContent = sousFamilleComboBox.Text.Split(delimiterChars);
                                    int refFamille = this.magasin.FamilleDao.getFamilleByName(sousFamilleBoxContent[1]).RefFamille;
                                    article.RefSousFamille = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(refFamille, sousFamilleBoxContent[0]);
                                    //article.RefSousFamille = (sousFamilleComboBox.SelectedItem as dynamic).Value;

                                    //Modification de l' Article dans la Base de donnée
                                    this.magasin.ArticleDao.updateArticle(article);

                                    Console.WriteLine(this.magasin.ListeArticles.Find(x => x.Description == article.Description && x.RefSousFamille.Nom == article.RefSousFamille.Nom && x.RefSousFamille.RefFamille.RefFamille == article.RefSousFamille.RefFamille.RefFamille && x.RefMarque.Nom == article.RefMarque.Nom));
                                    MessageBox.Show("Article " + article.ToString() + " a été modifié", "Succès Modification Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(ex.Message, "Erreur Modification Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
