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
    public partial class ReturnAVehiclePage : Form
    {
        private EmployeeLandingPage previousPage;
        private DbConnection connection;
        private String empId;

        // for current rental that is selected, will be updated in rentalsDataView_CellMouseClick
        private String rentalId = "";
        private int customerId = 0;
        private String customerName = "";
        private DateTime startDate;
        private DateTime expectedDropoffDate;
        private DateTime actualDropoffDate;
        private int totalMileageUsed = -1;
        private Decimal initialAmountPaid = -1.0m;
        private Decimal lateFee = -1.0m;
        private Decimal differentBranchFee = -1.0m;
        private String bookingEmployee = "";
        private String returnEmployee = "";
        private String pickupBranch_expectedDropoffLocation = "";
        private String dropoffBranch = "";
        private String classRequested = "";
        private String classGotten = "";
        private String vehicleRented = "";


        public ReturnAVehiclePage(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.connection = connection;
            this.empId = empId;

            startingSize();

            onlyUnreturnedVehicles.Checked = true;

            findByCombobox.Items.Add("CUSTOMER ID");
            findByCombobox.Items.Add("PHONE NUMBER");
            findByCombobox.Items.Add("PLATE NUMBER");
            findByCombobox.SelectedIndex = 0;
            findByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            returnDateTimePicker.Value = DateTime.Now;
            returnDateTimePicker.Enabled = true;
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
            String query = @"
SELECT 
    rental_id,
    (SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name FROM Customer WHERE customer_id = Rental.customer_id) [Name],
	[start_date] [Booking start date],
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
                else if (!Regex.IsMatch(searchInfoTextbox.Text, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
                {
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
                query += "CAST (area_code + phone_number AS BIGINT) = " + idOrPhoneNumOrPlateNum;
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
                // load data into the DataGripView
                rentalsDataView.DataSource = getCustomerRentals();
                //disable sorting the columns
                foreach (DataGridViewColumn dataGridViewColumn in rentalsDataView.Columns)
                {
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                rentalsDataView.Columns["rental_id"].Visible = false;
                if (rentalsDataView.CurrentCell != null)
                {
                    rentalsDataView.CurrentCell.Selected = false;
                }
                findRentalsPanel.Show();
                findAllRentalsSize();
            }
        }

        private void startAReturnButton_Click(object sender, EventArgs e)
        {
            if (rentalsDataView.SelectedRows.Count == 0)
            {// no vehicle has been selected
                selectAVehicleLabel.Text = "SELECT A VEHICLE";
                selectAVehicleLabel.Visible = true;
                return;
            }
            if (totalMileageUsed > -1)
            {
                selectAVehicleLabel.Text = "THAT VEHICLE HAS BEEN RETURNED";
                selectAVehicleLabel.Visible = true;
                return;
            }

            branchCombobox.Items.Clear();
            fillBranchCombobox();

            returnLabelText.Text = "RETURNING " + vehicleRented.ToUpper() + " FOR " + customerName.ToUpper();
            startAReturnSize();
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
            }
        }

        private Tuple<Decimal, Decimal, bool> getFees_goldStatus()
        {
            String? rentalId = rentalsDataView.CurrentRow.Cells["rental_id"].Value.ToString();
            String query = @"
SELECT change_branch_fee, late_fee
FROM Vehicle_Class                
WHERE vehicle_class_id in (SELECT vehicle_class_requested FROM Rental WHERE rental_id = " + rentalId + @");
SELECT membership_type 
FROM Customer
WHERE customer_id in (SELECT customer_id FROM Rental WHERE rental_id =  " + rentalId + @") ";
            SqlDataReader reader = connection.executeReader(query);
            Decimal changeBranchFee = 0.00m, lateFee = 0.00m;
            bool isGoldMember = false;
            if (reader.Read())
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
            if ((int)mileageUsedTextbox.Value <= 0)
            {
                mileageErrorLabel.Text = "MILEAGE SHOULD BE GREATER THAN 0";
                mileageErrorLabel.Visible = true;
                return;
            }

            Decimal changeBranchFee = 0.00m;
            Decimal lateFee = 0.00m;
            String actualDropoffLocation = (String)branchCombobox.SelectedItem;

            if (!String.Equals(actualDropoffLocation, pickupBranch_expectedDropoffLocation, StringComparison.OrdinalIgnoreCase))
            {// returning to the different location, might need to pay a fee
                if (getFees_goldStatus().Item3)
                {// gold member, no fee needed
                    feeWaiverLabel.Text = "DIFFERENT BRANCH RETURN FEE OF " + getFees_goldStatus().Item1.ToString("C") +
                        " HAS BEEN  WAIVED FOR THIS GOLD CUSTOMER HEHEHE";
                    feeWaiverLabel.Visible = true;
                }
                else
                {// not gold, paying a fee
                    feeWaiverLabel.Visible = false;
                    changeBranchFee = getFees_goldStatus().Item1;
                }
            }
            else
            {// not returning to a different location
                feeWaiverLabel.Visible = false;
            }

            if (expectedDropoffDate.AddDays(1) <= returnDateTimePicker.Value)
            {// drop off is late
                lateFee = getFees_goldStatus().Item2;
                MessageBox.Show("Late Returns");
            }

            Decimal amountDueNow = (lateFee + changeBranchFee);
            amountPaidLabel.Text = initialAmountPaid.ToString("C");
            lateFeeLabel.Text = lateFee.ToString("C");
            differentBranchFeeLabel.Text = changeBranchFee.ToString("C");

            amountDueNowLabel.Text = amountDueNow.ToString("C");
            if (amountDueNow == 0)
            {
                amountDueNowLabel.BackColor = Color.Green;
            }
            else if (amountDueNow > 0)
            {
                amountDueNowLabel.BackColor = Color.Red;
            }
            else
            {
                amountDueNowLabel.BackColor = Color.Yellow;
                amountDueNowLabel.Text = "ERROR in calculateAmountDue_Click";
            }

            finishReturnPanel.Visible = true;
            calculateAmountDueSize();
        }

        private void fillBranchCombobox()
        {
            String query = @"
SELECT branch_name FROM Branch;
SELECT Employee.branch_id
FROM Employee, Branch
WHERE Employee.branch_id = Branch.branch_id
AND emp_id = " + empId + @";";
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
            DialogResult confirmReturn = MessageBox.Show(
("Confirm returning of " + vehicleRented + " FOR " + customerName).ToUpper(),
"CONFIRM RETURN VEHICLE",
MessageBoxButtons.YesNo);

            if (confirmReturn == DialogResult.Yes)
            {
                if (returnSuccess(lateFeeLabel.Text, differentBranchFeeLabel.Text))
                {
                    MessageBox.Show("VEHICLE RETURNED SUCCESSFULLY");
                    //this.Close();
                    //previousPage.Visible = true;
                    this.Hide();
                    new ReturnAVehiclePage(previousPage, empId, connection).ShowDialog();
                    this.Close();
                }
                else// shouldn't execute
                {
                    MessageBox.Show("DATABASE ERROR OCCURED AT StartAReturnPage");
                }

            }
        }

        private bool returnSuccess(String calculatedLateFee, String calculatedDifferentBranchFee)
        {
            String actualDropoffDate = returnDateTimePicker.Value.Date.ToString("d");
            // do the return
            String query = @"
UPDATE Rental
SET actual_dropoff_date = " + addQuotes(actualDropoffDate) + @", 
    total_mileage_used = " + mileageUsedTextbox.Text + @", 
    late_fee = " + lateFee + @", 
    different_branch_fee = " + calculatedDifferentBranchFee + @", 
    emp_id_return = " + empId + @",
    dropoff_branch_id = " + (branchCombobox.SelectedIndex + 1) + @"
WHERE rental_id = " + rentalId;

            int vehicleReturn = connection.executeNonQuery(query);
            // update branch of returned vehicle
            query = @"
UPDATE Vehicle
SET branch_id = (SELECT dropoff_branch_id FROM Rental WHERE rental_id = " + rentalId + @"),
    current_mileage = ( (SELECT total_mileage_used FROM Rental WHERE rental_id =  " + rentalId + @") + current_mileage)
    
WHERE vehicle_id IN (SELECT vehicle_id FROM Rental WHERE rental_id = " + rentalId + @");";

            int vehicleBranchUpdate = connection.executeNonQuery(query);
            return vehicleReturn == 1 && vehicleBranchUpdate == 1;
        }


        private void viewFullDetails_Click(object sender, EventArgs e)
        {
            if (rentalsDataView.SelectedRows.Count == 0)
            {// no vehicle has been selected
                selectAVehicleLabel.Visible = true;
                return;
            }
            MessageBox.Show("Customer Name: " + customerName + " (" + customerId + ")" +
             "\nBooking start date: " + startDate.ToString("D") +
             "\nExpected drop off date: " + expectedDropoffDate.ToString("D") +
             "\nActual drop off date: " + (actualDropoffDate == DateTime.MinValue ? "N/A" : actualDropoffDate.ToString("D")) +
             "\nTotal mileage used: " + (totalMileageUsed == -1 ? "N/A" : totalMileageUsed) +
             "\nInitial amount paid: " + initialAmountPaid.ToString("C") +
             "\nLate fee: " + (Decimal.Equals(lateFee, -1.00m) ? "N/A" : lateFee.ToString("C")) +
             "\nDifferent branch fee: " + (Decimal.Equals(differentBranchFee, -1.00m) ? "N/A" : differentBranchFee.ToString("C")) +
             "\nBooking employee: " + bookingEmployee +
             "\nReturning employee: " + returnEmployee +
             "\nPickup branch/Expected dropoff branch: " + pickupBranch_expectedDropoffLocation +
             "\nActual dropoff branch: " + dropoffBranch +
             "\nClass requested: " + classRequested +
             "\nVehicle rented: " + vehicleRented + " (" + classGotten + ")",

             "FULL RENTAL DETAILS");
        }

        private void rentalsDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            rentalsDataView.ClearSelection();
        }

        private void rentalsDataView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectAVehicleLabel.Visible = false;
            if (rentalsDataView.Rows.Count <= 0)
            {// if cell mouse click happens when the data grid view is empty
                return;
            }
            rentalId = rentalsDataView.CurrentRow.Cells["rental_id"].Value.ToString().ToUpper();
            String query = @"
SELECT
	(SELECT customer_id FROM Customer WHERE customer_id = Rental.customer_id) AS [customer_id],
	(SELECT last_name + ' ' + first_name
		FROM Customer WHERE customer_id = Rental.customer_id) AS [customer_name],
	[start_date],
	expected_dropoff_date,
    -- using 0001-01-01 because c# DateTime.MinValue returns it
	(SELECT ISNULL (actual_dropoff_date, '0001-01-01')) AS [actual_dropoff_date], 
	(SELECT ISNULL (total_mileage_used, -1)) AS [total_mileage_used],
	initial_amount_paid,
    (SELECT ISNULL(late_fee, -1)) AS [late_fee], 
    (SELECT ISNULL(different_branch_fee, -1)) AS [different_branch_fee], 
	(SELECT last_name + ', ' + first_name + ' (' + CAST (emp_id AS VARCHAR) + ')'
		FROM Employee WHERE emp_id = emp_id_booking) AS [emp_who_booked],
	(SELECT ISNULL ((SELECT last_name + ' ' + first_name + ' (' + CAST (emp_id AS VARCHAR) + ')'
		FROM Employee WHERE emp_id = emp_id_return), 'N/A')) AS [emp_who_returned],
	(SELECT branch_name 
		FROM Branch WHERE branch_id = pickup_branch_id) AS [pickup_branch],
	(SELECT ISNULL((SELECT branch_name 
		FROM Branch WHERE branch_id = dropoff_branch_id), 'N/A')) AS [dropoff_branch],
	(SELECT vehicle_class 
		FROM Vehicle_Class WHERE vehicle_class_id = vehicle_class_requested) AS [class_requested], 
	(SELECT vehicle_class		
		FROM Vehicle, Vehicle_Class
		WHERE Vehicle.vehicle_id = Rental.vehicle_id 
			AND Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id) AS [class_gotten],
	(SELECT CAST ([year] AS VARCHAR) + ' ' + brand + ' ' + model
		FROM Vehicle WHERE Vehicle.vehicle_id = Rental.vehicle_id) AS [vehicle_gotten]
FROM Rental
WHERE rental_id = " + rentalId + ";";

            SqlDataReader reader = connection.executeReader(query);
            if (reader.Read())
            {
                customerId = reader.GetInt32("customer_id");
                customerName = reader.GetString("customer_name");
                startDate = reader.GetDateTime("start_date");
                expectedDropoffDate = reader.GetDateTime("expected_dropoff_date");
                actualDropoffDate = reader.GetDateTime("actual_dropoff_date");
                totalMileageUsed = reader.GetInt32("total_mileage_used");
                initialAmountPaid = reader.GetDecimal("initial_amount_paid");
                lateFee = reader.GetDecimal("late_fee");
                differentBranchFee = reader.GetDecimal("different_branch_fee");
                bookingEmployee = reader.GetString("emp_who_booked");
                returnEmployee = reader.GetString("emp_who_returned");
                pickupBranch_expectedDropoffLocation = reader.GetString("pickup_branch");
                dropoffBranch = reader.GetString("dropoff_branch");
                classRequested = reader.GetString("class_requested");
                classGotten = reader.GetString("class_gotten");
                vehicleRented = reader.GetString("vehicle_gotten");
            }
            reader.Close();
            returnLabelText.Text = "RETURNING " + vehicleRented.ToUpper() + " FOR " + customerName.ToUpper();



            if (totalMileageUsed > -1)
            {
                selectAVehicleLabel.Text = "THAT VEHICLE HAS BEEN RETURNED";
                selectAVehicleLabel.Visible = true;
                findAllRentalsSize();
                return;
            }
            // showing the actual return part
            branchCombobox.Items.Clear();
            fillBranchCombobox();
            startAReturnSize();
        }

        private void mileageUsedTextbox_ValueChanged(object sender, EventArgs e)
        {
            mileageErrorLabel.Visible = false;
        }

        private void startingSize()
        {
            this.Size = new Size(1288, 300);
            this.CenterToScreen();
        }

        private void findAllRentalsSize()
        {
            this.Size = new Size(1288, 600);
            this.CenterToScreen();
        }

        private void startAReturnSize()
        {
            this.Size = new Size(1288, 850);
            this.CenterToScreen();
        }

        private void calculateAmountDueSize()
        {
            this.Size = new Size(1288, 1148);
            this.CenterToScreen();
        }

        private void searchInfoChanged(object sender, EventArgs e)
        {
            startingSize();
            findRentalsPanel.Visible = false;
        }

        private void branchCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            startAReturnSize();
        }
    }

}
