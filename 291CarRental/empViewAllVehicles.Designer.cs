﻿namespace _291CarRental
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vehicleClassCombobox = new System.Windows.Forms.ComboBox();
            this.branchComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.customerIDLabel = new System.Windows.Forms.Label();
            this.customerIdTextbox = new System.Windows.Forms.TextBox();
            this.showVehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.estimatedCostLabel = new System.Windows.Forms.Label();
            this.rentVehicleButton = new System.Windows.Forms.Button();
            this.showVehicleDataGripViewPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).BeginInit();
            this.showVehicleDataGripViewPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(535, 8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker2.TabIndex = 1;
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
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(324, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 62);
            this.button1.TabIndex = 6;
            this.button1.Text = "FIND AVAILABLE VEHICLES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.findAvailableVehiclesButton_Click);
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
            // 
            // showVehicleDataGridView
            // 
            this.showVehicleDataGridView.AllowUserToAddRows = false;
            this.showVehicleDataGridView.AllowUserToDeleteRows = false;
            this.showVehicleDataGridView.AllowUserToResizeColumns = false;
            this.showVehicleDataGridView.AllowUserToResizeRows = false;
            this.showVehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showVehicleDataGridView.Location = new System.Drawing.Point(3, 3);
            this.showVehicleDataGridView.MultiSelect = false;
            this.showVehicleDataGridView.Name = "showVehicleDataGridView";
            this.showVehicleDataGridView.ReadOnly = true;
            this.showVehicleDataGridView.RowHeadersWidth = 62;
            this.showVehicleDataGridView.RowTemplate.Height = 33;
            this.showVehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showVehicleDataGridView.Size = new System.Drawing.Size(904, 398);
            this.showVehicleDataGridView.TabIndex = 10;
            this.showVehicleDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.vehicleInfoRow_Click);
            // 
            // estimatedCostLabel
            // 
            this.estimatedCostLabel.AutoSize = true;
            this.estimatedCostLabel.Location = new System.Drawing.Point(0, 417);
            this.estimatedCostLabel.Name = "estimatedCostLabel";
            this.estimatedCostLabel.Size = new System.Drawing.Size(200, 25);
            this.estimatedCostLabel.TabIndex = 11;
            this.estimatedCostLabel.Text = "ESTIMATED COST:  0.00";
            // 
            // rentVehicleButton
            // 
            this.rentVehicleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rentVehicleButton.Location = new System.Drawing.Point(359, 767);
            this.rentVehicleButton.Name = "rentVehicleButton";
            this.rentVehicleButton.Size = new System.Drawing.Size(199, 64);
            this.rentVehicleButton.TabIndex = 12;
            this.rentVehicleButton.Text = "RENT THIS VEHICLE";
            this.rentVehicleButton.UseVisualStyleBackColor = true;
            this.rentVehicleButton.Visible = false;
            this.rentVehicleButton.Click += new System.EventHandler(this.rentThisVehicleButton_Click);
            // 
            // showVehicleDataGripViewPanel
            // 
            this.showVehicleDataGripViewPanel.Controls.Add(this.showVehicleDataGridView);
            this.showVehicleDataGripViewPanel.Controls.Add(this.estimatedCostLabel);
            this.showVehicleDataGripViewPanel.Location = new System.Drawing.Point(19, 271);
            this.showVehicleDataGripViewPanel.Name = "showVehicleDataGripViewPanel";
            this.showVehicleDataGripViewPanel.Size = new System.Drawing.Size(931, 457);
            this.showVehicleDataGripViewPanel.TabIndex = 17;
            this.showVehicleDataGripViewPanel.Visible = false;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(543, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 16;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "ADDRESS:";
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.branchComboBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.vehicleClassCombobox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.rentVehicleButton);
            this.panel1.Controls.Add(this.showVehicleDataGripViewPanel);
            this.panel1.Controls.Add(this.customerIdTextbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.customerIDLabel);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(121, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 831);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(6, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 868);
            this.panel2.TabIndex = 24;
            // 
            // EmpViewAllVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 889);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "EmpViewAllVehicles";
            this.Text = "EMPLOYEE VIEWING AVAILABLE VEHICLES";
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).EndInit();
            this.showVehicleDataGripViewPanel.ResumeLayout(false);
            this.showVehicleDataGripViewPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private ComboBox vehicleClassCombobox;
        private ComboBox branchComboBox;
        private Button button1;
        private Label customerIDLabel;
        private TextBox customerIdTextbox;
        private DataGridView showVehicleDataGridView;
        private Label estimatedCostLabel;
        private Button rentVehicleButton;
        private Panel showVehicleDataGripViewPanel;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private Label label7;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Panel panel2;
    }
}