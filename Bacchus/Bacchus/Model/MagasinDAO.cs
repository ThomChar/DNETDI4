using Bacchus.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class MagasinDAO
    {
        private SQLiteConnection sql_con;
        private string dataBasePath;

        //private RequeteBD requeteBD { get; set; }
        private ArticleDao articleDao { get; set; }
        private FamilleDao familleDao { get; set; }
        private MarqueDao marqueDao { get; set; }
        private SousFamilleDao sousFamilleDao { get; set; }

        private List<Article> listeArticles { get; set; }
        private List<Famille> listeFamilles { get; set; }
        private List<Marque> listeMarques { get; set; }
        private List<SousFamille> listeSousFamilles { get; set; }

        public ArticleDao ArticleDao
        {
            get { return articleDao; }
            set { this.articleDao = value; }
        }

        public FamilleDao FamilleDao
        {
            get { return familleDao; }
            set { this.familleDao = value; }
        }

        public MarqueDao MarqueDao
        {
            get { return marqueDao; }
            set { this.marqueDao = value; }
        }

        public SousFamilleDao SousFamilleDao
        {
            get { return sousFamilleDao; }
            set { this.sousFamilleDao = value; }
        }

        public List<Article> ListeArticles
        {
            get { return listeArticles; }
            set{ listeArticles = value;}
        }

        public List<Famille> ListeFamilles
        {
            get { return listeFamilles; }
            set { listeFamilles = value;}
        }

        public List<SousFamille> ListeSousFamilles
        {
            get { return listeSousFamilles; }
            set { listeSousFamilles = value; }
        }

        public List<Marque> ListeMarques
        {
            get { return listeMarques; }
            set { listeMarques = value; }
        }

        public MagasinDAO(string dataPath)
        {
            this.dataBasePath = dataPath;
            this.SetConnection();
            //this.requeteBD = new RequeteBD(this.sql_con, this.dataBasePath,this);
            this.articleDao = new ArticleDao(this.sql_con, this.dataBasePath, this);
            this.familleDao = new FamilleDao(this.sql_con, this.dataBasePath, this);
            this.marqueDao = new MarqueDao(this.sql_con, this.dataBasePath, this);
            this.sousFamilleDao = new SousFamilleDao(this.sql_con, this.dataBasePath, this);
            this.listeArticles = new List<Article>();
            this.listeFamilles = new List<Famille>();
            this.listeMarques = new List<Marque>();
            this.listeSousFamilles = new List<SousFamille>();
            this.setMarquesBD();
            this.setFamillesBD();
            this.setSousFamillesBD();
            this.setArticlesBD();
            //Console.WriteLine(this.ToString());
        }

        public MagasinDAO() {
            this.dataBasePath = "./Bacchus.SQLite";
            this.SetConnection();
            this.articleDao = new ArticleDao(this.sql_con, this.dataBasePath, this);
            this.familleDao = new FamilleDao(this.sql_con, this.dataBasePath, this);
            this.marqueDao = new MarqueDao(this.sql_con, this.dataBasePath, this);
            this.sousFamilleDao = new SousFamilleDao(this.sql_con, this.dataBasePath, this);
            //this.requeteBD = new RequeteBD(this.sql_con, this.dataBasePath,this);
            this.setMarquesBD();
            this.setFamillesBD();
            this.setSousFamillesBD();
            this.setArticlesBD();
            //Console.WriteLine(this.ToString());
        }

        public MagasinDAO(List<Article> listeArticles, List<Famille> listeFamilles, List<Marque> listeMarques, List<SousFamille> listeSousFamilles) {
            this.listeArticles = listeArticles;
            this.listeFamilles = listeFamilles;
            this.listeMarques = listeMarques;
            this.listeSousFamilles = listeSousFamilles;
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source = " + this.dataBasePath + "; Version = 3;New=True;");
        }

        public SQLiteConnection GetConnection()
        {
            return this.sql_con;
        }

        public void ajouterArticle(Article article) {
            this.listeArticles.Add(article);
        }

        public void supprimerArticle(Article article) {
            this.listeArticles.Remove(article);
        }

        public void ajouterFamille(Famille famille) {
            this.listeFamilles.Add(famille);
        }

        public void supprimerFamille(Famille famille) {
            this.listeFamilles.Remove(famille);
        }

        public void ajouterMarque(Marque marque) {
            this.listeMarques.Add(marque);
        }

        public void supprimerMarque(Marque marque) {
            this.listeMarques.Remove(marque);
        }

        public void ajouterSousFamille(SousFamille sousFamille) {
            this.listeSousFamilles.Add(sousFamille);
        }

        public void supprimerSousFamille(SousFamille sousFamille) {
            this.listeSousFamilles.Remove(sousFamille);
        }

        public Famille getFamille(string refFamille)
        {
            //DataBase db = new DataBase(dataBasePath);

            //sql_con = new SQLiteConnection("data source= Bacchus.SQLite");
            //sql_con.Open();
            /*sql_con = new SQLiteConnection
                ("Data Source =" + this.dataBasePath + "; Version = 3;");*/
            /*sql_con = new SQLiteConnection
                ("Data Source = :memory:; Version = 3;New=True;");*/
            this.SetConnection();
            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille,Nom FROM Familles WHERE RefFamille =@refFamille", this.sql_con);
            command.Parameters.AddWithValue("@refFamille", refFamille);

            this.sql_con.Open();
            Famille famille = null;
            //SetConnection();
            /*SqlConnection connection = new SqlConnection("data source = localhost");
            connection.Open();*/
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {

                if (sqReader.Read())
                {

                    famille = new Famille(System.Convert.ToInt32(sqReader["RefFamille"]), String.Format("{0}", sqReader["Nom"]));

                }
            }

            this.sql_con.Close();
            return famille;
        }

        public Famille getFamilleParSousFamille(string refSousFamille)
        {
            //Cherche sous famille correspondant a refSousFamille 
            SousFamille sousFamille = this.getSousFamille(refSousFamille);
            string refFamille = sousFamille.RefFamille.RefFamille.ToString();

            //this.SetConnection();
           // DataBase db = new DataBase(dataBasePath);
            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille,Nom FROM Familles WHERE RefFamille =@refFamille", this.sql_con);
            command.Parameters.AddWithValue("@refFamille", refFamille);

            this.sql_con.Open();
            Famille famille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    famille = new Famille(System.Convert.ToInt32(sqReader["RefFamille"]), String.Format("{0}", sqReader["Nom"]));
                }
            }
            this.sql_con.Close();
            return famille;
        }

        public Marque getMarque(String refMarque)
        {
            //DataBase db = new DataBase(dataBasePath);
            //this.SetConnection();
            SQLiteCommand command = new SQLiteCommand("SELECT RefMarque,Nom FROM Marques WHERE RefMarque =@refMarque", this.sql_con);
            command.Parameters.AddWithValue("@refMarque", refMarque);

            Marque marque = null;
            this.sql_con.Open();
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    marque = new Marque(System.Convert.ToInt32(sqReader["RefMarque"]), String.Format("{0}", sqReader["Nom"]));
                }
            }
            this.sql_con.Close();
            return marque;
        }

        public SousFamille getSousFamille(String refSousFamille)
        {
            //this.SetConnection();
            //DataBase db = new DataBase(dataBasePath);
            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille,RefFamille,Nom FROM SousFamilles WHERE RefSousFamille =@refSousFamille", this.sql_con);
            command.Parameters.AddWithValue("@refSousFamille", refSousFamille);

            this.sql_con.Open();
            SousFamille sousFamille = null;
            using (SQLiteDataReader sqReader = command.ExecuteReader())
            {
                if (sqReader.Read())
                {
                    Famille famille = this.getFamille(String.Format("{0}", sqReader["RefFamille"]));
                    sousFamille = new SousFamille(System.Convert.ToInt32(sqReader["RefSousFamille"]), famille, String.Format("{0}", sqReader["Nom"]));
                }
            }
            this.sql_con.Close();
            return sousFamille;
        }

        public void setArticlesBD(){

            try
            {
                DataBase db = new DataBase(dataBasePath);
                DataTable dt = db.selectQuery("SELECT * FROM Articles");
                Article article;
                Famille famille;
                SousFamille sousFamille;
                Marque marque;

                foreach (DataRow rows in dt.Rows) {

                    //Cherche Famille correspondant à SousFamille
                    //famille = this.getFamilleParSousFamille(rows[2].ToString());
                    //Recherche auparavant si Sous Famille existe
                    sousFamille = this.getSousFamille(rows[2].ToString());
                    //Recherche aupravant si Marque existe
                    marque = this.getMarque(rows[3].ToString());
                    article = new Article(rows[0].ToString(), rows[1].ToString(), sousFamille, marque, System.Convert.ToDouble(rows[4]), System.Convert.ToInt32(rows[5]));
                    Console.WriteLine(article.ToString());
                    this.listeArticles.Add(article);
                }

            }catch (Exception ex){
                Console.WriteLine(ex);
            }
        }


        public void setFamillesBD(){
            try
            {
                DataBase db = new DataBase(dataBasePath);
                DataTable dt = db.selectQuery("SELECT * FROM Familles");
                Famille famille;

                foreach (DataRow rows in dt.Rows)
                {
                    famille = new Famille(System.Convert.ToInt32(rows[0]), rows[1].ToString());
                    Console.WriteLine(famille.ToString());
                    this.listeFamilles.Add(famille);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

            public void setSousFamillesBD(){
            try
            {
                DataBase db = new DataBase(dataBasePath);
                DataTable dt = db.selectQuery("SELECT * FROM SousFamilles");
                SousFamille sousFamille;
                Famille famille;

                foreach (DataRow rows in dt.Rows)
                {
                    
                    //Recherche famille correspondante à refFamille "rows[1]"
                    famille = this.getFamille(rows[1].ToString());
                    //Creation Famille temporaire
                    sousFamille = new SousFamille(System.Convert.ToInt32(rows[0]), famille, rows[2].ToString());
                    Console.WriteLine(sousFamille.ToString());

                    //Ajout a la famille de la liste
                    this.listeSousFamilles.Add(sousFamille);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void setMarquesBD(){
            try
            {
                DataBase db = new DataBase(dataBasePath);
                DataTable dt = db.selectQuery("SELECT * FROM Marques");
                Marque marque;

                foreach (DataRow rows in dt.Rows)
                {
                    marque = new Marque(System.Convert.ToInt32(rows[0]), rows[1].ToString());
                    Console.WriteLine(marque.ToString());
                    this.listeMarques.Add(marque);
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool export(string csvpath, object sender, DoWorkEventArgs e)
        {
            bool exportDone = false;
            BackgroundWorker bg = sender as BackgroundWorker;
            double percent = 0;
            double currentPosition = 0;
            double length =  0;

            //determiner le nombre de ligne totale à exporter
            foreach (Article art in this.ListeArticles)
            {
                for (int i = 0; i < art.Quantite; i++)
                {
                    length++;
                }
            }

            if (File.Exists(csvpath)){
                File.Delete(csvpath);
            }
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine("Description;Ref;Marque;Famille;Sous - Famille;Prix H.T.");
            foreach (Article art in this.ListeArticles)
            {
                for (int i = 0; i < art.Quantite; i++)
                {
                    if (bg.CancellationPending)     //On teste avant  pour chaque ligne si le client souhaite annuler l'export
                    {
                        //bg.CancelAsync();
                        e.Cancel = true;
                        Console.WriteLine("Annulation de l'export");
                        break;
                    }

                    csvcontent.AppendLine(art.Description + ";" + art.RefArticle + ";" + art.RefMarque.Nom + ";" + art.RefSousFamille.RefFamille.Nom + ";" + art.RefSousFamille.Nom + ";" + art.PrixHT);
                    
                    currentPosition = currentPosition+1;
                    percent = (currentPosition / length) * 100;
                    bg.ReportProgress(Convert.ToInt32(percent));
                }
            }
            //Console.WriteLine(currentPosition);
            //Console.WriteLine(percent);
            File.AppendAllText(csvpath, csvcontent.ToString(), Encoding.UTF8);//Regarder pour l'encoding ce n'est ptet pas le bon
            //percent = 100;      //Le pourcentage de complétion est de 100 lorsque l'on a fini le traitement
            //bg.ReportProgress(Convert.ToInt32(percent));
            return exportDone;
        }

        //Dans celle-ci on vide la base de donnée et on effectue les nouveau imports
        public bool import(string csvpath, object sender, DoWorkEventArgs e)
        {
            bool importDone = false;
            BackgroundWorker bg = sender as BackgroundWorker;
            double percent = 0;
            FileInfo fi = new FileInfo(csvpath);
            double length = fi.Length;
            double currentPosition = 0;

            using (StreamReader sReader = new StreamReader(csvpath, Encoding.Default, true))
            {
                //Déclaration de variables temporaires permettant le transfert des données
                Article article;
                Marque marque;
                SousFamille sousFamille;
                Famille famille;

                //Parcours du fichier
                string headerLine = sReader.ReadLine();
                //Console.WriteLine("Headers : " + headerLine);

                while (!sReader.EndOfStream)
                {
                    if (bg.CancellationPending)     //On teste avant  pour chaque ligne si le client souhaite annuler l'export
                    {
                        //bg.CancelAsync();
                        e.Cancel = true;
                        Console.WriteLine("Annulation de l'import");
                        break;
                    }

                    var line = sReader.ReadLine();      //Contient une ligne du fichier
                    var values = line.Split(';');       //Contient chaque élément d'une ligne du fichier
                    //Console.WriteLine(values[0] + ";" + values[1] + ";" + values[2] + ";" + values[3] + ";" + values[4] + ";" + values[5]);

                    //Si la marque n'existe pas on l'ajoute sinon on recupere l'objet correspondant au nom de la marque
                    if (this.MarqueDao.getMarqueByName(values[2]) != null)
                    {
                        marque = this.MarqueDao.getMarqueByName(values[2]);
                    }
                    else
                    {
                        marque = this.MarqueDao.addMarque(new Marque(0, values[2]));      //Ajout Marque en local se fait normalement par appel de la fonction add
                    }

                    //Si la famille n'existe pas on l'ajoute sinon on recupere l'objet correspondant au nom de la famille
                    if (this.FamilleDao.getFamilleByName(values[3]) != null)
                    {
                        famille = this.FamilleDao.getFamilleByName(values[3]);
                    }
                    else
                    {
                        famille = this.FamilleDao.addFamille(new Famille(0, values[3]));
                    }

                    //Si la sousfamille n'existe pas on l'ajoute sinon on recupere l'objet correspondant au nom de la sousfamille et à l'id de la famille récupéré précédement
                    if (this.SousFamilleDao.getSousFamilleByNameRefFamille(famille.RefFamille, values[4]) != null)
                    {
                        sousFamille = this.SousFamilleDao.getSousFamilleByNameRefFamille(famille.RefFamille, values[4]);
                    }
                    else
                    {
                        sousFamille = this.SousFamilleDao.addSousFamille(new SousFamille(0, famille, values[4]));
                    }

                    //Si l'article n'existe pas on en ajoute un nouveau sinon on augmente la quantite de 1 (test d'existance en fonction de ref article et de description)
                    if (this.ArticleDao.getArticle(values[1]) != null)
                    {              //si on trouve l'article par rapport à la ref on augmente sa quantité de 1 en local et dans la BD
                        article = this.ArticleDao.getArticle(values[1]);
                        article.Quantite = article.Quantite + 1;
                        article = this.ArticleDao.updateQteArticle(article);
                        //sousFamille = magasin.SousFamilleDao.getSousFamilleByNameRefFamille(values[4]);
                    }
                    else
                    {
                        article = this.ArticleDao.addArticle(new Article(values[1], values[0], sousFamille, marque, Convert.ToDouble(values[5]), 1));
                    }

                    
                    currentPosition += line.Count();
                    percent = (currentPosition / length) * 100;
                    //Console.WriteLine(length);
                    //Console.WriteLine(percent);
                    //Console.WriteLine((currentPosition / length));
                    bg.ReportProgress(Convert.ToInt32(percent));
                }
                percent = 100;      //Le pourcentage de complétion est de 100 lorsque l'on a fini le traitement
                bg.ReportProgress(Convert.ToInt32(percent));
            }
            return importDone;
        }
                    //Dans celle-ci on ne vide pas la base de donnée et on ajoute les nouveaux imports à la base de donnée
            public bool importCrush(string csvpath, object sender, DoWorkEventArgs e)
        {
            bool importDone = false;
            // Comme on fait import et ecrasement on commence par vider la base de données
            this.ArticleDao.deleteAllArticles();
            this.SousFamilleDao.deleteAllSousFamilles();
            this.MarqueDao.deleteAllMarques();
            this.FamilleDao.deleteAllFamilles();

            this.import(csvpath,sender,e);
            return importDone;
        }

        public override string ToString()
        {
            return "Articles: " + listeArticles.ToString() + "\nFamilles: " + listeFamilles.ToString() + "\nSousFamilles: " + listeSousFamilles.ToString() + "\nMarques: " + listeMarques.ToString();
        }
    }
}
