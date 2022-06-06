namespace _291CarRental
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
            this.customerRentalsDataGripView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customerIDRadio = new System.Windows.Forms.RadioButton();
            this.phoneNumberRadio = new System.Windows.Forms.RadioButton();
            this.plateNumberRadio = new System.Windows.Forms.RadioButton();
            this.radioButtonLabel = new System.Windows.Forms.Label();
            this.radioButtonTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.customerRentalsDataGripView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerRentalsDataGripView
            // 
            this.customerRentalsDataGripView.AllowUserToAddRows = false;
            this.customerRentalsDataGripView.AllowUserToDeleteRows = false;
            this.customerRentalsDataGripView.AllowUserToResizeColumns = false;
            this.customerRentalsDataGripView.AllowUserToResizeRows = false;
            this.customerRentalsDataGripView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerRentalsDataGripView.Location = new System.Drawing.Point(64, 211);
            this.customerRentalsDataGripView.MultiSelect = false;
            this.customerRentalsDataGripView.Name = "customerRentalsDataGripView";
            this.customerRentalsDataGripView.ReadOnly = true;
            this.customerRentalsDataGripView.RowHeadersWidth = 62;
            this.customerRentalsDataGripView.RowTemplate.Height = 33;
            this.customerRentalsDataGripView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerRentalsDataGripView.Size = new System.Drawing.Size(904, 324);
            this.customerRentalsDataGripView.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(396, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 62);
            this.button1.TabIndex = 8;
            this.button1.Text = "START A RETURN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.startAReturnButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "FIND BY";
            // 
            // customerIDRadio
            // 
            this.customerIDRadio.AutoSize = true;
            this.customerIDRadio.Location = new System.Drawing.Point(234, 19);
            this.customerIDRadio.Name = "customerIDRadio";
            this.customerIDRadio.Size = new System.Drawing.Size(151, 29);
            this.customerIDRadio.TabIndex = 10;
            this.customerIDRadio.TabStop = true;
            this.customerIDRadio.Text = "CUSTOMER ID";
            this.customerIDRadio.UseVisualStyleBackColor = true;
            this.customerIDRadio.CheckedChanged += new System.EventHandler(this.customerIDRadio_CheckedChanged);
            // 
            // phoneNumberRadio
            // 
            this.phoneNumberRadio.AutoSize = true;
            this.phoneNumberRadio.Location = new System.Drawing.Point(418, 19);
            this.phoneNumberRadio.Name = "phoneNumberRadio";
            this.phoneNumberRadio.Size = new System.Drawing.Size(172, 29);
            this.phoneNumberRadio.TabIndex = 11;
            this.phoneNumberRadio.TabStop = true;
            this.phoneNumberRadio.Text = "PHONE NUMBER";
            this.phoneNumberRadio.UseVisualStyleBackColor = true;
            this.phoneNumberRadio.CheckedChanged += new System.EventHandler(this.phoneNumberRadio_CheckedChanged);
            // 
            // plateNumberRadio
            // 
            this.plateNumberRadio.AutoSize = true;
            this.plateNumberRadio.Location = new System.Drawing.Point(620, 17);
            this.plateNumberRadio.Name = "plateNumberRadio";
            this.plateNumberRadio.Size = new System.Drawing.Size(161, 29);
            this.plateNumberRadio.TabIndex = 12;
            this.plateNumberRadio.TabStop = true;
            this.plateNumberRadio.Text = "PLATE NUMBER";
            this.plateNumberRadio.UseVisualStyleBackColor = true;
            this.plateNumberRadio.CheckedChanged += new System.EventHandler(this.plateNumberRadio_CheckedChanged);
            // 
            // radioButtonLabel
            // 
            this.radioButtonLabel.AutoSize = true;
            this.radioButtonLabel.Location = new System.Drawing.Point(309, 82);
            this.radioButtonLabel.Name = "radioButtonLabel";
            this.radioButtonLabel.Size = new System.Drawing.Size(147, 25);
            this.radioButtonLabel.TabIndex = 13;
            this.radioButtonLabel.Text = "PHONE NUMBER";
            // 
            // radioButtonTextbox
            // 
            this.radioButtonTextbox.Location = new System.Drawing.Point(462, 82);
            this.radioButtonTextbox.Name = "radioButtonTextbox";
            this.radioButtonTextbox.Size = new System.Drawing.Size(150, 31);
            this.radioButtonTextbox.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(396, 143);
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
            this.button4.Location = new System.Drawing.Point(930, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 44);
            this.button4.TabIndex = 25;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.radioButtonTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButtonLabel);
            this.panel1.Controls.Add(this.customerRentalsDataGripView);
            this.panel1.Controls.Add(this.plateNumberRadio);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.phoneNumberRadio);
            this.panel1.Controls.Add(this.customerIDRadio);
            this.panel1.Location = new System.Drawing.Point(29, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 636);
            this.panel1.TabIndex = 26;
            // 
            // ReturnAVehiclePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 660);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ReturnAVehiclePage";
            this.Text = "RETURNING A VEHICLE";
            ((System.ComponentModel.ISupportInitialize)(this.customerRentalsDataGripView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView customerRentalsDataGripView;
        private Button button1;
        private Label label1;
        private RadioButton customerIDRadio;
        private RadioButton phoneNumberRadio;
        private RadioButton plateNumberRadio;
        private Label radioButtonLabel;
        private TextBox radioButtonTextbox;
        private Button button3;
        private Button button2;
        private Button button4;
        private Panel panel1;
    }
}