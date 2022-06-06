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
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.empIdTextbox = new System.Windows.Forms.TextBox();
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
            this.empIdLabel.Location = new System.Drawing.Point(180, 293);
            this.empIdLabel.Name = "empIdLabel";
            this.empIdLabel.Size = new System.Drawing.Size(113, 25);
            this.empIdLabel.TabIndex = 2;
            this.empIdLabel.Text = "Employee ID";
            // 
            // empLoginButton
            // 
            this.empLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.empLoginButton.Location = new System.Drawing.Point(302, 378);
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
            // errorMessageLabel
            // 
            this.errorMessageLabel.AutoSize = true;
            this.errorMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(382, 325);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(160, 25);
            this.errorMessageLabel.TabIndex = 25;
            this.errorMessageLabel.Text = "ERROR MESSAGE";
            this.errorMessageLabel.Visible = false;
            // 
            // empIdTextbox
            // 
            this.empIdTextbox.Location = new System.Drawing.Point(382, 290);
            this.empIdTextbox.Name = "empIdTextbox";
            this.empIdTextbox.ShortcutsEnabled = false;
            this.empIdTextbox.Size = new System.Drawing.Size(150, 31);
            this.empIdTextbox.TabIndex = 27;
            this.empIdTextbox.Text = "1";
            this.empIdTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empIdTextbox_KeyPress);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.empIdTextbox);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.empLoginButton);
            this.Controls.Add(this.empIdLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LandingPage";
            this.Text = "LANDING PAGE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Label empIdLabel;
        private Button empLoginButton;
        private Button button3;
        private Label errorMessageLabel;
        private TextBox empIdTextbox;
    }
}