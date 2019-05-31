using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Article
    {
        private string refArticle;
        private string description;
        private SousFamille refSousFamille;
        private Marque refMarque;
        private double prixHT;
        private int quantite;

        public Article(){
        }

        public Article(string refArticle, string description, SousFamille refSousFamille, Marque refMarque, double prixHT, int quantite){
            this.refArticle = refArticle;
            this.description = description;
            this.refSousFamille = refSousFamille;
            this.refMarque = refMarque;
            this.prixHT = prixHT;
            this.quantite = quantite;
        }

        //propriétés
        public string RefArticle{
            get { return refArticle; }
            set{    //refArticle valide ?
                if (value == null || value.Trim().Length == 0){
                    throw new Exception("refArticle ("+value+") invalide");
                }else{
                    refArticle = value;
                }
            }
        }

        public string Description{
            get { return description; }
            set{    //description valide ?
                if (value == null || value.Trim().Length == 0){
                    throw new Exception("description (" + value + ") invalide");
                }else{
                    description = value;
                }
            }
        }

        public SousFamille RefSousFamille{
            get { return refSousFamille; }
            set{    //refSousFamille valide ?
                if (value == null){
                    throw new Exception("refSousFamille (" + value + ") invalide");
                }else{
                    refSousFamille = value;
                }
            }
        }

        public Marque RefMarque{
            get { return refMarque; }
            set{    //refMarque valide ?
                if (value == null){
                    throw new Exception("refMarque (" + value + ") invalide");
                }else {
                    refMarque = value;
                }
            }
        }

        public double PrixHT
        {
            get { return prixHT; }
            set{    //prixHT valide ?
                /*if (value >= 0.00){
                    throw new Exception("prixHT (" + value + ") invalide");
                }else{*/
                    prixHT = value;
                //}
            }
        }

        public int Quantite{
            get { return quantite; }
            set {    //quantite valide ?
                /*if (value >= 0) { 
                    throw new Exception("quantite (" + value + ") invalide");
                }else{*/
                    quantite = value;
                //}
            }
        }

        //Overide de la methode equals pour comparer les objets par rapport aux attributs
        public override bool Equals(object obj)
        {
            Article a = obj as Article;
            if (a == null) return false;
            return refArticle == a.RefArticle &&
                   description == a.Description &&
                   refSousFamille == a.RefSousFamille &&
                   refMarque == a.RefMarque &&
                   prixHT == a.PrixHT &&
                   quantite == a.Quantite;
        }

        public override int GetHashCode()
        {
            var hashCode = -846460144;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(refArticle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + EqualityComparer<SousFamille>.Default.GetHashCode(refSousFamille);
            hashCode = hashCode * -1521134295 + EqualityComparer<Marque>.Default.GetHashCode(refMarque);
            hashCode = hashCode * -1521134295 + prixHT.GetHashCode();
            hashCode = hashCode * -1521134295 + quantite.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RefArticle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<SousFamille>.Default.GetHashCode(RefSousFamille);
            hashCode = hashCode * -1521134295 + EqualityComparer<Marque>.Default.GetHashCode(RefMarque);
            hashCode = hashCode * -1521134295 + PrixHT.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantite.GetHashCode();
            return hashCode;
        }

        public override string ToString(){
            return "Article: " + refArticle + ", " + description + ", " + refSousFamille + ", " + refMarque + " " + prixHT + ", " + quantite;
        }
    }
}
