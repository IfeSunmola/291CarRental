﻿namespace _291CarRental
{
    partial class ReturnAVehiclePage
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
            this.rentalsDataView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.findByText = new System.Windows.Forms.Label();
            this.searchInfoTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.finishReturnPanel = new System.Windows.Forms.Panel();
            this.feeWaiverLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.amountDueNowLabel = new System.Windows.Forms.Label();
            this.amountPaidLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.finishReturnButton = new System.Windows.Forms.Button();
            this.lateFeeLabel = new System.Windows.Forms.Label();
            this.differentBranchFeeLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.calculateAmountDuePanel = new System.Windows.Forms.Panel();
            this.mileageUsedTextbox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calculateAmountDue = new System.Windows.Forms.Button();
            this.branchCombobox = new System.Windows.Forms.ComboBox();
            this.returnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.returnLabelText = new System.Windows.Forms.Label();
            this.findByCombobox = new System.Windows.Forms.ComboBox();
            this.findRentalsPanel = new System.Windows.Forms.Panel();
            this.selectAVehicleLabel = new System.Windows.Forms.Label();
            this.viewFullDetails = new System.Windows.Forms.Button();
            this.onlyUnreturnedVehicles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.rentalsDataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.finishReturnPanel.SuspendLayout();
            this.calculateAmountDuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageUsedTextbox)).BeginInit();
            this.findRentalsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rentalsDataView
            // 
            this.rentalsDataView.AllowUserToAddRows = false;
            this.rentalsDataView.AllowUserToDeleteRows = false;
            this.rentalsDataView.AllowUserToResizeColumns = false;
            this.rentalsDataView.AllowUserToResizeRows = false;
            this.rentalsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentalsDataView.Location = new System.Drawing.Point(0, 3);
            this.rentalsDataView.MultiSelect = false;
            this.rentalsDataView.Name = "rentalsDataView";
            this.rentalsDataView.ReadOnly = true;
            this.rentalsDataView.RowHeadersWidth = 62;
            this.rentalsDataView.RowTemplate.Height = 33;
            this.rentalsDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rentalsDataView.Size = new System.Drawing.Size(1069, 229);
            this.rentalsDataView.TabIndex = 4;
            this.rentalsDataView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rentalsDataView_CellMouseClick);
            this.rentalsDataView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.rentalsDataView_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(269, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "FIND BY";
            // 
            // findByText
            // 
            this.findByText.AutoSize = true;
            this.findByText.Location = new System.Drawing.Point(608, 13);
            this.findByText.Name = "findByText";
            this.findByText.Size = new System.Drawing.Size(147, 25);
            this.findByText.TabIndex = 13;
            this.findByText.Text = "PHONE NUMBER";
            // 
            // searchInfoTextbox
            // 
            this.searchInfoTextbox.Location = new System.Drawing.Point(761, 13);
            this.searchInfoTextbox.Name = "searchInfoTextbox";
            this.searchInfoTextbox.Size = new System.Drawing.Size(150, 31);
            this.searchInfoTextbox.TabIndex = 14;
            this.searchInfoTextbox.TextChanged += new System.EventHandler(this.searchInfoChanged);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(487, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 62);
            this.button3.TabIndex = 16;
            this.button3.Text = "FIND ALL RENTALS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.findAllRentalsButton_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 44);
            this.button2.TabIndex = 22;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(1102, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 44);
            this.button4.TabIndex = 25;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorMessageLabel);
            this.panel1.Controls.Add(this.finishReturnPanel);
            this.panel1.Controls.Add(this.calculateAmountDuePanel);
            this.panel1.Controls.Add(this.findByCombobox);
            this.panel1.Controls.Add(this.findRentalsPanel);
            this.panel1.Controls.Add(this.onlyUnreturnedVehicles);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.searchInfoTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.findByText);
            this.panel1.Location = new System.Drawing.Point(29, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 1088);
            this.panel1.TabIndex = 26;
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(104, 99);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(998, 25);
            this.errorMessageLabel.TabIndex = 43;
            this.errorMessageLabel.Text = "ERROR MESSAGE HEHE HEHE HEHE";
            this.errorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorMessageLabel.Visible = false;
            // 
            // finishReturnPanel
            // 
            this.finishReturnPanel.Controls.Add(this.feeWaiverLabel);
            this.finishReturnPanel.Controls.Add(this.label4);
            this.finishReturnPanel.Controls.Add(this.amountDueNowLabel);
            this.finishReturnPanel.Controls.Add(this.amountPaidLabel);
            this.finishReturnPanel.Controls.Add(this.label11);
            this.finishReturnPanel.Controls.Add(this.label7);
            this.finishReturnPanel.Controls.Add(this.finishReturnButton);
            this.finishReturnPanel.Controls.Add(this.lateFeeLabel);
            this.finishReturnPanel.Controls.Add(this.differentBranchFeeLabel);
            this.finishReturnPanel.Controls.Add(this.label9);
            this.finishReturnPanel.Location = new System.Drawing.Point(104, 778);
            this.finishReturnPanel.Name = "finishReturnPanel";
            this.finishReturnPanel.Size = new System.Drawing.Size(998, 300);
            this.finishReturnPanel.TabIndex = 38;
            // 
            // feeWaiverLabel
            // 
            this.feeWaiverLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.feeWaiverLabel.Location = new System.Drawing.Point(696, 47);
            this.feeWaiverLabel.Name = "feeWaiverLabel";
            this.feeWaiverLabel.Size = new System.Drawing.Size(219, 172);
            this.feeWaiverLabel.TabIndex = 29;
            this.feeWaiverLabel.Text = "DIFFERENT BRANCH RETURN FEE HAS BEEN WAIVED FOR THIS GOLD CUSTOMER";
            this.feeWaiverLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "INITIAL AMOUNT PAID";
            // 
            // amountDueNowLabel
            // 
            this.amountDueNowLabel.AutoSize = true;
            this.amountDueNowLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountDueNowLabel.Location = new System.Drawing.Point(308, 181);
            this.amountDueNowLabel.Name = "amountDueNowLabel";
            this.amountDueNowLabel.Size = new System.Drawing.Size(62, 38);
            this.amountDueNowLabel.TabIndex = 28;
            this.amountDueNowLabel.Text = "$50";
            // 
            // amountPaidLabel
            // 
            this.amountPaidLabel.AutoSize = true;
            this.amountPaidLabel.Location = new System.Drawing.Point(318, 27);
            this.amountPaidLabel.Name = "amountPaidLabel";
            this.amountPaidLabel.Size = new System.Drawing.Size(52, 25);
            this.amountPaidLabel.TabIndex = 21;
            this.amountPaidLabel.Text = "$120";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(0, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(272, 38);
            this.label11.TabIndex = 27;
            this.label11.Text = "AMOUNT DUE NOW";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "LATE FEE";
            // 
            // finishReturnButton
            // 
            this.finishReturnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishReturnButton.Location = new System.Drawing.Point(419, 247);
            this.finishReturnButton.Name = "finishReturnButton";
            this.finishReturnButton.Size = new System.Drawing.Size(158, 50);
            this.finishReturnButton.TabIndex = 26;
            this.finishReturnButton.Text = "FINISH RETURN";
            this.finishReturnButton.UseVisualStyleBackColor = true;
            this.finishReturnButton.Click += new System.EventHandler(this.finishReturnButton_Click);
            // 
            // lateFeeLabel
            // 
            this.lateFeeLabel.AutoSize = true;
            this.lateFeeLabel.Location = new System.Drawing.Point(318, 74);
            this.lateFeeLabel.Name = "lateFeeLabel";
            this.lateFeeLabel.Size = new System.Drawing.Size(42, 25);
            this.lateFeeLabel.TabIndex = 23;
            this.lateFeeLabel.Text = "$30";
            // 
            // differentBranchFeeLabel
            // 
            this.differentBranchFeeLabel.AutoSize = true;
            this.differentBranchFeeLabel.Location = new System.Drawing.Point(318, 122);
            this.differentBranchFeeLabel.Name = "differentBranchFeeLabel";
            this.differentBranchFeeLabel.Size = new System.Drawing.Size(42, 25);
            this.differentBranchFeeLabel.TabIndex = 25;
            this.differentBranchFeeLabel.Text = "$20";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(276, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "DIFFERENT BRANCH RETURN FEE";
            // 
            // calculateAmountDuePanel
            // 
            this.calculateAmountDuePanel.Controls.Add(this.mileageUsedTextbox);
            this.calculateAmountDuePanel.Controls.Add(this.label13);
            this.calculateAmountDuePanel.Controls.Add(this.label3);
            this.calculateAmountDuePanel.Controls.Add(this.label5);
            this.calculateAmountDuePanel.Controls.Add(this.calculateAmountDue);
            this.calculateAmountDuePanel.Controls.Add(this.branchCombobox);
            this.calculateAmountDuePanel.Controls.Add(this.returnDateTimePicker);
            this.calculateAmountDuePanel.Controls.Add(this.returnLabelText);
            this.calculateAmountDuePanel.Location = new System.Drawing.Point(104, 527);
            this.calculateAmountDuePanel.Name = "calculateAmountDuePanel";
            this.calculateAmountDuePanel.Size = new System.Drawing.Size(998, 245);
            this.calculateAmountDuePanel.TabIndex = 42;
            // 
            // mileageUsedTextbox
            // 
            this.mileageUsedTextbox.Location = new System.Drawing.Point(720, 122);
            this.mileageUsedTextbox.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.mileageUsedTextbox.Name = "mileageUsedTextbox";
            this.mileageUsedTextbox.Size = new System.Drawing.Size(180, 31);
            this.mileageUsedTextbox.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 25);
            this.label13.TabIndex = 41;
            this.label13.Text = "RETURN BRANCH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "RETURN DATE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "MILEAGE USED";
            // 
            // calculateAmountDue
            // 
            this.calculateAmountDue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateAmountDue.Location = new System.Drawing.Point(383, 184);
            this.calculateAmountDue.Name = "calculateAmountDue";
            this.calculateAmountDue.Size = new System.Drawing.Size(233, 61);
            this.calculateAmountDue.TabIndex = 37;
            this.calculateAmountDue.Text = "CALCULATE AMOUNT DUE";
            this.calculateAmountDue.UseVisualStyleBackColor = true;
            this.calculateAmountDue.Click += new System.EventHandler(this.calculateAmountDue_Click);
            // 
            // branchCombobox
            // 
            this.branchCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branchCombobox.FormattingEnabled = true;
            this.branchCombobox.Location = new System.Drawing.Point(344, 120);
            this.branchCombobox.Name = "branchCombobox";
            this.branchCombobox.Size = new System.Drawing.Size(182, 33);
            this.branchCombobox.TabIndex = 40;
            this.branchCombobox.SelectedValueChanged += new System.EventHandler(this.branchCombobox_SelectedValueChanged);
            // 
            // returnDateTimePicker
            // 
            this.returnDateTimePicker.Location = new System.Drawing.Point(21, 120);
            this.returnDateTimePicker.Name = "returnDateTimePicker";
            this.returnDateTimePicker.Size = new System.Drawing.Size(210, 31);
            this.returnDateTimePicker.TabIndex = 35;
            // 
            // returnLabelText
            // 
            this.returnLabelText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.returnLabelText.Location = new System.Drawing.Point(21, 18);
            this.returnLabelText.Name = "returnLabelText";
            this.returnLabelText.Size = new System.Drawing.Size(926, 38);
            this.returnLabelText.TabIndex = 27;
            this.returnLabelText.Text = "RETURNING FOR CUSTOMER JOHN HEHEHE";
            this.returnLabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // findByCombobox
            // 
            this.findByCombobox.FormattingEnabled = true;
            this.findByCombobox.Location = new System.Drawing.Point(383, 9);
            this.findByCombobox.Name = "findByCombobox";
            this.findByCombobox.Size = new System.Drawing.Size(217, 33);
            this.findByCombobox.TabIndex = 41;
            this.findByCombobox.SelectedIndexChanged += new System.EventHandler(this.findByCombobox_SelectedIndexChanged);
            // 
            // findRentalsPanel
            // 
            this.findRentalsPanel.Controls.Add(this.selectAVehicleLabel);
            this.findRentalsPanel.Controls.Add(this.rentalsDataView);
            this.findRentalsPanel.Controls.Add(this.viewFullDetails);
            this.findRentalsPanel.Location = new System.Drawing.Point(62, 193);
            this.findRentalsPanel.Name = "findRentalsPanel";
            this.findRentalsPanel.Size = new System.Drawing.Size(1069, 328);
            this.findRentalsPanel.TabIndex = 28;
            this.findRentalsPanel.Visible = false;
            // 
            // selectAVehicleLabel
            // 
            this.selectAVehicleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectAVehicleLabel.ForeColor = System.Drawing.Color.Red;
            this.selectAVehicleLabel.Location = new System.Drawing.Point(-3, 235);
            this.selectAVehicleLabel.Name = "selectAVehicleLabel";
            this.selectAVehicleLabel.Size = new System.Drawing.Size(998, 25);
            this.selectAVehicleLabel.TabIndex = 44;
            this.selectAVehicleLabel.Text = "SELECT A VEHICLE";
            this.selectAVehicleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectAVehicleLabel.Visible = false;
            // 
            // viewFullDetails
            // 
            this.viewFullDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewFullDetails.Location = new System.Drawing.Point(383, 266);
            this.viewFullDetails.Name = "viewFullDetails";
            this.viewFullDetails.Size = new System.Drawing.Size(216, 62);
            this.viewFullDetails.TabIndex = 27;
            this.viewFullDetails.Text = "VIEW FULL DETAILS";
            this.viewFullDetails.UseVisualStyleBackColor = true;
            this.viewFullDetails.Click += new System.EventHandler(this.viewFullDetails_Click);
            // 
            // onlyUnreturnedVehicles
            // 
            this.onlyUnreturnedVehicles.AutoSize = true;
            this.onlyUnreturnedVehicles.Location = new System.Drawing.Point(448, 67);
            this.onlyUnreturnedVehicles.Name = "onlyUnreturnedVehicles";
            this.onlyUnreturnedVehicles.Size = new System.Drawing.Size(339, 29);
            this.onlyUnreturnedVehicles.TabIndex = 26;
            this.onlyUnreturnedVehicles.Text = "ONLY SHOW UNRETURNED VEHICLES";
            this.onlyUnreturnedVehicles.UseVisualStyleBackColor = true;
            this.onlyUnreturnedVehicles.CheckedChanged += new System.EventHandler(this.searchInfoChanged);
            // 
            // ReturnAVehiclePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 1092);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReturnAVehiclePage";
            this.Text = "RETURNING A VEHICLE";
            ((System.ComponentModel.ISupportInitialize)(this.rentalsDataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.finishReturnPanel.ResumeLayout(false);
            this.finishReturnPanel.PerformLayout();
            this.calculateAmountDuePanel.ResumeLayout(false);
            this.calculateAmountDuePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageUsedTextbox)).EndInit();
            this.findRentalsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView rentalsDataView;
        private Label label1;
        private Label findByText;
        private TextBox searchInfoTextbox;
        private Button button3;
        private Button button2;
        private Button button4;
        private Panel panel1;
        private CheckBox onlyUnreturnedVehicles;
        private Button viewFullDetails;
        private Panel findRentalsPanel;
        private Label returnLabelText;
        private Label label13;
        private ComboBox branchCombobox;
        private NumericUpDown mileageUsedTextbox;
        private Panel finishReturnPanel;
        private Label feeWaiverLabel;
        private Label label4;
        private Label amountDueNowLabel;
        private Label amountPaidLabel;
        private Label label11;
        private Label label7;
        private Button finishReturnButton;
        private Label lateFeeLabel;
        private Label differentBranchFeeLabel;
        private Label label9;
        private Button calculateAmountDue;
        private Label label3;
        private Label label5;
        private DateTimePicker returnDateTimePicker;
        private ComboBox findByCombobox;
        private Panel calculateAmountDuePanel;
        private Label errorMessageLabel;
        private Label selectAVehicleLabel;
    }
}