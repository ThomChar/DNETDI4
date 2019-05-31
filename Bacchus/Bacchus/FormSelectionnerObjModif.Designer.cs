namespace Bacchus
{
    partial class FormSelectionnerObjModif
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
            this.objetLabel = new System.Windows.Forms.Label();
            this.ObjetComboBox = new System.Windows.Forms.ComboBox();
            this.title_label = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objetLabel
            // 
            this.objetLabel.AutoSize = true;
            this.objetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objetLabel.Location = new System.Drawing.Point(3, 55);
            this.objetLabel.Name = "objetLabel";
            this.objetLabel.Size = new System.Drawing.Size(64, 20);
            this.objetLabel.TabIndex = 40;
            this.objetLabel.Text = " Objet :";
            // 
            // ObjetComboBox
            // 
            this.ObjetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjetComboBox.FormattingEnabled = true;
            this.ObjetComboBox.Location = new System.Drawing.Point(96, 55);
            this.ObjetComboBox.Name = "ObjetComboBox";
            this.ObjetComboBox.Size = new System.Drawing.Size(457, 24);
            this.ObjetComboBox.TabIndex = 39;
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(2, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(204, 25);
            this.title_label.TabIndex = 36;
            this.title_label.Text = "Selectionner Objet :";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(415, 100);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(138, 32);
            this.updateButton.TabIndex = 35;
            this.updateButton.Text = "Modifier";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(234, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 32);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormSelectionnerObjModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 143);
            this.Controls.Add(this.objetLabel);
            this.Controls.Add(this.ObjetComboBox);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "FormSelectionnerObjModif";
            this.Text = "Selection Objet Modifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label objetLabel;
        private System.Windows.Forms.ComboBox ObjetComboBox;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
    }
}