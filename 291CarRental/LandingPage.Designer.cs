namespace _291CarRental
{
    partial class LandingPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.empIdLabel = new System.Windows.Forms.Label();
            this.empLoginButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.emptyTextboxLabel = new System.Windows.Forms.Label();
            this.empIdTextbox = new System.Windows.Forms.TextBox();
            this.loginMessageLabel = new System.Windows.Forms.Label();
            this.empLoginPanel = new System.Windows.Forms.Panel();
            this.empLoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(180, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 82);
            this.button1.TabIndex = 0;
            this.button1.Text = "CUSTOMERS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.custButton_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(435, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "EMPLOYEES";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.empButton_Click);
            // 
            // empIdLabel
            // 
            this.empIdLabel.AutoSize = true;
            this.empIdLabel.Location = new System.Drawing.Point(3, 0);
            this.empIdLabel.Name = "empIdLabel";
            this.empIdLabel.Size = new System.Drawing.Size(119, 25);
            this.empIdLabel.TabIndex = 2;
            this.empIdLabel.Text = "EMPLOYEE ID";
            // 
            // empLoginButton
            // 
            this.empLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.empLoginButton.Location = new System.Drawing.Point(123, 95);
            this.empLoginButton.Name = "empLoginButton";
            this.empLoginButton.Size = new System.Drawing.Size(168, 47);
            this.empLoginButton.TabIndex = 4;
            this.empLoginButton.Text = "LOGIN";
            this.empLoginButton.UseVisualStyleBackColor = true;
            this.empLoginButton.Click += new System.EventHandler(this.empLoginButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(686, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 44);
            this.button3.TabIndex = 24;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // emptyTextboxLabel
            // 
            this.emptyTextboxLabel.AutoSize = true;
            this.emptyTextboxLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emptyTextboxLabel.ForeColor = System.Drawing.Color.Red;
            this.emptyTextboxLabel.Location = new System.Drawing.Point(212, 35);
            this.emptyTextboxLabel.Name = "emptyTextboxLabel";
            this.emptyTextboxLabel.Size = new System.Drawing.Size(160, 25);
            this.emptyTextboxLabel.TabIndex = 25;
            this.emptyTextboxLabel.Text = "ERROR MESSAGE";
            this.emptyTextboxLabel.Visible = false;
            // 
            // empIdTextbox
            // 
            this.empIdTextbox.Location = new System.Drawing.Point(212, 0);
            this.empIdTextbox.Name = "empIdTextbox";
            this.empIdTextbox.ShortcutsEnabled = false;
            this.empIdTextbox.Size = new System.Drawing.Size(150, 31);
            this.empIdTextbox.TabIndex = 27;
            this.empIdTextbox.Text = "1";
            this.empIdTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empIdTextbox_KeyPress);
            // 
            // loginMessageLabel
            // 
            this.loginMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.loginMessageLabel.Location = new System.Drawing.Point(32, 67);
            this.loginMessageLabel.Name = "loginMessageLabel";
            this.loginMessageLabel.Size = new System.Drawing.Size(353, 25);
            this.loginMessageLabel.TabIndex = 28;
            this.loginMessageLabel.Text = "LOGIN SUCCESSFUL";
            this.loginMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginMessageLabel.Visible = false;
            // 
            // empLoginPanel
            // 
            this.empLoginPanel.Controls.Add(this.empIdLabel);
            this.empLoginPanel.Controls.Add(this.loginMessageLabel);
            this.empLoginPanel.Controls.Add(this.empLoginButton);
            this.empLoginPanel.Controls.Add(this.empIdTextbox);
            this.empLoginPanel.Controls.Add(this.emptyTextboxLabel);
            this.empLoginPanel.Location = new System.Drawing.Point(180, 291);
            this.empLoginPanel.Name = "empLoginPanel";
            this.empLoginPanel.Size = new System.Drawing.Size(423, 147);
            this.empLoginPanel.TabIndex = 29;
            this.empLoginPanel.Visible = false;
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.empLoginPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LandingPage";
            this.Text = "LANDING PAGE";
            this.empLoginPanel.ResumeLayout(false);
            this.empLoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private Label empIdLabel;
        private Button empLoginButton;
        private Button button3;
        private Label emptyTextboxLabel;
        private TextBox empIdTextbox;
        private Label loginMessageLabel;
        private Panel empLoginPanel;
    }
}