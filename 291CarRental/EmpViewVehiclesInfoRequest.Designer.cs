namespace _291CarRental
{
    partial class EmpViewVehiclesInfoRequest
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
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customerDetailsPanel = new System.Windows.Forms.Panel();
            this.showVehicleDataGripViewPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).BeginInit();
            this.customerDetailsPanel.SuspendLayout();
            this.showVehicleDataGripViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(568, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "TO";
            // 
            // vehicleClassCombobox
            // 
            this.vehicleClassCombobox.FormattingEnabled = true;
            this.vehicleClassCombobox.Location = new System.Drawing.Point(52, 88);
            this.vehicleClassCombobox.Name = "vehicleClassCombobox";
            this.vehicleClassCombobox.Size = new System.Drawing.Size(182, 33);
            this.vehicleClassCombobox.TabIndex = 4;
            this.vehicleClassCombobox.Text = "VEHICLE CLASS";
            // 
            // branchComboBox
            // 
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Location = new System.Drawing.Point(301, 88);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(182, 33);
            this.branchComboBox.TabIndex = 5;
            this.branchComboBox.Text = "BRANCH";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(347, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 62);
            this.button1.TabIndex = 6;
            this.button1.Text = "FIND AVAILABLE VEHICLES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customerIDLabel
            // 
            this.customerIDLabel.AutoSize = true;
            this.customerIDLabel.Location = new System.Drawing.Point(3, 423);
            this.customerIDLabel.Name = "customerIDLabel";
            this.customerIDLabel.Size = new System.Drawing.Size(126, 25);
            this.customerIDLabel.TabIndex = 7;
            this.customerIDLabel.Text = "CUSTOMER ID";
            // 
            // customerIdTextbox
            // 
            this.customerIdTextbox.Location = new System.Drawing.Point(155, 420);
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
            this.showVehicleDataGridView.Location = new System.Drawing.Point(3, 7);
            this.showVehicleDataGridView.MultiSelect = false;
            this.showVehicleDataGridView.Name = "showVehicleDataGridView";
            this.showVehicleDataGridView.ReadOnly = true;
            this.showVehicleDataGridView.RowHeadersWidth = 62;
            this.showVehicleDataGridView.RowTemplate.Height = 33;
            this.showVehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showVehicleDataGridView.Size = new System.Drawing.Size(904, 324);
            this.showVehicleDataGridView.TabIndex = 10;
            this.showVehicleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showVehicleDataGridView_CellContentClick);
            this.showVehicleDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.showVehicleDataGridView_CellMouseClick);
            // 
            // estimatedCostLabel
            // 
            this.estimatedCostLabel.AutoSize = true;
            this.estimatedCostLabel.Location = new System.Drawing.Point(3, 376);
            this.estimatedCostLabel.Name = "estimatedCostLabel";
            this.estimatedCostLabel.Size = new System.Drawing.Size(200, 25);
            this.estimatedCostLabel.TabIndex = 11;
            this.estimatedCostLabel.Text = "ESTIMATED COST:  0.00";
            // 
            // rentVehicleButton
            // 
            this.rentVehicleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rentVehicleButton.Location = new System.Drawing.Point(362, 838);
            this.rentVehicleButton.Name = "rentVehicleButton";
            this.rentVehicleButton.Size = new System.Drawing.Size(199, 64);
            this.rentVehicleButton.TabIndex = 12;
            this.rentVehicleButton.Text = "RENT THIS VEHICLE";
            this.rentVehicleButton.UseVisualStyleBackColor = true;
            this.rentVehicleButton.Visible = false;
            this.rentVehicleButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(702, 421);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 33);
            this.button3.TabIndex = 13;
            this.button3.Text = "GET CUSTOMER DETAILS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "CUSTOMER: JOHN DOE (003)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "GOLD MEMBER: YES";
            // 
            // customerDetailsPanel
            // 
            this.customerDetailsPanel.Controls.Add(this.label3);
            this.customerDetailsPanel.Controls.Add(this.label4);
            this.customerDetailsPanel.Location = new System.Drawing.Point(52, 734);
            this.customerDetailsPanel.Name = "customerDetailsPanel";
            this.customerDetailsPanel.Size = new System.Drawing.Size(243, 81);
            this.customerDetailsPanel.TabIndex = 16;
            this.customerDetailsPanel.Visible = false;
            // 
            // showVehicleDataGripViewPanel
            // 
            this.showVehicleDataGripViewPanel.Controls.Add(this.label6);
            this.showVehicleDataGripViewPanel.Controls.Add(this.textBox1);
            this.showVehicleDataGripViewPanel.Controls.Add(this.label5);
            this.showVehicleDataGripViewPanel.Controls.Add(this.showVehicleDataGridView);
            this.showVehicleDataGripViewPanel.Controls.Add(this.estimatedCostLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.button3);
            this.showVehicleDataGripViewPanel.Controls.Add(this.customerIDLabel);
            this.showVehicleDataGripViewPanel.Controls.Add(this.customerIdTextbox);
            this.showVehicleDataGripViewPanel.Location = new System.Drawing.Point(52, 250);
            this.showVehicleDataGripViewPanel.Name = "showVehicleDataGripViewPanel";
            this.showVehicleDataGripViewPanel.Size = new System.Drawing.Size(954, 464);
            this.showVehicleDataGripViewPanel.TabIndex = 17;
            this.showVehicleDataGripViewPanel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "PHONE NUMBER";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(533, 423);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "OR";
            // 
            // EmpViewVehiclesInfoRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 918);
            this.Controls.Add(this.showVehicleDataGripViewPanel);
            this.Controls.Add(this.customerDetailsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.rentVehicleButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vehicleClassCombobox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.branchComboBox);
            this.Name = "EmpViewVehiclesInfoRequest";
            this.Text = "ViewCarsInfoRequest";
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).EndInit();
            this.customerDetailsPanel.ResumeLayout(false);
            this.customerDetailsPanel.PerformLayout();
            this.showVehicleDataGripViewPanel.ResumeLayout(false);
            this.showVehicleDataGripViewPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button button3;
        private Label label3;
        private Label label4;
        private Panel customerDetailsPanel;
        private Panel showVehicleDataGripViewPanel;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
    }
}