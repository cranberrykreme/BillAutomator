namespace BillAutomatorUI
{
    partial class CreateNewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewForm));
            this.fileLocationLabel = new System.Windows.Forms.Label();
            this.fileLocationTextBox = new System.Windows.Forms.TextBox();
            this.fileLocationButton = new System.Windows.Forms.Button();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.clientNumberTextBox = new System.Windows.Forms.TextBox();
            this.clientNumberLabel = new System.Windows.Forms.Label();
            this.typeBillLabel = new System.Windows.Forms.Label();
            this.typeBillDropDown = new System.Windows.Forms.ComboBox();
            this.createFileButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileLocationLabel
            // 
            this.fileLocationLabel.AutoSize = true;
            this.fileLocationLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLocationLabel.Location = new System.Drawing.Point(26, 24);
            this.fileLocationLabel.Name = "fileLocationLabel";
            this.fileLocationLabel.Size = new System.Drawing.Size(135, 45);
            this.fileLocationLabel.TabIndex = 0;
            this.fileLocationLabel.Text = "Location";
            // 
            // fileLocationTextBox
            // 
            this.fileLocationTextBox.Location = new System.Drawing.Point(194, 33);
            this.fileLocationTextBox.Name = "fileLocationTextBox";
            this.fileLocationTextBox.Size = new System.Drawing.Size(438, 35);
            this.fileLocationTextBox.TabIndex = 1;
            // 
            // fileLocationButton
            // 
            this.fileLocationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.fileLocationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.fileLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileLocationButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLocationButton.Location = new System.Drawing.Point(665, 24);
            this.fileLocationButton.Name = "fileLocationButton";
            this.fileLocationButton.Size = new System.Drawing.Size(148, 48);
            this.fileLocationButton.TabIndex = 3;
            this.fileLocationButton.Text = "Find Location";
            this.fileLocationButton.UseVisualStyleBackColor = true;
            this.fileLocationButton.Click += new System.EventHandler(this.fileLocationButton_Click);
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Location = new System.Drawing.Point(259, 117);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(373, 35);
            this.clientNameTextBox.TabIndex = 5;
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNameLabel.Location = new System.Drawing.Point(26, 108);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(187, 45);
            this.clientNameLabel.TabIndex = 4;
            this.clientNameLabel.Text = "Client Name";
            // 
            // clientNumberTextBox
            // 
            this.clientNumberTextBox.Location = new System.Drawing.Point(259, 181);
            this.clientNumberTextBox.Name = "clientNumberTextBox";
            this.clientNumberTextBox.Size = new System.Drawing.Size(373, 35);
            this.clientNumberTextBox.TabIndex = 7;
            // 
            // clientNumberLabel
            // 
            this.clientNumberLabel.AutoSize = true;
            this.clientNumberLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNumberLabel.Location = new System.Drawing.Point(26, 172);
            this.clientNumberLabel.Name = "clientNumberLabel";
            this.clientNumberLabel.Size = new System.Drawing.Size(217, 45);
            this.clientNumberLabel.TabIndex = 6;
            this.clientNumberLabel.Text = "Client Number";
            // 
            // typeBillLabel
            // 
            this.typeBillLabel.AutoSize = true;
            this.typeBillLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeBillLabel.Location = new System.Drawing.Point(26, 235);
            this.typeBillLabel.Name = "typeBillLabel";
            this.typeBillLabel.Size = new System.Drawing.Size(168, 45);
            this.typeBillLabel.TabIndex = 8;
            this.typeBillLabel.Text = "Type of Bill";
            // 
            // typeBillDropDown
            // 
            this.typeBillDropDown.FormattingEnabled = true;
            this.typeBillDropDown.Items.AddRange(new object[] {
            "Party/Party",
            "Solicitor/Client"});
            this.typeBillDropDown.Location = new System.Drawing.Point(259, 244);
            this.typeBillDropDown.Name = "typeBillDropDown";
            this.typeBillDropDown.Size = new System.Drawing.Size(373, 38);
            this.typeBillDropDown.TabIndex = 9;
            // 
            // createFileButton
            // 
            this.createFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.createFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createFileButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createFileButton.Location = new System.Drawing.Point(665, 240);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(148, 48);
            this.createFileButton.TabIndex = 10;
            this.createFileButton.Text = "Create File";
            this.createFileButton.UseVisualStyleBackColor = true;
            // 
            // returnButton
            // 
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnButton.Location = new System.Drawing.Point(665, 177);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(148, 48);
            this.returnButton.TabIndex = 11;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            // 
            // CreateNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 312);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.typeBillDropDown);
            this.Controls.Add(this.typeBillLabel);
            this.Controls.Add(this.clientNumberTextBox);
            this.Controls.Add(this.clientNumberLabel);
            this.Controls.Add(this.clientNameTextBox);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.fileLocationButton);
            this.Controls.Add(this.fileLocationTextBox);
            this.Controls.Add(this.fileLocationLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "CreateNewForm";
            this.Text = "Create New";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileLocationLabel;
        private System.Windows.Forms.TextBox fileLocationTextBox;
        private System.Windows.Forms.Button fileLocationButton;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.TextBox clientNumberTextBox;
        private System.Windows.Forms.Label clientNumberLabel;
        private System.Windows.Forms.Label typeBillLabel;
        private System.Windows.Forms.ComboBox typeBillDropDown;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.Button returnButton;
    }
}