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
            this.counselButton = new System.Windows.Forms.Button();
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
            // 
            // counselButton
            // 
            this.counselButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.counselButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.counselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.counselButton.Location = new System.Drawing.Point(527, 86);
            this.counselButton.Name = "counselButton";
            this.counselButton.Size = new System.Drawing.Size(234, 52);
            this.counselButton.TabIndex = 5;
            this.counselButton.Text = "Counsel";
            this.counselButton.UseVisualStyleBackColor = true;
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
            // 
            // entriesLabel
            // 
            this.entriesLabel.AutoSize = true;
            this.entriesLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entriesLabel.Location = new System.Drawing.Point(19, 93);
            this.entriesLabel.Name = "entriesLabel";
            this.entriesLabel.Size = new System.Drawing.Size(109, 45);
            this.entriesLabel.TabIndex = 7;
            this.entriesLabel.Text = "Entries";
            // 
            // entriesBox
            // 
            this.entriesBox.FormattingEnabled = true;
            this.entriesBox.ItemHeight = 30;
            this.entriesBox.Location = new System.Drawing.Point(27, 149);
            this.entriesBox.Name = "entriesBox";
            this.entriesBox.Size = new System.Drawing.Size(734, 334);
            this.entriesBox.TabIndex = 8;
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedButton.Location = new System.Drawing.Point(780, 293);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(234, 52);
            this.deleteSelectedButton.TabIndex = 9;
            this.deleteSelectedButton.Text = "Delete Selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
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
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 574);
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
            this.Controls.Add(this.counselButton);
            this.Controls.Add(this.newEntryButton);
            this.Controls.Add(this.solicitorButton);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.clientLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "BillForm";
            this.Text = "Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.Button solicitorButton;
        private System.Windows.Forms.Button newEntryButton;
        private System.Windows.Forms.Button counselButton;
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
    }
}