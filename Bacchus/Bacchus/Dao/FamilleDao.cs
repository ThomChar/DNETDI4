using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Dao
{
    public class FamilleDao
    {
        private SQLiteConnection sql_con;
        private string dataBasePath;
        private MagasinDAO magasin;

        public FamilleDao()
        {
        }

        public FamilleDao(SQLiteConnection sql_con, string dataBasePath, MagasinDAO magasin)
        {
            this.sql_con = sql_con;
            this.dataBasePath = dataBasePath;
            this.magasin = magasin;
        }

        /// //////////////////////////////////////////////////////FAMILLE////////////////////////////////////////////

        public int getLastIdFamilles()  
        {
            int lastIdFamilles = 0;
            this.sql_con.Open();
            string sql = "SELECT COALESCE(MAX(RefFamille),0) FROM Familles";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                lastIdFamilles = Convert.ToInt32(cmd.ExecuteScalar());
                //Console.WriteLine(lastIdFamilles);
            }
            this.sql_con.Close();
            return lastIdFamilles;

        }

        public Famille addFamille(Famille famille)  //Nom de la famille dpit être unique
        {
            Famille fm = getFamilleByName(famille.Nom);
            if (fm == null)
            {
                //Si la famille n'existe pas cherche le lastId de la table pour l'affecter à la ref de la famille
                famille.RefFamille = getLastIdFamilles() + 1;

                sql_con.Open();
                string sql = "INSERT INTO Familles(RefFamille,Nom) VALUES(@refFamille,@nom)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
                {
                    //int idLastFamilleBD = this.magasin.ListeFamilles[this.magasin.ListeFamilles.Count - 1].RefFamille;
                    //Console.WriteLine(idLastFamilleBD);
                    cmd.Parameters.AddWithValue("@refFamille", famille.RefFamille);
                    cmd.Parameters.AddWithValue("@nom", famille.Nom);
                    cmd.ExecuteNonQuery();
                    fm = famille;
                    //ajout à la liste en local de la nouvelle famille
                    this.magasin.ListeFamilles.Add(famille);
                }
                this.sql_con.Close();
            }
            else
            {
                throw new Exception("Cette Famille existe déjà");
            }
            return fm;
        }

        public Famille updateFamille(Famille famille)
        {
            /*Marque mq = this.magasin.getMarque(marque.RefMarque.ToString());        //obtient l'ancien objet de la base de donnée si besoin
            if (mq != null) //alors on peut effectuer la modification
            {*/
            Famille fm = null;
            //on cherche puis modifie l'objet en local
            for (int i = 0; i < this.magasin.ListeFamilles.Count(); i++)
            {
                if (this.magasin.ListeFamilles[i].RefFamille == famille.RefFamille)
                {
                    this.magasin.ListeFamilles[i].Nom = famille.Nom;
                }
            }

            //Update tous les sousFamilles locals correspondant à cette Famille
            for (int i = 0; i < this.magasin.ListeSousFamilles.Count(); i++)
            {
                if (this.magasin.ListeSousFamilles[i].RefFamille.RefFamille == famille.RefFamille)
                {
                    this.magasin.ListeSousFamilles[i].RefFamille.Nom = famille.Nom;
                }
            }

            //Update tous les articles locals correspondant à cette Famille
            for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
            {
                if (this.magasin.ListeArticles[i].RefSousFamille.RefFamille.RefFamille == famille.RefFamille)
                {
                    this.magasin.ListeArticles[i].RefSousFamille.RefFamille.Nom = famille.Nom;
                }
            }

            sql_con.Open();
            string sql = "UPDATE Familles SET Nom = @nom  WHERE RefFamille=@refFamille";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                cmd.Parameters.AddWithValue("@refFamille", famille.RefFamille);
                cmd.Parameters.AddWithValue("@nom", famille.Nom);
                cmd.ExecuteNonQuery();
                fm = famille;
            }
            this.sql_con.Close();
            return fm;
        }

        public Famille getFamilleByName(string name)
        {

            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille,Nom FROM Familles WHERE Nom =@nom", this.sql_con);
            command.Parameters.AddWithValue("@nom", name);

            sql_con.Open();
            Famille famille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {

                if (sqReader.Read())
                {

                    famille = new Famille(System.Convert.ToInt32(sqReader["RefFamille"]), String.Format("{0}", sqReader["Nom"]));

                }
            }

            sql_con.Close();
            return famille;
        }

        public bool deleteSousFamillesFamille(int refFamille)
        {
            bool deleted = false;
            //On suppose que ref Marque existe
            if (this.magasin.getFamille(refFamille.ToString()) != null)
            {
                //Suppression en local des sousFamille de cette famille
                for (int i = 0; i < this.magasin.ListeSousFamilles.Count(); i++)
                {
                    if (this.magasin.ListeSousFamilles[i].RefFamille.RefFamille == refFamille)
                    {
                        //Suppression en local des sousFamille de cette famille avant suppresion de la sousFamille
                        this.magasin.SousFamilleDao.deleteArticlesSousFamille(this.magasin.ListeSousFamilles[i].RefSousFamille);
                        this.magasin.ListeSousFamilles.Remove(this.magasin.ListeSousFamilles[i]);
                    }
                }

                SQLiteCommand command = new SQLiteCommand("DELETE FROM Sousfamilles WHERE RefFamille=" + refFamille, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
               
                // this.magasin.ListeArticles = listTempArticles;
                deleted = true;
            }
            else
            {
                throw new Exception("La Sous Famille sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteFamille(int refFamille)
        {
            bool deleted = false;
            //Rechercher d'abord si la Famille existe
            if (this.magasin.getFamille(refFamille.ToString()) != null)
            {
                //Commence par suppression de l'ensemble des SousFamilles/Articles de cette Famille
                this.deleteSousFamillesFamille(refFamille);
                SQLiteCommand command = new SQLiteCommand("DELETE FROM Familles WHERE RefFamille=" + refFamille, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
                //Suppression en local de la famille
                Famille fm = this.magasin.getFamille(refFamille.ToString());
                this.magasin.ListeFamilles.Remove(fm);
                deleted = true;
            }
            else
            {
                throw new Exception("La famille sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteAllFamilles( ) 
        {
            bool deleted = false;
            this.magasin.ListeFamilles = new List<Famille>();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Familles", this.sql_con);
            sql_con.Open();
            command.ExecuteNonQuery();
            sql_con.Close();
            deleted = true;
            return deleted;
        }
    }
}
