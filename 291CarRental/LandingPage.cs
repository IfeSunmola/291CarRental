using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace _291CarRental
{
    public partial class LandingPage : Form
    {
        private DbConnection connection;

        public LandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            connection = new DbConnection();

        }

        private void custButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            empLoginPanel.Visible = false;
            new CustSelectVehicleFilters(this, connection).ShowDialog();
            this.Visible = true;
        }

        private void empButton_Click(object sender, EventArgs e)
        {
            empLoginPanel.Visible = true;
            emptyTextboxLabel.Visible = false;
            loginMessageLabel.Visible = false;
        }

        private void empLoginButton_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(empIdTextbox.Text))// empty text box
            {// empty text box, hide loginMessageLabel and show emptyTextboxLabel
                loginMessageLabel.Visible = false;

                emptyTextboxLabel.Text = "ID CANNOT BE EMPTY";
                emptyTextboxLabel.Visible = true;
            }
            else
            {// textbox is not empty, hide the emptyTextboxLabel
                emptyTextboxLabel.Visible = false;
                String query = "SELECT emp_id FROM Employee WHERE emp_id = " + empIdTextbox.Text + ";";
                String? empId = connection.executeScalar(query);

                if (empId != null)// id was found, show sucess message and hide error messages
                {// not null means a value was returned, value will only be returned if the emp_id was found
                    loginMessageLabel.Text = "LOGIN SUCCESSFUL";
                    loginMessageLabel.Visible = true;
                    loginMessageLabel.ForeColor = Colors.SUCCESS_COLOR;

                    Task.Delay(250).Wait();
                    this.Visible = false;
                    new EmployeeLandingPage(this, empId.ToString(), connection).ShowDialog();

                    emptyTextboxLabel.Visible = false;
                    loginMessageLabel.Visible = false;
                    this.Visible = true;
                }
                else// id was not found
                {
                    loginMessageLabel.Text = "EMPLOYEE ID NOT FOUND";
                    loginMessageLabel.ForeColor = Colors.ERROR_COLOR;
                    loginMessageLabel.Visible = true;
                    emptyTextboxLabel.Visible = false;
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