using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Famille
    {
        private int refFamille;
        private string nom;

        public Famille(){
        }

        public Famille(int refFamille, string nom){
            this.refFamille = refFamille;
            this.nom = nom;
        }

        //propriétés
        public int RefFamille{
            get { return refFamille; }
            set{    //refFamille valide ?
                if (value <= 0){
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
        public override bool Equals(object obj)
        {
            Famille f = obj as Famille;
            if (f == null) return false;
            return refFamille == f.refFamille &&
                   nom == f.nom;
        }

        public override string ToString(){
            return "Famille: " + refFamille + ", " + nom;
        }
    }
}
