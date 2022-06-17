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
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.classAvailableRadio = new System.Windows.Forms.RadioButton();
            this.classNotAvailableRadio = new System.Windows.Forms.RadioButton();
            this.branchStatsPanel = new System.Windows.Forms.Panel();
            this.branchDownToDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.branchDownFromDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.branchNumericUpdown2 = new System.Windows.Forms.NumericUpDown();
            this.branchBottomRadio = new System.Windows.Forms.RadioButton();
            this.branchUpToDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.branchUpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.branchNumericUpdown1 = new System.Windows.Forms.NumericUpDown();
            this.branchTopRadio = new System.Windows.Forms.RadioButton();
            this.employeeStatsPanel = new System.Windows.Forms.Panel();
            this.bottomRadioButton = new System.Windows.Forms.RadioButton();
            this.bottomBranchCombobox = new System.Windows.Forms.ComboBox();
            this.topBranchCombobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bottomToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.topToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bottomNumericUpdown = new System.Windows.Forms.NumericUpDown();
            this.topNumericUpdown = new System.Windows.Forms.NumericUpDown();
            this.bottomFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.topFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topRadioButton = new System.Windows.Forms.RadioButton();
            this.reportsDataView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.vehicleStatsPanel.SuspendLayout();
            this.branchStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown1)).BeginInit();
            this.employeeStatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT REPORT TO GENERATE";
            // 
            // reportCombobox
            // 
            this.reportCombobox.FormattingEnabled = true;
            this.reportCombobox.Location = new System.Drawing.Point(704, 7);
            this.reportCombobox.Name = "reportCombobox";
            this.reportCombobox.Size = new System.Drawing.Size(276, 33);
            this.reportCombobox.TabIndex = 1;
            this.reportCombobox.SelectedIndexChanged += new System.EventHandler(this.reportCombobox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateButton.Location = new System.Drawing.Point(615, 366);
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
            this.button4.Location = new System.Drawing.Point(1331, 0);
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
            this.panel1.Size = new System.Drawing.Size(1433, 1482);
            this.panel1.TabIndex = 28;
            // 
            // vehicleStatsPanel
            // 
            this.vehicleStatsPanel.Controls.Add(this.label7);
            this.vehicleStatsPanel.Controls.Add(this.label4);
            this.vehicleStatsPanel.Controls.Add(this.classAvailableRadio);
            this.vehicleStatsPanel.Controls.Add(this.classNotAvailableRadio);
            this.vehicleStatsPanel.Location = new System.Drawing.Point(68, 1111);
            this.vehicleStatsPanel.Name = "vehicleStatsPanel";
            this.vehicleStatsPanel.Size = new System.Drawing.Size(1278, 182);
            this.vehicleStatsPanel.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(561, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "WAS AVAILABLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(603, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "NOT AVAILABLE";
            // 
            // classAvailableRadio
            // 
            this.classAvailableRadio.AutoSize = true;
            this.classAvailableRadio.Location = new System.Drawing.Point(0, 101);
            this.classAvailableRadio.Name = "classAvailableRadio";
            this.classAvailableRadio.Size = new System.Drawing.Size(570, 29);
            this.classAvailableRadio.TabIndex = 1;
            this.classAvailableRadio.TabStop = true;
            this.classAvailableRadio.Text = "SHOW VEHICLE CLASSES THAT WERE REQUESTED THE MOST AND";
            this.classAvailableRadio.UseVisualStyleBackColor = true;
            // 
            // classNotAvailableRadio
            // 
            this.classNotAvailableRadio.AutoSize = true;
            this.classNotAvailableRadio.Location = new System.Drawing.Point(0, 38);
            this.classNotAvailableRadio.Name = "classNotAvailableRadio";
            this.classNotAvailableRadio.Size = new System.Drawing.Size(613, 29);
            this.classNotAvailableRadio.TabIndex = 0;
            this.classNotAvailableRadio.TabStop = true;
            this.classNotAvailableRadio.Text = "SHOW VEHICLE CLASSES THAT WERE REQUESTED THE MOST AND WAS";
            this.classNotAvailableRadio.UseVisualStyleBackColor = true;
            // 
            // branchStatsPanel
            // 
            this.branchStatsPanel.Controls.Add(this.branchDownToDate);
            this.branchStatsPanel.Controls.Add(this.label13);
            this.branchStatsPanel.Controls.Add(this.branchDownFromDate);
            this.branchStatsPanel.Controls.Add(this.label14);
            this.branchStatsPanel.Controls.Add(this.branchNumericUpdown2);
            this.branchStatsPanel.Controls.Add(this.branchBottomRadio);
            this.branchStatsPanel.Controls.Add(this.branchUpToDate);
            this.branchStatsPanel.Controls.Add(this.label11);
            this.branchStatsPanel.Controls.Add(this.branchUpFromDate);
            this.branchStatsPanel.Controls.Add(this.label5);
            this.branchStatsPanel.Controls.Add(this.branchNumericUpdown1);
            this.branchStatsPanel.Controls.Add(this.branchTopRadio);
            this.branchStatsPanel.Location = new System.Drawing.Point(68, 768);
            this.branchStatsPanel.Name = "branchStatsPanel";
            this.branchStatsPanel.Size = new System.Drawing.Size(1278, 232);
            this.branchStatsPanel.TabIndex = 32;
            // 
            // branchDownToDate
            // 
            this.branchDownToDate.Location = new System.Drawing.Point(894, 137);
            this.branchDownToDate.Name = "branchDownToDate";
            this.branchDownToDate.Size = new System.Drawing.Size(235, 31);
            this.branchDownToDate.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(827, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 25);
            this.label13.TabIndex = 46;
            this.label13.Text = "AND";
            // 
            // branchDownFromDate
            // 
            this.branchDownFromDate.Location = new System.Drawing.Point(575, 137);
            this.branchDownFromDate.Name = "branchDownFromDate";
            this.branchDownFromDate.Size = new System.Drawing.Size(235, 31);
            this.branchDownFromDate.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(394, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 25);
            this.label14.TabIndex = 43;
            this.label14.Text = "RENTALS BETWEEN";
            // 
            // branchNumericUpdown2
            // 
            this.branchNumericUpdown2.Location = new System.Drawing.Point(331, 135);
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
            this.branchBottomRadio.Location = new System.Drawing.Point(0, 137);
            this.branchBottomRadio.Name = "branchBottomRadio";
            this.branchBottomRadio.Size = new System.Drawing.Size(325, 29);
            this.branchBottomRadio.TabIndex = 41;
            this.branchBottomRadio.TabStop = true;
            this.branchBottomRadio.Text = "BRANCHES THAT MADE LESS THAN";
            this.branchBottomRadio.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.branchBottomRadio.UseVisualStyleBackColor = true;
            // 
            // branchUpToDate
            // 
            this.branchUpToDate.Location = new System.Drawing.Point(894, 38);
            this.branchUpToDate.Name = "branchUpToDate";
            this.branchUpToDate.Size = new System.Drawing.Size(235, 31);
            this.branchUpToDate.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(827, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 25);
            this.label11.TabIndex = 40;
            this.label11.Text = "AND";
            // 
            // branchUpFromDate
            // 
            this.branchUpFromDate.Location = new System.Drawing.Point(575, 38);
            this.branchUpFromDate.Name = "branchUpFromDate";
            this.branchUpFromDate.Size = new System.Drawing.Size(235, 31);
            this.branchUpFromDate.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "RENTALS BETWEEN";
            // 
            // branchNumericUpdown1
            // 
            this.branchNumericUpdown1.Location = new System.Drawing.Point(316, 38);
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
            this.branchTopRadio.Location = new System.Drawing.Point(0, 38);
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
            this.employeeStatsPanel.Controls.Add(this.bottomRadioButton);
            this.employeeStatsPanel.Controls.Add(this.bottomBranchCombobox);
            this.employeeStatsPanel.Controls.Add(this.topBranchCombobox);
            this.employeeStatsPanel.Controls.Add(this.label8);
            this.employeeStatsPanel.Controls.Add(this.label6);
            this.employeeStatsPanel.Controls.Add(this.bottomToDatePicker);
            this.employeeStatsPanel.Controls.Add(this.topToDatePicker);
            this.employeeStatsPanel.Controls.Add(this.label9);
            this.employeeStatsPanel.Controls.Add(this.label3);
            this.employeeStatsPanel.Controls.Add(this.bottomNumericUpdown);
            this.employeeStatsPanel.Controls.Add(this.topNumericUpdown);
            this.employeeStatsPanel.Controls.Add(this.bottomFromDatePicker);
            this.employeeStatsPanel.Controls.Add(this.topFromDatePicker);
            this.employeeStatsPanel.Controls.Add(this.label10);
            this.employeeStatsPanel.Controls.Add(this.label2);
            this.employeeStatsPanel.Controls.Add(this.topRadioButton);
            this.employeeStatsPanel.Location = new System.Drawing.Point(68, 77);
            this.employeeStatsPanel.Name = "employeeStatsPanel";
            this.employeeStatsPanel.Size = new System.Drawing.Size(1278, 232);
            this.employeeStatsPanel.TabIndex = 31;
            // 
            // bottomRadioButton
            // 
            this.bottomRadioButton.AutoSize = true;
            this.bottomRadioButton.Location = new System.Drawing.Point(0, 139);
            this.bottomRadioButton.Name = "bottomRadioButton";
            this.bottomRadioButton.Size = new System.Drawing.Size(107, 29);
            this.bottomRadioButton.TabIndex = 34;
            this.bottomRadioButton.TabStop = true;
            this.bottomRadioButton.Text = "BOTTOM";
            this.bottomRadioButton.UseVisualStyleBackColor = true;
            // 
            // bottomBranchCombobox
            // 
            this.bottomBranchCombobox.FormattingEnabled = true;
            this.bottomBranchCombobox.Location = new System.Drawing.Point(982, 137);
            this.bottomBranchCombobox.Name = "bottomBranchCombobox";
            this.bottomBranchCombobox.Size = new System.Drawing.Size(182, 33);
            this.bottomBranchCombobox.TabIndex = 33;
            // 
            // topBranchCombobox
            // 
            this.topBranchCombobox.FormattingEnabled = true;
            this.topBranchCombobox.Location = new System.Drawing.Point(939, 36);
            this.topBranchCombobox.Name = "topBranchCombobox";
            this.topBranchCombobox.Size = new System.Drawing.Size(182, 33);
            this.topBranchCombobox.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(946, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "IN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(903, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 25);
            this.label6.TabIndex = 35;
            this.label6.Text = "IN";
            // 
            // bottomToDatePicker
            // 
            this.bottomToDatePicker.Location = new System.Drawing.Point(695, 137);
            this.bottomToDatePicker.Name = "bottomToDatePicker";
            this.bottomToDatePicker.Size = new System.Drawing.Size(235, 31);
            this.bottomToDatePicker.TabIndex = 33;
            // 
            // topToDatePicker
            // 
            this.topToDatePicker.Location = new System.Drawing.Point(652, 36);
            this.topToDatePicker.Name = "topToDatePicker";
            this.topToDatePicker.Size = new System.Drawing.Size(235, 31);
            this.topToDatePicker.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(628, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "AND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "AND";
            // 
            // bottomNumericUpdown
            // 
            this.bottomNumericUpdown.Location = new System.Drawing.Point(110, 137);
            this.bottomNumericUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bottomNumericUpdown.Name = "bottomNumericUpdown";
            this.bottomNumericUpdown.Size = new System.Drawing.Size(53, 31);
            this.bottomNumericUpdown.TabIndex = 32;
            this.bottomNumericUpdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // topNumericUpdown
            // 
            this.topNumericUpdown.Location = new System.Drawing.Point(67, 36);
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
            // bottomFromDatePicker
            // 
            this.bottomFromDatePicker.Location = new System.Drawing.Point(376, 137);
            this.bottomFromDatePicker.Name = "bottomFromDatePicker";
            this.bottomFromDatePicker.Size = new System.Drawing.Size(235, 31);
            this.bottomFromDatePicker.TabIndex = 32;
            // 
            // topFromDatePicker
            // 
            this.topFromDatePicker.Location = new System.Drawing.Point(333, 36);
            this.topFromDatePicker.Name = "topFromDatePicker";
            this.topFromDatePicker.Size = new System.Drawing.Size(235, 31);
            this.topFromDatePicker.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "EMPLOYEES BETWEEN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "EMPLOYEES BETWEEN";
            // 
            // topRadioButton
            // 
            this.topRadioButton.Location = new System.Drawing.Point(0, 38);
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
            this.reportsDataView.Location = new System.Drawing.Point(428, 527);
            this.reportsDataView.MultiSelect = false;
            this.reportsDataView.Name = "reportsDataView";
            this.reportsDataView.ReadOnly = true;
            this.reportsDataView.RowHeadersWidth = 62;
            this.reportsDataView.RowTemplate.Height = 33;
            this.reportsDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportsDataView.Size = new System.Drawing.Size(588, 192);
            this.reportsDataView.TabIndex = 30;
            // 
            // RunCustomReportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 1506);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RunCustomReportPage";
            this.Text = "RunCustomScript";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.vehicleStatsPanel.ResumeLayout(false);
            this.vehicleStatsPanel.PerformLayout();
            this.branchStatsPanel.ResumeLayout(false);
            this.branchStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchNumericUpdown1)).EndInit();
            this.employeeStatsPanel.ResumeLayout(false);
            this.employeeStatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpdown)).EndInit();
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
        private Label label3;
        private DateTimePicker topFromDatePicker;
        private ComboBox bottomBranchCombobox;
        private Label label8;
        private DateTimePicker bottomToDatePicker;
        private Label label9;
        private NumericUpDown bottomNumericUpdown;
        private DateTimePicker bottomFromDatePicker;
        private Label label10;
        private ComboBox topBranchCombobox;
        private Label label6;
        private RadioButton bottomRadioButton;
        private Panel branchStatsPanel;
        private DateTimePicker branchDownToDate;
        private Label label13;
        private DateTimePicker branchDownFromDate;
        private Label label14;
        private NumericUpDown branchNumericUpdown2;
        private RadioButton branchBottomRadio;
        private DateTimePicker branchUpToDate;
        private Label label11;
        private DateTimePicker branchUpFromDate;
        private Label label5;
        private NumericUpDown branchNumericUpdown1;
        private RadioButton branchTopRadio;
        private Panel vehicleStatsPanel;
        private Label label7;
        private Label label4;
        private RadioButton classAvailableRadio;
        private RadioButton classNotAvailableRadio;
    }
}