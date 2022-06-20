using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _291CarRental
{
    /// <summary>
    /// This class/form is shows the customer filters before they can view the available vehicles
    /// </summary>
    public partial class CustSelectVehicleFilters : Form
    {
        private DbConnection connection;
        private LandingPage previousPage;// previous page for back button

        public CustSelectVehicleFilters(LandingPage previousPage, DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            this.previousPage = previousPage;
            this.StartPosition = FormStartPosition.CenterScreen;// center screen
            fromDatePicker.Value = DateTime.Now.AddDays(1);// vehicles can only be booked a day before
            toDatePicker.Value = DateTime.Now.AddDays(2);
            addressLabel.Visible = false;
            fillComboBoxes();// fill class and branch combo box
        }

        /// <summary>
        /// Back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        /// <summary>
        /// On click action for when the search button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (validateFilter())
            {
                this.Visible = false;
                new CustViewVehiclePage(this, fromDatePicker, toDatePicker, (int)vehicleClassCombobox.SelectedIndex,
                    (int)branchComboBox.SelectedIndex, connection).ShowDialog();
            }
        }

        /// <summary>
        /// This method gets the branch address (from the db) of the current branch selected in the combo box
        /// </summary>
        /// <returns>String containing the branch address</returns>
        private String getBranchAddress()
        {
            int branchId = (int)branchComboBox.SelectedIndex;// not adding +1 because of "ALL BRANCHES"
            if (branchId == 0)// all brancbes was selected, return nothing
            {
                return "";
            }

            String query =
                @"SELECT trim(street_number + ' ' + street_name + ', ' + city)
                        FROM Branch 
                    WHERE  branch_id = " + branchId + ";";

            // null checking is not needed here because of the earlier validations but... why not
            String? branchAddress = connection.executeScalar(query);
            if (branchAddress == null)
            {
                branchAddress = "DATABASE ERROR OCCURED IN CustSelectVehicleFilters, contact your administator";
            }

            return branchAddress;
        }

        /// <summary>
        /// This method checks if the filters selected by the customer are valid
        /// </summary>
        /// <returns>True if there are no issues and false if they're not</returns>
        private bool validateFilter()
        {
            bool result = false;
            if (fromDatePicker.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Vehicles must be booked one day before");
            }
            else if (fromDatePicker.Value.Date >= toDatePicker.Value.Date)
            {
                MessageBox.Show("FROM DATE HAS TO BE BEFORE TO DATE");
            }
            else if (String.IsNullOrEmpty((String)vehicleClassCombobox.SelectedItem))
            {
                MessageBox.Show("SELECT A VEHICLE CLASS");
            }
            else if (String.IsNullOrEmpty((String)branchComboBox.SelectedItem))
            {
                MessageBox.Show("SELECT A BRANCH");
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// This method fills the class and branch combo box
        /// </summary>
        private void fillComboBoxes()
        {
            vehicleClassCombobox.Items.Add("ALL CLASSES");
            branchComboBox.Items.Add("ALL BRANCHES");
            vehicleClassCombobox.SelectedIndex = 0;// all classes and 
            branchComboBox.SelectedIndex = 0;// all branches are selected by default

            String query = "SELECT vehicle_class FROM Vehicle_Class; SELECT branch_name FROM Branch;";

            SqlDataReader reader = connection.executeReader(query);
            while (reader.Read())
            {// fill vehicle class
                vehicleClassCombobox.Items.Add(reader.GetString("vehicle_class").ToUpper());
            }
            reader.NextResult();
            while (reader.Read())
            {// fill branch
                branchComboBox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            reader.Close();
        }

        /// <summary>
        /// exit button that will close the entire app
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
        /// Method to update the address field as the customer selects different branches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressLabel.Text = getBranchAddress();
            addressLabel.Visible = true;
        }
    }
}
