namespace _291CarRental
{
    partial class empViewVehiclePage
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
            this.button1 = new System.Windows.Forms.Button();
            this.showVehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SHOWING AVAILABLE VEHICLES FROM NOVEMBER 20, 2022 TO SEPTEMBER 12, 2022";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(960, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "RENT THIS VEHICLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rentVehicleButton);
            // 
            // showVehicleDataGridView
            // 
            this.showVehicleDataGridView.AllowUserToAddRows = false;
            this.showVehicleDataGridView.AllowUserToDeleteRows = false;
            this.showVehicleDataGridView.AllowUserToResizeColumns = false;
            this.showVehicleDataGridView.AllowUserToResizeRows = false;
            this.showVehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showVehicleDataGridView.Location = new System.Drawing.Point(332, 75);
            this.showVehicleDataGridView.MultiSelect = false;
            this.showVehicleDataGridView.Name = "showVehicleDataGridView";
            this.showVehicleDataGridView.ReadOnly = true;
            this.showVehicleDataGridView.RowHeadersWidth = 62;
            this.showVehicleDataGridView.RowTemplate.Height = 33;
            this.showVehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showVehicleDataGridView.Size = new System.Drawing.Size(904, 324);
            this.showVehicleDataGridView.TabIndex = 3;
            this.showVehicleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showVehicleDataGridView_CellContentClick);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(332, 460);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(276, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "GET COSTS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "John Smith (129)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Customer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mary Jane (023)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Employee:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Gold Member: YES";
            // 
            // empViewVehiclePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 519);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.showVehicleDataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "empViewVehiclePage";
            this.Text = "ViewCarsResultPage";
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView showVehicleDataGridView;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label6;
    }
}