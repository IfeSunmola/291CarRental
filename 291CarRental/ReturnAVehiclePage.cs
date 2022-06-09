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
    //Starting: 1288, 660
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
            this.Size = new Size(1288, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            onlyUnreturnedVehicles.Checked = true;

            findByCombobox.Items.Add("CUSTOMER ID");
            findByCombobox.Items.Add("PHONE NUMBER");
            findByCombobox.Items.Add("PLATE NUMBER");
            findByCombobox.SelectedIndex = 0;
            findByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            fillBranchCombobox();
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
            if (findByCombobox.SelectedIndex == 0)
            {
                query += "\nWHERE customer_id = " + custInput;
            }
            else if (findByCombobox.SelectedIndex == 1)
            {
                query += "\nWHERE Rental.customer_id IN (SELECT customer_id FROM Customer WHERE area_code + '' + phone_number = " + addQuotes(custInput) + @")";
            }
            else if (findByCombobox.SelectedIndex == 2)
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
            String? name = customerRentalsDataGripView.CurrentRow.Cells["Name"].Value.ToString();
            String? vehicleRented = customerRentalsDataGripView.CurrentRow.Cells["Vehicle Rented"].Value.ToString();

            returnLabelText.Text = "RETURNING " + vehicleRented.ToUpper() + " FOR " + name.ToUpper();
            if (getReturnDetails().Item3)// customer is a gold member
            {
                returnLabelText.Text += " (GOLD MEMBER)";
            }
            this.Size = new(1288, 830);
            this.CenterToScreen();

        }

        //private void customerIDRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    radioButtonLabel.Text = customerIDRadio.Text;
        //}

        //private void phoneNumberRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    radioButtonLabel.Text = phoneNumberRadio.Text;
        //}

        //private void plateNumberRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    radioButtonLabel.Text = plateNumberRadio.Text;
        //}


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

        private void findByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = findByCombobox.SelectedItem.ToString();
        }

        private Tuple<Decimal, Decimal, bool> getReturnDetails()
        {
            String? rentalId = customerRentalsDataGripView.CurrentRow.Cells["rental_id"].Value.ToString();
            String query = @"SELECT change_branch_fee, late_fee
                FROM Vehicle_Class
                WHERE vehicle_class_id in (SELECT vehicle_class_requested FROM Rental WHERE rental_id = " + rentalId + @");
                SELECT membership_type 
                FROM Customer
                WHERE customer_id in (SELECT customer_id FROM Rental WHERE rental_id =  " + rentalId + @") ";
            SqlDataReader reader = connection.executeReader(query);
            Decimal changeBranchFee = 0.00m, lateFee = 0.00m;
            bool isGoldMember = false;
            while (reader.Read())
            {
                changeBranchFee = reader.GetDecimal("change_branch_fee");
                lateFee = reader.GetDecimal("late_fee");
            }
            reader.NextResult();
            if (reader.Read())
            {
                String status = reader.GetString("membership_type");
                isGoldMember = String.Equals(status, "GOLD", StringComparison.OrdinalIgnoreCase);
            }
            return Tuple.Create(changeBranchFee, lateFee, isGoldMember);
        }

        private void calculateAmountDue_Click(object sender, EventArgs e)
        {
            String? expectedDropoffLocation = customerRentalsDataGripView.CurrentRow.Cells["Expected dropoff location"].Value.ToString();
            String? tempDate = customerRentalsDataGripView.CurrentRow.Cells["Expected drop off date"].Value.ToString();
            String? amountPaid = customerRentalsDataGripView.CurrentRow.Cells["Amount paid"].Value.ToString();

            DateTime expectedDropoffDate = Convert.ToDateTime(tempDate);
            Decimal changeBranchFee = 0.00m;
            Decimal lateFee = 0.00m;
            bool isGoldMember = getReturnDetails().Item3;
            // is late fee a flat fee or is it based on how many days late the customer was?

            if ((int)mileageUsedTextbox.Value <= 0)
            {
                MessageBox.Show("Enter a valid mileage");
                return;
            }
            else
            {
                String actualDropoffLocation = (String)branchCombobox.SelectedItem;
                if (!String.Equals(actualDropoffLocation, expectedDropoffLocation, StringComparison.OrdinalIgnoreCase))
                {// returning to the different location
                    if (!isGoldMember)
                    {
                        changeBranchFee = getReturnDetails().Item1;
                        MessageBox.Show("Returning to different location");
                    }
                    else
                    {
                        feeWaiverLabel.Text = "DIFFERENT BRANCH RETURN FEE OF " + getReturnDetails().Item1.ToString("C") + " HAS BEEN " +
                 " WAIVED FOR THIS GOLD CUSTOMER HEHEHE";
                        feeWaiverLabel.Visible = true;
                    }
                }
                else
                {
                    feeWaiverLabel.Visible = false;
                }
                if (expectedDropoffDate.AddDays(1) <= returnDateTimePicker.Value) 
                //if (expectedDropoffDate.Value.AddDays(1) <= returnDateTimePicker.Value)
                {// drop off is late
                    lateFee = getReturnDetails().Item2;
                    MessageBox.Show("Late Returns");
                }
            }
            amountPaidLabel.Text = amountPaid;
            lateFeeLabel.Text = lateFee.ToString("C");
            differentBranchFeeLabel.Text = changeBranchFee.ToString("C");
            amountDueNowLabel.Text = (lateFee + changeBranchFee).ToString("C");
            finishReturnPanel.Visible = true;
            this.Size = new(1288, 1167);
            this.CenterToScreen();
        }

        private void fillBranchCombobox()
        {
            String query =
                "\nSELECT branch_name FROM Branch;" +
                "\nSELECT Employee.branch_id" +
                "\nFROM Employee, Branch " +
                "\nWHERE Employee.branch_id = Branch.branch_id" +
                "\nAND emp_id = " + empId;
            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                branchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            reader.NextResult();
            if (reader.Read())
            {
                branchCombobox.SelectedIndex = reader.GetInt32("branch_id") - 1;
            }

            branchCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void finishReturnButton_Click(object sender, EventArgs e)
        {
            String? name = customerRentalsDataGripView.CurrentRow.Cells["Name"].Value.ToString();
            String? vehicleRented = customerRentalsDataGripView.CurrentRow.Cells["Vehicle Rented"].Value.ToString();
            String? rentalId = customerRentalsDataGripView.CurrentRow.Cells["rental_id"].Value.ToString();

            DialogResult confirmReturn = MessageBox.Show(
("Confirm returning of " + vehicleRented + " FOR " + name).ToUpper(),
"CONFIRM RETURN VEHICLE",
MessageBoxButtons.YesNo);

            if (confirmReturn == DialogResult.Yes)
            {

                if (returnSuccess(amountDueNowLabel.Text, rentalId))
                {
                    MessageBox.Show("VEHICLE RETURNED SUCCESSFULLY");
                    this.Close();
                    previousPage.Visible = true;
                }
                else
                {
                    MessageBox.Show("DATABASE ERROR OCCURED AT StartAReturnPage");
                }


            }
            else if (confirmReturn == DialogResult.No)
            {
                MessageBox.Show("VEHICLE RETURN CANCELLED");
            }
        }
        private bool returnSuccess(String extraCharge, String rentalId)
        {
            String actualDropoffDate = returnDateTimePicker.Value.Date.ToString("d");
            String query = @"UPDATE Rental
                            SET actual_dropoff_date = " + addQuotes(actualDropoffDate) + @", 
total_mileage_used = " + mileageUsedTextbox.Text + @", extra_charges = " + extraCharge + ", emp_id_return = " + empId + ", " +
"dropoff_branch_id = " + (branchCombobox.SelectedIndex + 1) +
@"WHERE rental_id = " + rentalId;

            MessageBox.Show(query);
            return connection.executeNonQuery(query) > 0;
        }
    }
}
