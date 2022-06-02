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

        private void customerButtonClick(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustViewVehiclesInfoRequest(this).Show();
        }

        private void employeeButtonClick(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empOrCustomerIdButton_Click(object sender, EventArgs e)
        {
            new EmployeeLandingPage(this).Show();
        }
    }
}