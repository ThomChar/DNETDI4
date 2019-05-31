using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Dao
{
    public class ArticleDao
    {
        private SQLiteConnection sql_con;
        private string dataBasePath;
        private MagasinDAO magasin;

        public ArticleDao()
        {
        }

        public ArticleDao(SQLiteConnection sql_con, string dataBasePath, MagasinDAO magasin)
        {
            this.sql_con = sql_con;
            this.dataBasePath = dataBasePath;
            this.magasin = magasin;
        }

        /// //////////////////////////////////////////////////////ARTICLE////////////////////////////////////////////

        public Article addArticle(Article article)  //Nom de la famille doit être unique
        {
            //Controle de si reference existe (celle entrée doit être unique)
            //Seulement dans ce cas on ajoute l'objet en Bd et en local
            if (this.getArticle(article.RefArticle)!=null)
            {
                throw new Exception("La RefArticle de l'objet article existe déjà");
            }
            //Controle de si  Sous famille existe   dans ce cas recuperation de tout l'objet sous famille et surtout l'id       Problème pour les articles qui ont le même nom mais Familles differente
            SousFamille sf = this.magasin.SousFamilleDao.getSousFamilleByNameRefFamille(article.RefSousFamille.RefFamille.RefFamille,article.RefSousFamille.Nom.ToString());  // Faire une nouvelle fonction qui controle les 2 infos
            if (sf == null)
            {
                throw new Exception("La RefSousFamille n'existe actuellement pas, veuillez changer la référence SousFamille");
            }
            
            article.RefSousFamille = sf;

            //Controle de si Marque existe  dans ce cas recuperation de tout l'objet marque et surtout id
            Marque mq = this.magasin.MarqueDao.getMarqueByName(article.RefMarque.Nom.ToString());
            //Console.WriteLine(mq.ToString());
            if (mq == null)
            {
                throw new Exception("La RefMarque n'existe actuellement pas, veuillez changer la référence Marque");
            }
            article.RefMarque = mq; 

            Article art = null;
            sql_con.Open();
            string sql = "INSERT INTO Articles(RefArticle,Description,RefSousFamille,RefMarque,PrixHT,Quantite) VALUES(@refArticle,@description,@refSousFamille,@refMarque,@prixHT,@quantite)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                cmd.Parameters.AddWithValue("@refArticle", article.RefArticle);
                cmd.Parameters.AddWithValue("@description", article.Description);
                cmd.Parameters.AddWithValue("@refSousFamille", article.RefSousFamille.RefSousFamille);
                cmd.Parameters.AddWithValue("@refMarque", article.RefMarque.RefMarque);
                cmd.Parameters.AddWithValue("@prixHT", article.PrixHT);
                cmd.Parameters.AddWithValue("@quantite", article.Quantite);
                cmd.ExecuteNonQuery();
                art = article;
                //ajout à la liste en local de la nouvelle famille
                this.magasin.ListeArticles.Add(article);
            }
            this.sql_con.Close();
            
            return art;
        }

        public Article updateArticle(Article article)
        {
            Article art = null;
            //on cherche puis modifie l'objet en local
            for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
            {
                if (this.magasin.ListeArticles[i].RefArticle == article.RefArticle)
                {
                    this.magasin.ListeArticles[i].RefMarque = article.RefMarque;
                    this.magasin.ListeArticles[i].RefSousFamille = article.RefSousFamille;
                    this.magasin.ListeArticles[i].Quantite = article.Quantite;
                    this.magasin.ListeArticles[i].Description = article.Description;
                    this.magasin.ListeArticles[i].PrixHT = article.PrixHT;
                }
            }

            sql_con.Open();
            string sql = "UPDATE Articles SET Description = @description, RefSousFamille = @refSousFamille, RefMarque = @refMarque, Quantite = @quantite, PrixHT = @prixHT  WHERE RefArticle=@refArticle";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                cmd.Parameters.AddWithValue("@description", article.Description);
                cmd.Parameters.AddWithValue("@refSousFamille", article.RefSousFamille.RefSousFamille);
                cmd.Parameters.AddWithValue("@refMarque", article.RefMarque.RefMarque);
                cmd.Parameters.AddWithValue("@quantite", article.Quantite);
                cmd.Parameters.AddWithValue("@prixHT", article.PrixHT);
                cmd.Parameters.AddWithValue("@refArticle", article.RefArticle);
                cmd.ExecuteNonQuery();
                art = article;
            }
            this.sql_con.Close();
            return art;
        }

        public Article updateQteArticle(Article article)  //Nom de la famille doit être unique
        {
            Article art = null;
            //On ajoute d'abord en local la nouvelle quantite
            for (int i =0; i< this.magasin.ListeArticles.Count(); i++){
                if (this.magasin.ListeArticles[i].RefArticle == article.RefArticle) {
                    this.magasin.ListeArticles[i].Quantite = this.magasin.ListeArticles[i].Quantite+1;
                }
            }

            sql_con.Open();
            string sql = "UPDATE Articles SET Quantite = @quantite  WHERE RefArticle=@refArticle";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                cmd.Parameters.AddWithValue("@refArticle", article.RefArticle);
                cmd.Parameters.AddWithValue("@quantite", article.Quantite);
                cmd.ExecuteNonQuery();
                art = article;
            }
            this.sql_con.Close();

            return art;
        }

        /*private SousFamille getSousFamilleByNameId(string name)
        {
            Famille fm = this.magasin.FamilleDao.getFamilleByName(nomFamille);
            if (fm == null) throw new Exception("La refFamille ne correspond à aucune famille existante dans la Base de données");

            //Regarde si il existe deja une famille ayant la ref famille et le nom

            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom FROM SousFamilles WHERE Nom =@nom and RefFamille=@refFamille", this.sql_con);
            command.Parameters.AddWithValue("@nom", sousFamilleNom);
            command.Parameters.AddWithValue("@refFamille", fm.RefFamille);

            this.sql_con.Open();
            SousFamille sousFamille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    Famille famille = this.magasin.getFamille(String.Format("{0}", sqReader["RefFamille"]));
                    sousFamille = new SousFamille(System.Convert.ToInt32(sqReader["RefSousFamille"]), famille, String.Format("{0}", sqReader["Nom"]));
                }
            }
            this.sql_con.Close();
            return sousFamille;
        }*/

        public Article getArticle(string refArticle)
        {

            SQLiteCommand command = new SQLiteCommand("SELECT RefArticle,Description,RefSousFamille,RefMarque,PrixHT,Quantite FROM Articles WHERE RefArticle =@refArticle", this.sql_con);
            command.Parameters.AddWithValue("@refArticle", refArticle);

            sql_con.Open();
            Article article = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    SousFamille sousFamille = this.magasin.getSousFamille(String.Format("{0}", sqReader["RefSousFamille"]));
                    Marque marque = this.magasin.getMarque(String.Format("{0}", sqReader["RefMarque"]));
                    article = new Article(String.Format("{0}", sqReader["RefArticle"]), String.Format("{0}", sqReader["Description"]), sousFamille, marque, System.Convert.ToDouble(sqReader["PrixHT"]), System.Convert.ToInt32(sqReader["Quantite"]));

                }
            }
            sql_con.Close();
            return article;
        }

        public bool deleteArticle(string refArticle)    //test du = sinon mettre un Like
        {
            bool deleted = false;
            //Rechercher d'abord si l'Article existe
            if (this.getArticle(refArticle) != null)
            {
                Article art = this.getArticle(refArticle);
                SQLiteCommand command = new SQLiteCommand("DELETE FROM Articles WHERE RefArticle = '" + refArticle +"'", this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                //Suppression en local de l'article
                this.magasin.ListeArticles.Remove(art);
                sql_con.Close();
                deleted = true;
            }
            else
            {
                throw new Exception("L'article sélectionné n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteAllArticles()    //test du = sinon mettre un Like
        {
            bool deleted = false;
            this.magasin.ListeArticles = new List<Article>();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Articles", this.sql_con);
            sql_con.Open();
            command.ExecuteNonQuery();
            sql_con.Close();
            deleted = true;
            return deleted;
        }
    }
}
