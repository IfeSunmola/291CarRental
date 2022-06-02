using System.Data.SqlClient;

namespace _291CarRental
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Visible = false;
            empIdTextbox.Visible = false;
            empLoginButton.Visible = false;
        }

        private void custButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustSelectVehicleFilters(this).Show();
        }

        private void empButton_Click(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empLoginButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new EmployeeLandingPage(this).Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmExit = MessageBox.Show(
                "Are you sure you want to exit the application?" +
                "\nAny unsaved information will be lost".ToUpper(),
                "CONFIRM EXIT",
                MessageBoxButtons.YesNo);
            if (confirmExit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}