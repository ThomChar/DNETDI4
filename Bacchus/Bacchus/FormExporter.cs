using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormExporter : Form
    {
        private string dataBasePath;
        private MagasinDAO magasin;
        private int nbArticlesExport;

        public FormExporter()
        {
           InitializeComponent();
        }

        public FormExporter(MagasinDAO magasin)
        {
            this.magasin = magasin;
            this.nbArticlesExport = 0;
            InitializeComponent();
        }

        private void csvFileNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void browserButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "untitled";
                sfd.Filter = "CSV (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    csvFileNameLabel.Text = Path.GetFileName(sfd.FileName); //FileName permet d'obtenir le chemin complet du fichier
                    this.dataBasePath = sfd.FileName;
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (dataBasePath != null)
            {
                //this.magasin.export(dataBasePath, sender, e);
                backgroundWorker.RunWorkerAsync();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un fichier avant d'appuyer sur le bouton Exporter","Erreur Générée lors de l'export",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //throw new Exception("Veuillez selectionner un fichier avant d'appuyer sur le bouton Exporter");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
             this.nbArticlesExport = this.magasin.export(dataBasePath, this.backgroundWorker, e); 
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            percentageLabel.Text = e.ProgressPercentage.ToString() + " %";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                display("Annulation ! " + this.nbArticlesExport + " articles ont tout de même été exporté");
                progressBar.Value = 0;
                percentageLabel.Text = " 0 %";
            }
            else
            {
                display("Succés! " + this.nbArticlesExport + " articles ont été exporté");
                this.Close();
            }
        }

        private void simulateHeavyJob()
        {
            Thread.Sleep(100);
        }

        private void display(string text)
        {
            MessageBox.Show(text);
        }
    }
}
