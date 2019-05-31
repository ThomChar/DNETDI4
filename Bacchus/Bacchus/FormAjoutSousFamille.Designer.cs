namespace Bacchus
{
    partial class FormAjoutSousFamille
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
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.nomFamilleLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.familleComboBox = new System.Windows.Forms.ComboBox();
            this.familleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.nomTextBox.Location = new System.Drawing.Point(100, 62);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(350, 24);
            this.nomTextBox.TabIndex = 24;
            this.nomTextBox.Text = "ex : Sous-Famille ...";
            this.nomTextBox.Enter += new System.EventHandler(this.nomTextBox_Enter);
            // 
            // nomFamilleLabel
            // 
            this.nomFamilleLabel.AutoSize = true;
            this.nomFamilleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomFamilleLabel.Location = new System.Drawing.Point(4, 62);
            this.nomFamilleLabel.Name = "nomFamilleLabel";
            this.nomFamilleLabel.Size = new System.Drawing.Size(59, 20);
            this.nomFamilleLabel.TabIndex = 23;
            this.nomFamilleLabel.Text = " Nom :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(240, 25);
            this.title_label.TabIndex = 22;
            this.title_label.Text = "Création Sous-Famille :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(310, 152);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 152);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // familleComboBox
            // 
            this.familleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.familleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familleComboBox.FormattingEnabled = true;
            this.familleComboBox.Location = new System.Drawing.Point(100, 105);
            this.familleComboBox.Name = "familleComboBox";
            this.familleComboBox.Size = new System.Drawing.Size(350, 26);
            this.familleComboBox.TabIndex = 25;
            // 
            // familleLabel
            // 
            this.familleLabel.AutoSize = true;
            this.familleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familleLabel.Location = new System.Drawing.Point(4, 105);
            this.familleLabel.Name = "familleLabel";
            this.familleLabel.Size = new System.Drawing.Size(78, 20);
            this.familleLabel.TabIndex = 26;
            this.familleLabel.Text = " Famille :";
            // 
            // FormAjoutSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 192);
            this.Controls.Add(this.familleLabel);
            this.Controls.Add(this.familleComboBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomFamilleLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormAjoutSousFamille";
            this.Text = "Création Sous-Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Label nomFamilleLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox familleComboBox;
        private System.Windows.Forms.Label familleLabel;
    }
}