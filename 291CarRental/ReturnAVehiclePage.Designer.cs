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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.getCustomerRentalsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerRentalsDataGripView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRentalsDataGripView
            // 
            this.customerRentalsDataGripView.AllowUserToAddRows = false;
            this.customerRentalsDataGripView.AllowUserToDeleteRows = false;
            this.customerRentalsDataGripView.AllowUserToResizeColumns = false;
            this.customerRentalsDataGripView.AllowUserToResizeRows = false;
            this.customerRentalsDataGripView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerRentalsDataGripView.Location = new System.Drawing.Point(68, 147);
            this.customerRentalsDataGripView.MultiSelect = false;
            this.customerRentalsDataGripView.Name = "customerRentalsDataGripView";
            this.customerRentalsDataGripView.ReadOnly = true;
            this.customerRentalsDataGripView.RowHeadersWidth = 62;
            this.customerRentalsDataGripView.RowTemplate.Height = 33;
            this.customerRentalsDataGripView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerRentalsDataGripView.Size = new System.Drawing.Size(904, 324);
            this.customerRentalsDataGripView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "CUSTOMER ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(252, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 6;
            // 
            // getCustomerRentalsButton
            // 
            this.getCustomerRentalsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getCustomerRentalsButton.Location = new System.Drawing.Point(355, 87);
            this.getCustomerRentalsButton.Name = "getCustomerRentalsButton";
            this.getCustomerRentalsButton.Size = new System.Drawing.Size(276, 34);
            this.getCustomerRentalsButton.TabIndex = 7;
            this.getCustomerRentalsButton.Text = "FIND ALL RENTALS";
            this.getCustomerRentalsButton.UseVisualStyleBackColor = true;
            this.getCustomerRentalsButton.Click += new System.EventHandler(this.getCustomerRentalsButton_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(378, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "START A RETURN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReturnAVehiclePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.getCustomerRentalsButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerRentalsDataGripView);
            this.Name = "ReturnAVehiclePage";
            this.Text = "ReturnAVehiclePage";
            ((System.ComponentModel.ISupportInitialize)(this.customerRentalsDataGripView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView customerRentalsDataGripView;
        private Label label1;
        private TextBox textBox1;
        private Button getCustomerRentalsButton;
        private Button button1;
    }
}