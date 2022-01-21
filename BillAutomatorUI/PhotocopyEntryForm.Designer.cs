namespace BillAutomatorUI
{
    partial class PhotocopyEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotocopyEntryForm));
            this.returnButton = new System.Windows.Forms.Button();
            this.editCounselButton = new System.Windows.Forms.Button();
            this.addCounselButton = new System.Windows.Forms.Button();
            this.counselBox = new System.Windows.Forms.ListBox();
            this.counselLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // returnButton
            // 
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(460, 345);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(148, 52);
            this.returnButton.TabIndex = 36;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            // 
            // editCounselButton
            // 
            this.editCounselButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.editCounselButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.editCounselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCounselButton.Location = new System.Drawing.Point(460, 93);
            this.editCounselButton.Name = "editCounselButton";
            this.editCounselButton.Size = new System.Drawing.Size(148, 52);
            this.editCounselButton.TabIndex = 35;
            this.editCounselButton.Text = "Edit Selected";
            this.editCounselButton.UseVisualStyleBackColor = true;
            // 
            // addCounselButton
            // 
            this.addCounselButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.addCounselButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.addCounselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCounselButton.Location = new System.Drawing.Point(460, 12);
            this.addCounselButton.Name = "addCounselButton";
            this.addCounselButton.Size = new System.Drawing.Size(148, 52);
            this.addCounselButton.TabIndex = 34;
            this.addCounselButton.Text = "Add New";
            this.addCounselButton.UseVisualStyleBackColor = true;
            // 
            // counselBox
            // 
            this.counselBox.FormattingEnabled = true;
            this.counselBox.ItemHeight = 30;
            this.counselBox.Location = new System.Drawing.Point(33, 63);
            this.counselBox.Name = "counselBox";
            this.counselBox.Size = new System.Drawing.Size(386, 334);
            this.counselBox.TabIndex = 33;
            // 
            // counselLabel
            // 
            this.counselLabel.AutoSize = true;
            this.counselLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counselLabel.Location = new System.Drawing.Point(25, 11);
            this.counselLabel.Name = "counselLabel";
            this.counselLabel.Size = new System.Drawing.Size(185, 45);
            this.counselLabel.TabIndex = 32;
            this.counselLabel.Text = "Photocopies";
            // 
            // PhotocopyManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 409);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.editCounselButton);
            this.Controls.Add(this.addCounselButton);
            this.Controls.Add(this.counselBox);
            this.Controls.Add(this.counselLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "PhotocopyManagementForm";
            this.Text = "Photocopy Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button editCounselButton;
        private System.Windows.Forms.Button addCounselButton;
        private System.Windows.Forms.ListBox counselBox;
        private System.Windows.Forms.Label counselLabel;
    }
}