﻿namespace _291CarRental
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
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.vehicleFilters = new System.Windows.Forms.Panel();
            this.mileageBetween2 = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.mileageBetweenLabel = new System.Windows.Forms.Label();
            this.mileageBetweenAndLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.mileageBetween1 = new System.Windows.Forms.NumericUpDown();
            this.brandCombobox = new System.Windows.Forms.ComboBox();
            this.colorCombobox = new System.Windows.Forms.ComboBox();
            this.yearCombobox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.filterFromDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.filterToDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.branchCombobox = new System.Windows.Forms.ComboBox();
            this.branchLabel = new System.Windows.Forms.Label();
            this.vehicleStatsPanel = new System.Windows.Forms.Panel();
            this.vehicleRadio5 = new System.Windows.Forms.RadioButton();
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
            this.profitableNumericUpdown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.branchNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.branchRadio3 = new System.Windows.Forms.RadioButton();
            this.branchMostLeastProfitable = new System.Windows.Forms.ComboBox();
            this.branchRadio2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.branchNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.branchRadio1 = new System.Windows.Forms.RadioButton();
            this.employeeStatsPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.employeeNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.employeeRadio2 = new System.Windows.Forms.RadioButton();
            this.employeeNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.employeeRadio1 = new System.Windows.Forms.RadioButton();
            this.reportsDataView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.filtersPanel.SuspendLayout();
            this.vehicleFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageBetween2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mileageBetween1)).BeginInit();
            this.vehicleStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageNumericUpdown)).BeginInit();
            this.branchStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profitableNumericUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumeric1)).BeginInit();
            this.employeeStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNumeric1)).BeginInit();
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
            this.generateButton.Location = new System.Drawing.Point(512, 578);
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
            this.panel1.Controls.Add(this.errorMessageLabel);
            this.panel1.Controls.Add(this.filtersPanel);
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
            // errorMessageLabel
            // 
            this.errorMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(181, 550);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(831, 25);
            this.errorMessageLabel.TabIndex = 35;
            this.errorMessageLabel.Text = "ERROR HEHE HEHE";
            this.errorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorMessageLabel.Visible = false;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Controls.Add(this.vehicleFilters);
            this.filtersPanel.Controls.Add(this.label25);
            this.filtersPanel.Controls.Add(this.filterFromDate);
            this.filtersPanel.Controls.Add(this.label17);
            this.filtersPanel.Controls.Add(this.filterToDate);
            this.filtersPanel.Controls.Add(this.label18);
            this.filtersPanel.Controls.Add(this.branchCombobox);
            this.filtersPanel.Controls.Add(this.branchLabel);
            this.filtersPanel.Location = new System.Drawing.Point(181, 328);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(831, 207);
            this.filtersPanel.TabIndex = 34;
            // 
            // vehicleFilters
            // 
            this.vehicleFilters.Controls.Add(this.mileageBetween2);
            this.vehicleFilters.Controls.Add(this.label26);
            this.vehicleFilters.Controls.Add(this.mileageBetweenLabel);
            this.vehicleFilters.Controls.Add(this.mileageBetweenAndLabel);
            this.vehicleFilters.Controls.Add(this.label23);
            this.vehicleFilters.Controls.Add(this.mileageBetween1);
            this.vehicleFilters.Controls.Add(this.brandCombobox);
            this.vehicleFilters.Controls.Add(this.colorCombobox);
            this.vehicleFilters.Controls.Add(this.yearCombobox);
            this.vehicleFilters.Controls.Add(this.label24);
            this.vehicleFilters.Location = new System.Drawing.Point(180, 86);
            this.vehicleFilters.Name = "vehicleFilters";
            this.vehicleFilters.Size = new System.Drawing.Size(558, 118);
            this.vehicleFilters.TabIndex = 34;
            this.vehicleFilters.Visible = false;
            // 
            // mileageBetween2
            // 
            this.mileageBetween2.Enabled = false;
            this.mileageBetween2.Location = new System.Drawing.Point(404, 83);
            this.mileageBetween2.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.mileageBetween2.Name = "mileageBetween2";
            this.mileageBetween2.Size = new System.Drawing.Size(113, 31);
            this.mileageBetween2.TabIndex = 67;
            this.mileageBetween2.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.mileageBetween2.ValueChanged += new System.EventHandler(this.valueChanged);
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
            // mileageBetweenLabel
            // 
            this.mileageBetweenLabel.AutoSize = true;
            this.mileageBetweenLabel.Location = new System.Drawing.Point(0, 89);
            this.mileageBetweenLabel.Name = "mileageBetweenLabel";
            this.mileageBetweenLabel.Size = new System.Drawing.Size(213, 25);
            this.mileageBetweenLabel.TabIndex = 36;
            this.mileageBetweenLabel.Text = "WITH MILEAGE BETWEEN";
            // 
            // mileageBetweenAndLabel
            // 
            this.mileageBetweenAndLabel.AutoSize = true;
            this.mileageBetweenAndLabel.Location = new System.Drawing.Point(341, 85);
            this.mileageBetweenAndLabel.Name = "mileageBetweenAndLabel";
            this.mileageBetweenAndLabel.Size = new System.Drawing.Size(50, 25);
            this.mileageBetweenAndLabel.TabIndex = 66;
            this.mileageBetweenAndLabel.Text = "AND";
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
            // mileageBetween1
            // 
            this.mileageBetween1.Enabled = false;
            this.mileageBetween1.Location = new System.Drawing.Point(224, 83);
            this.mileageBetween1.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.mileageBetween1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mileageBetween1.Name = "mileageBetween1";
            this.mileageBetween1.Size = new System.Drawing.Size(113, 31);
            this.mileageBetween1.TabIndex = 65;
            this.mileageBetween1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mileageBetween1.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // brandCombobox
            // 
            this.brandCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brandCombobox.FormattingEnabled = true;
            this.brandCombobox.Location = new System.Drawing.Point(206, 28);
            this.brandCombobox.Name = "brandCombobox";
            this.brandCombobox.Size = new System.Drawing.Size(182, 33);
            this.brandCombobox.TabIndex = 63;
            this.brandCombobox.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // colorCombobox
            // 
            this.colorCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorCombobox.FormattingEnabled = true;
            this.colorCombobox.Location = new System.Drawing.Point(0, 28);
            this.colorCombobox.Name = "colorCombobox";
            this.colorCombobox.Size = new System.Drawing.Size(140, 33);
            this.colorCombobox.TabIndex = 58;
            this.colorCombobox.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // yearCombobox
            // 
            this.yearCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCombobox.FormattingEnabled = true;
            this.yearCombobox.Location = new System.Drawing.Point(424, 28);
            this.yearCombobox.Name = "yearCombobox";
            this.yearCombobox.Size = new System.Drawing.Size(134, 33);
            this.yearCombobox.TabIndex = 60;
            this.yearCombobox.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
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
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 25);
            this.label25.TabIndex = 62;
            this.label25.Text = "FILTERS:";
            // 
            // filterFromDate
            // 
            this.filterFromDate.Location = new System.Drawing.Point(83, 36);
            this.filterFromDate.Name = "filterFromDate";
            this.filterFromDate.Size = new System.Drawing.Size(235, 31);
            this.filterFromDate.TabIndex = 51;
            this.filterFromDate.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(341, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 25);
            this.label17.TabIndex = 57;
            this.label17.Text = "TO";
            // 
            // filterToDate
            // 
            this.filterToDate.Location = new System.Drawing.Point(389, 36);
            this.filterToDate.Name = "filterToDate";
            this.filterToDate.Size = new System.Drawing.Size(235, 31);
            this.filterToDate.TabIndex = 53;
            this.filterToDate.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 25);
            this.label18.TabIndex = 56;
            this.label18.Text = "FROM";
            // 
            // branchCombobox
            // 
            this.branchCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branchCombobox.FormattingEnabled = true;
            this.branchCombobox.Location = new System.Drawing.Point(0, 114);
            this.branchCombobox.Name = "branchCombobox";
            this.branchCombobox.Size = new System.Drawing.Size(160, 33);
            this.branchCombobox.TabIndex = 52;
            this.branchCombobox.SelectedIndexChanged += new System.EventHandler(this.branchFilter_Changed);
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Location = new System.Drawing.Point(0, 86);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(86, 25);
            this.branchLabel.TabIndex = 55;
            this.branchLabel.Text = "BRANCH:";
            // 
            // vehicleStatsPanel
            // 
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio5);
            this.vehicleStatsPanel.Controls.Add(this.vehicleMostLeastCombobox);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio4);
            this.vehicleStatsPanel.Controls.Add(this.label16);
            this.vehicleStatsPanel.Controls.Add(this.mileageNumericUpdown);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio3);
            this.vehicleStatsPanel.Controls.Add(this.label7);
            this.vehicleStatsPanel.Controls.Add(this.label4);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio2);
            this.vehicleStatsPanel.Controls.Add(this.vehicleRadio1);
            this.vehicleStatsPanel.Location = new System.Drawing.Point(181, 60);
            this.vehicleStatsPanel.Name = "vehicleStatsPanel";
            this.vehicleStatsPanel.Size = new System.Drawing.Size(831, 262);
            this.vehicleStatsPanel.TabIndex = 33;
            // 
            // vehicleRadio5
            // 
            this.vehicleRadio5.AutoSize = true;
            this.vehicleRadio5.Location = new System.Drawing.Point(0, 203);
            this.vehicleRadio5.Name = "vehicleRadio5";
            this.vehicleRadio5.Size = new System.Drawing.Size(355, 29);
            this.vehicleRadio5.TabIndex = 51;
            this.vehicleRadio5.TabStop = true;
            this.vehicleRadio5.Text = "VEHICLES THAT HAVEN\'T BEEN RENTED ";
            this.vehicleRadio5.UseVisualStyleBackColor = true;
            this.vehicleRadio5.CheckedChanged += new System.EventHandler(this.vehicleRadio5_CheckedChanged);
            // 
            // vehicleMostLeastCombobox
            // 
            this.vehicleMostLeastCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleMostLeastCombobox.FormattingEnabled = true;
            this.vehicleMostLeastCombobox.Location = new System.Drawing.Point(361, 153);
            this.vehicleMostLeastCombobox.Name = "vehicleMostLeastCombobox";
            this.vehicleMostLeastCombobox.Size = new System.Drawing.Size(123, 33);
            this.vehicleMostLeastCombobox.TabIndex = 50;
            this.vehicleMostLeastCombobox.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // vehicleRadio4
            // 
            this.vehicleRadio4.AutoSize = true;
            this.vehicleRadio4.Location = new System.Drawing.Point(0, 157);
            this.vehicleRadio4.Name = "vehicleRadio4";
            this.vehicleRadio4.Size = new System.Drawing.Size(355, 29);
            this.vehicleRadio4.TabIndex = 49;
            this.vehicleRadio4.TabStop = true;
            this.vehicleRadio4.Text = "VEHICLE CLASS THAT WAS RENTED THE";
            this.vehicleRadio4.UseVisualStyleBackColor = true;
            this.vehicleRadio4.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(320, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 25);
            this.label16.TabIndex = 48;
            this.label16.Text = "MILEAGE";
            // 
            // mileageNumericUpdown
            // 
            this.mileageNumericUpdown.Location = new System.Drawing.Point(180, 99);
            this.mileageNumericUpdown.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.mileageNumericUpdown.Name = "mileageNumericUpdown";
            this.mileageNumericUpdown.Size = new System.Drawing.Size(133, 31);
            this.mileageNumericUpdown.TabIndex = 43;
            this.mileageNumericUpdown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mileageNumericUpdown.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // vehicleRadio3
            // 
            this.vehicleRadio3.AutoSize = true;
            this.vehicleRadio3.Location = new System.Drawing.Point(0, 101);
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
            this.label7.Location = new System.Drawing.Point(412, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "WAS AVAILABLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(455, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "NOT AVAILABLE";
            // 
            // vehicleRadio2
            // 
            this.vehicleRadio2.AutoSize = true;
            this.vehicleRadio2.Location = new System.Drawing.Point(0, 50);
            this.vehicleRadio2.Name = "vehicleRadio2";
            this.vehicleRadio2.Size = new System.Drawing.Size(421, 29);
            this.vehicleRadio2.TabIndex = 1;
            this.vehicleRadio2.TabStop = true;
            this.vehicleRadio2.Text = "VEHICLE CLASSES THAT WERE REQUESTED AND";
            this.vehicleRadio2.UseVisualStyleBackColor = true;
            this.vehicleRadio2.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // vehicleRadio1
            // 
            this.vehicleRadio1.AutoSize = true;
            this.vehicleRadio1.Location = new System.Drawing.Point(0, 3);
            this.vehicleRadio1.Name = "vehicleRadio1";
            this.vehicleRadio1.Size = new System.Drawing.Size(464, 29);
            this.vehicleRadio1.TabIndex = 0;
            this.vehicleRadio1.TabStop = true;
            this.vehicleRadio1.Text = "VEHICLE CLASSES THAT WERE REQUESTED AND WAS";
            this.vehicleRadio1.UseVisualStyleBackColor = true;
            this.vehicleRadio1.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // branchStatsPanel
            // 
            this.branchStatsPanel.Controls.Add(this.profitableNumericUpdown);
            this.branchStatsPanel.Controls.Add(this.label3);
            this.branchStatsPanel.Controls.Add(this.label14);
            this.branchStatsPanel.Controls.Add(this.branchNumeric2);
            this.branchStatsPanel.Controls.Add(this.branchRadio3);
            this.branchStatsPanel.Controls.Add(this.branchMostLeastProfitable);
            this.branchStatsPanel.Controls.Add(this.branchRadio2);
            this.branchStatsPanel.Controls.Add(this.label5);
            this.branchStatsPanel.Controls.Add(this.branchNumeric1);
            this.branchStatsPanel.Controls.Add(this.branchRadio1);
            this.branchStatsPanel.Location = new System.Drawing.Point(181, 1073);
            this.branchStatsPanel.Name = "branchStatsPanel";
            this.branchStatsPanel.Size = new System.Drawing.Size(831, 262);
            this.branchStatsPanel.TabIndex = 32;
            // 
            // profitableNumericUpdown
            // 
            this.profitableNumericUpdown.Location = new System.Drawing.Point(67, 40);
            this.profitableNumericUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.profitableNumericUpdown.Name = "profitableNumericUpdown";
            this.profitableNumericUpdown.Size = new System.Drawing.Size(53, 31);
            this.profitableNumericUpdown.TabIndex = 54;
            this.profitableNumericUpdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "PROFITABLE BRANCH(ES)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(390, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 25);
            this.label14.TabIndex = 43;
            this.label14.Text = "RENTALS";
            // 
            // branchNumeric2
            // 
            this.branchNumeric2.Location = new System.Drawing.Point(331, 162);
            this.branchNumeric2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumeric2.Name = "branchNumeric2";
            this.branchNumeric2.Size = new System.Drawing.Size(53, 31);
            this.branchNumeric2.TabIndex = 42;
            this.branchNumeric2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumeric2.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // branchRadio3
            // 
            this.branchRadio3.Location = new System.Drawing.Point(0, 40);
            this.branchRadio3.Name = "branchRadio3";
            this.branchRadio3.Size = new System.Drawing.Size(72, 29);
            this.branchRadio3.TabIndex = 44;
            this.branchRadio3.TabStop = true;
            this.branchRadio3.Text = "TOP";
            this.branchRadio3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchRadio3.UseVisualStyleBackColor = true;
            // 
            // branchMostLeastProfitable
            // 
            this.branchMostLeastProfitable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branchMostLeastProfitable.FormattingEnabled = true;
            this.branchMostLeastProfitable.Location = new System.Drawing.Point(141, 40);
            this.branchMostLeastProfitable.Name = "branchMostLeastProfitable";
            this.branchMostLeastProfitable.Size = new System.Drawing.Size(123, 33);
            this.branchMostLeastProfitable.TabIndex = 51;
            // 
            // branchRadio2
            // 
            this.branchRadio2.Location = new System.Drawing.Point(0, 164);
            this.branchRadio2.Name = "branchRadio2";
            this.branchRadio2.Size = new System.Drawing.Size(325, 29);
            this.branchRadio2.TabIndex = 41;
            this.branchRadio2.TabStop = true;
            this.branchRadio2.Text = "BRANCHES THAT MADE LESS THAN";
            this.branchRadio2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchRadio2.UseVisualStyleBackColor = true;
            this.branchRadio2.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "RENTALS";
            // 
            // branchNumeric1
            // 
            this.branchNumeric1.Location = new System.Drawing.Point(316, 95);
            this.branchNumeric1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumeric1.Name = "branchNumeric1";
            this.branchNumeric1.Size = new System.Drawing.Size(53, 31);
            this.branchNumeric1.TabIndex = 36;
            this.branchNumeric1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.branchNumeric1.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // branchRadio1
            // 
            this.branchRadio1.Location = new System.Drawing.Point(0, 95);
            this.branchRadio1.Name = "branchRadio1";
            this.branchRadio1.Size = new System.Drawing.Size(325, 29);
            this.branchRadio1.TabIndex = 29;
            this.branchRadio1.TabStop = true;
            this.branchRadio1.Text = "BRANCHES THAT MADE AT LEAST";
            this.branchRadio1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchRadio1.UseVisualStyleBackColor = true;
            this.branchRadio1.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // employeeStatsPanel
            // 
            this.employeeStatsPanel.Controls.Add(this.label10);
            this.employeeStatsPanel.Controls.Add(this.label21);
            this.employeeStatsPanel.Controls.Add(this.employeeNumeric2);
            this.employeeStatsPanel.Controls.Add(this.label22);
            this.employeeStatsPanel.Controls.Add(this.employeeRadio2);
            this.employeeStatsPanel.Controls.Add(this.employeeNumeric1);
            this.employeeStatsPanel.Controls.Add(this.label2);
            this.employeeStatsPanel.Controls.Add(this.employeeRadio1);
            this.employeeStatsPanel.Location = new System.Drawing.Point(181, 773);
            this.employeeStatsPanel.Name = "employeeStatsPanel";
            this.employeeStatsPanel.Size = new System.Drawing.Size(831, 262);
            this.employeeStatsPanel.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(195, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 25);
            this.label10.TabIndex = 44;
            this.label10.Text = "PERFORMING EMPLOYEE(S)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(177, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(231, 25);
            this.label21.TabIndex = 40;
            this.label21.Text = "PERFORMING EMPLOYEE(S)";
            // 
            // employeeNumeric2
            // 
            this.employeeNumeric2.Location = new System.Drawing.Point(67, 103);
            this.employeeNumeric2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.employeeNumeric2.Name = "employeeNumeric2";
            this.employeeNumeric2.Size = new System.Drawing.Size(53, 31);
            this.employeeNumeric2.TabIndex = 42;
            this.employeeNumeric2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.employeeNumeric2.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(126, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 25);
            this.label22.TabIndex = 43;
            this.label22.Text = "WORST";
            // 
            // employeeRadio2
            // 
            this.employeeRadio2.Location = new System.Drawing.Point(0, 103);
            this.employeeRadio2.Name = "employeeRadio2";
            this.employeeRadio2.Size = new System.Drawing.Size(72, 29);
            this.employeeRadio2.TabIndex = 41;
            this.employeeRadio2.TabStop = true;
            this.employeeRadio2.Text = "TOP";
            this.employeeRadio2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.employeeRadio2.UseVisualStyleBackColor = true;
            this.employeeRadio2.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // employeeNumeric1
            // 
            this.employeeNumeric1.Location = new System.Drawing.Point(67, 31);
            this.employeeNumeric1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.employeeNumeric1.Name = "employeeNumeric1";
            this.employeeNumeric1.Size = new System.Drawing.Size(53, 31);
            this.employeeNumeric1.TabIndex = 32;
            this.employeeNumeric1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.employeeNumeric1.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(126, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "BEST";
            // 
            // employeeRadio1
            // 
            this.employeeRadio1.Location = new System.Drawing.Point(0, 31);
            this.employeeRadio1.Name = "employeeRadio1";
            this.employeeRadio1.Size = new System.Drawing.Size(72, 29);
            this.employeeRadio1.TabIndex = 29;
            this.employeeRadio1.TabStop = true;
            this.employeeRadio1.Text = "TOP";
            this.employeeRadio1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.employeeRadio1.UseVisualStyleBackColor = true;
            this.employeeRadio1.CheckedChanged += new System.EventHandler(this.valueChanged);
            // 
            // reportsDataView
            // 
            this.reportsDataView.AllowUserToAddRows = false;
            this.reportsDataView.AllowUserToDeleteRows = false;
            this.reportsDataView.AllowUserToResizeColumns = false;
            this.reportsDataView.AllowUserToResizeRows = false;
            this.reportsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDataView.Location = new System.Drawing.Point(400, 676);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunCustomScript";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.vehicleFilters.ResumeLayout(false);
            this.vehicleFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageBetween2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mileageBetween1)).EndInit();
            this.vehicleStatsPanel.ResumeLayout(false);
            this.vehicleStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageNumericUpdown)).EndInit();
            this.branchStatsPanel.ResumeLayout(false);
            this.branchStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profitableNumericUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumeric1)).EndInit();
            this.employeeStatsPanel.ResumeLayout(false);
            this.employeeStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeNumeric1)).EndInit();
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
        private RadioButton employeeRadio1;
        private NumericUpDown employeeNumeric1;
        private Panel branchStatsPanel;
        private Label label14;
        private NumericUpDown branchNumeric2;
        private RadioButton branchRadio2;
        private NumericUpDown branchNumeric1;
        private RadioButton branchRadio1;
        private Panel vehicleStatsPanel;
        private Label label7;
        private Label label4;
        private RadioButton vehicleRadio2;
        private RadioButton vehicleRadio1;
        private Label label5;
        private Label label17;
        private Label label18;
        private Label branchLabel;
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
        private NumericUpDown employeeNumeric2;
        private Label label22;
        private RadioButton employeeRadio2;
        private Label label26;
        private ComboBox brandCombobox;
        private Label label25;
        private Label label24;
        private ComboBox yearCombobox;
        private Label label23;
        private ComboBox colorCombobox;
        private Panel vehicleFilters;
        private Panel filtersPanel;
        private Label errorMessageLabel;
        private RadioButton vehicleRadio5;
        private NumericUpDown mileageBetween1;
        private Label mileageBetweenLabel;
        private NumericUpDown mileageBetween2;
        private Label mileageBetweenAndLabel;
        private Label label3;
        private ComboBox branchMostLeastProfitable;
        private RadioButton branchRadio3;
        private NumericUpDown profitableNumericUpdown;
    }
}