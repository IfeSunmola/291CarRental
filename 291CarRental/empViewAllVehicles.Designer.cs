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
            this.vehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.rentVehicleButton = new System.Windows.Forms.Button();
            this.showVehicleDataGripViewPanel = new System.Windows.Forms.Panel();
            this.selectAVehicleLabel = new System.Windows.Forms.Label();
            this.amountOfDaysLabel = new System.Windows.Forms.Label();
            this.estimatedCostLabel = new System.Windows.Forms.Label();
            this.showingVehiclesLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.customerInfoPanel = new System.Windows.Forms.Panel();
            this.findByLabel = new System.Windows.Forms.Label();
            this.customerInfoTextbox = new System.Windows.Forms.TextBox();
            this.addressPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.findByCombobox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.customerInfoPanel.SuspendLayout();
            this.addressPanel.SuspendLayout();
            this.customerDetailsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(19, 42);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(300, 31);
            this.fromDatePicker.TabIndex = 0;
            this.fromDatePicker.ValueChanged += new System.EventHandler(this.filtersValueChanged);
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(438, 42);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(300, 31);
            this.toDatePicker.TabIndex = 1;
            this.toDatePicker.ValueChanged += new System.EventHandler(this.filtersValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "BOOKING START DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "BOOKING END DATE";
            // 
            // vehicleClassCombobox
            // 
            this.vehicleClassCombobox.FormattingEnabled = true;
            this.vehicleClassCombobox.Location = new System.Drawing.Point(15, 136);
            this.vehicleClassCombobox.Name = "vehicleClassCombobox";
            this.vehicleClassCombobox.Size = new System.Drawing.Size(182, 33);
            this.vehicleClassCombobox.TabIndex = 4;
            this.vehicleClassCombobox.Text = "SELECT ONE";
            this.vehicleClassCombobox.SelectedIndexChanged += new System.EventHandler(this.filtersValueChanged);
            this.vehicleClassCombobox.DropDownClosed += new System.EventHandler(this.vehicleClassCombobox_DropDownClosed);
            // 
            // branchComboBox
            // 
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Location = new System.Drawing.Point(280, 136);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(182, 33);
            this.branchComboBox.TabIndex = 5;
            this.branchComboBox.Text = "BRANCH";
            this.branchComboBox.SelectedIndexChanged += new System.EventHandler(this.branchComboBox_SelectedIndexChanged);
            // 
            // findAvailableVehiclesButton
            // 
            this.findAvailableVehiclesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(86)))), ((int)(((byte)(97)))));
            this.findAvailableVehiclesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findAvailableVehiclesButton.Location = new System.Drawing.Point(326, 297);
            this.findAvailableVehiclesButton.Name = "findAvailableVehiclesButton";
            this.findAvailableVehiclesButton.Size = new System.Drawing.Size(263, 62);
            this.findAvailableVehiclesButton.TabIndex = 6;
            this.findAvailableVehiclesButton.Text = "FIND AVAILABLE VEHICLES";
            this.findAvailableVehiclesButton.UseVisualStyleBackColor = false;
            this.findAvailableVehiclesButton.Click += new System.EventHandler(this.findAvailableVehiclesButton_Click);
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
            this.vehicleDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.vehicleDataGridView_CellFormatting);
            this.vehicleDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.vehicleDataGridView_CellMouseClick);
            this.vehicleDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.vehicleDataGridView_DataBindingComplete);
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
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(14, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "ESTIMATED COST: ";
            // 
            // rentVehicleButton
            // 
            this.rentVehicleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(86)))), ((int)(((byte)(97)))));
            this.rentVehicleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rentVehicleButton.Location = new System.Drawing.Point(318, 477);
            this.rentVehicleButton.Name = "rentVehicleButton";
            this.rentVehicleButton.Size = new System.Drawing.Size(199, 64);
            this.rentVehicleButton.TabIndex = 12;
            this.rentVehicleButton.Text = "RENT THIS VEHICLE";
            this.rentVehicleButton.UseVisualStyleBackColor = false;
            this.rentVehicleButton.Click += new System.EventHandler(this.rentThisVehicleButton_Click);
            // 
            // showVehicleDataGripViewPanel
            // 
            this.showVehicleDataGripViewPanel.Controls.Add(this.selectAVehicleLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.amountOfDaysLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.estimatedCostLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.showingVehiclesLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.vehicleDataGridView);
            this.showVehicleDataGripViewPanel.Controls.Add(this.label7);
            this.showVehicleDataGripViewPanel.Controls.Add(this.rentVehicleButton);
            this.showVehicleDataGripViewPanel.Location = new System.Drawing.Point(19, 417);
            this.showVehicleDataGripViewPanel.Name = "showVehicleDataGripViewPanel";
            this.showVehicleDataGripViewPanel.Size = new System.Drawing.Size(859, 557);
            this.showVehicleDataGripViewPanel.TabIndex = 17;
            this.showVehicleDataGripViewPanel.Visible = false;
            // 
            // selectAVehicleLabel
            // 
            this.selectAVehicleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectAVehicleLabel.ForeColor = System.Drawing.Color.Red;
            this.selectAVehicleLabel.Location = new System.Drawing.Point(318, 449);
            this.selectAVehicleLabel.Name = "selectAVehicleLabel";
            this.selectAVehicleLabel.Size = new System.Drawing.Size(199, 25);
            this.selectAVehicleLabel.TabIndex = 49;
            this.selectAVehicleLabel.Text = "SELECT A VEHICLE";
            this.selectAVehicleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectAVehicleLabel.Visible = false;
            // 
            // amountOfDaysLabel
            // 
            this.amountOfDaysLabel.AutoSize = true;
            this.amountOfDaysLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.amountOfDaysLabel.Location = new System.Drawing.Point(179, 463);
            this.amountOfDaysLabel.Name = "amountOfDaysLabel";
            this.amountOfDaysLabel.Size = new System.Drawing.Size(111, 25);
            this.amountOfDaysLabel.TabIndex = 18;
            this.amountOfDaysLabel.Text = "HEHE DAYS";
            // 
            // estimatedCostLabel
            // 
            this.estimatedCostLabel.AutoSize = true;
            this.estimatedCostLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.estimatedCostLabel.Location = new System.Drawing.Point(179, 438);
            this.estimatedCostLabel.Name = "estimatedCostLabel";
            this.estimatedCostLabel.Size = new System.Drawing.Size(47, 25);
            this.estimatedCostLabel.TabIndex = 17;
            this.estimatedCostLabel.Text = "0.00";
            // 
            // showingVehiclesLabel
            // 
            this.showingVehiclesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.showingVehiclesLabel.Location = new System.Drawing.Point(12, 0);
            this.showingVehiclesLabel.Name = "showingVehiclesLabel";
            this.showingVehiclesLabel.Size = new System.Drawing.Size(844, 25);
            this.showingVehiclesLabel.TabIndex = 16;
            this.showingVehiclesLabel.Text = "SHOWING AVAILABLE VEHICLES";
            this.showingVehiclesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(90, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(226, 25);
            this.addressLabel.TabIndex = 18;
            this.addressLabel.Text = "ADDRESS TEXT HEHEHEHE";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(86)))), ((int)(((byte)(97)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 44);
            this.button2.TabIndex = 21;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(86)))), ((int)(((byte)(97)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(1052, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 44);
            this.button3.TabIndex = 22;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorMessageLabel);
            this.panel1.Controls.Add(this.customerInfoPanel);
            this.panel1.Controls.Add(this.addressPanel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.findByCombobox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.customerDetailsPanel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.branchComboBox);
            this.panel1.Controls.Add(this.findAvailableVehiclesButton);
            this.panel1.Controls.Add(this.vehicleClassCombobox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.showVehicleDataGripViewPanel);
            this.panel1.Controls.Add(this.toDatePicker);
            this.panel1.Controls.Add(this.fromDatePicker);
            this.panel1.Location = new System.Drawing.Point(129, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 990);
            this.panel1.TabIndex = 23;
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(19, 261);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(858, 25);
            this.errorMessageLabel.TabIndex = 48;
            this.errorMessageLabel.Text = "HEHE HEHE SHEE UP SD SHEESH SS HEHE";
            this.errorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorMessageLabel.Visible = false;
            // 
            // customerInfoPanel
            // 
            this.customerInfoPanel.Controls.Add(this.findByLabel);
            this.customerInfoPanel.Controls.Add(this.customerInfoTextbox);
            this.customerInfoPanel.Location = new System.Drawing.Point(271, 218);
            this.customerInfoPanel.Name = "customerInfoPanel";
            this.customerInfoPanel.Size = new System.Drawing.Size(397, 33);
            this.customerInfoPanel.TabIndex = 47;
            // 
            // findByLabel
            // 
            this.findByLabel.AutoSize = true;
            this.findByLabel.Location = new System.Drawing.Point(0, 0);
            this.findByLabel.Name = "findByLabel";
            this.findByLabel.Size = new System.Drawing.Size(126, 25);
            this.findByLabel.TabIndex = 42;
            this.findByLabel.Text = "CUSTOMER ID";
            // 
            // customerInfoTextbox
            // 
            this.customerInfoTextbox.Location = new System.Drawing.Point(153, 0);
            this.customerInfoTextbox.Name = "customerInfoTextbox";
            this.customerInfoTextbox.ShortcutsEnabled = false;
            this.customerInfoTextbox.Size = new System.Drawing.Size(150, 31);
            this.customerInfoTextbox.TabIndex = 43;
            this.customerInfoTextbox.TextChanged += new System.EventHandler(this.filtersValueChanged);
            this.customerInfoTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customerInfoTextbox_KeyPress);
            // 
            // addressPanel
            // 
            this.addressPanel.Controls.Add(this.label3);
            this.addressPanel.Controls.Add(this.addressLabel);
            this.addressPanel.Location = new System.Drawing.Point(495, 136);
            this.addressPanel.Name = "addressPanel";
            this.addressPanel.Size = new System.Drawing.Size(411, 33);
            this.addressPanel.TabIndex = 46;
            this.addressPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "ADDRESS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 25);
            this.label5.TabIndex = 45;
            this.label5.Text = "FIND CUSTOMER BY";
            // 
            // findByCombobox
            // 
            this.findByCombobox.FormattingEnabled = true;
            this.findByCombobox.Location = new System.Drawing.Point(15, 218);
            this.findByCombobox.Name = "findByCombobox";
            this.findByCombobox.Size = new System.Drawing.Size(182, 33);
            this.findByCombobox.TabIndex = 44;
            this.findByCombobox.SelectedIndexChanged += new System.EventHandler(this.findByCombobox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "BRANCH NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "CLASS REQUESTED";
            // 
            // customerDetailsPanel
            // 
            this.customerDetailsPanel.Controls.Add(this.expiryDate);
            this.customerDetailsPanel.Controls.Add(this.expiresLabel);
            this.customerDetailsPanel.Controls.Add(this.goldMemberLabel);
            this.customerDetailsPanel.Controls.Add(this.customerNameLabel);
            this.customerDetailsPanel.Controls.Add(this.label8);
            this.customerDetailsPanel.Controls.Add(this.label9);
            this.customerDetailsPanel.Location = new System.Drawing.Point(15, 287);
            this.customerDetailsPanel.Name = "customerDetailsPanel";
            this.customerDetailsPanel.Size = new System.Drawing.Size(300, 75);
            this.customerDetailsPanel.TabIndex = 21;
            // 
            // expiryDate
            // 
            this.expiryDate.AutoSize = true;
            this.expiryDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.expiryDate.ForeColor = System.Drawing.Color.Green;
            this.expiryDate.Location = new System.Drawing.Point(81, 50);
            this.expiryDate.Name = "expiryDate";
            this.expiryDate.Size = new System.Drawing.Size(106, 25);
            this.expiryDate.TabIndex = 25;
            this.expiryDate.Text = "2022-11-24";
            this.expiryDate.Visible = false;
            // 
            // expiresLabel
            // 
            this.expiresLabel.AutoSize = true;
            this.expiresLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.expiresLabel.ForeColor = System.Drawing.Color.Green;
            this.expiresLabel.Location = new System.Drawing.Point(0, 50);
            this.expiresLabel.Name = "expiresLabel";
            this.expiresLabel.Size = new System.Drawing.Size(88, 25);
            this.expiresLabel.TabIndex = 24;
            this.expiresLabel.Text = "EXPIRES:";
            this.expiresLabel.Visible = false;
            // 
            // goldMemberLabel
            // 
            this.goldMemberLabel.AutoSize = true;
            this.goldMemberLabel.Location = new System.Drawing.Point(135, 25);
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
            this.label9.Location = new System.Drawing.Point(0, 25);
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
            this.panel2.Size = new System.Drawing.Size(1154, 1008);
            this.panel2.TabIndex = 24;
            // 
            // EmpViewAllVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1172, 1026);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EmpViewAllVehicles";
            this.Text = "EMPLOYEE VIEWING AVAILABLE VEHICLES";
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataGridView)).EndInit();
            this.showVehicleDataGripViewPanel.ResumeLayout(false);
            this.showVehicleDataGripViewPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customerInfoPanel.ResumeLayout(false);
            this.customerInfoPanel.PerformLayout();
            this.addressPanel.ResumeLayout(false);
            this.addressPanel.PerformLayout();
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
        private DataGridView vehicleDataGridView;
        private Label label7;
        private Button rentVehicleButton;
        private Panel showVehicleDataGripViewPanel;
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
        private Label label10;
        private Label label4;
        private Label label5;
        private ComboBox findByCombobox;
        private TextBox customerInfoTextbox;
        private Label findByLabel;
        private Panel addressPanel;
        private Panel customerInfoPanel;
        private Label errorMessageLabel;
        private Label amountOfDaysLabel;
        private Label selectAVehicleLabel;
    }
}