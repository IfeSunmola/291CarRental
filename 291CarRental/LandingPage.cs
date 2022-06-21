using System.Data;
using System.Data.SqlClient;

namespace _291CarRental
{
    /// <summary>
    /// This form is the first form a customer or employee would see
    /// </summary>
    public partial class LandingPage : Form
    {
        private DbConnection connection;

        public LandingPage()
        {
            InitializeComponent();
            connection = new DbConnection();
        }

        /// <summary>
        /// on "CUSTOMERS" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;// hide current form
            empLoginPanel.Visible = false;// hide the emp login textbox 
            new CustSelectVehicleFilters(this, connection).ShowDialog();//move to Customers screen
            this.Visible = true;// on exit
        }

        /// <summary>
        /// On "EMPLOYEES" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empButton_Click(object sender, EventArgs e)
        {
            empLoginPanel.Visible = true;
            emptyTextboxLabel.Visible = false;
            loginMessageLabel.Visible = false;
        }

        /// <summary>
        /// when the login button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empLoginButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(empIdTextbox.Text))// empty text box, hide loginMessageLabel and show emptyTextboxLabel
            {
                loginMessageLabel.Visible = false;

                emptyTextboxLabel.Text = "ID CANNOT BE EMPTY";
                emptyTextboxLabel.Visible = true;
            }
            else
            {// textbox is not empty, hide the emptyTextboxLabel
                emptyTextboxLabel.Visible = false;
                // checking if the employee is in the database
                String query = "SELECT emp_id, first_name FROM Employee WHERE emp_id = " + empIdTextbox.Text + ";";
                String firstName = "";
                String? emp_id = null;
                SqlDataReader reader = connection.executeReader(query);
                
                while (reader.Read())
                {
                    emp_id = reader.GetInt32("emp_id").ToString();
                    firstName = reader.GetString("first_name");
                }
                reader.Close();

                if (emp_id != null)// id was found, show sucess message and hide error messages
                {// not null means a value was returned, value will only be returned if the emp_id was found
                    loginMessageLabel.Text = "WELCOME, " + firstName.ToUpper();
                    loginMessageLabel.Visible = true;
                    loginMessageLabel.ForeColor = Color.Green;

                    Task.Delay(250).Wait();// just so the employee can see the login message
                   this.Visible = false;
                    new EmployeeLandingPage(this, emp_id, connection).ShowDialog();

                    emptyTextboxLabel.Visible = false;
                    loginMessageLabel.Visible = false;
                    this.Visible = true;
                }
                else// id was not found
                {
                    loginMessageLabel.Text = "EMPLOYEE ID NOT FOUND";
                    loginMessageLabel.ForeColor = Color.Red;
                    loginMessageLabel.Visible = true;
                    emptyTextboxLabel.Visible = false;
                }
            }
        }

        /// <summary>
        /// EXIT BUTTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method makes any textbox ignore input that aren't numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ignoreCharInput(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}