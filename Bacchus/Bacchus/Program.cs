using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Recuperation du chemin de la base de donnée
            string Path = Application.ExecutablePath.ToString(); 
            string Path1 = Directory.GetParent(Path).ToString(); 
            string Path2 = Directory.GetParent(Path1).ToString();
            string DBPath = Directory.GetParent(Path2).ToString();

            //Demarrage Base de Donnee et transfert en local
            MagasinDAO magasin = new MagasinDAO(DBPath+ "/Bacchus.SQLite");

            Console.WriteLine("Nombre d'articles chargés : " + magasin.ListeArticles.Count());
            Console.WriteLine("Nombre de marques chargées : " + magasin.ListeMarques.Count());
            Console.WriteLine("Nombre de familles chargées : " + magasin.ListeFamilles.Count());
            Console.WriteLine("Nombre de sous familles chargées : " + magasin.ListeSousFamilles.Count());

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Test Fonctionnalitées
            
            //Test requete ajout Famille                            OK
            Famille testFamille = new Famille(2,"électromenager");
            Famille testFamille2 = new Famille(2, "multimedia");
            ///magasin.FamilleDao.addFamille(testFamille);
            //magasin.FamilleDao.addFamille(testFamille2);
            //Console.WriteLine("Nombre de familles chargées : " + magasin.ListeFamilles.Count());


            //Test reuete supression Famille de la Base de donnée                  OK
            //magasin.FamilleDao.deleteFamille(4);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Test Fonctionnalitées
            //Test requete ajout SousFamille                            OK
            SousFamille testSousFamille = new SousFamille(1, testFamille, "éléctromenangerSousFamille");
            SousFamille testSousFamille2 = new SousFamille(1, testFamille2, "multimediaSousFamille");
            //magasin.SousFamilleDao.addSousFamille(testSousFamille);
            //magasin.SousFamilleDao.addSousFamille(testSousFamille2);

            //Test reuete supression SousFamille de la Base de donnée        OK           
            //magasin.SousFamilleDao.deleteSousFamille(8);
            //magasin.SousFamilleDao.deleteSousFamille(9);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Test Fonctionnalitées
            //Test requete ajout Marque                                          OK 
            Marque testMarque = new Marque(1, "thomson");
            Marque testMarque2 = new Marque(1, "bosh");
            //magasin.MarqueDao.addMarque(testMarque);
            //magasin.MarqueDao.addMarque(testMarque2);

            //Test reuete supression Marque de la Base de donnée                  OK 
            //magasin.MarqueDao.deleteMarque(8);
            //magasin.MarqueDao.deleteMarque(7);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Test Fonctionnalitées
            //Test requete ajout Article                                             OK         Probleme par rapport à sous famille
            Article testArticle = new Article("ssa7", "hallo", testSousFamille, testMarque, 3.5, 2);
            //Article testArticle2 = new Article("ssa5", "hallo2", testSousFamille, testMarque, 4.5, 6);
            //magasin.ArticleDao.addArticle(testArticle);
            //magasin.ArticleDao.addArticle(testArticle2);

            //Test reuete supression Article de la Base de donnée                    OK 
            //magasin.ArticleDao.deleteArticle("ssa4");
            //magasin.MarqueDao.deleteMarque("ssa5");

            //Export

            /*     bool exportDone = false;
             if (File.Exists(DBPath + " /test.csv"))
             {
                 File.Delete(DBPath + " /test.csv");
             }
                 StringBuilder csvcontent = new StringBuilder();
                 csvcontent.AppendLine("Description;Ref;Marque;Famille;Sous - Famille;Prix H.T.");
                 foreach (Article art in magasin.ListeArticles)
                 {
                     for (int i = 0; i < art.Quantite;i++) {
                         csvcontent.AppendLine(art.Description + ";" + art.RefArticle + ";" + art.RefMarque.Nom + ";" + art.RefSousFamille.RefFamille.Nom + ";" + art.RefSousFamille.Nom + ";" + art.PrixHT);
                     }

                 }
                 //csvcontent.AppendLine("Mahesh;31");
                 string csvpath = DBPath + " /test.csv";
                 File.AppendAllText(csvpath, csvcontent.ToString());*/

            //Import Crush

            // Comme on fait import et ecrasement on commence par vider la base de données
            //magasin.ArticleDao.deleteAllArticles();
            //magasin.SousFamilleDao.deleteAllSousFamilles();
            //magasin.MarqueDao.deleteAllMarques();
            //magasin.FamilleDao.deleteAllFamilles();

            Console.WriteLine("Nombre d'articles chargés : " + magasin.ListeArticles.Count());
            Console.WriteLine("Nombre de marques chargées : " + magasin.ListeMarques.Count());
            Console.WriteLine("Nombre de familles chargées : " + magasin.ListeFamilles.Count());
            Console.WriteLine("Nombre de sous familles chargées : " + magasin.ListeSousFamilles.Count());
            //Demarrage de l'application
            Application.Run(new FormMain(magasin)); 
        }
    }
}
