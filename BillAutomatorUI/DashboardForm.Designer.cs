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
            this.openFileLabel = new System.Windows.Forms.Label();
            this.openFileTextBox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileLabel.Location = new System.Drawing.Point(32, 28);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(149, 45);
            this.openFileLabel.TabIndex = 0;
            this.openFileLabel.Text = "Open File";
            // 
            // openFileTextBox
            // 
            this.openFileTextBox.Location = new System.Drawing.Point(212, 37);
            this.openFileTextBox.Name = "openFileTextBox";
            this.openFileTextBox.Size = new System.Drawing.Size(309, 35);
            this.openFileTextBox.TabIndex = 1;
            // 
            // openFileButton
            // 
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(40, 146);
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
            this.createFileButton.Location = new System.Drawing.Point(373, 146);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(148, 52);
            this.createFileButton.TabIndex = 3;
            this.createFileButton.Text = "Create New";
            this.createFileButton.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 213);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.openFileTextBox);
            this.Controls.Add(this.openFileLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "DashboardForm";
            this.Text = "Bill of costs Automator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label openFileLabel;
        private System.Windows.Forms.TextBox openFileTextBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button createFileButton;
    }
}

