namespace _291CarRental
{
    partial class RunCustomReportPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.reportCombobox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vehicleStatsPanel = new System.Windows.Forms.Panel();
            this.vehicleFilters = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.brandCombobox = new System.Windows.Forms.ComboBox();
            this.colorCombobox = new System.Windows.Forms.ComboBox();
            this.yearCombobox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.branchCombobox = new System.Windows.Forms.ComboBox();
            this.filterToDate = new System.Windows.Forms.DateTimePicker();
            this.filterFromDate = new System.Windows.Forms.DateTimePicker();
            this.vehicleMostLeastCombobox = new System.Windows.Forms.ComboBox();
            this.vehicleRadio4 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.mileageNumericUpdown = new System.Windows.Forms.NumericUpDown();
            this.vehicleRadio3 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vehicleRadio2 = new System.Windows.Forms.RadioButton();
            this.vehicleRadio1 = new System.Windows.Forms.RadioButton();
            this.branchStatsPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.branchNumericUpdown2 = new System.Windows.Forms.NumericUpDown();
            this.branchBottomRadio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.branchNumericUpdown1 = new System.Windows.Forms.NumericUpDown();
            this.branchTopRadio = new System.Windows.Forms.RadioButton();
            this.employeeStatsPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.topBranchCombobox = new System.Windows.Forms.ComboBox();
            this.topToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.topNumericUpdown = new System.Windows.Forms.NumericUpDown();
            this.topFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.topRadioButton = new System.Windows.Forms.RadioButton();
            this.reportsDataView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.vehicleStatsPanel.SuspendLayout();
            this.vehicleFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageNumericUpdown)).BeginInit();
            this.branchStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown1)).BeginInit();
            this.employeeStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT REPORT TO GENERATE";
            // 
            // reportCombobox
            // 
            this.reportCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportCombobox.FormattingEnabled = true;
            this.reportCombobox.Location = new System.Drawing.Point(582, 7);
            this.reportCombobox.Name = "reportCombobox";
            this.reportCombobox.Size = new System.Drawing.Size(276, 33);
            this.reportCombobox.TabIndex = 1;
            this.reportCombobox.SelectedIndexChanged += new System.EventHandler(this.reportCombobox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateButton.Location = new System.Drawing.Point(512, 492);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(194, 82);
            this.generateButton.TabIndex = 9;
            this.generateButton.Text = "GENERATE";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(1088, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 44);
            this.button4.TabIndex = 26;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 44);
            this.button2.TabIndex = 27;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.backButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vehicleStatsPanel);
            this.panel1.Controls.Add(this.branchStatsPanel);
            this.panel1.Controls.Add(this.employeeStatsPanel);
            this.panel1.Controls.Add(this.reportsDataView);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.generateButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.reportCombobox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 1482);
            this.panel1.TabIndex = 28;
            // 
            // vehicleStatsPanel
            // 
            this.vehicleStatsPanel.Controls.Add(this.vehicleFilters);
            this.vehicleStatsPanel.Controls.Add(this.label25);
            this.vehicleStatsPanel.Controls.Add(this.label17);
            this.vehicleStatsPanel.Controls.Add(this.label18);
            this.vehicleStatsPanel.Controls.Add(this.label19);
            this.vehicleStatsPanel.Controls.Add(this.label20);
            this.vehicleStatsPanel.Controls.Add(this.branchCombobox);
            this.vehicleStatsPanel.Controls.Add(this.filterToDate);
            this.vehicleStatsPanel.Controls.Add(this.filterFromDate);
            this.vehicleStatsPanel.Controls.Add(this.vehicleMostLeastCombobox);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio4);
            this.vehicleStatsPanel.Controls.Add(this.label16);
            this.vehicleStatsPanel.Controls.Add(this.mileageNumericUpdown);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio3);
            this.vehicleStatsPanel.Controls.Add(this.label7);
            this.vehicleStatsPanel.Controls.Add(this.label4);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio2);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio1);
            this.vehicleStatsPanel.Location = new System.Drawing.Point(111, 61);
            this.vehicleStatsPanel.Name = "vehicleStatsPanel";
            this.vehicleStatsPanel.Size = new System.Drawing.Size(976, 414);
            this.vehicleStatsPanel.TabIndex = 33;
            // 
            // vehicleFilters
            // 
            this.vehicleFilters.Controls.Add(this.label26);
            this.vehicleFilters.Controls.Add(this.label23);
            this.vehicleFilters.Controls.Add(this.brandCombobox);
            this.vehicleFilters.Controls.Add(this.colorCombobox);
            this.vehicleFilters.Controls.Add(this.yearCombobox);
            this.vehicleFilters.Controls.Add(this.label24);
            this.vehicleFilters.Location = new System.Drawing.Point(236, 343);
            this.vehicleFilters.Name = "vehicleFilters";
            this.vehicleFilters.Size = new System.Drawing.Size(558, 61);
            this.vehicleFilters.TabIndex = 34;
            this.vehicleFilters.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(206, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 25);
            this.label26.TabIndex = 64;
            this.label26.Text = "BRAND";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 25);
            this.label23.TabIndex = 59;
            this.label23.Text = "COLOR:";
            // 
            // brandCombobox
            // 
            this.brandCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brandCombobox.FormattingEnabled = true;
            this.brandCombobox.Location = new System.Drawing.Point(206, 28);
            this.brandCombobox.Name = "brandCombobox";
            this.brandCombobox.Size = new System.Drawing.Size(182, 33);
            this.brandCombobox.TabIndex = 63;
            // 
            // colorCombobox
            // 
            this.colorCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorCombobox.FormattingEnabled = true;
            this.colorCombobox.Location = new System.Drawing.Point(0, 28);
            this.colorCombobox.Name = "colorCombobox";
            this.colorCombobox.Size = new System.Drawing.Size(140, 33);
            this.colorCombobox.TabIndex = 58;
            // 
            // yearCombobox
            // 
            this.yearCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCombobox.FormattingEnabled = true;
            this.yearCombobox.Location = new System.Drawing.Point(424, 28);
            this.yearCombobox.Name = "yearCombobox";
            this.yearCombobox.Size = new System.Drawing.Size(134, 33);
            this.yearCombobox.TabIndex = 60;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(424, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 25);
            this.label24.TabIndex = 61;
            this.label24.Text = "YEAR";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(56, 257);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 25);
            this.label25.TabIndex = 62;
            this.label25.Text = "FILTERS:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(467, 299);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 25);
            this.label17.TabIndex = 57;
            this.label17.Text = "TO";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(126, 294);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 25);
            this.label18.TabIndex = 56;
            this.label18.Text = "FROM";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(56, 343);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 25);
            this.label19.TabIndex = 55;
            this.label19.Text = "BRANCH:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(56, 294);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 25);
            this.label20.TabIndex = 54;
            this.label20.Text = "DATE:";
            // 
            // branchCombobox
            // 
            this.branchCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branchCombobox.FormattingEnabled = true;
            this.branchCombobox.Location = new System.Drawing.Point(56, 371);
            this.branchCombobox.Name = "branchCombobox";
            this.branchCombobox.Size = new System.Drawing.Size(160, 33);
            this.branchCombobox.TabIndex = 52;
            // 
            // filterToDate
            // 
            this.filterToDate.Location = new System.Drawing.Point(515, 294);
            this.filterToDate.Name = "filterToDate";
            this.filterToDate.Size = new System.Drawing.Size(235, 31);
            this.filterToDate.TabIndex = 53;
            // 
            // filterFromDate
            // 
            this.filterFromDate.Location = new System.Drawing.Point(209, 294);
            this.filterFromDate.Name = "filterFromDate";
            this.filterFromDate.Size = new System.Drawing.Size(235, 31);
            this.filterFromDate.TabIndex = 51;
            // 
            // vehicleMostLeastCombobox
            // 
            this.vehicleMostLeastCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleMostLeastCombobox.FormattingEnabled = true;
            this.vehicleMostLeastCombobox.Location = new System.Drawing.Point(417, 207);
            this.vehicleMostLeastCombobox.Name = "vehicleMostLeastCombobox";
            this.vehicleMostLeastCombobox.Size = new System.Drawing.Size(123, 33);
            this.vehicleMostLeastCombobox.TabIndex = 50;
            // 
            // vehicleRadio4
            // 
            this.vehicleRadio4.AutoSize = true;
            this.vehicleRadio4.Location = new System.Drawing.Point(56, 211);
            this.vehicleRadio4.Name = "vehicleRadio4";
            this.vehicleRadio4.Size = new System.Drawing.Size(355, 29);
            this.vehicleRadio4.TabIndex = 49;
            this.vehicleRadio4.TabStop = true;
            this.vehicleRadio4.Text = "VEHICLE CLASS THAT WAS RENTED THE";
            this.vehicleRadio4.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(376, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 25);
            this.label16.TabIndex = 48;
            this.label16.Text = "MILEAGE";
            // 
            // mileageNumericUpdown
            // 
            this.mileageNumericUpdown.Location = new System.Drawing.Point(236, 152);
            this.mileageNumericUpdown.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.mileageNumericUpdown.Name = "mileageNumericUpdown";
            this.mileageNumericUpdown.Size = new System.Drawing.Size(133, 31);
            this.mileageNumericUpdown.TabIndex = 43;
            this.mileageNumericUpdown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // vehicleRadio3
            // 
            this.vehicleRadio3.AutoSize = true;
            this.vehicleRadio3.Location = new System.Drawing.Point(56, 154);
            this.vehicleRadio3.Name = "vehicleRadio3";
            this.vehicleRadio3.Size = new System.Drawing.Size(174, 29);
            this.vehicleRadio3.TabIndex = 36;
            this.vehicleRadio3.TabStop = true;
            this.vehicleRadio3.Text = "VEHICLES ABOVE";
            this.vehicleRadio3.UseVisualStyleBackColor = true;
            this.vehicleRadio3.CheckedChanged += new System.EventHandler(this.vehicleRadio3_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(468, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "WAS AVAILABLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(511, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "NOT AVAILABLE";
            // 
            // vehicleRadio2
            // 
            this.vehicleRadio2.AutoSize = true;
            this.vehicleRadio2.Location = new System.Drawing.Point(56, 97);
            this.vehicleRadio2.Name = "vehicleRadio2";
            this.vehicleRadio2.Size = new System.Drawing.Size(421, 29);
            this.vehicleRadio2.TabIndex = 1;
            this.vehicleRadio2.TabStop = true;
            this.vehicleRadio2.Text = "VEHICLE CLASSES THAT WERE REQUESTED AND";
            this.vehicleRadio2.UseVisualStyleBackColor = true;
            // 
            // vehicleRadio1
            // 
            this.vehicleRadio1.AutoSize = true;
            this.vehicleRadio1.Location = new System.Drawing.Point(56, 34);
            this.vehicleRadio1.Name = "vehicleRadio1";
            this.vehicleRadio1.Size = new System.Drawing.Size(464, 29);
            this.vehicleRadio1.TabIndex = 0;
            this.vehicleRadio1.TabStop = true;
            this.vehicleRadio1.Text = "VEHICLE CLASSES THAT WERE REQUESTED AND WAS";
            this.vehicleRadio1.UseVisualStyleBackColor = true;
            // 
            // branchStatsPanel
            // 
            this.branchStatsPanel.Controls.Add(this.label3);
            this.branchStatsPanel.Controls.Add(this.label6);
            this.branchStatsPanel.Controls.Add(this.label12);
            this.branchStatsPanel.Controls.Add(this.label13);
            this.branchStatsPanel.Controls.Add(this.comboBox1);
            this.branchStatsPanel.Controls.Add(this.dateTimePicker1);
            this.branchStatsPanel.Controls.Add(this.dateTimePicker2);
            this.branchStatsPanel.Controls.Add(this.label14);
            this.branchStatsPanel.Controls.Add(this.branchNumericUpdown2);
            this.branchStatsPanel.Controls.Add(this.branchBottomRadio);
            this.branchStatsPanel.Controls.Add(this.label5);
            this.branchStatsPanel.Controls.Add(this.branchNumericUpdown1);
            this.branchStatsPanel.Controls.Add(this.branchTopRadio);
            this.branchStatsPanel.Location = new System.Drawing.Point(55, 1130);
            this.branchStatsPanel.Name = "branchStatsPanel";
            this.branchStatsPanel.Size = new System.Drawing.Size(1059, 349);
            this.branchStatsPanel.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 25);
            this.label3.TabIndex = 50;
            this.label3.Text = "TO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 49;
            this.label6.Text = "FROM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 25);
            this.label12.TabIndex = 48;
            this.label12.Text = "FILTER BY BRANCH:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(56, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 25);
            this.label13.TabIndex = 47;
            this.label13.Text = "FILTER BY DATE:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(252, 237);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 33);
            this.comboBox1.TabIndex = 45;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(492, 175);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(235, 31);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(199, 175);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(235, 31);
            this.dateTimePicker2.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(450, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 25);
            this.label14.TabIndex = 43;
            this.label14.Text = "RENTALS BETWEEN";
            // 
            // branchNumericUpdown2
            // 
            this.branchNumericUpdown2.Location = new System.Drawing.Point(387, 103);
            this.branchNumericUpdown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumericUpdown2.Name = "branchNumericUpdown2";
            this.branchNumericUpdown2.Size = new System.Drawing.Size(53, 31);
            this.branchNumericUpdown2.TabIndex = 42;
            this.branchNumericUpdown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // branchBottomRadio
            // 
            this.branchBottomRadio.Location = new System.Drawing.Point(56, 105);
            this.branchBottomRadio.Name = "branchBottomRadio";
            this.branchBottomRadio.Size = new System.Drawing.Size(325, 29);
            this.branchBottomRadio.TabIndex = 41;
            this.branchBottomRadio.TabStop = true;
            this.branchBottomRadio.Text = "BRANCHES THAT MADE LESS THAN";
            this.branchBottomRadio.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchBottomRadio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "RENTALS BETWEEN";
            // 
            // branchNumericUpdown1
            // 
            this.branchNumericUpdown1.Location = new System.Drawing.Point(372, 37);
            this.branchNumericUpdown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumericUpdown1.Name = "branchNumericUpdown1";
            this.branchNumericUpdown1.Size = new System.Drawing.Size(53, 31);
            this.branchNumericUpdown1.TabIndex = 36;
            this.branchNumericUpdown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // branchTopRadio
            // 
            this.branchTopRadio.Location = new System.Drawing.Point(56, 37);
            this.branchTopRadio.Name = "branchTopRadio";
            this.branchTopRadio.Size = new System.Drawing.Size(325, 29);
            this.branchTopRadio.TabIndex = 29;
            this.branchTopRadio.TabStop = true;
            this.branchTopRadio.Text = "BRANCHES THAT MADE AT LEAST";
            this.branchTopRadio.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchTopRadio.UseVisualStyleBackColor = true;
            // 
            // employeeStatsPanel
            // 
            this.employeeStatsPanel.Controls.Add(this.label10);
            this.employeeStatsPanel.Controls.Add(this.label21);
            this.employeeStatsPanel.Controls.Add(this.numericUpDown2);
            this.employeeStatsPanel.Controls.Add(this.label15);
            this.employeeStatsPanel.Controls.Add(this.label22);
            this.employeeStatsPanel.Controls.Add(this.label11);
            this.employeeStatsPanel.Controls.Add(this.radioButton3);
            this.employeeStatsPanel.Controls.Add(this.label9);
            this.employeeStatsPanel.Controls.Add(this.label8);
            this.employeeStatsPanel.Controls.Add(this.topBranchCombobox);
            this.employeeStatsPanel.Controls.Add(this.topToDatePicker);
            this.employeeStatsPanel.Controls.Add(this.topNumericUpdown);
            this.employeeStatsPanel.Controls.Add(this.topFromDatePicker);
            this.employeeStatsPanel.Controls.Add(this.label2);
            this.employeeStatsPanel.Controls.Add(this.topRadioButton);
            this.employeeStatsPanel.Location = new System.Drawing.Point(81, 915);
            this.employeeStatsPanel.Name = "employeeStatsPanel";
            this.employeeStatsPanel.Size = new System.Drawing.Size(1059, 349);
            this.employeeStatsPanel.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 25);
            this.label10.TabIndex = 44;
            this.label10.Text = "PERFORMING EMPLOYEE(S)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(233, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(231, 25);
            this.label21.TabIndex = 40;
            this.label21.Text = "PERFORMING EMPLOYEE(S)";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(123, 107);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(53, 31);
            this.numericUpDown2.TabIndex = 42;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(492, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 25);
            this.label15.TabIndex = 39;
            this.label15.Text = "TO";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(182, 107);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 25);
            this.label22.TabIndex = 43;
            this.label22.Text = "WORST";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(196, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 25);
            this.label11.TabIndex = 38;
            this.label11.Text = "FROM";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(56, 107);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 29);
            this.radioButton3.TabIndex = 41;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "TOP";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 25);
            this.label9.TabIndex = 37;
            this.label9.Text = "FILTER BY BRANCH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 25);
            this.label8.TabIndex = 36;
            this.label8.Text = "FILTER BY DATE:";
            // 
            // topBranchCombobox
            // 
            this.topBranchCombobox.FormattingEnabled = true;
            this.topBranchCombobox.Location = new System.Drawing.Point(252, 250);
            this.topBranchCombobox.Name = "topBranchCombobox";
            this.topBranchCombobox.Size = new System.Drawing.Size(182, 33);
            this.topBranchCombobox.TabIndex = 33;
            // 
            // topToDatePicker
            // 
            this.topToDatePicker.Location = new System.Drawing.Point(492, 188);
            this.topToDatePicker.Name = "topToDatePicker";
            this.topToDatePicker.Size = new System.Drawing.Size(235, 31);
            this.topToDatePicker.TabIndex = 33;
            // 
            // topNumericUpdown
            // 
            this.topNumericUpdown.Location = new System.Drawing.Point(123, 35);
            this.topNumericUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topNumericUpdown.Name = "topNumericUpdown";
            this.topNumericUpdown.Size = new System.Drawing.Size(53, 31);
            this.topNumericUpdown.TabIndex = 32;
            this.topNumericUpdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // topFromDatePicker
            // 
            this.topFromDatePicker.Location = new System.Drawing.Point(199, 188);
            this.topFromDatePicker.Name = "topFromDatePicker";
            this.topFromDatePicker.Size = new System.Drawing.Size(235, 31);
            this.topFromDatePicker.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(182, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "BEST";
            // 
            // topRadioButton
            // 
            this.topRadioButton.Location = new System.Drawing.Point(56, 35);
            this.topRadioButton.Name = "topRadioButton";
            this.topRadioButton.Size = new System.Drawing.Size(72, 29);
            this.topRadioButton.TabIndex = 29;
            this.topRadioButton.TabStop = true;
            this.topRadioButton.Text = "TOP";
            this.topRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.topRadioButton.UseVisualStyleBackColor = true;
            // 
            // reportsDataView
            // 
            this.reportsDataView.AllowUserToAddRows = false;
            this.reportsDataView.AllowUserToDeleteRows = false;
            this.reportsDataView.AllowUserToResizeColumns = false;
            this.reportsDataView.AllowUserToResizeRows = false;
            this.reportsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDataView.Location = new System.Drawing.Point(396, 595);
            this.reportsDataView.MultiSelect = false;
            this.reportsDataView.Name = "reportsDataView";
            this.reportsDataView.ReadOnly = true;
            this.reportsDataView.RowHeadersWidth = 62;
            this.reportsDataView.RowTemplate.Height = 33;
            this.reportsDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportsDataView.Size = new System.Drawing.Size(386, 91);
            this.reportsDataView.TabIndex = 30;
            // 
            // RunCustomReportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 1506);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RunCustomReportPage";
            this.Text = "RunCustomScript";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.vehicleStatsPanel.ResumeLayout(false);
            this.vehicleStatsPanel.PerformLayout();
            this.vehicleFilters.ResumeLayout(false);
            this.vehicleFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageNumericUpdown)).EndInit();
            this.branchStatsPanel.ResumeLayout(false);
            this.branchStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown1)).EndInit();
            this.employeeStatsPanel.ResumeLayout(false);
            this.employeeStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private ComboBox reportCombobox;
        private Button generateButton;
        private Button button4;
        private Button button2;
        private Panel panel1;
        private DataGridView reportsDataView;
        private Panel employeeStatsPanel;
        private Label label2;
        private RadioButton topRadioButton;
        private NumericUpDown topNumericUpdown;
        private DateTimePicker topToDatePicker;
        private ComboBox topBranchCombobox;
        private Panel branchStatsPanel;
        private Label label14;
        private NumericUpDown branchNumericUpdown2;
        private RadioButton branchBottomRadio;
        private NumericUpDown branchNumericUpdown1;
        private RadioButton branchTopRadio;
        private Panel vehicleStatsPanel;
        private Label label7;
        private Label label4;
        private RadioButton vehicleRadio2;
        private RadioButton vehicleRadio1;
        private Label label3;
        private Label label6;
        private Label label12;
        private Label label13;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label5;
        private Label label15;
        private Label label11;
        private Label label9;
        private Label label8;
        private DateTimePicker topFromDatePicker;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private ComboBox branchCombobox;
        private DateTimePicker filterToDate;
        private DateTimePicker filterFromDate;
        private ComboBox vehicleMostLeastCombobox;
        private RadioButton vehicleRadio4;
        private Label label16;
        private NumericUpDown mileageNumericUpdown;
        private RadioButton vehicleRadio3;
        private Label label10;
        private Label label21;
        private NumericUpDown numericUpDown2;
        private Label label22;
        private RadioButton radioButton3;
        private Label label26;
        private ComboBox brandCombobox;
        private Label label25;
        private Label label24;
        private ComboBox yearCombobox;
        private Label label23;
        private ComboBox colorCombobox;
        private Panel vehicleFilters;
    }
}