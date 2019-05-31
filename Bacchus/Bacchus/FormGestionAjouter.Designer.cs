namespace Bacchus
{
    partial class FormGestionAjouter
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
            this.title_label = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.objectComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(3, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(94, 25);
            this.title_label.TabIndex = 28;
            this.title_label.Text = "Ajouter :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(244, 92);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 32);
            this.addButton.TabIndex = 30;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(67, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 29;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
            this.objectComboBox.Location = new System.Drawing.Point(135, 51);
            this.objectComboBox.Name = "objectComboBox";
            this.objectComboBox.Size = new System.Drawing.Size(247, 24);
            this.objectComboBox.Sorted = true;
            this.objectComboBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Objet à ajouter :";
            // 
            // FormGestionAjouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objectComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.title_label);
            this.Name = "FormGestionAjouter";
            this.Text = "Gestionnaire Ajouter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox objectComboBox;
        private System.Windows.Forms.Label label1;
    }
}