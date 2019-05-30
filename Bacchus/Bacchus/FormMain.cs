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
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormMain : Form
    {

        private ListViewColumnSorter lvwColumnSorter;


        public FormMain()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.itemsView.ListViewItemSorter = lvwColumnSorter;

        }


        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImporter formImporter = new FormImporter();
            formImporter.ShowDialog();                      //Permet affichage en mode modal sinon utiliser show()
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region Items treeView
        private void itemsView_AfterSelect(object sender, TreeViewEventArgs e)
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
        public void displayProducts()
        {
            itemsView.Columns.Clear();
            itemsView.Items.Clear();

            itemsView.Columns.Add("item");
            itemsView.Columns.Add("Ref-Article");
            itemsView.Columns.Add("Description");
            itemsView.Columns.Add("Famille - Sous famille");
            itemsView.Columns.Add("Marque");
            itemsView.Columns.Add("Prix HT");
            itemsView.Columns.Add("Quantité");

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("Crayon de bois");
            item1.SubItems.Add("Fourniture - crayon");
            item1.SubItems.Add("Leclerc");
            item1.SubItems.Add("1,00€");
            item1.SubItems.Add("5");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.Checked = true;
            item2.SubItems.Add("1");
            item2.SubItems.Add("Crayon de papier");
            item2.SubItems.Add("Fourniture - crayon");
            item2.SubItems.Add("Leclerc");
            item2.SubItems.Add("4,00€");
            item2.SubItems.Add("2");
            ListViewItem item3 = new ListViewItem("item3", 2);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("1");
            item3.SubItems.Add("Crayon papier");
            item3.SubItems.Add("Fourniture - crayon");
            item3.SubItems.Add("Leclerc");
            item3.SubItems.Add("5,00€");
            item3.SubItems.Add("1");


            // itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


            //Add the items to the ListView.
            itemsView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void displayFamilies()
        {
            itemsView.Columns.Clear();
            itemsView.Items.Clear();

            itemsView.Columns.Add("item");
            itemsView.Columns.Add("Ref-Famille");
            itemsView.Columns.Add("Nom");

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("AAAAAAAAAAAA");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("BBBBBBBBB");
            ListViewItem item3 = new ListViewItem("item3", 2);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("CCCCCCCCCC");

            /*
            itemsView.Columns.Add("AAAAAAAAAAAAA", 100, HorizontalAlignment.Left);
            itemsView.Columns.Add("BBBBBBB", 100, HorizontalAlignment.Left);
            itemsView.Columns.Add("CCCCCCCCCCCCC", 200, HorizontalAlignment.Left);
            itemsView.Columns.Add("DDDDDDDDDDDDDDD", 200, HorizontalAlignment.Left);
            */
            //Add the items to the ListView.
            itemsView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

        }

        public void displaySubfamilies()
        {
            itemsView.Columns.Clear();
            itemsView.Items.Clear();

            itemsView.Columns.Add("item");
            itemsView.Columns.Add("Ref-Sous Famille");
            itemsView.Columns.Add("nom");
            itemsView.Columns.Add("Famille");

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 2);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");


            // itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


            //Add the items to the ListView.
            itemsView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void displayBrands()
        {
            itemsView.Columns.Clear();
            itemsView.Items.Clear();

            itemsView.Columns.Add("item");
            itemsView.Columns.Add("Ref-Marque");
            itemsView.Columns.Add("nom");

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            ListViewItem item3 = new ListViewItem("item3", 2);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");

           


            // itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


            //Add the items to the ListView.
            itemsView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            for (int i = 0; i < 20; i++)
            {
                ListViewItem item4 = new ListViewItem("item2", 1);
                item4.SubItems.Add("4");
                item4.SubItems.Add("5");

                itemsView.Items.Add(item4);
            }


            itemsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }


        private void itemsView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.

            Console.WriteLine("e.Column:"+ e.Column);
            Console.WriteLine("lvwColumnSorter.SortColumn:" + lvwColumnSorter.SortColumn);
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.itemsView.Sort();
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            SizeLastColumn(itemsView);
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
    }
}




/// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Specifies the column to be sorted
    /// </summary>
    private int ColumnToSort;
    /// <summary>
    /// Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder OrderOfSort;
    /// <summary>
    /// Case insensitive comparer object
    /// </summary>
    private CaseInsensitiveComparer ObjectCompare;

    /// <summary>
    /// Class constructor.  Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
        // Initialize the column to '0'
        ColumnToSort = 0;

        // Initialize the sort order to 'none'
        OrderOfSort = SortOrder.None;

        // Initialize the CaseInsensitiveComparer object
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listviewX, listviewY;

        // Cast the objects to be compared to ListViewItem objects
        listviewX = (ListViewItem)x;
        listviewY = (ListViewItem)y;

        decimal num = 0;
        if (decimal.TryParse(listviewX.SubItems[ColumnToSort].Text, out num))
        {
            compareResult = decimal.Compare(num, Convert.ToDecimal(listviewY.SubItems[ColumnToSort].Text));
        }
        else
        {
            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
        }

        // Calculate correct return value based on object comparison
        if (OrderOfSort == SortOrder.Ascending)
        {
            // Ascending sort is selected, return normal result of compare operation
            return compareResult;
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            // Descending sort is selected, return negative result of compare operation
            return (-compareResult);
        }
        else
        {
            // Return '0' to indicate they are equal
            return 0;
        }
    }

    /// <summary>
    /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    /// </summary>
    public int SortColumn
    {
        set
        {
            ColumnToSort = value;
        }
        get
        {
            return ColumnToSort;
        }
    }

    /// <summary>
    /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    /// </summary>
    public SortOrder Order
    {
        set
        {
            OrderOfSort = value;
        }
        get
        {
            return OrderOfSort;
        }
    }

}