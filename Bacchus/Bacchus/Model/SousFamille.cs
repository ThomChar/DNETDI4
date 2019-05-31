using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class SousFamille
    {
        private int refSousFamille;
        private Famille refFamille;
        private string nom;

        public SousFamille(){
        }

        public SousFamille(int refSousFamille, Famille refFamille, string nom)
        {
            this.refSousFamille = refSousFamille;
            this.refFamille = refFamille;
            this.nom = nom;
        }

        //propriétés
        public int RefSousFamille{
            get { return refSousFamille; }
            set{    //refSousFamille valide ?
                if (value <= 0){
                    throw new Exception("refSousFamille (" + value + ") invalide");
                }else{
                    refSousFamille = value;
                }
            }
        }

        public Famille RefFamille{
            get { return refFamille; }
            set {    //refFamille valide ?
                if (value == null){
                    throw new Exception("refFamille (" + value + ") invalide");
                }else{
                    refFamille = value;
                }
            }
        }

        public string Nom{
            get { return nom; }
            set {    //nom valide ?
                if (value == null || value.Trim().Length == 0){
                    throw new Exception("nom (" + value + ") invalide");
                }else{
                    nom = value;
                }
            }
        }

        //Overide de la methode equals pour comparer les objets par rapport aux attributs
        public override bool Equals(object obj){
            SousFamille sf = obj as SousFamille;
            if (sf == null) return false;
            return refSousFamille == sf.RefSousFamille &&
                   refFamille == sf.RefFamille &&
                   nom == sf.Nom;
        }

        public override int GetHashCode()
        {
            var hashCode = 1236327150;
            hashCode = hashCode * -1521134295 + refSousFamille.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Famille>.Default.GetHashCode(refFamille);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + RefSousFamille.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Famille>.Default.GetHashCode(RefFamille);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            return hashCode;
        }

        public override string ToString(){
            return "Sous Famille: " + refSousFamille + ", " + refFamille + ", " + nom;
        }
    }
}
