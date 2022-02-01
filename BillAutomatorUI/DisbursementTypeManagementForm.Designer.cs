namespace BillAutomatorUI
{
    partial class DisbursementTypeManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisbursementTypeManagementForm));
            this.returnButton = new System.Windows.Forms.Button();
            this.editTypeButton = new System.Windows.Forms.Button();
            this.addTypeButton = new System.Windows.Forms.Button();
            this.DisbursementTypesBox = new System.Windows.Forms.ListBox();
            this.disbursementTypesLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // returnButton
            // 
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(458, 353);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(148, 52);
            this.returnButton.TabIndex = 36;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // editTypeButton
            // 
            this.editTypeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.editTypeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.editTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editTypeButton.Location = new System.Drawing.Point(458, 93);
            this.editTypeButton.Name = "editTypeButton";
            this.editTypeButton.Size = new System.Drawing.Size(148, 52);
            this.editTypeButton.TabIndex = 35;
            this.editTypeButton.Text = "Edit Selected";
            this.editTypeButton.UseVisualStyleBackColor = true;
            this.editTypeButton.Click += new System.EventHandler(this.editTypeButton_Click);
            // 
            // addTypeButton
            // 
            this.addTypeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.addTypeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.addTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTypeButton.Location = new System.Drawing.Point(458, 16);
            this.addTypeButton.Name = "addTypeButton";
            this.addTypeButton.Size = new System.Drawing.Size(148, 52);
            this.addTypeButton.TabIndex = 34;
            this.addTypeButton.Text = "Add New";
            this.addTypeButton.UseVisualStyleBackColor = true;
            this.addTypeButton.Click += new System.EventHandler(this.addTypeButton_Click);
            // 
            // DisbursementTypesBox
            // 
            this.DisbursementTypesBox.FormattingEnabled = true;
            this.DisbursementTypesBox.ItemHeight = 30;
            this.DisbursementTypesBox.Location = new System.Drawing.Point(31, 71);
            this.DisbursementTypesBox.Name = "DisbursementTypesBox";
            this.DisbursementTypesBox.Size = new System.Drawing.Size(386, 334);
            this.DisbursementTypesBox.TabIndex = 33;
            // 
            // disbursementTypesLabel
            // 
            this.disbursementTypesLabel.AutoSize = true;
            this.disbursementTypesLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disbursementTypesLabel.Location = new System.Drawing.Point(23, 15);
            this.disbursementTypesLabel.Name = "disbursementTypesLabel";
            this.disbursementTypesLabel.Size = new System.Drawing.Size(290, 45);
            this.disbursementTypesLabel.TabIndex = 32;
            this.disbursementTypesLabel.Text = "Disbursement Types";
            // 
            // deleteButton
            // 
            this.deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(458, 169);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(148, 52);
            this.deleteButton.TabIndex = 37;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // DisbursementTypeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 420);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.editTypeButton);
            this.Controls.Add(this.addTypeButton);
            this.Controls.Add(this.DisbursementTypesBox);
            this.Controls.Add(this.disbursementTypesLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "DisbursementTypeManagementForm";
            this.Text = "Disbursement Types Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisbursementTypeManagementForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button editTypeButton;
        private System.Windows.Forms.Button addTypeButton;
        private System.Windows.Forms.ListBox DisbursementTypesBox;
        private System.Windows.Forms.Label disbursementTypesLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}