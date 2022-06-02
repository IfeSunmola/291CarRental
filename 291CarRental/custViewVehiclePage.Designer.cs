namespace _291CarRental
{
    partial class CustViewVehiclePage
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
            this.showVehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showVehicleDataGridView
            // 
            this.showVehicleDataGridView.AllowUserToAddRows = false;
            this.showVehicleDataGridView.AllowUserToDeleteRows = false;
            this.showVehicleDataGridView.AllowUserToResizeColumns = false;
            this.showVehicleDataGridView.AllowUserToResizeRows = false;
            this.showVehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showVehicleDataGridView.Location = new System.Drawing.Point(32, 69);
            this.showVehicleDataGridView.MultiSelect = false;
            this.showVehicleDataGridView.Name = "showVehicleDataGridView";
            this.showVehicleDataGridView.ReadOnly = true;
            this.showVehicleDataGridView.RowHeadersWidth = 62;
            this.showVehicleDataGridView.RowTemplate.Height = 33;
            this.showVehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showVehicleDataGridView.Size = new System.Drawing.Size(904, 324);
            this.showVehicleDataGridView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "SHOWING AVAILABLE VEHICLES FROM NOVEMBER 20, 2022 TO SEPTEMBER 12, 2022";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 44);
            this.button3.TabIndex = 23;
            this.button3.Text = "BACK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(882, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 44);
            this.button1.TabIndex = 24;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.showVehicleDataGridView);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 476);
            this.panel1.TabIndex = 25;
            // 
            // CustViewVehiclePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 510);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "CustViewVehiclePage";
            this.Text = "CUSTOMER VIEWING AVAILABLE VEHICLES";
            ((System.ComponentModel.ISupportInitialize)(this.showVehicleDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView showVehicleDataGridView;
        private Label label1;
        private Button button3;
        private Button button1;
        private Panel panel1;
    }
}