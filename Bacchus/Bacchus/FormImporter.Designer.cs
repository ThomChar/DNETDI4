namespace Bacchus
{
    partial class FormImporter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.browserButton = new System.Windows.Forms.Button();
            this.csvFileNameLabel = new System.Windows.Forms.Label();
            this.crushButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.title_label = new System.Windows.Forms.Label();
            this.FileTitilelabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(7, 149);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(200, 149);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Validate_Click);
            // 
            // browserButton
            // 
            this.browserButton.Location = new System.Drawing.Point(394, 67);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(138, 32);
            this.browserButton.TabIndex = 2;
            this.browserButton.Text = "Parcourir";
            this.browserButton.UseVisualStyleBackColor = true;
            this.browserButton.Click += new System.EventHandler(this.selectionCsvFile_Click);
            // 
            // csvFileNameLabel
            // 
            this.csvFileNameLabel.AutoSize = true;
            this.csvFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFileNameLabel.Location = new System.Drawing.Point(196, 72);
            this.csvFileNameLabel.Name = "csvFileNameLabel";
            this.csvFileNameLabel.Size = new System.Drawing.Size(115, 20);
            this.csvFileNameLabel.TabIndex = 4;
            this.csvFileNameLabel.Text = "Aucun fichier..";
            // 
            // crushButton
            // 
            this.crushButton.Location = new System.Drawing.Point(394, 149);
            this.crushButton.Name = "crushButton";
            this.crushButton.Size = new System.Drawing.Size(138, 32);
            this.crushButton.TabIndex = 5;
            this.crushButton.Text = "Ecraser";
            this.crushButton.UseVisualStyleBackColor = true;
            this.crushButton.Click += new System.EventHandler(this.CrushButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 110);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(477, 23);
            this.progressBar.TabIndex = 6;
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(2, 19);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(234, 25);
            this.title_label.TabIndex = 7;
            this.title_label.Text = "Importer des données :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileTitilelabel
            // 
            this.FileTitilelabel.AutoSize = true;
            this.FileTitilelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTitilelabel.Location = new System.Drawing.Point(3, 72);
            this.FileTitilelabel.Name = "FileTitilelabel";
            this.FileTitilelabel.Size = new System.Drawing.Size(165, 20);
            this.FileTitilelabel.TabIndex = 8;
            this.FileTitilelabel.Text = " Fichier selectionné :";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.percentageLabel.Location = new System.Drawing.Point(488, 110);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(41, 18);
            this.percentageLabel.TabIndex = 9;
            this.percentageLabel.Text = "  0 %";
            // 
            // FormImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 191);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.FileTitilelabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.crushButton);
            this.Controls.Add(this.csvFileNameLabel);
            this.Controls.Add(this.browserButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormImporter";
            this.Text = "Importer";
            this.Load += new System.EventHandler(this.FormImporter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button browserButton;
        private System.Windows.Forms.Label csvFileNameLabel;
        private System.Windows.Forms.Button crushButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label FileTitilelabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label percentageLabel;
    }
}