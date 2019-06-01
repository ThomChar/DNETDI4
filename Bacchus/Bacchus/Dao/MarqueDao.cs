using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Dao
{
    public class MarqueDao
    {
        private SQLiteConnection sql_con;
        private string dataBasePath;
        private MagasinDAO magasin;

        public MarqueDao()
        {
        }

        public MarqueDao(SQLiteConnection sql_con, string dataBasePath, MagasinDAO magasin)
        {
            this.sql_con = sql_con;
            this.dataBasePath = dataBasePath;
            this.magasin = magasin;
        }

        /// //////////////////////////////////////////////////////MARQUE/////////////////////////////////////////////

        public int getLastIdMarques()
        {
            int lastIdMarques = 0;
            this.sql_con.Open();
            string sql = "SELECT COALESCE(MAX(RefMarque),0) FROM Marques";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                lastIdMarques = Convert.ToInt32(cmd.ExecuteScalar());
                //Console.WriteLine(lastIdMarques);
            }
            this.sql_con.Close();
            return lastIdMarques;

        }

        public Marque addMarque(Marque marque)  //Nom de la marque doit être unique
        {
            Marque mq = getMarqueByName(marque.Nom);
            if (mq == null)
            {
                //Si la marque n'existe pas cherche le lastId de la table pour l'affecter à la ref de la marque
                marque.RefMarque = getLastIdMarques() + 1;

                sql_con.Open();
                string sql = "INSERT INTO Marques(RefMarque,Nom) VALUES(@refMarque,@nom)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
                {
                    //int idLastFamilleBD = this.magasin.ListeFamilles[this.magasin.ListeFamilles.Count - 1].RefFamille;
                    //Console.WriteLine(idLastFamilleBD);
                    cmd.Parameters.AddWithValue("@refMarque", marque.RefMarque);
                    cmd.Parameters.AddWithValue("@nom", marque.Nom);
                    cmd.ExecuteNonQuery();
                    mq = marque;
                    //ajout à la liste en local de la nouvelle famille
                    this.magasin.ListeMarques.Add(marque);
                }
                this.sql_con.Close();
            }
            else
            {
                throw new Exception("Cette Marque existe déjà");
            }
            return mq;
        }

        public Marque updateMarque(Marque marque)  
        {
            /*Marque mq = this.magasin.getMarque(marque.RefMarque.ToString());        //obtient l'ancien objet de la base de donnée si besoin
            if (mq != null) //alors on peut effectuer la modification
            {*/
            Marque mq = null;
                //on cherche puis modifie l'objet en local
                for (int i = 0; i< this.magasin.ListeMarques.Count();i++){
                    if (this.magasin.ListeMarques[i].RefMarque == marque.RefMarque)
                    {
                        this.magasin.ListeMarques[i].Nom = marque.Nom;
                    }
                }

                //Update tous les articles locals correspondant à cette marque
                for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
                {
                    if (this.magasin.ListeArticles[i].RefMarque.RefMarque == marque.RefMarque)
                    {
                        this.magasin.ListeArticles[i].RefMarque.Nom = marque.Nom;
                    }
                }

            sql_con.Open();
                string sql = "UPDATE Marques SET Nom = @nom  WHERE RefMarque=@refMarque";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
                {
                    cmd.Parameters.AddWithValue("@refMarque", marque.RefMarque);
                    cmd.Parameters.AddWithValue("@nom", marque.Nom);
                    cmd.ExecuteNonQuery();
                    mq = marque;
                }
                this.sql_con.Close();
            return mq;
        }

        public Marque getMarqueByName(string name)
        {

            SQLiteCommand command = new SQLiteCommand("SELECT RefMarque,Nom FROM Marques WHERE Nom =@nom", this.sql_con);
            command.Parameters.AddWithValue("@nom", name);

            sql_con.Open();
            Marque marque = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {

                if (sqReader.Read())
                {
                   
                    marque = new Marque(System.Convert.ToInt32(sqReader["RefMarque"]), String.Format("{0}", sqReader["Nom"]));

                }
            }

            sql_con.Close();
            return marque;
        }

        public bool deleteArticlesMarque(int refMarque)
        {
            bool deleted = false;
            //On suppose que ref Marque existe
            if (this.magasin.getMarque(refMarque.ToString()) != null)
            {
                //Suppression en local des articles de cette marques

                for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
                {
                    if (this.magasin.ListeArticles[i].RefMarque.RefMarque == refMarque)
                    {
                        this.magasin.ListeArticles.Remove(this.magasin.ListeArticles[i]);
                    }
                }

                SQLiteCommand command = new SQLiteCommand("DELETE FROM Articles WHERE RefMarque=" + refMarque, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
                

                deleted = true;
            }else{
                throw new Exception("La marque sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteMarque(int refMarque)
        {
            bool deleted = false;
            //Rechercher d'abord si la Marque existe
            if (this.magasin.getMarque(refMarque.ToString()) != null)
            {
                //Commence par suppression de l'ensemble des Articles de cette Marque
                this.deleteArticlesMarque(refMarque);
                SQLiteCommand command = new SQLiteCommand("DELETE FROM Marques WHERE RefMarque=" + refMarque, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
                //Suppression en local de la marque
                Marque mq = this.magasin.getMarque(refMarque.ToString());
                this.magasin.ListeMarques.Remove(mq);
                deleted = true;
            }
            else
            {
                throw new Exception("La marque sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteAllMarques()
        {
            bool deleted = false;
            this.magasin.ListeMarques = new List<Marque>();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Marques", this.sql_con);
            sql_con.Open();
            command.ExecuteNonQuery();
            sql_con.Close();
            deleted = true;
            return deleted;
        }
    }
}
