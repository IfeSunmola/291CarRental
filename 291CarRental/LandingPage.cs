using System.Data;
using System.Data.SqlClient;

namespace _291CarRental
{
    public partial class LandingPage : Form
    {
        private DbConnection connection;

        public LandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Visible = false;
            empIdTextbox.Visible = false;
            empLoginButton.Visible = false;

            connection = new DbConnection();
        }

        private void custButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustSelectVehicleFilters(this, connection).ShowDialog();
        }

        private void empButton_Click(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empLoginButton_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(empIdTextbox.Text))// empty text box
            {
                errorMessageLabel.Text = "ID CANNOT BE EMPTY";
                errorMessageLabel.Visible = true;
            }
            else
            {
                errorMessageLabel.Visible = false;
                String query = "SELECT emp_id FROM Employee WHERE emp_id = " + empIdTextbox.Text + ";";
                String? empId = connection.executeScalar(query);

                if (empId != null)
                {// not null means a value was returned, value will only be returned if the emp_id was found
                    loginMessageLabel.Text = "LOGIN SUCCESSFUL";
                    loginMessageLabel.Visible = true;
                    loginMessageLabel.ForeColor = Color.Green;

                    Task.Delay(500).Wait();
                    this.Visible = false;
                    errorMessageLabel.Visible = false;
                    new EmployeeLandingPage(this, empId.ToString(), connection).ShowDialog();
                    loginMessageLabel.Visible = false;
                }
                else
                {
                    //MessageBox.Show("Employee not found, try again", "INCORRECT ID");
                    loginMessageLabel.Text = "EMPLOYEE ID NOT FOUND";
                    loginMessageLabel.ForeColor= Color.Red;
                    loginMessageLabel.Visible = true;
                }

            }
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

        // this method make the employee id textbox only accept numbers
        // copy and paste won't work because Shortcuts are disabled
        private void empIdTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}