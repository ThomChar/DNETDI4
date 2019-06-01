using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bacchus.Controller;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        internal System.Windows.Forms.ListBox ListBox1;
        private MagasinDAO magasin;

        // The column we are currently using for sorting.
        private ColumnHeader SortingColumn = null;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(MagasinDAO magasin)
        {
            this.magasin = magasin;
            InitializeComponent();

            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));


            listView.ContextMenuStrip = this.contextMenuStrip1;

            // Set the view to show details.
            listView.View = View.Details;
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
            this.listView.DoubleClick += new EventHandler(this.listView_DoubleClick);

           // this.listView. += new MouseEventArgs(listView_MouseUp);


            this.KeyPreview = true;

            //this.KeyDown += new KeyEventHandler(Form_KeyDown);
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            //this.KeyUp += new KeyEventHandler(this.Form_KeyDown);
        }

        public MagasinDAO MagasinDAO
        {
            get { return magasin; }
            set { this.magasin = value; }
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.F1Size.Width == 0) Properties.Settings.Default.Upgrade();   //optionnel

            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));  //ajouter code Rémi pour placer fenetre au depart
                //// optional: add default values
            }
            else
            {
                this.WindowState = Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }
            
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

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region treeView
        private void listView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;

            switch (selectedNodeText)
            {
                case "Articles":
                    displayProducts();
                    refreshStatusStrip("Affichage de "+ magasin.ListeArticles.Count +" produit(s).");
                    break;
                case "Familles":
                    displayFamilies();
                    refreshStatusStrip("Affichage de " + magasin.ListeFamilles.Count + " famille(s).");
                    break;
                case "Sous familles":
                    displaySubfamilies();
                    refreshStatusStrip("Affichage de " + magasin.ListeSousFamilles.Count + " sous-famille(s).");
                    break;
                case "Marques":
                    displayBrands();
                    refreshStatusStrip("Affichage de " + magasin.ListeMarques.Count + " marques(s).");
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

        public void refresh()
        {
            Console.WriteLine("refresh objects");
            magasin.refresh();

            // get selected node of treeview
            String selectedNodeText = treeView1.SelectedNode.Text;

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

        #region events
        /**
         * Event with the keybord
         **/
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    // refresh objects
                    Console.WriteLine("refresh objects");
                    refreshStatusStrip("Mise à jour des données.");
                    refresh();
                    break;

                case Keys.Enter:
                    // Update object
                    updateObject();
                    break;

                case Keys.Delete:
                    // Remove object
                    removeObject();
                    break;
            }
        }

        private void modifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateObject();
        }

        private void listView_DoubleClick(object sender, System.EventArgs e)
        {
            updateObject();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeObject();
        }

        private void refreshStatusStrip(String text)
        {
            toolStripStatusLabel1.Text = text;
            statusStrip1.Font = new Font("Arial", 9, FontStyle.Regular);
            statusStrip1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
        }

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
                    if (SortingColumn.Text.StartsWith("⇓ "))
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
                refreshStatusStrip("Tri ascendant sur " + new_sorting_column.Text + ".");
                SortingColumn.Text = "⇓ " + SortingColumn.Text;
            }
            else
            {
                refreshStatusStrip("Tri descendant sur " + new_sorting_column.Text + ".");
                SortingColumn.Text = "⇑ " + SortingColumn.Text;
            }

            // Create a comparer.
            listView.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            listView.Sort();
        }
        #endregion

        #region menu
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionAjouter formGestionAjouter = new FormGestionAjouter(magasin);
            formGestionAjouter.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionModifier formGestionModifier = new FormGestionModifier(magasin);
            formGestionModifier.ShowDialog();
        }
        private void ajouterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormGestionAjouter formGestionAjouter = new FormGestionAjouter(magasin);
            formGestionAjouter.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormGestionModifier formGestionModifier = new FormGestionModifier(magasin);
            formGestionModifier.ShowDialog();
        }
        #endregion

        #region operationOnObjects
        
        /**
         * add an element (article, family, subfamily, brand)
         **/
        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // get selected node of treeview
            String selectedNodeText = treeView1.SelectedNode.Text;

            switch (selectedNodeText)
            {
                case "Articles":
                    Console.WriteLine("Add product");
                    refreshStatusStrip("Ajout d'un produit.");
                    FormAjoutArticle formAjoutArticle = new FormAjoutArticle(magasin);
                    formAjoutArticle.ShowDialog();
                    break;
                case "Familles":
                    Console.WriteLine("Add subfamily");
                    refreshStatusStrip("Ajout d'une famille.");
                    FormAjoutFamille formAjoutFamille = new FormAjoutFamille(magasin);
                    formAjoutFamille.ShowDialog();
                    break;
                case "Sous familles":
                    Console.WriteLine("Add family");
                    refreshStatusStrip("Ajout d'une sous-famille.");
                    FormAjoutSousFamille formAjoutSousFamille = new FormAjoutSousFamille(magasin);
                    formAjoutSousFamille.ShowDialog();
                    break;
                case "Marques":
                    Console.WriteLine("Add brand");
                    refreshStatusStrip("Ajout d'une marque.");
                    FormAjoutMarque formAjoutMarque = new FormAjoutMarque(magasin);
                    formAjoutMarque.ShowDialog();
                    break;
            }
            refresh();
        }

        /**
         * Update an element (article, family, subfamily, brand)
         **/
        private void updateObject()
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
                    foreach (ListViewItem item in breakfast)
                    {
                        Article article = listView.SelectedItems[0].Tag as Article;
                        if (article != null)
                        {
                            Console.WriteLine("update article " + article.RefArticle + " : " + article.Description);
                            refreshStatusStrip("Modifier l'article " + article.RefArticle + " : " + article.Description + ".");
                            FormModifArticle formUpdateArticle = new FormModifArticle(magasin, article.RefArticle);
                            formUpdateArticle.ShowDialog();
                        }

                    }
                    break;
                case "Familles":
                    foreach (ListViewItem item in breakfast)
                    {
                        Famille family = listView.SelectedItems[0].Tag as Famille;
                        if (family != null)
                        {
                            Console.WriteLine("update family " + family.RefFamille + ": " + family.Nom);
                            refreshStatusStrip("Modifier la famille " + family.RefFamille + ": " + family.Nom + ".");
                            FormModifFamille formUpdateFamily = new FormModifFamille(magasin, family);    //Modification pour adaptation code thomas anciennement "family.RefFamille.ToString()"
                            formUpdateFamily.ShowDialog();
                        }

                    }
                    break;
                case "Sous familles":
                    foreach (ListViewItem item in breakfast)
                    {
                        SousFamille subFamily = listView.SelectedItems[0].Tag as SousFamille;
                        if (subFamily != null)
                        {
                            Console.WriteLine("update subfamily " + subFamily.RefSousFamille + ": " + subFamily.Nom);
                            refreshStatusStrip("Modifier la sous-famille " + subFamily.RefSousFamille + ": " + subFamily.Nom + ".");
                            FormModifSousFamille formUpdateSubFamily = new FormModifSousFamille(magasin, subFamily); //Modification pour adaptation code thomas anciennement "subFamily.ToString()"
                            formUpdateSubFamily.ShowDialog();
                        }
                    }
                    break;
                case "Marques":
                    foreach (ListViewItem item in breakfast)
                    {
                        Marque brand = listView.SelectedItems[0].Tag as Marque;
                        if (brand != null)
                        {
                            Console.WriteLine("update brand " + brand.RefMarque + ": " + brand.Nom);
                            refreshStatusStrip("Modifier la marque " + brand.RefMarque + ": " + brand.Nom + ".");
                            FormModifMarque formUpdateBrand = new FormModifMarque(magasin, brand); //Modification pour adaptation code thomas anciennement "brand.RefMarque.ToString()"
                            formUpdateBrand.ShowDialog();
                        }
                    }
                    break;
            }
            refresh();
        }

        /**
         * Remove an element (article, family, subfamily, brand)
         **/
        private void removeObject()
        {
            // get selected node of treeview
            String selectedNodeText = treeView1.SelectedNode.Text;

            // get selected item
            ListView.SelectedListViewItemCollection breakfast = this.listView.SelectedItems;

            try
            {
                // action on item
                switch (selectedNodeText)
                {
                    case "Articles":
                        foreach (ListViewItem item in breakfast)
                        {
                            Article article = listView.SelectedItems[0].Tag as Article;
                            if (article != null)
                            {
                                Console.WriteLine("remove article " + article.RefArticle + " : " + article.Description);
                                var confirmResult = MessageBox.Show("Voullez-vous vraiment supprimer l'article " + article.RefArticle + " : " + article.Description + " ?",
                                         "Confirmation de suppression",
                                         MessageBoxButtons.YesNo);

                                if (confirmResult == DialogResult.Yes)
                                {
                                    Console.WriteLine("deleted article");
                                    magasin.ArticleDao.deleteArticle(article.RefArticle);
                                    refreshStatusStrip("L'article " + article.RefArticle + " : " + article.Description + " a été supprimé.");
                                    refresh();
                                }
                                else
                                {
                                    Console.WriteLine("removal canceled");
                                }
                            }
                        }
                        break;
                    case "Familles":
                        foreach (ListViewItem item in breakfast)
                        {
                            Famille family = listView.SelectedItems[0].Tag as Famille;
                            if (family != null)
                            {
                                Console.WriteLine("remove family " + family.RefFamille + " : " + family.Nom);
                                var confirmResult = MessageBox.Show("Voullez-vous vraiment supprimer la famille " + family.RefFamille + " : " + family.Nom + " ?",
                                         "Confirmation de suppression",
                                         MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    int nbArticles = magasin.getArticlesByFamily(family.RefFamille).Count;
                                    int nbSubFamilies = magasin.getSubFamiliesByFamily(family.RefFamille).Count;
                                    if (nbArticles > 0 || nbSubFamilies > 0)
                                    {
                                        var confirmDelete = MessageBox.Show("La famille compte " + nbSubFamilies + " sous-famille(s) et " +
                                             nbArticles + " article(s). Cette opération supprimera ces sous-familles et ces articles. Voullez-vous vraiment supprimer la famille " + family.RefFamille + " : " + family.Nom + " ?",
                                         "Attention, suppression en cascade !!!",
                                         MessageBoxButtons.YesNo);
                                        if (confirmDelete != DialogResult.Yes)
                                        {
                                            Console.WriteLine("removal canceled");
                                            break;
                                        }
                                    }

                                    Console.WriteLine("deleted family");
                                    magasin.FamilleDao.deleteFamille(family.RefFamille);
                                    refreshStatusStrip("La famille " + family.RefFamille + " : " + family.Nom + " a été supprimée.");
                                    refresh();
                                }
                                else
                                {
                                    Console.WriteLine("removal canceled");
                                }
                            }

                        }
                        break;
                    case "Sous familles":
                        foreach (ListViewItem item in breakfast)
                        {
                            SousFamille subFamily = listView.SelectedItems[0].Tag as SousFamille;
                            if (subFamily != null)
                            {
                                Console.WriteLine("remove subFamily " + subFamily.RefFamille + " : " + subFamily.Nom);
                                var confirmResult = MessageBox.Show("Voullez-vous vraiment supprimer la  sous-famille " + subFamily.RefFamille + " : " + subFamily.Nom + " ?",
                                         "Confirmation de suppression",
                                         MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    int nbArticles = magasin.getArticlesBySubFamily(subFamily.RefSousFamille).Count;
                                    if (nbArticles > 0)
                                    {
                                        var confirmDelete = MessageBox.Show("La famille compte " + nbArticles + " article(s). Cette opération supprimera ces articles. Voullez-vous vraiment supprimer la sous famille " + subFamily.RefFamille + " : " + subFamily.Nom + " ?",
                                         "Attention, suppression en cascade !!!",
                                         MessageBoxButtons.YesNo);
                                        if (confirmDelete != DialogResult.Yes)
                                        {
                                            Console.WriteLine("removal canceled");
                                            break;
                                        }
                                    }

                                    Console.WriteLine("deleted subfamily");
                                    magasin.SousFamilleDao.deleteSousFamille(subFamily.RefSousFamille);
                                    refreshStatusStrip("La sous-famille " + subFamily.RefSousFamille + " : " + subFamily.Nom + " a été supprimée.");
                                    refresh();
                                }
                                else
                                {
                                    Console.WriteLine("removal canceled");
                                }
                            }
                        }
                        break;
                    case "Marques":
                        foreach (ListViewItem item in breakfast)
                        {
                            Marque brand = listView.SelectedItems[0].Tag as Marque;
                            if (brand != null)
                            {
                                Console.WriteLine("remove brand " + brand.RefMarque + " : " + brand.Nom);
                                var confirmResult = MessageBox.Show("Voullez-vous vraiment supprimer la  marque " + brand.RefMarque + " : " + brand.Nom + " ?",
                                         "Confirmation de suppression",
                                         MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    int nbArticles = magasin.getArticlesByBrand(brand.RefMarque).Count;
                                    if (nbArticles > 0)
                                    {
                                        var confirmDelete = MessageBox.Show("La marque compte " + nbArticles + " article(s). Cette opération supprimera ces articles. Voullez-vous vraiment supprimer la marque " + brand.RefMarque + " : " + brand.Nom + " ?",
                                         "Attention, suppression en cascade !!!",
                                         MessageBoxButtons.YesNo);
                                        if (confirmDelete != DialogResult.Yes)
                                        {
                                            Console.WriteLine("removal canceled");
                                            break;
                                        }
                                    }

                                    Console.WriteLine("deleted brand");
                                    magasin.MarqueDao.deleteMarque(brand.RefMarque);
                                    refreshStatusStrip("La marque " + brand.RefMarque + " : " + brand.Nom + " a été supprimée.");
                                    refresh();
                                }
                                else
                                {
                                    Console.WriteLine("removal canceled");
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("nothing selected");
                        break;
                }
            }
            catch (InvalidCastException e)
            {
                // Impossible deletion
                MessageBox.Show(e.Message, "Suppression Imppossible");
            }

        }
        #endregion

        private void formMain_Closing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
        }
    }
}