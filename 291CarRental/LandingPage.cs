using System.Data.SqlClient;

namespace _291CarRental
{
    public partial class LandingPage : Form
    {
        //public static SqlConnection? connecton;
        //private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        public LandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Visible = false;
            empIdTextbox.Visible = false;
            empLoginButton.Visible = false;
          //  connecton = new SqlConnection(connectionString);
        }

        private void customerButtonClick(object sender, EventArgs e)
        {
            /*empOrCustomerIdLabel.Text = "Customer ID: ";
            empOrCustomerIdLabel.Visible = true;

            empOrCustomerIdTextbox.Text = "";
            empOrCustomerIdTextbox.Visible=true;

            empOrCustomerIdButton.Text = "VIEW VEHICLES";
            empOrCustomerIdButton.Visible=true;*/
            new CustViewVehiclesInfoRequest().Show();
        }

        private void employeeButtonClick(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empOrCustomerIdButton_Click(object sender, EventArgs e)
        {
            new EmployeeLandingPage().Show();
        }
    }
}