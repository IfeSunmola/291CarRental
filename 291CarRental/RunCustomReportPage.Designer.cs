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
            this.reportsDataView = new System.Windows.Forms.DataGridView();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT REPORT TO GENERATE";
            // 
            // reportCombobox
            // 
            this.reportCombobox.FormattingEnabled = true;
            this.reportCombobox.Location = new System.Drawing.Point(384, 11);
            this.reportCombobox.Name = "reportCombobox";
            this.reportCombobox.Size = new System.Drawing.Size(276, 33);
            this.reportCombobox.TabIndex = 1;
            this.reportCombobox.SelectedIndexChanged += new System.EventHandler(this.reportCombobox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateButton.Location = new System.Drawing.Point(311, 189);
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
            this.button4.Location = new System.Drawing.Point(764, 0);
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
            this.panel1.Controls.Add(this.reportsDataView);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.generateButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.reportCombobox);
            this.panel1.Location = new System.Drawing.Point(36, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 558);
            this.panel1.TabIndex = 28;
            // 
            // reportsDataView
            // 
            this.reportsDataView.AllowUserToAddRows = false;
            this.reportsDataView.AllowUserToDeleteRows = false;
            this.reportsDataView.AllowUserToResizeColumns = false;
            this.reportsDataView.AllowUserToResizeRows = false;
            this.reportsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDataView.Location = new System.Drawing.Point(78, 293);
            this.reportsDataView.MultiSelect = false;
            this.reportsDataView.Name = "reportsDataView";
            this.reportsDataView.ReadOnly = true;
            this.reportsDataView.RowHeadersWidth = 62;
            this.reportsDataView.RowTemplate.Height = 33;
            this.reportsDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportsDataView.Size = new System.Drawing.Size(721, 192);
            this.reportsDataView.TabIndex = 30;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(108, 113);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(624, 29);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "EMPLOYEES WITH THE LEAST RENTALS";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(108, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(624, 29);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "EMPLOYEES WITH THE MOST RENTALS";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // RunCustomReportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 595);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RunCustomReportPage";
            this.Text = "RunCustomScript";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private DataGridView reportsDataView;
    }
}