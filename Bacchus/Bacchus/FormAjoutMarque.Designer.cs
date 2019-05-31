namespace Bacchus
{
    partial class FormAjoutMarque
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
            this.nomMarqueLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nomMarqueLabel
            // 
            this.nomMarqueLabel.AutoSize = true;
            this.nomMarqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomMarqueLabel.Location = new System.Drawing.Point(2, 62);
            this.nomMarqueLabel.Name = "nomMarqueLabel";
            this.nomMarqueLabel.Size = new System.Drawing.Size(59, 20);
            this.nomMarqueLabel.TabIndex = 17;
            this.nomMarqueLabel.Text = " Nom :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(1, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(186, 25);
            this.title_label.TabIndex = 16;
            this.title_label.Text = "Création Marque :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(310, 114);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(141, 114);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.nomTextBox.Location = new System.Drawing.Point(86, 62);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(362, 24);
            this.nomTextBox.TabIndex = 19;
            this.nomTextBox.Text = "ex : Marque ...";
            this.nomTextBox.Enter += new System.EventHandler(this.nomTextBox_Enter);
            // 
            // FormAjoutMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 157);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomMarqueLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormAjoutMarque";
            this.Text = "Création Marque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomMarqueLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nomTextBox;
    }
}