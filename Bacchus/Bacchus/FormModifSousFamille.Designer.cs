namespace Bacchus
{
    partial class FormModifSousFamille
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
            this.familleLabel = new System.Windows.Forms.Label();
            this.familleComboBox = new System.Windows.Forms.ComboBox();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.nomFamilleLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nomSousFamilleOriginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // familleLabel
            // 
            this.familleLabel.AutoSize = true;
            this.familleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familleLabel.Location = new System.Drawing.Point(4, 105);
            this.familleLabel.Name = "familleLabel";
            this.familleLabel.Size = new System.Drawing.Size(78, 20);
            this.familleLabel.TabIndex = 33;
            this.familleLabel.Text = " Famille :";
            // 
            // familleComboBox
            // 
            this.familleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.familleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familleComboBox.FormattingEnabled = true;
            this.familleComboBox.Location = new System.Drawing.Point(102, 105);
            this.familleComboBox.Name = "familleComboBox";
            this.familleComboBox.Size = new System.Drawing.Size(484, 26);
            this.familleComboBox.TabIndex = 32;
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.Location = new System.Drawing.Point(102, 62);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(484, 24);
            this.nomTextBox.TabIndex = 31;
            // 
            // nomFamilleLabel
            // 
            this.nomFamilleLabel.AutoSize = true;
            this.nomFamilleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomFamilleLabel.Location = new System.Drawing.Point(4, 62);
            this.nomFamilleLabel.Name = "nomFamilleLabel";
            this.nomFamilleLabel.Size = new System.Drawing.Size(59, 20);
            this.nomFamilleLabel.TabIndex = 30;
            this.nomFamilleLabel.Text = " Nom :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(274, 25);
            this.title_label.TabIndex = 29;
            this.title_label.Text = "Modification Sous-Famille :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(448, 150);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(138, 32);
            this.updateButton.TabIndex = 28;
            this.updateButton.Text = "Modifier";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(286, 150);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nomSousFamilleOriginLabel
            // 
            this.nomSousFamilleOriginLabel.AutoSize = true;
            this.nomSousFamilleOriginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomSousFamilleOriginLabel.Location = new System.Drawing.Point(283, 13);
            this.nomSousFamilleOriginLabel.Name = "nomSousFamilleOriginLabel";
            this.nomSousFamilleOriginLabel.Size = new System.Drawing.Size(141, 20);
            this.nomSousFamilleOriginLabel.TabIndex = 36;
            this.nomSousFamilleOriginLabel.Text = " NomSousFamille";
            // 
            // FormModifSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 190);
            this.Controls.Add(this.nomSousFamilleOriginLabel);
            this.Controls.Add(this.familleLabel);
            this.Controls.Add(this.familleComboBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomFamilleLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormModifSousFamille";
            this.Text = "Modification SousFamille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label familleLabel;
        private System.Windows.Forms.ComboBox familleComboBox;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Label nomFamilleLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label nomSousFamilleOriginLabel;
    }
}