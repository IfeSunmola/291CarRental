using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            String custInput = searchInfoTextbox.Text;
            if (findByCombobox.SelectedIndex == 0)
            {
                query += "\nWHERE customer_id = " + custInput;
            }
            else if (findByCombobox.SelectedIndex == 1)
            {
                query += "\nWHERE Rental.customer_id IN (SELECT customer_id FROM Customer WHERE CAST (area_code + phone_number AS VARCHAR) = " + addQuotes(custInput) + @")";
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

        private bool validateSearchTextbox()
        {
            bool result = false;
            if (string.IsNullOrEmpty(searchInfoTextbox.Text))
            {
                errorMessageLabel.Text = findByText.Text + " IS REQUIRED";
                errorMessageLabel.Visible = true;
                return result;
            }

            if (findByCombobox.SelectedIndex == 0)
            {// customer id validations
                if (searchInfoTextbox.Text.Any(char.IsLetter))
                {
                    errorMessageLabel.Text = "CUSTOMER ID CAN'T HAVE LETTERS";
                }
                else if (!idOrPhoneNumOrPlateNumInDb("ID", searchInfoTextbox.Text))
                {
                    errorMessageLabel.Text = "CUSTOMER ID NOT FOUND";
                }
                else
                {
                    result = true;
                }
            }
            else if (findByCombobox.SelectedIndex == 1)
            {// phone number validations
                if (searchInfoTextbox.Text.Length != 10)
                {
                    errorMessageLabel.Text = "PHONE NUMBER MUST BE 10 DIGITS";
                }
                else if (searchInfoTextbox.Text.Any(char.IsLetter))
                {
                    errorMessageLabel.Text = "PHONE NUMBERS CAN'T HAVE LETTERS";
                }
                else if (!idOrPhoneNumOrPlateNumInDb("NUMBER", searchInfoTextbox.Text))
                {
                    errorMessageLabel.Text = "PHONE NUMBER NOT FOUND";
                }
                else
                {
                    result = true;
                }
            }
            else if (findByCombobox.SelectedIndex == 2)
            {// plate number validations
                if (searchInfoTextbox.Text.Length != 8)
                {
                    errorMessageLabel.Text = "PLATE NUMBER MUST BE 8 CHARACTERS";
                }
                else if (!Regex.IsMatch(searchInfoTextbox.Text, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$")){
                    errorMessageLabel.Text = "PLATE NUMBER MUST BE IN THE FORM A1B-C2D3";
                }
                else if (!idOrPhoneNumOrPlateNumInDb("PLATE", searchInfoTextbox.Text))
                {
                    errorMessageLabel.Text = "PLATE NUMBER NOT FOUND";
                }
                else
                {
                    result = true;
                }
            }


            if (!result)
            {
                errorMessageLabel.Visible = true;
            }
            return result;
        }

        private bool idOrPhoneNumOrPlateNumInDb(String flag, String idOrPhoneNumOrPlateNum)
        {
            String query = "SELECT customer_id FROM Customer WHERE ";
            if (String.Equals(flag, "ID"))
            {// find id
                query += "customer_id  = " + idOrPhoneNumOrPlateNum;
            }
            else if (String.Equals(flag, "NUMBER"))
            {// find phone number
                query += "CAST (area_code + phone_number AS VARCHAR) = " + idOrPhoneNumOrPlateNum;
            }
            else if (String.Equals(flag, "PLATE"))
            {
                query = "SELECT plate_number FROM Vehicle WHERE plate_number = " + addQuotes(idOrPhoneNumOrPlateNum);
            }
            return connection.executeScalar(query) != null;// not null: data was found
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void findAllRentalsButton_Click(object sender, EventArgs e)
        {
            if (validateSearchTextbox())
            {
                errorMessageLabel.Visible = false;
                // load data into the DataGridView
                rentalsDataView.DataSource = getCustomerRentals();
                foreach (DataGridViewColumn dataGridViewColumn in rentalsDataView.Columns)
                {
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                rentalsDataView.Columns["rental_id"].Visible = false;

                findRentalsPanel.Visible = true;
            }
        }

        private void startAReturnButton_Click(object sender, EventArgs e)
        {
            branchCombobox.Items.Clear();
            fillBranchCombobox();
            String? name = rentalsDataView.CurrentRow.Cells["Name"].Value.ToString();
            String? vehicleRented = rentalsDataView.CurrentRow.Cells["Vehicle Rented"].Value.ToString();

            returnLabelText.Text = "RETURNING " + vehicleRented.ToUpper() + " FOR " + name.ToUpper();
            if (getReturnDetails().Item3)// customer is a gold member
            {
                returnLabelText.Text += " (GOLD MEMBER)";
            }
            this.Size = new(1288, 830);
            this.CenterToScreen();

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

        private void findByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchInfoTextbox.Clear();
            errorMessageLabel.Text = "";
            findByText.Text = findByCombobox.SelectedItem.ToString();
            if (findByCombobox.SelectedIndex == 0)
            {// customer id
                searchInfoTextbox.MaxLength = 5;
                onlyUnreturnedVehicles.Visible = true;
            }
            if (findByCombobox.SelectedIndex == 1)
            {// phone number
                searchInfoTextbox.MaxLength = 10;
                onlyUnreturnedVehicles.Visible = true;
            }
            if (findByCombobox.SelectedIndex == 2)
            {// plate number
                searchInfoTextbox.MaxLength = 8;
                searchInfoTextbox.CharacterCasing = CharacterCasing.Upper;
                onlyUnreturnedVehicles.Visible = false;
            }
        }

        private Tuple<Decimal, Decimal, bool> getReturnDetails()
        {
            String? rentalId = rentalsDataView.CurrentRow.Cells["rental_id"].Value.ToString();
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
            String? expectedDropoffLocation = rentalsDataView.CurrentRow.Cells["Expected dropoff location"].Value.ToString();
            String? tempDate = rentalsDataView.CurrentRow.Cells["Expected drop off date"].Value.ToString();
            String? amountPaid = rentalsDataView.CurrentRow.Cells["Amount paid"].Value.ToString();

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
            String? name = rentalsDataView.CurrentRow.Cells["Name"].Value.ToString();
            String? vehicleRented = rentalsDataView.CurrentRow.Cells["Vehicle Rented"].Value.ToString();
            String? rentalId = rentalsDataView.CurrentRow.Cells["rental_id"].Value.ToString();

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
                else// shouldn't execute
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
            // do the return
            String query = @"UPDATE Rental
                            SET actual_dropoff_date = " + addQuotes(actualDropoffDate) + @", 
total_mileage_used = " + mileageUsedTextbox.Text + @", extra_charges = " + extraCharge + ", emp_id_return = " + empId + ", " +
"dropoff_branch_id = " + (branchCombobox.SelectedIndex + 1) +
@"WHERE rental_id = " + rentalId;
            int vehicleReturn = connection.executeNonQuery(query);
            // update branch of returned vehicle
            query = @"UPDATE Vehicle
SET branch_id = (SELECT dropoff_branch_id FROM Rental WHERE rental_id = " + rentalId + @")
WHERE vehicle_id IN (SELECT vehicle_id FROM Rental WHERE rental_id = " + rentalId + @");";
            int vehicleBranchUpdate = connection.executeNonQuery(query);
            return vehicleReturn == 1 && vehicleBranchUpdate == 1;
        }

        // if the customer id, phone number or plate number is changed, hide the screen below
        private void custIdOrPhoneOrPlateNumber_TextChanged(object sender, EventArgs e)
        {
            findRentalsPanel.Visible = false;
            this.Size = new Size(1288, 600);
            this.CenterToScreen();
        }

        private void onlyUnreturnedVehicles_CheckedChanged(object sender, EventArgs e)
        {
            findRentalsPanel.Visible = false;
            this.Size = new Size(1288, 600);
            this.CenterToScreen();
        }

        // if return date, return branch, mileage is changed, hide the screen
        private void returnDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.Size = new(1288, 830);
            this.CenterToScreen();
        }

        private void branchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Size = new(1288, 830);
            this.CenterToScreen();
        }

        private void viewFullDetails_Click(object sender, EventArgs e)
        {
            if (rentalsDataView.SelectedRows.Count == 0)
            {// no vehicle has been selected
                selectAVehicleLabel.Visible = true;
                return;
            }
        }

        private void customerRentalsDataGripView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectAVehicleLabel.Visible = false;
        }

        private void rentalsDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // disable selecting the first vehicle
            rentalsDataView.ClearSelection();
        }
    }
}
