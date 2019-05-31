namespace Bacchus
{
    partial class FormGestionModifier
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
            this.Objetlabel = new System.Windows.Forms.Label();
            this.objectComboBox = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Objetlabel
            // 
            this.Objetlabel.AutoSize = true;
            this.Objetlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Objetlabel.Location = new System.Drawing.Point(5, 52);
            this.Objetlabel.Name = "Objetlabel";
            this.Objetlabel.Size = new System.Drawing.Size(120, 18);
            this.Objetlabel.TabIndex = 37;
            this.Objetlabel.Text = "Objet à modifier :";
            // 
            // objectComboBox
            // 
            this.objectComboBox.DisplayMember = "Article";
            this.objectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectComboBox.FormattingEnabled = true;
            this.objectComboBox.Items.AddRange(new object[] {
            "Article",
            "Famille",
            "Marque",
            "Sous-Famille"});
            this.objectComboBox.Location = new System.Drawing.Point(143, 51);
            this.objectComboBox.Name = "objectComboBox";
            this.objectComboBox.Size = new System.Drawing.Size(239, 24);
            this.objectComboBox.Sorted = true;
            this.objectComboBox.TabIndex = 36;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(244, 92);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(138, 32);
            this.updateButton.TabIndex = 35;
            this.updateButton.Text = "Modifier";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(67, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(102, 25);
            this.title_label.TabIndex = 33;
            this.title_label.Text = "Modifier :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGestionModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 132);
            this.Controls.Add(this.Objetlabel);
            this.Controls.Add(this.objectComboBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.title_label);
            this.Name = "FormGestionModifier";
            this.Text = "Gestionnaire Modifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Objetlabel;
        private System.Windows.Forms.ComboBox objectComboBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label title_label;
    }
}