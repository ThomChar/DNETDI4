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
            this.button1 = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.csvFileNameBox = new System.Windows.Forms.TextBox();
            this.csvFileNameLabel = new System.Windows.Forms.Label();
            this.crushButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(200, 91);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Validate_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(394, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Selectionner";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.selectionCsvFile_Click);
            // 
            // csvFileNameBox
            // 
            this.csvFileNameBox.Location = new System.Drawing.Point(113, 32);
            this.csvFileNameBox.Name = "csvFileNameBox";
            this.csvFileNameBox.Size = new System.Drawing.Size(275, 22);
            this.csvFileNameBox.TabIndex = 3;
            // 
            // csvFileNameLabel
            // 
            this.csvFileNameLabel.AutoSize = true;
            this.csvFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFileNameLabel.Location = new System.Drawing.Point(3, 32);
            this.csvFileNameLabel.Name = "csvFileNameLabel";
            this.csvFileNameLabel.Size = new System.Drawing.Size(95, 20);
            this.csvFileNameLabel.TabIndex = 4;
            this.csvFileNameLabel.Text = "Fichier .csv";
            // 
            // crushButton
            // 
            this.crushButton.Location = new System.Drawing.Point(394, 92);
            this.crushButton.Name = "crushButton";
            this.crushButton.Size = new System.Drawing.Size(138, 32);
            this.crushButton.TabIndex = 5;
            this.crushButton.Text = "Ecraser";
            this.crushButton.UseVisualStyleBackColor = true;
            this.crushButton.Click += new System.EventHandler(this.CrushButton_Click);
            // 
            // FormImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 135);
            this.Controls.Add(this.crushButton);
            this.Controls.Add(this.csvFileNameLabel);
            this.Controls.Add(this.csvFileNameBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.button1);
            this.Name = "FormImporter";
            this.Text = "Importer";
            this.Load += new System.EventHandler(this.FormImporter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox csvFileNameBox;
        private System.Windows.Forms.Label csvFileNameLabel;
        private System.Windows.Forms.Button crushButton;
    }
}