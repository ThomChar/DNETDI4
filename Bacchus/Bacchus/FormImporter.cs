using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormImporter : Form
    {
        private string dataBasePath;
        private MagasinDAO magasin;
        private bool importdecision;    // si valeur = true on lance export et ecrasement sinon on lance export ajout

        public FormImporter()
        {
            InitializeComponent();
        }

        public FormImporter(MagasinDAO magasin)
        {
            this.magasin = magasin;
            this.importdecision = false;
            InitializeComponent();
        }

        private void FormImporter_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                Console.WriteLine("Cancel done");
            }
            else
            {
                this.Close();
            }
            //backgroundWorker.CancelAsync();
            //Console.WriteLine("Cancel done");
            //this.Close();
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            //backgroundWorker.RunWorkerAsync();
            if (dataBasePath != null)
            {
                this.importdecision = false;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un fichier avant d'appuyer sur le bouton Importer (Ajout)", "Erreur Générée lors de l'import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception("Veuillez selectionner un fichier avant d'appuyer sur le bouton Exporter");
            }
        }

        private void CrushButton_Click(object sender, EventArgs e)
        {
            //backgroundWorker.RunWorkerAsync();
            if (dataBasePath != null)
            {
                this.importdecision = true;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un fichier avant d'appuyer sur le bouton Importer (Ecrasement)", "Erreur Générée lors de l'import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception("Veuillez selectionner un fichier avant d'appuyer sur le bouton Exporter");
            }
        }

        private void selectionCsvFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fbd = new OpenFileDialog())
            {
                if (fbd.ShowDialog()==DialogResult.OK)
                {
                    csvFileNameLabel.Text = fbd.SafeFileName; //FileName permet d'obtenir le chemin complet du fichier
                    Console.WriteLine(fbd.FileName);
                    dataBasePath = fbd.FileName;
                }
            }
        }
        
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (this.importdecision == true) {
                    this.magasin.importCrush(dataBasePath, this.backgroundWorker,  e);
                }else
                {
                    this.magasin.import(dataBasePath, this.backgroundWorker,  e);
                }
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
                display("Vous avez annulé l'import");
                progressBar.Value = 0;
                percentageLabel.Text = " 0 %";
            }
            else
            {
                display("Succés! L'import est maintenant terminé");
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
