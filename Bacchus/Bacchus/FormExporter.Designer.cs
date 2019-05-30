namespace Bacchus
{
    partial class FormExporter
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
            this.FileTitilelabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exportButton = new System.Windows.Forms.Button();
            this.csvFileNameLabel = new System.Windows.Forms.Label();
            this.browserButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileTitilelabel
            // 
            this.FileTitilelabel.AutoSize = true;
            this.FileTitilelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTitilelabel.Location = new System.Drawing.Point(10, 71);
            this.FileTitilelabel.Name = "FileTitilelabel";
            this.FileTitilelabel.Size = new System.Drawing.Size(128, 20);
            this.FileTitilelabel.TabIndex = 16;
            this.FileTitilelabel.Text = "Nom du fichier :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(9, 18);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(236, 25);
            this.title_label.TabIndex = 15;
            this.title_label.Text = "Exporter des données :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 109);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(481, 23);
            this.progressBar.TabIndex = 14;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(401, 148);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(138, 32);
            this.exportButton.TabIndex = 13;
            this.exportButton.Text = "Exporter";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // csvFileNameLabel
            // 
            this.csvFileNameLabel.AutoSize = true;
            this.csvFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFileNameLabel.Location = new System.Drawing.Point(203, 71);
            this.csvFileNameLabel.Name = "csvFileNameLabel";
            this.csvFileNameLabel.Size = new System.Drawing.Size(115, 20);
            this.csvFileNameLabel.TabIndex = 12;
            this.csvFileNameLabel.Text = "Aucun fichier..";
            // 
            // browserButton
            // 
            this.browserButton.Location = new System.Drawing.Point(401, 66);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(138, 32);
            this.browserButton.TabIndex = 11;
            this.browserButton.Text = "Parcourir";
            this.browserButton.UseVisualStyleBackColor = true;
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(207, 148);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
            this.percentageLabel.Location = new System.Drawing.Point(496, 109);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(41, 18);
            this.percentageLabel.TabIndex = 17;
            this.percentageLabel.Text = "  0 %";
            // 
            // FormExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 191);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.FileTitilelabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.csvFileNameLabel);
            this.Controls.Add(this.browserButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormExporter";
            this.Text = "FormExporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileTitilelabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label csvFileNameLabel;
        private System.Windows.Forms.Button browserButton;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label percentageLabel;
    }
}