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
            this.solTableTextBox = new System.Windows.Forms.TextBox();
            this.solTableLabel = new System.Windows.Forms.Label();
            this.typeBillLabel = new System.Windows.Forms.Label();
            this.billTypeDropDown = new System.Windows.Forms.ComboBox();
            this.entriesTableTextBox = new System.Windows.Forms.TextBox();
            this.entriesTableLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(35, 322);
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
            this.createFileButton.Location = new System.Drawing.Point(688, 322);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(148, 52);
            this.createFileButton.TabIndex = 3;
            this.createFileButton.Text = "Create New";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // solTableTextBox
            // 
            this.solTableTextBox.Location = new System.Drawing.Point(463, 131);
            this.solTableTextBox.Name = "solTableTextBox";
            this.solTableTextBox.Size = new System.Drawing.Size(373, 35);
            this.solTableTextBox.TabIndex = 5;
            // 
            // solTableLabel
            // 
            this.solTableLabel.AutoSize = true;
            this.solTableLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solTableLabel.Location = new System.Drawing.Point(27, 122);
            this.solTableLabel.Name = "solTableLabel";
            this.solTableLabel.Size = new System.Drawing.Size(330, 45);
            this.solTableLabel.TabIndex = 4;
            this.solTableLabel.Text = "Solicitor Table Number";
            // 
            // typeBillLabel
            // 
            this.typeBillLabel.AutoSize = true;
            this.typeBillLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeBillLabel.Location = new System.Drawing.Point(27, 28);
            this.typeBillLabel.Name = "typeBillLabel";
            this.typeBillLabel.Size = new System.Drawing.Size(168, 45);
            this.typeBillLabel.TabIndex = 6;
            this.typeBillLabel.Text = "Type of Bill";
            // 
            // billTypeDropDown
            // 
            this.billTypeDropDown.FormattingEnabled = true;
            this.billTypeDropDown.Location = new System.Drawing.Point(463, 37);
            this.billTypeDropDown.Name = "billTypeDropDown";
            this.billTypeDropDown.Size = new System.Drawing.Size(373, 38);
            this.billTypeDropDown.TabIndex = 10;
            this.billTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.billTypeDropDown_SelectedIndexChanged);
            // 
            // entriesTableTextBox
            // 
            this.entriesTableTextBox.Location = new System.Drawing.Point(463, 195);
            this.entriesTableTextBox.Name = "entriesTableTextBox";
            this.entriesTableTextBox.Size = new System.Drawing.Size(373, 35);
            this.entriesTableTextBox.TabIndex = 12;
            // 
            // entriesTableLabel
            // 
            this.entriesTableLabel.AutoSize = true;
            this.entriesTableLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entriesTableLabel.Location = new System.Drawing.Point(27, 186);
            this.entriesTableLabel.Name = "entriesTableLabel";
            this.entriesTableLabel.Size = new System.Drawing.Size(311, 45);
            this.entriesTableLabel.TabIndex = 11;
            this.entriesTableLabel.Text = "Entries Table Number";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 386);
            this.Controls.Add(this.entriesTableTextBox);
            this.Controls.Add(this.entriesTableLabel);
            this.Controls.Add(this.billTypeDropDown);
            this.Controls.Add(this.typeBillLabel);
            this.Controls.Add(this.solTableTextBox);
            this.Controls.Add(this.solTableLabel);
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
        private System.Windows.Forms.TextBox solTableTextBox;
        private System.Windows.Forms.Label solTableLabel;
        private System.Windows.Forms.Label typeBillLabel;
        private System.Windows.Forms.ComboBox billTypeDropDown;
        private System.Windows.Forms.TextBox entriesTableTextBox;
        private System.Windows.Forms.Label entriesTableLabel;
    }
}

