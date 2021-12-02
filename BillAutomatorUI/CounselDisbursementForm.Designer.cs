namespace BillAutomatorUI
{
    partial class CounselDisbursementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounselDisbursementForm));
            this.cancelEntryButton = new System.Windows.Forms.Button();
            this.createEntryButton = new System.Windows.Forms.Button();
            this.noChargeCheckBox = new System.Windows.Forms.CheckBox();
            this.counselDropDown = new System.Windows.Forms.ComboBox();
            this.counselLabel = new System.Windows.Forms.Label();
            this.totalInput = new System.Windows.Forms.NumericUpDown();
            this.totalLabel = new System.Windows.Forms.Label();
            this.gstInput = new System.Windows.Forms.NumericUpDown();
            this.gstLabel = new System.Windows.Forms.Label();
            this.hoursInput = new System.Windows.Forms.NumericUpDown();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.totalInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gstInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursInput)).BeginInit();
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
            // counselDropDown
            // 
            this.counselDropDown.FormattingEnabled = true;
            this.counselDropDown.Location = new System.Drawing.Point(194, 337);
            this.counselDropDown.Name = "counselDropDown";
            this.counselDropDown.Size = new System.Drawing.Size(165, 38);
            this.counselDropDown.TabIndex = 40;
            // 
            // counselLabel
            // 
            this.counselLabel.AutoSize = true;
            this.counselLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counselLabel.Location = new System.Drawing.Point(16, 328);
            this.counselLabel.Name = "counselLabel";
            this.counselLabel.Size = new System.Drawing.Size(127, 45);
            this.counselLabel.TabIndex = 39;
            this.counselLabel.Text = "Counsel";
            // 
            // totalInput
            // 
            this.totalInput.DecimalPlaces = 1;
            this.totalInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
            this.gstInput.DecimalPlaces = 1;
            this.gstInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
            // hoursInput
            // 
            this.hoursInput.DecimalPlaces = 1;
            this.hoursInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.hoursInput.Location = new System.Drawing.Point(194, 260);
            this.hoursInput.Name = "hoursInput";
            this.hoursInput.Size = new System.Drawing.Size(165, 35);
            this.hoursInput.TabIndex = 34;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursLabel.Location = new System.Drawing.Point(16, 250);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(100, 45);
            this.hoursLabel.TabIndex = 33;
            this.hoursLabel.Text = "Hours";
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
            // CounselDisbursementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 405);
            this.Controls.Add(this.cancelEntryButton);
            this.Controls.Add(this.createEntryButton);
            this.Controls.Add(this.noChargeCheckBox);
            this.Controls.Add(this.counselDropDown);
            this.Controls.Add(this.counselLabel);
            this.Controls.Add(this.totalInput);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.gstInput);
            this.Controls.Add(this.gstLabel);
            this.Controls.Add(this.hoursInput);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.dateLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "CounselDisbursementForm";
            this.Text = "Counsel Disbursements";
            ((System.ComponentModel.ISupportInitialize)(this.totalInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gstInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelEntryButton;
        private System.Windows.Forms.Button createEntryButton;
        private System.Windows.Forms.CheckBox noChargeCheckBox;
        private System.Windows.Forms.ComboBox counselDropDown;
        private System.Windows.Forms.Label counselLabel;
        private System.Windows.Forms.NumericUpDown totalInput;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.NumericUpDown gstInput;
        private System.Windows.Forms.Label gstLabel;
        private System.Windows.Forms.NumericUpDown hoursInput;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label dateLabel;
    }
}