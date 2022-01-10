namespace BillAutomatorUI
{
    partial class EditCreateSolicitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCreateSolicitorForm));
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.initialsTextBox = new System.Windows.Forms.TextBox();
            this.initialsLabel = new System.Windows.Forms.Label();
            this.hourlyRateInput = new System.Windows.Forms.NumericUpDown();
            this.hourlyRateLabel = new System.Windows.Forms.Label();
            this.dateOfAdmissionLabel = new System.Windows.Forms.Label();
            this.periodStartDate = new System.Windows.Forms.DateTimePicker();
            this.fromPeriodLabel = new System.Windows.Forms.Label();
            this.periodStartLabel = new System.Windows.Forms.Label();
            this.periodEndLabel = new System.Windows.Forms.Label();
            this.periodEndDate = new System.Windows.Forms.DateTimePicker();
            this.hourlyRatesBox = new System.Windows.Forms.ListBox();
            this.hourlyRatesLabel = new System.Windows.Forms.Label();
            this.deleteHourlyRateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.noChangeInRateCheckBox = new System.Windows.Forms.CheckBox();
            this.doaTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.hourlyRateInput)).BeginInit();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(190, 20);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(309, 35);
            this.firstNameTextBox.TabIndex = 3;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.firstNameTextBox_TextChanged);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(10, 11);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(165, 45);
            this.firstNameLabel.TabIndex = 2;
            this.firstNameLabel.Text = "First Name";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(190, 85);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(309, 35);
            this.lastNameTextBox.TabIndex = 5;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.lastNameTextBox_TextChanged);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(10, 76);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(163, 45);
            this.lastNameLabel.TabIndex = 4;
            this.lastNameLabel.Text = "Last Name";
            // 
            // initialsTextBox
            // 
            this.initialsTextBox.Location = new System.Drawing.Point(190, 146);
            this.initialsTextBox.Name = "initialsTextBox";
            this.initialsTextBox.Size = new System.Drawing.Size(71, 35);
            this.initialsTextBox.TabIndex = 7;
            this.initialsTextBox.TextChanged += new System.EventHandler(this.initialsTextBox_TextChanged);
            // 
            // initialsLabel
            // 
            this.initialsLabel.AutoSize = true;
            this.initialsLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialsLabel.Location = new System.Drawing.Point(10, 137);
            this.initialsLabel.Name = "initialsLabel";
            this.initialsLabel.Size = new System.Drawing.Size(103, 45);
            this.initialsLabel.TabIndex = 6;
            this.initialsLabel.Text = "Initials";
            // 
            // hourlyRateInput
            // 
            this.hourlyRateInput.Location = new System.Drawing.Point(190, 276);
            this.hourlyRateInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.hourlyRateInput.Name = "hourlyRateInput";
            this.hourlyRateInput.Size = new System.Drawing.Size(165, 35);
            this.hourlyRateInput.TabIndex = 20;
            // 
            // hourlyRateLabel
            // 
            this.hourlyRateLabel.AutoSize = true;
            this.hourlyRateLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourlyRateLabel.Location = new System.Drawing.Point(10, 266);
            this.hourlyRateLabel.Name = "hourlyRateLabel";
            this.hourlyRateLabel.Size = new System.Drawing.Size(179, 45);
            this.hourlyRateLabel.TabIndex = 19;
            this.hourlyRateLabel.Text = "Hourly Rate";
            // 
            // dateOfAdmissionLabel
            // 
            this.dateOfAdmissionLabel.AutoSize = true;
            this.dateOfAdmissionLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfAdmissionLabel.Location = new System.Drawing.Point(10, 195);
            this.dateOfAdmissionLabel.Name = "dateOfAdmissionLabel";
            this.dateOfAdmissionLabel.Size = new System.Drawing.Size(86, 45);
            this.dateOfAdmissionLabel.TabIndex = 21;
            this.dateOfAdmissionLabel.Text = "DOA";
            // 
            // periodStartDate
            // 
            this.periodStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.periodStartDate.Location = new System.Drawing.Point(603, 276);
            this.periodStartDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.periodStartDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.periodStartDate.Name = "periodStartDate";
            this.periodStartDate.Size = new System.Drawing.Size(145, 35);
            this.periodStartDate.TabIndex = 24;
            // 
            // fromPeriodLabel
            // 
            this.fromPeriodLabel.AutoSize = true;
            this.fromPeriodLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromPeriodLabel.Location = new System.Drawing.Point(411, 266);
            this.fromPeriodLabel.Name = "fromPeriodLabel";
            this.fromPeriodLabel.Size = new System.Drawing.Size(186, 45);
            this.fromPeriodLabel.TabIndex = 23;
            this.fromPeriodLabel.Text = "From Period";
            // 
            // periodStartLabel
            // 
            this.periodStartLabel.AutoSize = true;
            this.periodStartLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodStartLabel.Location = new System.Drawing.Point(633, 228);
            this.periodStartLabel.Name = "periodStartLabel";
            this.periodStartLabel.Size = new System.Drawing.Size(83, 45);
            this.periodStartLabel.TabIndex = 25;
            this.periodStartLabel.Text = "Start";
            // 
            // periodEndLabel
            // 
            this.periodEndLabel.AutoSize = true;
            this.periodEndLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodEndLabel.Location = new System.Drawing.Point(792, 228);
            this.periodEndLabel.Name = "periodEndLabel";
            this.periodEndLabel.Size = new System.Drawing.Size(71, 45);
            this.periodEndLabel.TabIndex = 27;
            this.periodEndLabel.Text = "End";
            // 
            // periodEndDate
            // 
            this.periodEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.periodEndDate.Location = new System.Drawing.Point(754, 276);
            this.periodEndDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.periodEndDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.periodEndDate.Name = "periodEndDate";
            this.periodEndDate.Size = new System.Drawing.Size(145, 35);
            this.periodEndDate.TabIndex = 26;
            // 
            // hourlyRatesBox
            // 
            this.hourlyRatesBox.FormattingEnabled = true;
            this.hourlyRatesBox.ItemHeight = 30;
            this.hourlyRatesBox.Location = new System.Drawing.Point(565, 71);
            this.hourlyRatesBox.Name = "hourlyRatesBox";
            this.hourlyRatesBox.Size = new System.Drawing.Size(334, 154);
            this.hourlyRatesBox.TabIndex = 29;
            // 
            // hourlyRatesLabel
            // 
            this.hourlyRatesLabel.AutoSize = true;
            this.hourlyRatesLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourlyRatesLabel.Location = new System.Drawing.Point(558, 11);
            this.hourlyRatesLabel.Name = "hourlyRatesLabel";
            this.hourlyRatesLabel.Size = new System.Drawing.Size(191, 45);
            this.hourlyRatesLabel.TabIndex = 28;
            this.hourlyRatesLabel.Text = "Hourly Rates";
            // 
            // deleteHourlyRateButton
            // 
            this.deleteHourlyRateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteHourlyRateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteHourlyRateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteHourlyRateButton.Location = new System.Drawing.Point(751, 12);
            this.deleteHourlyRateButton.Name = "deleteHourlyRateButton";
            this.deleteHourlyRateButton.Size = new System.Drawing.Size(148, 52);
            this.deleteHourlyRateButton.TabIndex = 30;
            this.deleteHourlyRateButton.Text = "Delete Rate";
            this.deleteHourlyRateButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(18, 316);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(148, 52);
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(565, 316);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(148, 52);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(751, 316);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(148, 52);
            this.saveButton.TabIndex = 33;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noChangeInRateCheckBox
            // 
            this.noChangeInRateCheckBox.AutoSize = true;
            this.noChangeInRateCheckBox.Location = new System.Drawing.Point(419, 239);
            this.noChangeInRateCheckBox.Name = "noChangeInRateCheckBox";
            this.noChangeInRateCheckBox.Size = new System.Drawing.Size(208, 34);
            this.noChangeInRateCheckBox.TabIndex = 42;
            this.noChangeInRateCheckBox.Text = "No Change in Rate";
            this.noChangeInRateCheckBox.UseVisualStyleBackColor = true;
            // 
            // doaTextBox
            // 
            this.doaTextBox.Location = new System.Drawing.Point(190, 204);
            this.doaTextBox.Name = "doaTextBox";
            this.doaTextBox.Size = new System.Drawing.Size(309, 35);
            this.doaTextBox.TabIndex = 43;
            // 
            // EditCreateSolicitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 378);
            this.Controls.Add(this.doaTextBox);
            this.Controls.Add(this.noChangeInRateCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.deleteHourlyRateButton);
            this.Controls.Add(this.hourlyRatesBox);
            this.Controls.Add(this.hourlyRatesLabel);
            this.Controls.Add(this.periodEndLabel);
            this.Controls.Add(this.periodEndDate);
            this.Controls.Add(this.periodStartLabel);
            this.Controls.Add(this.periodStartDate);
            this.Controls.Add(this.fromPeriodLabel);
            this.Controls.Add(this.dateOfAdmissionLabel);
            this.Controls.Add(this.hourlyRateInput);
            this.Controls.Add(this.hourlyRateLabel);
            this.Controls.Add(this.initialsTextBox);
            this.Controls.Add(this.initialsLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditCreateSolicitorForm";
            this.Text = "Create/Edit Solicitors";
            ((System.ComponentModel.ISupportInitialize)(this.hourlyRateInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox initialsTextBox;
        private System.Windows.Forms.Label initialsLabel;
        private System.Windows.Forms.NumericUpDown hourlyRateInput;
        private System.Windows.Forms.Label hourlyRateLabel;
        private System.Windows.Forms.Label dateOfAdmissionLabel;
        private System.Windows.Forms.DateTimePicker periodStartDate;
        private System.Windows.Forms.Label fromPeriodLabel;
        private System.Windows.Forms.Label periodStartLabel;
        private System.Windows.Forms.Label periodEndLabel;
        private System.Windows.Forms.DateTimePicker periodEndDate;
        private System.Windows.Forms.ListBox hourlyRatesBox;
        private System.Windows.Forms.Label hourlyRatesLabel;
        private System.Windows.Forms.Button deleteHourlyRateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox noChangeInRateCheckBox;
        private System.Windows.Forms.TextBox doaTextBox;
    }
}