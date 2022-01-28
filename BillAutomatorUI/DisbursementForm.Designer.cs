namespace BillAutomatorUI
{
    partial class DisbursementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisbursementForm));
            this.cancelEntryButton = new System.Windows.Forms.Button();
            this.createEntryButton = new System.Windows.Forms.Button();
            this.noChargeCheckBox = new System.Windows.Forms.CheckBox();
            this.totalInput = new System.Windows.Forms.NumericUpDown();
            this.totalLabel = new System.Windows.Forms.Label();
            this.gstInput = new System.Windows.Forms.NumericUpDown();
            this.gstLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.barristersFeesButton = new System.Windows.Forms.Button();
            this.gstCheckBox = new System.Windows.Forms.CheckBox();
            this.typeDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.totalInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gstInput)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelEntryButton
            // 
            this.cancelEntryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancelEntryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.cancelEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelEntryButton.Location = new System.Drawing.Point(597, 329);
            this.cancelEntryButton.Name = "cancelEntryButton";
            this.cancelEntryButton.Size = new System.Drawing.Size(148, 52);
            this.cancelEntryButton.TabIndex = 43;
            this.cancelEntryButton.Text = "Cancel";
            this.cancelEntryButton.UseVisualStyleBackColor = true;
            this.cancelEntryButton.Click += new System.EventHandler(this.cancelEntryButton_Click);
            // 
            // createEntryButton
            // 
            this.createEntryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createEntryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.createEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createEntryButton.Location = new System.Drawing.Point(751, 329);
            this.createEntryButton.Name = "createEntryButton";
            this.createEntryButton.Size = new System.Drawing.Size(148, 52);
            this.createEntryButton.TabIndex = 42;
            this.createEntryButton.Text = "Create";
            this.createEntryButton.UseVisualStyleBackColor = true;
            // 
            // noChargeCheckBox
            // 
            this.noChargeCheckBox.AutoSize = true;
            this.noChargeCheckBox.Location = new System.Drawing.Point(455, 339);
            this.noChargeCheckBox.Name = "noChargeCheckBox";
            this.noChargeCheckBox.Size = new System.Drawing.Size(132, 34);
            this.noChargeCheckBox.TabIndex = 41;
            this.noChargeCheckBox.Text = "No Charge";
            this.noChargeCheckBox.UseVisualStyleBackColor = true;
            // 
            // totalInput
            // 
            this.totalInput.DecimalPlaces = 2;
            this.totalInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.totalInput.Location = new System.Drawing.Point(779, 260);
            this.totalInput.Name = "totalInput";
            this.totalInput.Size = new System.Drawing.Size(120, 35);
            this.totalInput.TabIndex = 38;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(686, 250);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(87, 45);
            this.totalLabel.TabIndex = 37;
            this.totalLabel.Text = "Total";
            // 
            // gstInput
            // 
            this.gstInput.DecimalPlaces = 2;
            this.gstInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.gstInput.Location = new System.Drawing.Point(526, 260);
            this.gstInput.Name = "gstInput";
            this.gstInput.Size = new System.Drawing.Size(120, 35);
            this.gstInput.TabIndex = 36;
            // 
            // gstLabel
            // 
            this.gstLabel.AutoSize = true;
            this.gstLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gstLabel.Location = new System.Drawing.Point(447, 250);
            this.gstLabel.Name = "gstLabel";
            this.gstLabel.Size = new System.Drawing.Size(73, 45);
            this.gstLabel.TabIndex = 35;
            this.gstLabel.Text = "GST";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(474, 23);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(85, 45);
            this.typeLabel.TabIndex = 33;
            this.typeLabel.Text = "Type";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(194, 105);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(705, 129);
            this.descriptionTextBox.TabIndex = 32;
            this.descriptionTextBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(16, 96);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(172, 45);
            this.descriptionLabel.TabIndex = 31;
            this.descriptionLabel.Text = "Description";
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeBox.Location = new System.Drawing.Point(194, 31);
            this.dateTimeBox.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimeBox.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(145, 35);
            this.dateTimeBox.TabIndex = 30;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(16, 23);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(84, 45);
            this.dateLabel.TabIndex = 29;
            this.dateLabel.Text = "Date";
            // 
            // barristersFeesButton
            // 
            this.barristersFeesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.barristersFeesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.barristersFeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.barristersFeesButton.Location = new System.Drawing.Point(24, 329);
            this.barristersFeesButton.Name = "barristersFeesButton";
            this.barristersFeesButton.Size = new System.Drawing.Size(164, 52);
            this.barristersFeesButton.TabIndex = 44;
            this.barristersFeesButton.Text = "Barristers Fees";
            this.barristersFeesButton.UseVisualStyleBackColor = true;
            // 
            // gstCheckBox
            // 
            this.gstCheckBox.AutoSize = true;
            this.gstCheckBox.Location = new System.Drawing.Point(291, 339);
            this.gstCheckBox.Name = "gstCheckBox";
            this.gstCheckBox.Size = new System.Drawing.Size(102, 34);
            this.gstCheckBox.TabIndex = 45;
            this.gstCheckBox.Text = "No GST";
            this.gstCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeDropDown
            // 
            this.typeDropDown.FormattingEnabled = true;
            this.typeDropDown.Location = new System.Drawing.Point(572, 32);
            this.typeDropDown.Name = "typeDropDown";
            this.typeDropDown.Size = new System.Drawing.Size(327, 38);
            this.typeDropDown.TabIndex = 46;
            // 
            // DisbursementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 405);
            this.Controls.Add(this.typeDropDown);
            this.Controls.Add(this.gstCheckBox);
            this.Controls.Add(this.barristersFeesButton);
            this.Controls.Add(this.cancelEntryButton);
            this.Controls.Add(this.createEntryButton);
            this.Controls.Add(this.noChargeCheckBox);
            this.Controls.Add(this.totalInput);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.gstInput);
            this.Controls.Add(this.gstLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.dateLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "DisbursementForm";
            this.Text = "Create Disbursement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisbursementForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.totalInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gstInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelEntryButton;
        private System.Windows.Forms.Button createEntryButton;
        private System.Windows.Forms.CheckBox noChargeCheckBox;
        private System.Windows.Forms.NumericUpDown totalInput;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.NumericUpDown gstInput;
        private System.Windows.Forms.Label gstLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button barristersFeesButton;
        private System.Windows.Forms.CheckBox gstCheckBox;
        private System.Windows.Forms.ComboBox typeDropDown;
    }
}