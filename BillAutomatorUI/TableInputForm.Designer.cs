namespace BillAutomatorUI
{
    partial class TableInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableInputForm));
            this.cancelTablesButton = new System.Windows.Forms.Button();
            this.confirmTablesButton = new System.Windows.Forms.Button();
            this.entriesTableTextBox = new System.Windows.Forms.TextBox();
            this.entriesTableLabel = new System.Windows.Forms.Label();
            this.billTypeDropDown = new System.Windows.Forms.ComboBox();
            this.typeBillLabel = new System.Windows.Forms.Label();
            this.solTableTextBox = new System.Windows.Forms.TextBox();
            this.solTableLabel = new System.Windows.Forms.Label();
            this.disbursementsTableTextBox = new System.Windows.Forms.TextBox();
            this.disbursementsTableLabel = new System.Windows.Forms.Label();
            this.hasDisbursementsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelTablesButton
            // 
            this.cancelTablesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancelTablesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.cancelTablesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelTablesButton.Location = new System.Drawing.Point(499, 271);
            this.cancelTablesButton.Name = "cancelTablesButton";
            this.cancelTablesButton.Size = new System.Drawing.Size(148, 52);
            this.cancelTablesButton.TabIndex = 14;
            this.cancelTablesButton.Text = "Cancel";
            this.cancelTablesButton.UseVisualStyleBackColor = true;
            this.cancelTablesButton.Click += new System.EventHandler(this.cancelTablesButton_Click);
            // 
            // confirmTablesButton
            // 
            this.confirmTablesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.confirmTablesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.confirmTablesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmTablesButton.Location = new System.Drawing.Point(675, 271);
            this.confirmTablesButton.Name = "confirmTablesButton";
            this.confirmTablesButton.Size = new System.Drawing.Size(148, 52);
            this.confirmTablesButton.TabIndex = 13;
            this.confirmTablesButton.Text = "Confirm";
            this.confirmTablesButton.UseVisualStyleBackColor = true;
            this.confirmTablesButton.Click += new System.EventHandler(this.confirmTablesButton_Click);
            // 
            // entriesTableTextBox
            // 
            this.entriesTableTextBox.Location = new System.Drawing.Point(450, 153);
            this.entriesTableTextBox.Name = "entriesTableTextBox";
            this.entriesTableTextBox.Size = new System.Drawing.Size(373, 35);
            this.entriesTableTextBox.TabIndex = 20;
            // 
            // entriesTableLabel
            // 
            this.entriesTableLabel.AutoSize = true;
            this.entriesTableLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entriesTableLabel.Location = new System.Drawing.Point(14, 144);
            this.entriesTableLabel.Name = "entriesTableLabel";
            this.entriesTableLabel.Size = new System.Drawing.Size(311, 45);
            this.entriesTableLabel.TabIndex = 19;
            this.entriesTableLabel.Text = "Entries Table Number";
            // 
            // billTypeDropDown
            // 
            this.billTypeDropDown.FormattingEnabled = true;
            this.billTypeDropDown.Location = new System.Drawing.Point(450, 21);
            this.billTypeDropDown.Name = "billTypeDropDown";
            this.billTypeDropDown.Size = new System.Drawing.Size(373, 38);
            this.billTypeDropDown.TabIndex = 18;
            this.billTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.billTypeDropDown_SelectedIndexChanged);
            // 
            // typeBillLabel
            // 
            this.typeBillLabel.AutoSize = true;
            this.typeBillLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeBillLabel.Location = new System.Drawing.Point(14, 12);
            this.typeBillLabel.Name = "typeBillLabel";
            this.typeBillLabel.Size = new System.Drawing.Size(168, 45);
            this.typeBillLabel.TabIndex = 17;
            this.typeBillLabel.Text = "Type of Bill";
            // 
            // solTableTextBox
            // 
            this.solTableTextBox.Location = new System.Drawing.Point(450, 89);
            this.solTableTextBox.Name = "solTableTextBox";
            this.solTableTextBox.Size = new System.Drawing.Size(373, 35);
            this.solTableTextBox.TabIndex = 16;
            // 
            // solTableLabel
            // 
            this.solTableLabel.AutoSize = true;
            this.solTableLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solTableLabel.Location = new System.Drawing.Point(14, 80);
            this.solTableLabel.Name = "solTableLabel";
            this.solTableLabel.Size = new System.Drawing.Size(330, 45);
            this.solTableLabel.TabIndex = 15;
            this.solTableLabel.Text = "Solicitor Table Number";
            // 
            // disbursementsTableTextBox
            // 
            this.disbursementsTableTextBox.Location = new System.Drawing.Point(450, 217);
            this.disbursementsTableTextBox.Name = "disbursementsTableTextBox";
            this.disbursementsTableTextBox.Size = new System.Drawing.Size(373, 35);
            this.disbursementsTableTextBox.TabIndex = 22;
            // 
            // disbursementsTableLabel
            // 
            this.disbursementsTableLabel.AutoSize = true;
            this.disbursementsTableLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disbursementsTableLabel.Location = new System.Drawing.Point(14, 208);
            this.disbursementsTableLabel.Name = "disbursementsTableLabel";
            this.disbursementsTableLabel.Size = new System.Drawing.Size(418, 45);
            this.disbursementsTableLabel.TabIndex = 21;
            this.disbursementsTableLabel.Text = "Disbursements Table Number";
            // 
            // hasDisbursementsCheckBox
            // 
            this.hasDisbursementsCheckBox.AutoSize = true;
            this.hasDisbursementsCheckBox.Location = new System.Drawing.Point(22, 266);
            this.hasDisbursementsCheckBox.Name = "hasDisbursementsCheckBox";
            this.hasDisbursementsCheckBox.Size = new System.Drawing.Size(160, 64);
            this.hasDisbursementsCheckBox.TabIndex = 28;
            this.hasDisbursementsCheckBox.Text = "Matter has \r\nDibursements";
            this.hasDisbursementsCheckBox.UseVisualStyleBackColor = true;
            // 
            // TableInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 334);
            this.Controls.Add(this.hasDisbursementsCheckBox);
            this.Controls.Add(this.disbursementsTableTextBox);
            this.Controls.Add(this.disbursementsTableLabel);
            this.Controls.Add(this.entriesTableTextBox);
            this.Controls.Add(this.entriesTableLabel);
            this.Controls.Add(this.billTypeDropDown);
            this.Controls.Add(this.typeBillLabel);
            this.Controls.Add(this.solTableTextBox);
            this.Controls.Add(this.solTableLabel);
            this.Controls.Add(this.cancelTablesButton);
            this.Controls.Add(this.confirmTablesButton);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TableInputForm";
            this.Text = "Input Tables to Read";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelTablesButton;
        private System.Windows.Forms.Button confirmTablesButton;
        private System.Windows.Forms.TextBox entriesTableTextBox;
        private System.Windows.Forms.Label entriesTableLabel;
        private System.Windows.Forms.ComboBox billTypeDropDown;
        private System.Windows.Forms.Label typeBillLabel;
        private System.Windows.Forms.TextBox solTableTextBox;
        private System.Windows.Forms.Label solTableLabel;
        private System.Windows.Forms.TextBox disbursementsTableTextBox;
        private System.Windows.Forms.Label disbursementsTableLabel;
        private System.Windows.Forms.CheckBox hasDisbursementsCheckBox;
    }
}