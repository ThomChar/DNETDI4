using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bacchus.Dao
{
    public class SousFamilleDao
    {
        private SQLiteConnection sql_con;
        private string dataBasePath;
        private MagasinDAO magasin;

        public SousFamilleDao()
        {
        }

        public SousFamilleDao(SQLiteConnection sql_con, string dataBasePath, MagasinDAO magasin)
        {
            this.sql_con = sql_con;
            this.dataBasePath = dataBasePath;
            this.magasin = magasin;
        }

        /// //////////////////////////////////////////////////////SOUSFAMILLE////////////////////////////////////////

        public int getLastIdSousFamilles()  
        {
            int lastIdSousFamilles = 0;
            this.sql_con.Open();
            string sql = "SELECT COALESCE(MAX(RefSousFamille),0) FROM SousFamilles";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                lastIdSousFamilles = Convert.ToInt32(cmd.ExecuteScalar());
                //Console.WriteLine(lastIdSousFamilles);
            }
            this.sql_con.Close();
            return lastIdSousFamilles;

        }

        public SousFamille addSousFamille(SousFamille sousFamille)  //Nom de la famille dpit être unique
        {
            //Regarder si ref de la famille existe
            //Regarder si par rapport à la ref il existe un objet contenant le même nom de sous Familles
            //SousFamille sfm = getSousFamilleByName(sousFamille.Nom);
            
            //Recherche de la famille correspondate avec les infos complètes et non juste le nom(besoin de l'id correspondant au nom)
            /*Famille fm = this.magasin.FamilleDao.getFamilleByName(sousFamille.RefFamille.Nom);                    // En commentaire pour le moment on suppose qu'on donne l'objet corect dès le début contenant l'id de celui-ci
            if (fm != null)
            {
                sousFamille.RefFamille = this.magasin.FamilleDao.getFamilleByName(sousFamille.RefFamille.Nom);
                //Console.WriteLine(fm.ToString());
            }*/
            SousFamille sfm = getSousFamilleByName(sousFamille.Nom);
                           if (!sousFamilleExisteFamille(sousFamille.RefFamille.Nom,sousFamille.Nom))//problème lorsqu'on souhaite ajouter ne se met pas dans la bonne catégorie pourtant teste existe test la bonne catégorie
                {
                    //init la refFamille correct de l'objet
                    sousFamille.RefSousFamille = getLastIdSousFamilles() + 1;
                    sql_con.Open();
                    string sql = "INSERT INTO SousFamilles(RefSousFamille,RefFamille,Nom) VALUES(@refSousFamille,@refFamille,@nom)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
                    {
                        cmd.Parameters.AddWithValue("@refSousFamille", sousFamille.RefSousFamille);
                        cmd.Parameters.AddWithValue("@refFamille", sousFamille.RefFamille.RefFamille);
                        cmd.Parameters.AddWithValue("@nom", sousFamille.Nom);
                        cmd.ExecuteNonQuery();
                        sfm = sousFamille;
                        //ajout à la liste en local de la nouvelle famille
                        this.magasin.ListeSousFamilles.Add(sousFamille);
                    }
                    this.sql_con.Close();
                }
            else
            {
                throw new Exception("Cette SousFamille existe déjà ou un paramètre de la sousFamille est incorrect (RefFamille.nom inexistant et RefSousFamille.nom existant)");
            }
            return sfm;
        }

        public bool sousFamilleExisteFamille(string nomFamille, string sousFamilleNom)
        {
            bool found = false;

            //Regarder si La famille existe dans la BD
            Famille fm = this.magasin.FamilleDao.getFamilleByName(nomFamille);
            if (fm == null)throw new Exception("La refFamille ne correspond à aucune famille existante dans la Base de données");

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

            if (sousFamille !=null){ found = true; }
            
            return found;
        }

        public SousFamille updateSousFamille(SousFamille sousFamille)
        {
            SousFamille sfm = null;
            //on cherche puis modifie l'objet en local
            for (int i = 0; i < this.magasin.ListeSousFamilles.Count(); i++)
            {
                if (this.magasin.ListeSousFamilles[i].RefSousFamille == sousFamille.RefSousFamille)
                {
                    this.magasin.ListeSousFamilles[i].RefFamille = sousFamille.RefFamille;
                    this.magasin.ListeSousFamilles[i].Nom = sousFamille.Nom;
                }
            }

            //Update tous les articles locals correspondant à cette SousFamille
            for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
            {
                if (this.magasin.ListeArticles[i].RefSousFamille.RefSousFamille == sousFamille.RefSousFamille)
                {
                    this.magasin.ListeArticles[i].RefSousFamille.Nom = sousFamille.Nom;
                }
            }

            sql_con.Open();
            string sql = "UPDATE SousFamilles SET Nom = @nom, RefFamille = @refFamille  WHERE RefSousFamille=@refSousFamille";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, sql_con))
            {
                cmd.Parameters.AddWithValue("@refFamille", sousFamille.RefFamille.RefFamille);
                cmd.Parameters.AddWithValue("@nom", sousFamille.Nom);
                cmd.Parameters.AddWithValue("@refSousFamille", sousFamille.RefSousFamille);
                cmd.ExecuteNonQuery();
                sfm = sousFamille;
            }
            this.sql_con.Close();
            return sfm;
        }

        public SousFamille getSousFamilleByName(string name)
        {

            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom FROM SousFamilles WHERE Nom =@nom", this.sql_con);
            command.Parameters.AddWithValue("@nom", name);

            sql_con.Open();
            SousFamille sousFamille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    Famille famille = this.magasin.getFamille(String.Format("{0}", sqReader["RefFamille"]));
                    sousFamille = new SousFamille(System.Convert.ToInt32(sqReader["RefSousFamille"]), famille, String.Format("{0}", sqReader["Nom"]));
                }
            }
            sql_con.Close();
            return sousFamille;
        }

        public bool deleteArticlesSousFamille(int refSousFamille)
        {
            bool deleted = false;
            //On suppose que ref Marque existe
            if (this.magasin.getSousFamille(refSousFamille.ToString()) != null)
            {
                //Suppression en local des articles de cette marques
                for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
                {
                    if (this.magasin.ListeArticles[i].RefSousFamille.RefSousFamille == refSousFamille)
                    {
                        this.magasin.ListeArticles.Remove(this.magasin.ListeArticles[i]);
                    }
                }
                SQLiteCommand command = new SQLiteCommand("DELETE FROM Articles WHERE RefSousFamille=" + refSousFamille, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
                //Suppression en local des articles de cette marques
               for (int i = 0; i < this.magasin.ListeArticles.Count(); i++)
                {
                    if (this.magasin.ListeArticles[i].RefSousFamille.RefSousFamille == refSousFamille)
                    {
                        this.magasin.ListeArticles.Remove(this.magasin.ListeArticles[i]);
                    }
                }
               // this.magasin.ListeArticles = listTempArticles;
                deleted = true;
            }
            else
            {
                throw new Exception("La Sous Famille sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        public bool deleteSousFamille(int refSousFamille)
        {
            bool deleted = false;
            //Rechercher d'abord si la Famille existe
            if (this.magasin.getSousFamille(refSousFamille.ToString()) != null)
            {
                //Commence par suppression de l'ensemble des Articles de cette sousFamille
                this.deleteArticlesSousFamille(refSousFamille);
                SQLiteCommand command = new SQLiteCommand("DELETE FROM SousFamilles WHERE RefSousFamille=" + refSousFamille, this.sql_con);
                sql_con.Open();
                command.ExecuteNonQuery();
                sql_con.Close();
                //Suppression en local de la famille
                SousFamille sfm = this.magasin.getSousFamille(refSousFamille.ToString());
                this.magasin.ListeSousFamilles.Remove(sfm);
                deleted = true;
            }
            else
            {
                throw new Exception("La Sous famille sélectionnée n'a pas été trouvée");
            }
            return deleted;
        }

        internal SousFamille getSousFamilleByNameRefFamille(int refFamille, string nomSousFamille)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom FROM SousFamilles WHERE RefFamille = @refFamille AND Nom =@nom", this.sql_con);
            command.Parameters.AddWithValue("@refFamille", refFamille);
            command.Parameters.AddWithValue("@nom", nomSousFamille);

            sql_con.Open();
            SousFamille sousFamille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    Famille famille = this.magasin.getFamille(String.Format("{0}", sqReader["RefFamille"]));
                    //Console.WriteLine(famille.ToString());
                    sousFamille = new SousFamille(System.Convert.ToInt32(sqReader["RefSousFamille"]), famille, String.Format("{0}", sqReader["Nom"]));
                    //Console.WriteLine(sousFamille.ToString());
                }
            }
            sql_con.Close();
            return sousFamille;
        }

        public bool deleteAllSousFamilles()
        {
            bool deleted = false;
            this.magasin.ListeSousFamilles = new List<SousFamille>();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM SousFamilles", this.sql_con);
            sql_con.Open();
            command.ExecuteNonQuery();
            sql_con.Close();
            deleted = true;
            return deleted;
        }
    }
}
