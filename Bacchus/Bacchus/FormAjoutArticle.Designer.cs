namespace Bacchus
{
    partial class FormAjoutArticle
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
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.referenceArticleLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.marqueLabel = new System.Windows.Forms.Label();
            this.sousFamilleLabel = new System.Windows.Forms.Label();
            this.marqueComboBox = new System.Windows.Forms.ComboBox();
            this.sousFamilleComboBox = new System.Windows.Forms.ComboBox();
            this.prixLabel = new System.Windows.Forms.Label();
            this.quantiteLabel = new System.Windows.Forms.Label();
            this.quantiteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.prixNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.quantiteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.referenceTextBox.Location = new System.Drawing.Point(126, 60);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(503, 24);
            this.referenceTextBox.TabIndex = 29;
            this.referenceTextBox.Text = "ex : refArticle ...";
            this.referenceTextBox.Enter += new System.EventHandler(this.referenceTextBox_Enter);
            // 
            // referenceArticleLabel
            // 
            this.referenceArticleLabel.AutoSize = true;
            this.referenceArticleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceArticleLabel.Location = new System.Drawing.Point(4, 60);
            this.referenceArticleLabel.Name = "referenceArticleLabel";
            this.referenceArticleLabel.Size = new System.Drawing.Size(96, 20);
            this.referenceArticleLabel.TabIndex = 28;
            this.referenceArticleLabel.Text = "Reference :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(174, 25);
            this.title_label.TabIndex = 27;
            this.title_label.Text = "Création Article :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(491, 287);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 26;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(312, 287);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // marqueLabel
            // 
            this.marqueLabel.AutoSize = true;
            this.marqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueLabel.Location = new System.Drawing.Point(4, 203);
            this.marqueLabel.Name = "marqueLabel";
            this.marqueLabel.Size = new System.Drawing.Size(75, 20);
            this.marqueLabel.TabIndex = 30;
            this.marqueLabel.Text = "Marque :";
            // 
            // sousFamilleLabel
            // 
            this.sousFamilleLabel.AutoSize = true;
            this.sousFamilleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousFamilleLabel.Location = new System.Drawing.Point(-2, 155);
            this.sousFamilleLabel.Name = "sousFamilleLabel";
            this.sousFamilleLabel.Size = new System.Drawing.Size(122, 20);
            this.sousFamilleLabel.TabIndex = 31;
            this.sousFamilleLabel.Text = " Sous-Famille :";
            // 
            // marqueComboBox
            // 
            this.marqueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marqueComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueComboBox.FormattingEnabled = true;
            this.marqueComboBox.Location = new System.Drawing.Point(126, 203);
            this.marqueComboBox.Name = "marqueComboBox";
            this.marqueComboBox.Size = new System.Drawing.Size(503, 26);
            this.marqueComboBox.Sorted = true;
            this.marqueComboBox.TabIndex = 32;
            // 
            // sousFamilleComboBox
            // 
            this.sousFamilleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sousFamilleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousFamilleComboBox.FormattingEnabled = true;
            this.sousFamilleComboBox.Location = new System.Drawing.Point(126, 155);
            this.sousFamilleComboBox.Name = "sousFamilleComboBox";
            this.sousFamilleComboBox.Size = new System.Drawing.Size(503, 26);
            this.sousFamilleComboBox.Sorted = true;
            this.sousFamilleComboBox.TabIndex = 33;
            // 
            // prixLabel
            // 
            this.prixLabel.AutoSize = true;
            this.prixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixLabel.Location = new System.Drawing.Point(4, 250);
            this.prixLabel.Name = "prixLabel";
            this.prixLabel.Size = new System.Drawing.Size(80, 20);
            this.prixLabel.TabIndex = 34;
            this.prixLabel.Text = "Prix H.T :";
            // 
            // quantiteLabel
            // 
            this.quantiteLabel.AutoSize = true;
            this.quantiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantiteLabel.Location = new System.Drawing.Point(341, 249);
            this.quantiteLabel.Name = "quantiteLabel";
            this.quantiteLabel.Size = new System.Drawing.Size(82, 20);
            this.quantiteLabel.TabIndex = 35;
            this.quantiteLabel.Text = "Quantite :";
            // 
            // quantiteNumericUpDown
            // 
            this.quantiteNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantiteNumericUpDown.Location = new System.Drawing.Point(447, 249);
            this.quantiteNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.quantiteNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantiteNumericUpDown.Name = "quantiteNumericUpDown";
            this.quantiteNumericUpDown.Size = new System.Drawing.Size(182, 24);
            this.quantiteNumericUpDown.TabIndex = 36;
            this.quantiteNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // prixNumericUpDown
            // 
            this.prixNumericUpDown.DecimalPlaces = 2;
            this.prixNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixNumericUpDown.Location = new System.Drawing.Point(126, 248);
            this.prixNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.prixNumericUpDown.Name = "prixNumericUpDown";
            this.prixNumericUpDown.Size = new System.Drawing.Size(185, 24);
            this.prixNumericUpDown.TabIndex = 37;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(4, 107);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(105, 20);
            this.descriptionLabel.TabIndex = 38;
            this.descriptionLabel.Text = "Description :";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.descriptionTextBox.Location = new System.Drawing.Point(126, 107);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(503, 24);
            this.descriptionTextBox.TabIndex = 39;
            this.descriptionTextBox.Text = "ex : descriptionArticle ...";
            this.descriptionTextBox.Enter += new System.EventHandler(this.descriptionTextBox_Enter);
            // 
            // FormAjoutArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 329);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.prixNumericUpDown);
            this.Controls.Add(this.quantiteNumericUpDown);
            this.Controls.Add(this.quantiteLabel);
            this.Controls.Add(this.prixLabel);
            this.Controls.Add(this.sousFamilleComboBox);
            this.Controls.Add(this.marqueComboBox);
            this.Controls.Add(this.sousFamilleLabel);
            this.Controls.Add(this.marqueLabel);
            this.Controls.Add(this.referenceTextBox);
            this.Controls.Add(this.referenceArticleLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormAjoutArticle";
            this.Text = "Création Article";
            ((System.ComponentModel.ISupportInitialize)(this.quantiteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.Label referenceArticleLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label marqueLabel;
        private System.Windows.Forms.Label sousFamilleLabel;
        private System.Windows.Forms.ComboBox marqueComboBox;
        private System.Windows.Forms.ComboBox sousFamilleComboBox;
        private System.Windows.Forms.Label prixLabel;
        private System.Windows.Forms.Label quantiteLabel;
        private System.Windows.Forms.NumericUpDown quantiteNumericUpDown;
        private System.Windows.Forms.NumericUpDown prixNumericUpDown;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}