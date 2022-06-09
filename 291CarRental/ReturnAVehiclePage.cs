using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291CarRental
{
    public partial class ReturnAVehiclePage : Form
    {
        private EmployeeLandingPage previousPage;
        private DbConnection connection;
        private String empId;

        public ReturnAVehiclePage(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.connection = connection;
            this.empId = empId;
            this.StartPosition = FormStartPosition.CenterScreen;

            customerIDRadio.Checked = true;
            onlyUnreturnedVehicles.Checked = true;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        private DataTable getCustomerRentals()
        {
            DataTable customerRentals = new DataTable();
            String query = @"SELECT 
    rental_id,
    (SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name FROM Customer WHERE customer_id = Rental.customer_id) [Name],
	start_date_of_booking [Booking start date],
	expected_dropoff_date [Expected drop off date],
	FORMAT(initial_amount_paid, 'C') [Amount paid],
	(SELECT branch_name FROM Branch WHERE Branch.branch_id = Rental.pickup_branch_id) [Expected dropoff location],
	(SELECT CAST ([year] AS VARCHAR) + ', ' + brand + ' ' + model FROM Vehicle WHERE Rental.vehicle_id = Vehicle.vehicle_id) [Vehicle Rented]
FROM Rental";

            String custInput = custIdOrPhoneOrPlateNumber.Text;
            if (customerIDRadio.Checked)
            {
                query += "\nWHERE customer_id = " + custInput;
            }
            else if (phoneNumberRadio.Checked)
            {
                query += "\nWHERE Rental.customer_id IN (SELECT customer_id FROM Customer WHERE area_code + '' + phone_number = " + addQuotes(custInput) + @")";
            }
            else if (plateNumberRadio.Checked)
            {
                query += "\nWHERE Rental.vehicle_id IN (SELECT vehicle_id FROM Vehicle WHERE plate_number = " + addQuotes(custInput) + @")";
            }
            else
            {
                MessageBox.Show("INTERNAL ERROR OCCURED IN ReturnAVehiclePage");
            }

            if (onlyUnreturnedVehicles.Checked)
            {
                query += "\nAND actual_dropoff_date IS NULL";
            }
            //MessageBox.Show(query);
            customerRentals.Load(connection.executeReader(query));
            return customerRentals;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void findAllRentalsButton_Click(object sender, EventArgs e)
        {
            // load data into the DataGripView
            customerRentalsDataGripView.DataSource = getCustomerRentals();
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in customerRentalsDataGripView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            customerRentalsDataGripView.Columns["rental_id"].Visible = false;
            findRentalsPanel.Show();
        }

        private void startAReturnButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            String? rentalId = customerRentalsDataGripView.CurrentRow.Cells["rental_id"].Value.ToString();
            String? name = customerRentalsDataGripView.CurrentRow.Cells["Name"].Value.ToString();
            String? startDate = customerRentalsDataGripView.CurrentRow.Cells["Booking start date"].Value.ToString();
            String? expectedDropoffDate= customerRentalsDataGripView.CurrentRow.Cells["Expected drop off date"].Value.ToString();
            String? amountPaid = customerRentalsDataGripView.CurrentRow.Cells["Amount paid"].Value.ToString();
            String? expectedDropoffLocation = customerRentalsDataGripView.CurrentRow.Cells["Expected dropoff location"].Value.ToString();
            String? vehicleRented = customerRentalsDataGripView.CurrentRow.Cells["Vehicle Rented"].Value.ToString();
            
            
            //MessageBox.Show(name + "\n" + startDate + "\n" + expectedDropoffDate + "\n" + expectedDropoffLocation +
            //    "\n" + amountPaid + "\n" + expectedDropoffLocation + "\n" + vehicleRented);
            new StartAReturnPage(this, empId, connection, rentalId, name, startDate, expectedDropoffDate,
                amountPaid, expectedDropoffLocation, vehicleRented).ShowDialog();
        }

        private void customerIDRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = customerIDRadio.Text;
        }

        private void phoneNumberRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = phoneNumberRadio.Text;
        }

        private void plateNumberRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = plateNumberRadio.Text;
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
