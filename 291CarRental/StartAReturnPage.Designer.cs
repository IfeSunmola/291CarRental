namespace _291CarRental
{
    partial class StartAReturnPage
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
            this.returnLabelText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.returnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.calculateAmountDue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.amountPaidLabel = new System.Windows.Forms.Label();
            this.lateFeeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.differentBranchFeeLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.amountDueNowLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.amountDuePanel = new System.Windows.Forms.Panel();
            this.feeWaiverLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.branchCombobox = new System.Windows.Forms.ComboBox();
            this.mileageUsedTextbox = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.amountDuePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageUsedTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // returnLabelText
            // 
            this.returnLabelText.Location = new System.Drawing.Point(166, 0);
            this.returnLabelText.Name = "returnLabelText";
            this.returnLabelText.Size = new System.Drawing.Size(626, 27);
            this.returnLabelText.TabIndex = 0;
            this.returnLabelText.Text = "Returning Toyota Corolla for John Doe";
            this.returnLabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "RETURN DATE";
            // 
            // returnDateTimePicker
            // 
            this.returnDateTimePicker.Location = new System.Drawing.Point(111, 77);
            this.returnDateTimePicker.Name = "returnDateTimePicker";
            this.returnDateTimePicker.Size = new System.Drawing.Size(210, 31);
            this.returnDateTimePicker.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "MILEAGE USED";
            // 
            // calculateAmountDue
            // 
            this.calculateAmountDue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateAmountDue.Location = new System.Drawing.Point(353, 133);
            this.calculateAmountDue.Name = "calculateAmountDue";
            this.calculateAmountDue.Size = new System.Drawing.Size(233, 61);
            this.calculateAmountDue.TabIndex = 19;
            this.calculateAmountDue.Text = "CALCULATE AMOUNT DUE";
            this.calculateAmountDue.UseVisualStyleBackColor = true;
            this.calculateAmountDue.Click += new System.EventHandler(this.calculateAmountDue_ButtonClicked);
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
            // amountPaidLabel
            // 
            this.amountPaidLabel.AutoSize = true;
            this.amountPaidLabel.Location = new System.Drawing.Point(318, 27);
            this.amountPaidLabel.Name = "amountPaidLabel";
            this.amountPaidLabel.Size = new System.Drawing.Size(52, 25);
            this.amountPaidLabel.TabIndex = 21;
            this.amountPaidLabel.Text = "$120";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "LATE FEE";
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
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(251, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 50);
            this.button2.TabIndex = 26;
            this.button2.Text = "FINISH RETURN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.finishReturn_ButtonClicked);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Red;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(0, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(272, 38);
            this.label11.TabIndex = 27;
            this.label11.Text = "AMOUNT DUE NOW";
            // 
            // amountDuePanel
            // 
            this.amountDuePanel.Controls.Add(this.feeWaiverLabel);
            this.amountDuePanel.Controls.Add(this.label4);
            this.amountDuePanel.Controls.Add(this.amountDueNowLabel);
            this.amountDuePanel.Controls.Add(this.amountPaidLabel);
            this.amountDuePanel.Controls.Add(this.label11);
            this.amountDuePanel.Controls.Add(this.label7);
            this.amountDuePanel.Controls.Add(this.button2);
            this.amountDuePanel.Controls.Add(this.lateFeeLabel);
            this.amountDuePanel.Controls.Add(this.differentBranchFeeLabel);
            this.amountDuePanel.Controls.Add(this.label9);
            this.amountDuePanel.Location = new System.Drawing.Point(111, 227);
            this.amountDuePanel.Name = "amountDuePanel";
            this.amountDuePanel.Size = new System.Drawing.Size(723, 346);
            this.amountDuePanel.TabIndex = 29;
            // 
            // feeWaiverLabel
            // 
            this.feeWaiverLabel.Location = new System.Drawing.Point(462, 63);
            this.feeWaiverLabel.Name = "feeWaiverLabel";
            this.feeWaiverLabel.Size = new System.Drawing.Size(219, 172);
            this.feeWaiverLabel.TabIndex = 29;
            this.feeWaiverLabel.Text = "DIFFERENT BRANCH RETURN FEE HAS BEEN WAIVED FOR THIS GOLD CUSTOMER";
            this.feeWaiverLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.branchCombobox);
            this.panel1.Controls.Add(this.mileageUsedTextbox);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.amountDuePanel);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.calculateAmountDue);
            this.panel1.Controls.Add(this.returnLabelText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.returnDateTimePicker);
            this.panel1.Location = new System.Drawing.Point(56, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 592);
            this.panel1.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(377, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 25);
            this.label13.TabIndex = 33;
            this.label13.Text = "RETURN BRANCH";
            // 
            // branchCombobox
            // 
            this.branchCombobox.FormattingEnabled = true;
            this.branchCombobox.Location = new System.Drawing.Point(377, 79);
            this.branchCombobox.Name = "branchCombobox";
            this.branchCombobox.Size = new System.Drawing.Size(182, 33);
            this.branchCombobox.TabIndex = 32;
            // 
            // mileageUsedTextbox
            // 
            this.mileageUsedTextbox.Location = new System.Drawing.Point(684, 79);
            this.mileageUsedTextbox.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.mileageUsedTextbox.Name = "mileageUsedTextbox";
            this.mileageUsedTextbox.Size = new System.Drawing.Size(180, 31);
            this.mileageUsedTextbox.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(869, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 44);
            this.button4.TabIndex = 31;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 44);
            this.button3.TabIndex = 22;
            this.button3.Text = "BACK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.backButton_Click);
            // 
            // StartAReturnPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 638);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartAReturnPage";
            this.Text = "RETURNING A VEHICLE";
            this.amountDuePanel.ResumeLayout(false);
            this.amountDuePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mileageUsedTextbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label returnLabelText;
        private Label label2;
        private DateTimePicker returnDateTimePicker;
        private Label label3;
        private Button calculateAmountDue;
        private Label label4;
        private Label amountPaidLabel;
        private Label lateFeeLabel;
        private Label label7;
        private Label differentBranchFeeLabel;
        private Label label9;
        private Button button2;
        private Label amountDueNowLabel;
        private Label label11;
        private Panel amountDuePanel;
        private Label feeWaiverLabel;
        private Panel panel1;
        private Button button3;
        private Button button4;
        private NumericUpDown mileageUsedTextbox;
        private Label label13;
        private ComboBox branchCombobox;
    }
}