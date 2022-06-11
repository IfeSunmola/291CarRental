namespace _291CarRental
{
    partial class EmpViewAllVehicles
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
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vehicleClassCombobox = new System.Windows.Forms.ComboBox();
            this.branchComboBox = new System.Windows.Forms.ComboBox();
            this.findAvailableVehiclesButton = new System.Windows.Forms.Button();
            this.customerIDLabel = new System.Windows.Forms.Label();
            this.customerIdTextbox = new System.Windows.Forms.TextBox();
            this.vehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.rentVehicleButton = new System.Windows.Forms.Button();
            this.showVehicleDataGripViewPanel = new System.Windows.Forms.Panel();
            this.estimatedCostLabel = new System.Windows.Forms.Label();
            this.showingVehiclesLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.phoneNumberTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.customerDetailsPanel = new System.Windows.Forms.Panel();
            this.expiryDate = new System.Windows.Forms.Label();
            this.expiresLabel = new System.Windows.Forms.Label();
            this.goldMemberLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataGridView)).BeginInit();
            this.showVehicleDataGripViewPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customerDetailsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(112, 8);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(300, 31);
            this.fromDatePicker.TabIndex = 0;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(535, 8);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(300, 31);
            this.toDatePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "TO";
            // 
            // vehicleClassCombobox
            // 
            this.vehicleClassCombobox.FormattingEnabled = true;
            this.vehicleClassCombobox.Location = new System.Drawing.Point(19, 75);
            this.vehicleClassCombobox.Name = "vehicleClassCombobox";
            this.vehicleClassCombobox.Size = new System.Drawing.Size(182, 33);
            this.vehicleClassCombobox.TabIndex = 4;
            this.vehicleClassCombobox.Text = "VEHICLE CLASS";
            // 
            // branchComboBox
            // 
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Location = new System.Drawing.Point(268, 75);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(182, 33);
            this.branchComboBox.TabIndex = 5;
            this.branchComboBox.Text = "BRANCH";
            this.branchComboBox.SelectedIndexChanged += new System.EventHandler(this.branchComboBox_SelectedIndexChanged);
            // 
            // findAvailableVehiclesButton
            // 
            this.findAvailableVehiclesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findAvailableVehiclesButton.Location = new System.Drawing.Point(324, 189);
            this.findAvailableVehiclesButton.Name = "findAvailableVehiclesButton";
            this.findAvailableVehiclesButton.Size = new System.Drawing.Size(263, 62);
            this.findAvailableVehiclesButton.TabIndex = 6;
            this.findAvailableVehiclesButton.Text = "FIND AVAILABLE VEHICLES";
            this.findAvailableVehiclesButton.UseVisualStyleBackColor = true;
            this.findAvailableVehiclesButton.Click += new System.EventHandler(this.findAvailableVehiclesButton_Click);
            // 
            // customerIDLabel
            // 
            this.customerIDLabel.AutoSize = true;
            this.customerIDLabel.Location = new System.Drawing.Point(13, 134);
            this.customerIDLabel.Name = "customerIDLabel";
            this.customerIDLabel.Size = new System.Drawing.Size(126, 25);
            this.customerIDLabel.TabIndex = 7;
            this.customerIDLabel.Text = "CUSTOMER ID";
            // 
            // customerIdTextbox
            // 
            this.customerIdTextbox.Location = new System.Drawing.Point(165, 131);
            this.customerIdTextbox.Name = "customerIdTextbox";
            this.customerIdTextbox.Size = new System.Drawing.Size(150, 31);
            this.customerIdTextbox.TabIndex = 8;
            this.customerIdTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customerIdTextbox_KeyPress);
            // 
            // vehicleDataGridView
            // 
            this.vehicleDataGridView.AllowUserToAddRows = false;
            this.vehicleDataGridView.AllowUserToDeleteRows = false;
            this.vehicleDataGridView.AllowUserToResizeColumns = false;
            this.vehicleDataGridView.AllowUserToResizeRows = false;
            this.vehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.vehicleDataGridView.Location = new System.Drawing.Point(14, 37);
            this.vehicleDataGridView.MultiSelect = false;
            this.vehicleDataGridView.Name = "vehicleDataGridView";
            this.vehicleDataGridView.ReadOnly = true;
            this.vehicleDataGridView.RowHeadersWidth = 62;
            this.vehicleDataGridView.RowTemplate.Height = 33;
            this.vehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehicleDataGridView.Size = new System.Drawing.Size(844, 398);
            this.vehicleDataGridView.TabIndex = 10;
            this.vehicleDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.vehicleDataGridView_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Location";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Class";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Year";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Brand";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Model";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "ESTIMATED COST: ";
            // 
            // rentVehicleButton
            // 
            this.rentVehicleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rentVehicleButton.Location = new System.Drawing.Point(315, 490);
            this.rentVehicleButton.Name = "rentVehicleButton";
            this.rentVehicleButton.Size = new System.Drawing.Size(199, 64);
            this.rentVehicleButton.TabIndex = 12;
            this.rentVehicleButton.Text = "RENT THIS VEHICLE";
            this.rentVehicleButton.UseVisualStyleBackColor = true;
            this.rentVehicleButton.Click += new System.EventHandler(this.rentThisVehicleButton_Click);
            // 
            // showVehicleDataGripViewPanel
            // 
            this.showVehicleDataGripViewPanel.Controls.Add(this.estimatedCostLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.showingVehiclesLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.vehicleDataGridView);
            this.showVehicleDataGripViewPanel.Controls.Add(this.label7);
            this.showVehicleDataGripViewPanel.Controls.Add(this.rentVehicleButton);
            this.showVehicleDataGripViewPanel.Location = new System.Drawing.Point(19, 308);
            this.showVehicleDataGripViewPanel.Name = "showVehicleDataGripViewPanel";
            this.showVehicleDataGripViewPanel.Size = new System.Drawing.Size(887, 557);
            this.showVehicleDataGripViewPanel.TabIndex = 17;
            this.showVehicleDataGripViewPanel.Visible = false;
            // 
            // estimatedCostLabel
            // 
            this.estimatedCostLabel.AutoSize = true;
            this.estimatedCostLabel.Location = new System.Drawing.Point(155, 438);
            this.estimatedCostLabel.Name = "estimatedCostLabel";
            this.estimatedCostLabel.Size = new System.Drawing.Size(46, 25);
            this.estimatedCostLabel.TabIndex = 17;
            this.estimatedCostLabel.Text = "0.00";
            // 
            // showingVehiclesLabel
            // 
            this.showingVehiclesLabel.Location = new System.Drawing.Point(14, 9);
            this.showingVehiclesLabel.Name = "showingVehiclesLabel";
            this.showingVehiclesLabel.Size = new System.Drawing.Size(844, 25);
            this.showingVehiclesLabel.TabIndex = 16;
            this.showingVehiclesLabel.Text = "SHOWING AVAILABLE VEHICLES";
            this.showingVehiclesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "PHONE NUMBER";
            // 
            // phoneNumberTextbox
            // 
            this.phoneNumberTextbox.Location = new System.Drawing.Point(543, 134);
            this.phoneNumberTextbox.MaxLength = 10;
            this.phoneNumberTextbox.Name = "phoneNumberTextbox";
            this.phoneNumberTextbox.Size = new System.Drawing.Size(150, 31);
            this.phoneNumberTextbox.TabIndex = 16;
            this.phoneNumberTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumberTextbox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "OR";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(557, 78);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(94, 25);
            this.addressLabel.TabIndex = 18;
            this.addressLabel.Text = "ADDRESS:";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 44);
            this.button2.TabIndex = 21;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(1052, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 44);
            this.button3.TabIndex = 22;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.customerDetailsPanel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.branchComboBox);
            this.panel1.Controls.Add(this.findAvailableVehiclesButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.vehicleClassCombobox);
            this.panel1.Controls.Add(this.addressLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.phoneNumberTextbox);
            this.panel1.Controls.Add(this.showVehicleDataGripViewPanel);
            this.panel1.Controls.Add(this.customerIdTextbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.toDatePicker);
            this.panel1.Controls.Add(this.customerIDLabel);
            this.panel1.Controls.Add(this.fromDatePicker);
            this.panel1.Location = new System.Drawing.Point(121, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 882);
            this.panel1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "ADDRESS:";
            // 
            // customerDetailsPanel
            // 
            this.customerDetailsPanel.Controls.Add(this.expiryDate);
            this.customerDetailsPanel.Controls.Add(this.expiresLabel);
            this.customerDetailsPanel.Controls.Add(this.goldMemberLabel);
            this.customerDetailsPanel.Controls.Add(this.customerNameLabel);
            this.customerDetailsPanel.Controls.Add(this.label8);
            this.customerDetailsPanel.Controls.Add(this.label9);
            this.customerDetailsPanel.Location = new System.Drawing.Point(13, 182);
            this.customerDetailsPanel.Name = "customerDetailsPanel";
            this.customerDetailsPanel.Size = new System.Drawing.Size(300, 99);
            this.customerDetailsPanel.TabIndex = 21;
            // 
            // expiryDate
            // 
            this.expiryDate.AutoSize = true;
            this.expiryDate.Location = new System.Drawing.Point(75, 74);
            this.expiryDate.Name = "expiryDate";
            this.expiryDate.Size = new System.Drawing.Size(106, 25);
            this.expiryDate.TabIndex = 25;
            this.expiryDate.Text = "2022-11-24";
            this.expiryDate.Visible = false;
            // 
            // expiresLabel
            // 
            this.expiresLabel.AutoSize = true;
            this.expiresLabel.Location = new System.Drawing.Point(0, 74);
            this.expiresLabel.Name = "expiresLabel";
            this.expiresLabel.Size = new System.Drawing.Size(81, 25);
            this.expiresLabel.TabIndex = 24;
            this.expiresLabel.Text = "EXPIRES:";
            this.expiresLabel.Visible = false;
            // 
            // goldMemberLabel
            // 
            this.goldMemberLabel.AutoSize = true;
            this.goldMemberLabel.Location = new System.Drawing.Point(135, 40);
            this.goldMemberLabel.Name = "goldMemberLabel";
            this.goldMemberLabel.Size = new System.Drawing.Size(41, 25);
            this.goldMemberLabel.TabIndex = 23;
            this.goldMemberLabel.Text = "YES";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(161, 0);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(86, 25);
            this.customerNameLabel.TabIndex = 21;
            this.customerNameLabel.Text = "T.Beifong";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "CUSTOMER NAME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "GOLD MEMBER:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(6, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 907);
            this.panel2.TabIndex = 24;
            // 
            // EmpViewAllVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 931);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EmpViewAllVehicles";
            this.Text = "EMPLOYEE VIEWING AVAILABLE VEHICLES";
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataGridView)).EndInit();
            this.showVehicleDataGripViewPanel.ResumeLayout(false);
            this.showVehicleDataGripViewPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customerDetailsPanel.ResumeLayout(false);
            this.customerDetailsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
        private Label label1;
        private Label label2;
        private ComboBox vehicleClassCombobox;
        private ComboBox branchComboBox;
        private Button findAvailableVehiclesButton;
        private Label customerIDLabel;
        private TextBox customerIdTextbox;
        private DataGridView vehicleDataGridView;
        private Label label7;
        private Button rentVehicleButton;
        private Panel showVehicleDataGripViewPanel;
        private Label label6;
        private TextBox phoneNumberTextbox;
        private Label label5;
        private Label addressLabel;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Panel panel2;
        private Label showingVehiclesLabel;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label9;
        private Label label8;
        private Panel customerDetailsPanel;
        private Label estimatedCostLabel;
        private Label label3;
        private Label goldMemberLabel;
        private Label customerNameLabel;
        private Label expiresLabel;
        private Label expiryDate;
    }
}