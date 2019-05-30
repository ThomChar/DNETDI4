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
    }
}
