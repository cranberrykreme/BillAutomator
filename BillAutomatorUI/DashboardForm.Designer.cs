namespace BillAutomatorUI
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.openFileButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.fileLocTextBox = new System.Windows.Forms.TextBox();
            this.fileLocLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(35, 100);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(148, 52);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "Open";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.createFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createFileButton.Location = new System.Drawing.Point(447, 100);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(148, 52);
            this.createFileButton.TabIndex = 3;
            this.createFileButton.Text = "Create New";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // fileLocTextBox
            // 
            this.fileLocTextBox.Location = new System.Drawing.Point(222, 19);
            this.fileLocTextBox.Name = "fileLocTextBox";
            this.fileLocTextBox.Size = new System.Drawing.Size(373, 35);
            this.fileLocTextBox.TabIndex = 12;
            // 
            // fileLocLabel
            // 
            this.fileLocLabel.AutoSize = true;
            this.fileLocLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLocLabel.Location = new System.Drawing.Point(27, 9);
            this.fileLocLabel.Name = "fileLocLabel";
            this.fileLocLabel.Size = new System.Drawing.Size(189, 45);
            this.fileLocLabel.TabIndex = 11;
            this.fileLocLabel.Text = "File Location";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 162);
            this.Controls.Add(this.fileLocTextBox);
            this.Controls.Add(this.fileLocLabel);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.openFileButton);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "DashboardForm";
            this.Text = "Bill of costs Automator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.TextBox fileLocTextBox;
        private System.Windows.Forms.Label fileLocLabel;
    }
}

