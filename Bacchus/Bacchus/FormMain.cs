using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Remoting;
using Bacchus.Controller;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        private MagasinDAO magasin;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            // Set the view to show details.
            listView.View = View.Details;
            // Allow the user to edit item text.
            listView.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listView.FullRowSelect = true;
            // Display grid lines.
            listView.GridLines = true;
            // Sort the items in the list in ascending order.
            listView.Sorting = SortOrder.Ascending;

            // Set the initial sorting type for the ListView.
            this.listView.Sorting = SortOrder.None;
            // Disable automatic sorting to enable manual sorting.
            this.listView.View = View.Details;
            this.listView.Location = new Point(10, 10);
            this.listView.Name = "listView1";
            this.listView.Size = new Size(300, 100);
            this.listView.TabIndex = 0;
            // Enable editing of the items in the ListView.
            this.listView.LabelEdit = true;
            // Connect the ListView.ColumnClick event to the ColumnClick event handler.
            this.listView.ColumnClick += new ColumnClickEventHandler(listView_ColumnClick);
        }

        public MagasinDAO MagasinDAO
        {
            get { return magasin; }
            set { this.magasin = value; }
        }


        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImporter formImporter = new FormImporter(magasin);
            formImporter.ShowDialog();                      //Permet affichage en mode modal sinon utiliser show()
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExporter formExporter = new FormExporter(magasin);
            formExporter.ShowDialog();                      //Permet affichage en mode modal sinon utiliser show()

        }

<<<<<<< HEAD
        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region Items treeView
        private void listView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;

            switch (selectedNodeText)
            {
                case "Articles":
                    Console.WriteLine("Display products");
                    displayProducts();
                    break;
                case "Familles":
                    Console.WriteLine("Display families");
                    displayFamilies();
                    break;
                case "Sous familles":
                    Console.WriteLine("Display subfamilies");
                    displaySubfamilies();
                    break;
                case "Marques":
                    Console.WriteLine("Display brands");
                    displayBrands();
                    break;
                default:
                    Console.WriteLine("Display nothing");
                    break;
            }
        }
        #endregion

        #region ListView
        /**
         * Display Products
         **/
        public void displayProducts()
        {
            listView.Columns.Clear();
            listView.Items.Clear();

            // metadata of listView
            listView.Columns.Add("Ref-Article");
            listView.Columns.Add("Description");
            listView.Columns.Add("Famille - Sous famille");
            listView.Columns.Add("Marque");
            listView.Columns.Add("Prix HT");
            listView.Columns.Add("Quantité");

            List<Article> articles = magasin.ListeArticles;

            // add all articles on listView
            foreach (Article article in articles)
            {
                ListViewItem item = new ListViewItem(article.RefArticle.ToString());
                item.Tag = article; // tag with object Article
                item.SubItems.Add(article.Description); // description
                item.SubItems.Add(article.RefSousFamille.RefFamille.Nom + " - " + article.RefSousFamille.Nom); // family name and subfamily name
                item.SubItems.Add(article.RefMarque.Nom); // brand name
                item.SubItems.Add(article.PrixHT.ToString() + " €"); // price
                item.SubItems.Add(article.Quantite.ToString()); // quantity
                listView.Items.Add(item);
            }
            
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        /**
         * Display Families
         **/
        public void displayFamilies()
        {
            listView.Columns.Clear();
            listView.Items.Clear();

            // metadata of listView
            listView.Columns.Add("Ref-Famille");
            listView.Columns.Add("Nom");

            // get families
            List<Famille> families = magasin.ListeFamilles;

            // add all families on listView
            foreach (Famille family in families)
            {
                ListViewItem item = new ListViewItem(family.RefFamille.ToString());
                item.Tag = family; // tag with object Famille
                item.SubItems.Add(family.Nom);  // family name
                listView.Items.Add(item);
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /**
         * Display Subfamilies
         **/
        public void displaySubfamilies()
        {
            listView.Columns.Clear();
            listView.Items.Clear();

            // metadata of listView
            listView.Columns.Add("Ref-Sous Famille");
            listView.Columns.Add("nom");
            listView.Columns.Add("Famille");

            // get subfamilies
            List<SousFamille> subFamilies = magasin.ListeSousFamilles;

            // add all subfamilies on listView
            foreach (SousFamille subfamily in subFamilies)
            {
                ListViewItem item = new ListViewItem(subfamily.RefSousFamille.ToString());
                item.Tag = subfamily; // tag with object SousFamille
                item.SubItems.Add(subfamily.Nom);   // subfamily name
                item.SubItems.Add(subfamily.RefFamille.Nom);    // family name
                listView.Items.Add(item);
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /**
         * Display Brands
         **/
        public void displayBrands()
        {
            listView.Columns.Clear();
            listView.Items.Clear();

            // metadata of listView
            listView.Columns.Add("Ref-Marque");
            listView.Columns.Add("nom");

            // get brands
            List<Marque> brands = magasin.ListeMarques;

            // add all brands on listView
            foreach (Marque brand in brands)
            {
                ListViewItem item = new ListViewItem(brand.RefMarque.ToString());
                item.Tag = brand; // tag with object Marque
                item.SubItems.Add(brand.Nom);   // brand name
                listView.Items.Add(item);
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SizeLastColumn(listView);
        }

        private void listView1_Resize(object sender, System.EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }

        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
        #endregion

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected node of treeview
            String selectedNodeText = treeView1.SelectedNode.Text;
            //Console.WriteLine("selectedNodeText:"+ selectedNodeText);

            // get selected item
            ListView.SelectedListViewItemCollection breakfast = this.listView.SelectedItems;

            // action on item
            switch (selectedNodeText)
            {
                case "Articles":
                    Console.WriteLine("get product selected");
                    foreach (ListViewItem item in breakfast)
                    {
                        Article article = listView.SelectedItems[0].Tag as Article;
                        if (article != null)
                            Console.WriteLine(article.ToString());
                    }
                    break;
                case "Familles":
                    Console.WriteLine("get family selected");
                    foreach (ListViewItem item in breakfast)
                    {
                        Famille family = listView.SelectedItems[0].Tag as Famille;
                        if (family != null)
                            Console.WriteLine(family.ToString());
                    }
                    break;
                case "Sous familles":
                    Console.WriteLine("get subfamily selected");
                    foreach (ListViewItem item in breakfast)
                    {
                        SousFamille subFamily = listView.SelectedItems[0].Tag as SousFamille;
                        if (subFamily != null)
                            Console.WriteLine(subFamily.ToString());
                    }
                    break;
                case "Marques":
                    Console.WriteLine("get brand selected");
                    foreach (ListViewItem item in breakfast)
                    {
                        Marque brand = listView.SelectedItems[0].Tag as Marque;
                        if (brand != null)
                            Console.WriteLine(brand.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("nothing selected");
                    break;
            }
        }

        // The column we are currently using for sorting.
        private ColumnHeader SortingColumn = null;

        // Sort on this column.
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            Console.WriteLine("Hello");
            // Get the new sorting column.
            ColumnHeader new_sorting_column = listView.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            listView.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            listView.Sort();
=======
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionAjouter formGestionAjouter = new FormGestionAjouter(magasin);
            formGestionAjouter.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionModifier formGestionModifier = new FormGestionModifier(magasin);
            formGestionModifier.ShowDialog();
>>>>>>> thomas3
        }
    }

}


