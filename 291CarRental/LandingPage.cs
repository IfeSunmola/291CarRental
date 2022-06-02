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

        // start on click events
        private void custButtonClicked(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustSelectVehicleFilters(this).Show();
        }

        private void empButtonClicked(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empLoginButtonClicked(object sender, EventArgs e)
        {
            this.Visible = false;
            new EmployeeLandingPage(this).Show();
        }
        // end on click events
    }
}