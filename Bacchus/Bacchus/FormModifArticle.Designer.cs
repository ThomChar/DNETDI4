namespace Bacchus
{
    partial class FormModifArticle
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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.prixNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantiteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantiteLabel = new System.Windows.Forms.Label();
            this.prixLabel = new System.Windows.Forms.Label();
            this.sousFamilleComboBox = new System.Windows.Forms.ComboBox();
            this.marqueComboBox = new System.Windows.Forms.ComboBox();
            this.sousFamilleLabel = new System.Windows.Forms.Label();
            this.marqueLabel = new System.Windows.Forms.Label();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.referenceArticleLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nomArticleOriginLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prixNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantiteNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(125, 107);
            this.descriptionTextBox.MaxLength = 150;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(595, 24);
            this.descriptionTextBox.TabIndex = 54;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(3, 107);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(105, 20);
            this.descriptionLabel.TabIndex = 53;
            this.descriptionLabel.Text = "Description :";
            // 
            // prixNumericUpDown
            // 
            this.prixNumericUpDown.DecimalPlaces = 2;
            this.prixNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixNumericUpDown.Location = new System.Drawing.Point(125, 244);
            this.prixNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.prixNumericUpDown.Name = "prixNumericUpDown";
            this.prixNumericUpDown.Size = new System.Drawing.Size(228, 24);
            this.prixNumericUpDown.TabIndex = 52;
            // 
            // quantiteNumericUpDown
            // 
            this.quantiteNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantiteNumericUpDown.Location = new System.Drawing.Point(491, 244);
            this.quantiteNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.quantiteNumericUpDown.Name = "quantiteNumericUpDown";
            this.quantiteNumericUpDown.Size = new System.Drawing.Size(229, 24);
            this.quantiteNumericUpDown.TabIndex = 51;
            // 
            // quantiteLabel
            // 
            this.quantiteLabel.AutoSize = true;
            this.quantiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantiteLabel.Location = new System.Drawing.Point(372, 244);
            this.quantiteLabel.Name = "quantiteLabel";
            this.quantiteLabel.Size = new System.Drawing.Size(82, 20);
            this.quantiteLabel.TabIndex = 50;
            this.quantiteLabel.Text = "Quantite :";
            // 
            // prixLabel
            // 
            this.prixLabel.AutoSize = true;
            this.prixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixLabel.Location = new System.Drawing.Point(3, 248);
            this.prixLabel.Name = "prixLabel";
            this.prixLabel.Size = new System.Drawing.Size(80, 20);
            this.prixLabel.TabIndex = 49;
            this.prixLabel.Text = "Prix H.T :";
            // 
            // sousFamilleComboBox
            // 
            this.sousFamilleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sousFamilleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousFamilleComboBox.FormattingEnabled = true;
            this.sousFamilleComboBox.Location = new System.Drawing.Point(125, 155);
            this.sousFamilleComboBox.Name = "sousFamilleComboBox";
            this.sousFamilleComboBox.Size = new System.Drawing.Size(595, 26);
            this.sousFamilleComboBox.TabIndex = 48;
            // 
            // marqueComboBox
            // 
            this.marqueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marqueComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueComboBox.FormattingEnabled = true;
            this.marqueComboBox.Location = new System.Drawing.Point(125, 203);
            this.marqueComboBox.Name = "marqueComboBox";
            this.marqueComboBox.Size = new System.Drawing.Size(595, 26);
            this.marqueComboBox.TabIndex = 47;
            // 
            // sousFamilleLabel
            // 
            this.sousFamilleLabel.AutoSize = true;
            this.sousFamilleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousFamilleLabel.Location = new System.Drawing.Point(-3, 155);
            this.sousFamilleLabel.Name = "sousFamilleLabel";
            this.sousFamilleLabel.Size = new System.Drawing.Size(122, 20);
            this.sousFamilleLabel.TabIndex = 46;
            this.sousFamilleLabel.Text = " Sous-Famille :";
            // 
            // marqueLabel
            // 
            this.marqueLabel.AutoSize = true;
            this.marqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueLabel.Location = new System.Drawing.Point(3, 203);
            this.marqueLabel.Name = "marqueLabel";
            this.marqueLabel.Size = new System.Drawing.Size(75, 20);
            this.marqueLabel.TabIndex = 45;
            this.marqueLabel.Text = "Marque :";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Enabled = false;
            this.referenceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceTextBox.Location = new System.Drawing.Point(125, 60);
            this.referenceTextBox.MaxLength = 8;
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(595, 24);
            this.referenceTextBox.TabIndex = 44;
            // 
            // referenceArticleLabel
            // 
            this.referenceArticleLabel.AutoSize = true;
            this.referenceArticleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceArticleLabel.Location = new System.Drawing.Point(3, 60);
            this.referenceArticleLabel.Name = "referenceArticleLabel";
            this.referenceArticleLabel.Size = new System.Drawing.Size(96, 20);
            this.referenceArticleLabel.TabIndex = 43;
            this.referenceArticleLabel.Text = "Reference :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(2, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(208, 25);
            this.title_label.TabIndex = 42;
            this.title_label.Text = "Modification Article :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(582, 285);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(138, 32);
            this.updateButton.TabIndex = 41;
            this.updateButton.Text = "Modifier";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(376, 285);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 40;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nomArticleOriginLabel
            // 
            this.nomArticleOriginLabel.AutoSize = true;
            this.nomArticleOriginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomArticleOriginLabel.Location = new System.Drawing.Point(231, 14);
            this.nomArticleOriginLabel.Name = "nomArticleOriginLabel";
            this.nomArticleOriginLabel.Size = new System.Drawing.Size(97, 20);
            this.nomArticleOriginLabel.TabIndex = 55;
            this.nomArticleOriginLabel.Text = " NomArticle";
            // 
            // FormModifArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 329);
            this.Controls.Add(this.nomArticleOriginLabel);
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
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormModifArticle";
            this.Text = "Modification Article";
            ((System.ComponentModel.ISupportInitialize)(this.prixNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantiteNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.NumericUpDown prixNumericUpDown;
        private System.Windows.Forms.NumericUpDown quantiteNumericUpDown;
        private System.Windows.Forms.Label quantiteLabel;
        private System.Windows.Forms.Label prixLabel;
        private System.Windows.Forms.ComboBox sousFamilleComboBox;
        private System.Windows.Forms.ComboBox marqueComboBox;
        private System.Windows.Forms.Label sousFamilleLabel;
        private System.Windows.Forms.Label marqueLabel;
        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.Label referenceArticleLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label nomArticleOriginLabel;
    }
}