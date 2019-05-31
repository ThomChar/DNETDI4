namespace Bacchus
{
    partial class FormModifFamille
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
            this.nomFamilleOriginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(88, 62);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(362, 22);
            this.nomTextBox.TabIndex = 34;
            // 
            // nomFamilleLabel
            // 
            this.nomFamilleLabel.AutoSize = true;
            this.nomFamilleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomFamilleLabel.Location = new System.Drawing.Point(4, 62);
            this.nomFamilleLabel.Name = "nomFamilleLabel";
            this.nomFamilleLabel.Size = new System.Drawing.Size(59, 20);
            this.nomFamilleLabel.TabIndex = 33;
            this.nomFamilleLabel.Text = " Nom :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(216, 25);
            this.title_label.TabIndex = 32;
            this.title_label.Text = "Modification Famille :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(312, 100);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 31;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 30;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nomFamilleOriginLabel
            // 
            this.nomFamilleOriginLabel.AutoSize = true;
            this.nomFamilleOriginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomFamilleOriginLabel.Location = new System.Drawing.Point(237, 14);
            this.nomFamilleOriginLabel.Name = "nomFamilleOriginLabel";
            this.nomFamilleOriginLabel.Size = new System.Drawing.Size(103, 20);
            this.nomFamilleOriginLabel.TabIndex = 35;
            this.nomFamilleOriginLabel.Text = " NomFamille";
            // 
            // FormModifFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 142);
            this.Controls.Add(this.nomFamilleOriginLabel);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomFamilleLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormModifFamille";
            this.Text = "Modification Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Label nomFamilleLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label nomFamilleOriginLabel;
    }
}