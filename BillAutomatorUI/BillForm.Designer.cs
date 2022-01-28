namespace BillAutomatorUI
{
    partial class BillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillForm));
            this.clientLabel = new System.Windows.Forms.Label();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.solicitorButton = new System.Windows.Forms.Button();
            this.newEntryButton = new System.Windows.Forms.Button();
            this.DisbursementTypesButton = new System.Windows.Forms.Button();
            this.newDisbursementButton = new System.Windows.Forms.Button();
            this.entriesLabel = new System.Windows.Forms.Label();
            this.entriesBox = new System.Windows.Forms.ListBox();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveCloseButton = new System.Windows.Forms.Button();
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.alterPositionLabel = new System.Windows.Forms.Label();
            this.displayAllEntriesButton = new System.Windows.Forms.Button();
            this.editSelectedButton = new System.Windows.Forms.Button();
            this.reOpenWordButton = new System.Windows.Forms.Button();
            this.displayAllDisbursementsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientLabel.Location = new System.Drawing.Point(19, 18);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(97, 45);
            this.clientLabel.TabIndex = 1;
            this.clientLabel.Text = "Client";
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNameLabel.Location = new System.Drawing.Point(129, 18);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(137, 45);
            this.clientNameLabel.TabIndex = 2;
            this.clientNameLabel.Text = "<name>";
            // 
            // solicitorButton
            // 
            this.solicitorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.solicitorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.solicitorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solicitorButton.Location = new System.Drawing.Point(527, 19);
            this.solicitorButton.Name = "solicitorButton";
            this.solicitorButton.Size = new System.Drawing.Size(234, 52);
            this.solicitorButton.TabIndex = 3;
            this.solicitorButton.Text = "Solicitors";
            this.solicitorButton.UseVisualStyleBackColor = true;
            this.solicitorButton.Click += new System.EventHandler(this.solicitorButton_Click);
            // 
            // newEntryButton
            // 
            this.newEntryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.newEntryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.newEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newEntryButton.Location = new System.Drawing.Point(780, 19);
            this.newEntryButton.Name = "newEntryButton";
            this.newEntryButton.Size = new System.Drawing.Size(234, 52);
            this.newEntryButton.TabIndex = 4;
            this.newEntryButton.Text = "New Entry";
            this.newEntryButton.UseVisualStyleBackColor = true;
            this.newEntryButton.Click += new System.EventHandler(this.newEntryButton_Click);
            // 
            // DisbursementTypesButton
            // 
            this.DisbursementTypesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.DisbursementTypesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.DisbursementTypesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisbursementTypesButton.Location = new System.Drawing.Point(527, 86);
            this.DisbursementTypesButton.Name = "DisbursementTypesButton";
            this.DisbursementTypesButton.Size = new System.Drawing.Size(234, 52);
            this.DisbursementTypesButton.TabIndex = 5;
            this.DisbursementTypesButton.Text = "Disubrsement Types";
            this.DisbursementTypesButton.UseVisualStyleBackColor = true;
            this.DisbursementTypesButton.Click += new System.EventHandler(this.DisbursementTypesButton_Click);
            // 
            // newDisbursementButton
            // 
            this.newDisbursementButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.newDisbursementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.newDisbursementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newDisbursementButton.Location = new System.Drawing.Point(780, 86);
            this.newDisbursementButton.Name = "newDisbursementButton";
            this.newDisbursementButton.Size = new System.Drawing.Size(234, 52);
            this.newDisbursementButton.TabIndex = 6;
            this.newDisbursementButton.Text = "New Disbursement";
            this.newDisbursementButton.UseVisualStyleBackColor = true;
            this.newDisbursementButton.Click += new System.EventHandler(this.newDisbursementButton_Click);
            // 
            // entriesLabel
            // 
            this.entriesLabel.AutoSize = true;
            this.entriesLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entriesLabel.Location = new System.Drawing.Point(19, 85);
            this.entriesLabel.Name = "entriesLabel";
            this.entriesLabel.Size = new System.Drawing.Size(117, 45);
            this.entriesLabel.TabIndex = 7;
            this.entriesLabel.Text = "Display";
            // 
            // entriesBox
            // 
            this.entriesBox.FormattingEnabled = true;
            this.entriesBox.HorizontalScrollbar = true;
            this.entriesBox.ItemHeight = 30;
            this.entriesBox.Location = new System.Drawing.Point(27, 149);
            this.entriesBox.Name = "entriesBox";
            this.entriesBox.Size = new System.Drawing.Size(734, 334);
            this.entriesBox.TabIndex = 8;
            this.entriesBox.DoubleClick += new System.EventHandler(this.entriesBox_doubleClick);
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedButton.Location = new System.Drawing.Point(780, 315);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(234, 52);
            this.deleteSelectedButton.TabIndex = 9;
            this.deleteSelectedButton.Text = "Delete Selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(527, 510);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(234, 52);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveCloseButton
            // 
            this.saveCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.saveCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveCloseButton.Location = new System.Drawing.Point(780, 510);
            this.saveCloseButton.Name = "saveCloseButton";
            this.saveCloseButton.Size = new System.Drawing.Size(234, 52);
            this.saveCloseButton.TabIndex = 11;
            this.saveCloseButton.Text = "Save and Close";
            this.saveCloseButton.UseVisualStyleBackColor = true;
            this.saveCloseButton.Click += new System.EventHandler(this.saveCloseButton_Click);
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeBox.Location = new System.Drawing.Point(869, 204);
            this.dateTimeBox.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimeBox.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(145, 35);
            this.dateTimeBox.TabIndex = 16;
            this.dateTimeBox.ValueChanged += new System.EventHandler(this.dateTimeBox_ValueChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(772, 196);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(84, 45);
            this.dateLabel.TabIndex = 15;
            this.dateLabel.Text = "Date";
            // 
            // upButton
            // 
            this.upButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.upButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Location = new System.Drawing.Point(780, 431);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(96, 52);
            this.upButton.TabIndex = 17;
            this.upButton.Text = "^";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.downButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Location = new System.Drawing.Point(918, 431);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(96, 52);
            this.downButton.TabIndex = 18;
            this.downButton.Text = "v";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // alterPositionLabel
            // 
            this.alterPositionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterPositionLabel.Location = new System.Drawing.Point(833, 385);
            this.alterPositionLabel.Name = "alterPositionLabel";
            this.alterPositionLabel.Size = new System.Drawing.Size(128, 43);
            this.alterPositionLabel.TabIndex = 19;
            this.alterPositionLabel.Text = "Alter Position of Selected Entry";
            // 
            // displayAllEntriesButton
            // 
            this.displayAllEntriesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.displayAllEntriesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.displayAllEntriesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayAllEntriesButton.Location = new System.Drawing.Point(136, 86);
            this.displayAllEntriesButton.Name = "displayAllEntriesButton";
            this.displayAllEntriesButton.Size = new System.Drawing.Size(175, 52);
            this.displayAllEntriesButton.TabIndex = 20;
            this.displayAllEntriesButton.Text = "Entries";
            this.displayAllEntriesButton.UseVisualStyleBackColor = true;
            this.displayAllEntriesButton.Click += new System.EventHandler(this.displayAllEntriesButton_Click);
            // 
            // editSelectedButton
            // 
            this.editSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.editSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.editSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSelectedButton.Location = new System.Drawing.Point(780, 257);
            this.editSelectedButton.Name = "editSelectedButton";
            this.editSelectedButton.Size = new System.Drawing.Size(234, 52);
            this.editSelectedButton.TabIndex = 21;
            this.editSelectedButton.Text = "Edit Selected";
            this.editSelectedButton.UseVisualStyleBackColor = true;
            this.editSelectedButton.Click += new System.EventHandler(this.editSelectedButton_Click);
            // 
            // reOpenWordButton
            // 
            this.reOpenWordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.reOpenWordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.reOpenWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reOpenWordButton.Location = new System.Drawing.Point(27, 510);
            this.reOpenWordButton.Name = "reOpenWordButton";
            this.reOpenWordButton.Size = new System.Drawing.Size(234, 52);
            this.reOpenWordButton.TabIndex = 22;
            this.reOpenWordButton.Text = "Re-Open Word";
            this.reOpenWordButton.UseVisualStyleBackColor = true;
            this.reOpenWordButton.Click += new System.EventHandler(this.reOpenWordButton_Click);
            // 
            // displayAllDisbursementsButton
            // 
            this.displayAllDisbursementsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.displayAllDisbursementsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.displayAllDisbursementsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayAllDisbursementsButton.Location = new System.Drawing.Point(317, 86);
            this.displayAllDisbursementsButton.Name = "displayAllDisbursementsButton";
            this.displayAllDisbursementsButton.Size = new System.Drawing.Size(175, 52);
            this.displayAllDisbursementsButton.TabIndex = 23;
            this.displayAllDisbursementsButton.Text = "Disbursements";
            this.displayAllDisbursementsButton.UseVisualStyleBackColor = true;
            this.displayAllDisbursementsButton.Click += new System.EventHandler(this.displayAllDisbursementsButton_Click);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 574);
            this.Controls.Add(this.displayAllDisbursementsButton);
            this.Controls.Add(this.reOpenWordButton);
            this.Controls.Add(this.editSelectedButton);
            this.Controls.Add(this.displayAllEntriesButton);
            this.Controls.Add(this.alterPositionLabel);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.saveCloseButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteSelectedButton);
            this.Controls.Add(this.entriesBox);
            this.Controls.Add(this.entriesLabel);
            this.Controls.Add(this.newDisbursementButton);
            this.Controls.Add(this.DisbursementTypesButton);
            this.Controls.Add(this.newEntryButton);
            this.Controls.Add(this.solicitorButton);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.clientLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "BillForm";
            this.Text = "Bill";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BillForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.Button solicitorButton;
        private System.Windows.Forms.Button newEntryButton;
        private System.Windows.Forms.Button DisbursementTypesButton;
        private System.Windows.Forms.Button newDisbursementButton;
        private System.Windows.Forms.Label entriesLabel;
        private System.Windows.Forms.ListBox entriesBox;
        private System.Windows.Forms.Button deleteSelectedButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveCloseButton;
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Label alterPositionLabel;
        private System.Windows.Forms.Button displayAllEntriesButton;
        private System.Windows.Forms.Button editSelectedButton;
        private System.Windows.Forms.Button reOpenWordButton;
        private System.Windows.Forms.Button displayAllDisbursementsButton;
    }
}