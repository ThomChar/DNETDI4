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
    public partial class FormImporter : Form
    {
        public FormImporter()
        {
            InitializeComponent();
        }

        private void FormImporter_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrushButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectionCsvFile_Click(object sender, EventArgs e)
        {

        }
    }
}
