namespace BillAutomatorUI
{
    partial class EditCreateDisbursementTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCreateDisbursementTypeForm));
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.DefaultTypesBox = new System.Windows.Forms.ListBox();
            this.defaultTypesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(113, 21);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(407, 35);
            this.typeTextBox.TabIndex = 22;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(22, 12);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(85, 45);
            this.typeLabel.TabIndex = 21;
            this.typeLabel.Text = "Type";
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(285, 373);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(148, 52);
            this.saveButton.TabIndex = 35;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(99, 373);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(148, 52);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DefaultTypesBox
            // 
            this.DefaultTypesBox.FormattingEnabled = true;
            this.DefaultTypesBox.ItemHeight = 30;
            this.DefaultTypesBox.Location = new System.Drawing.Point(30, 123);
            this.DefaultTypesBox.Name = "DefaultTypesBox";
            this.DefaultTypesBox.Size = new System.Drawing.Size(490, 244);
            this.DefaultTypesBox.TabIndex = 37;
            this.DefaultTypesBox.SelectedIndexChanged += new System.EventHandler(this.DefaultTypesBox_SelectedIndexChanged);
            // 
            // defaultTypesLabel
            // 
            this.defaultTypesLabel.AutoSize = true;
            this.defaultTypesLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTypesLabel.Location = new System.Drawing.Point(22, 75);
            this.defaultTypesLabel.Name = "defaultTypesLabel";
            this.defaultTypesLabel.Size = new System.Drawing.Size(203, 45);
            this.defaultTypesLabel.TabIndex = 36;
            this.defaultTypesLabel.Text = "Default Types";
            // 
            // EditCreateDisbursementTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 436);
            this.Controls.Add(this.DefaultTypesBox);
            this.Controls.Add(this.defaultTypesLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.typeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditCreateDisbursementTypeForm";
            this.Text = "Create/Edit Disbursement Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCreateDisbursementTypeForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox DefaultTypesBox;
        private System.Windows.Forms.Label defaultTypesLabel;
    }
}