namespace BillAutomatorUI
{
    partial class SolicitorManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitorManagementForm));
            this.solicitorsBox = new System.Windows.Forms.ListBox();
            this.solicitorsLabel = new System.Windows.Forms.Label();
            this.addSolicitorButton = new System.Windows.Forms.Button();
            this.editSolicitorButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // solicitorsBox
            // 
            this.solicitorsBox.FormattingEnabled = true;
            this.solicitorsBox.ItemHeight = 30;
            this.solicitorsBox.Location = new System.Drawing.Point(33, 65);
            this.solicitorsBox.Name = "solicitorsBox";
            this.solicitorsBox.Size = new System.Drawing.Size(386, 334);
            this.solicitorsBox.TabIndex = 10;
            // 
            // solicitorsLabel
            // 
            this.solicitorsLabel.AutoSize = true;
            this.solicitorsLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solicitorsLabel.Location = new System.Drawing.Point(25, 9);
            this.solicitorsLabel.Name = "solicitorsLabel";
            this.solicitorsLabel.Size = new System.Drawing.Size(140, 45);
            this.solicitorsLabel.TabIndex = 9;
            this.solicitorsLabel.Text = "Solicitors";
            // 
            // addSolicitorButton
            // 
            this.addSolicitorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.addSolicitorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.addSolicitorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSolicitorButton.Location = new System.Drawing.Point(460, 10);
            this.addSolicitorButton.Name = "addSolicitorButton";
            this.addSolicitorButton.Size = new System.Drawing.Size(148, 52);
            this.addSolicitorButton.TabIndex = 29;
            this.addSolicitorButton.Text = "Add New";
            this.addSolicitorButton.UseVisualStyleBackColor = true;
            this.addSolicitorButton.Click += new System.EventHandler(this.addSolicitorButton_Click);
            // 
            // editSolicitorButton
            // 
            this.editSolicitorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.editSolicitorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.editSolicitorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSolicitorButton.Location = new System.Drawing.Point(460, 87);
            this.editSolicitorButton.Name = "editSolicitorButton";
            this.editSolicitorButton.Size = new System.Drawing.Size(148, 52);
            this.editSolicitorButton.TabIndex = 30;
            this.editSolicitorButton.Text = "Edit Selected";
            this.editSolicitorButton.UseVisualStyleBackColor = true;
            this.editSolicitorButton.Click += new System.EventHandler(this.editSolicitorButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(460, 347);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(148, 52);
            this.returnButton.TabIndex = 31;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // SolicitorManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 409);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.editSolicitorButton);
            this.Controls.Add(this.addSolicitorButton);
            this.Controls.Add(this.solicitorsBox);
            this.Controls.Add(this.solicitorsLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SolicitorManagementForm";
            this.Text = "Solicitor Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox solicitorsBox;
        private System.Windows.Forms.Label solicitorsLabel;
        private System.Windows.Forms.Button addSolicitorButton;
        private System.Windows.Forms.Button editSolicitorButton;
        private System.Windows.Forms.Button returnButton;
    }
}