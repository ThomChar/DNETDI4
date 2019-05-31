namespace Bacchus
{
    partial class FormModifMarque
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
            this.nomMarqueLabel = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nomMarqueOriginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.Location = new System.Drawing.Point(87, 62);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(362, 24);
            this.nomTextBox.TabIndex = 24;
            this.nomTextBox.Text = "ex : Marque ...";
            this.nomTextBox.Enter += new System.EventHandler(this.nomTextBox_Enter);
            // 
            // nomMarqueLabel
            // 
            this.nomMarqueLabel.AutoSize = true;
            this.nomMarqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomMarqueLabel.Location = new System.Drawing.Point(3, 62);
            this.nomMarqueLabel.Name = "nomMarqueLabel";
            this.nomMarqueLabel.Size = new System.Drawing.Size(59, 20);
            this.nomMarqueLabel.TabIndex = 23;
            this.nomMarqueLabel.Text = " Nom :";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(2, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(220, 25);
            this.title_label.TabIndex = 22;
            this.title_label.Text = "Modification Marque :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(311, 110);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(138, 32);
            this.updateButton.TabIndex = 21;
            this.updateButton.Text = "Modifier";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 110);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nomMarqueOriginLabel
            // 
            this.nomMarqueOriginLabel.AutoSize = true;
            this.nomMarqueOriginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomMarqueOriginLabel.Location = new System.Drawing.Point(237, 14);
            this.nomMarqueOriginLabel.Name = "nomMarqueOriginLabel";
            this.nomMarqueOriginLabel.Size = new System.Drawing.Size(105, 20);
            this.nomMarqueOriginLabel.TabIndex = 25;
            this.nomMarqueOriginLabel.Text = " NomMarque";
            // 
            // FormModifMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 153);
            this.Controls.Add(this.nomMarqueOriginLabel);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomMarqueLabel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormModifMarque";
            this.Text = "Modification Marque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Label nomMarqueLabel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label nomMarqueOriginLabel;
    }
}