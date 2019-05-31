using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Marque
    {
        private int refMarque;
        private string nom;

        public Marque(){
        }

        public Marque(int refMarque, string nom){
            this.refMarque = refMarque;
            this.nom = nom;
        }

        //propriétés
        public int RefMarque{
            get { return refMarque; }
            set{    //refMarque valide ?
                if (value <= 0){
                    throw new Exception("refMarque (" + value + ") invalide");
                }else{
                    refMarque = value;
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
            Marque m = obj as Marque;
            if (m == null) return false;
            return refMarque== m.RefMarque &&
                   nom == m.Nom;
        }

        public override int GetHashCode()
        {
            var hashCode = -945976064;
            hashCode = hashCode * -1521134295 + refMarque.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + RefMarque.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            return hashCode;
        }

        public override string ToString(){
            return "Marque: " + refMarque + ", " + nom;
        }
    }
}
