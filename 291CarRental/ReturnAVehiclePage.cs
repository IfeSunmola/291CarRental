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

        private String currentRentalId;
        //private DateTime startDateOfBooking;
        //private DateTime expectedDropoffDate;
        //private int totalMileageUsed;
        //private Decimal initialAmountPaid;
        //private Decimal extraCharges;
        

        public ReturnAVehiclePage(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.connection = connection;
            this.empId = empId;
            this.Size = new Size(1288, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            onlyUnreturnedVehicles.Checked = true;

            findByCombobox.Items.Add("CUSTOMER ID");
            findByCombobox.Items.Add("PHONE NUMBER");
            findByCombobox.Items.Add("PLATE NUMBER");
            findByCombobox.SelectedIndex = 0;
            findByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            // this would be changed so if it shows somewhere along the program, it wasn't changed properly
            this.currentRentalId = "ERROR IN ReturnAVehiclePage constructor";
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
                this.Size = new Size(1288, 500);
                this.CenterToScreen();
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
        }

        private void fillBranchCombobox()
        {
            String query = @"
SELECT branch_name FROM Branch;
SELECT Employee.branch_id
FROM Employee, Branch
WHERE Employee.branch_id = Branch.branch_id
AND emp_id = " +empId + @";";
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


        private void viewFullDetails_Click(object sender, EventArgs e)
        {
            if (rentalsDataView.SelectedRows.Count == 0)
            {// no vehicle has been selected
                selectAVehicleLabel.Visible = true;
                return;
            }
            String query = @"
SELECT
	(SELECT last_name + ' ' + first_name + ' (' + CAST (customer_id AS VARCHAR) + ')'
		FROM Customer WHERE customer_id = Rental.customer_id) AS [customer_name],
	[start_date],
	expected_dropoff_date,
	(SELECT ISNULL (actual_dropoff_date, '')) AS [actual_dropoff_date],
	(SELECT ISNULL (total_mileage_used, -1)) AS [total_mileage_used],
	initial_amount_paid,
	(SELECT ISNULL(extra_charges, -1)) AS [extra_charges], 
	(SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name + ' (' + CAST (emp_id AS VARCHAR) + ')'
		FROM Employee WHERE emp_id = emp_id_booking) AS [emp_who_booked],
	(SELECT ISNULL ((SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name + ' (' + CAST (emp_id AS VARCHAR) + ')'
		FROM Employee WHERE emp_id = emp_id_return), 'N/A')) AS [emp_who_returned],
	(SELECT branch_name + ' (' + CAST (branch_id AS VARCHAR) + ')' 
		FROM Branch WHERE branch_id = pickup_branch_id) AS [pickup_branch],
	(SELECT ISNULL((SELECT branch_name + ' (' + CAST (branch_id AS VARCHAR) + ')' 
		FROM Branch WHERE branch_id = dropoff_branch_id), 'N/A')) AS [dropoff_branch],

	(SELECT vehicle_class 
		FROM Vehicle_Class WHERE vehicle_class_id = vehicle_class_requested) AS [class_requested], 
	(SELECT CAST ([year] AS VARCHAR) + ' ' + brand + ' ' + model + ' (' + 
			(SELECT vehicle_class FROM Vehicle_Class WHERE Vehicle.vehicle_class_id = Vehicle_Class.vehicle_class_id) + ')'
		FROM Vehicle WHERE Vehicle.vehicle_id = Rental.vehicle_id) AS [vehicle_gotten]
FROM Rental
WHERE rental_id = " + currentRentalId + ";";

            String customerName = "";
            String startDate = "";
            String expectedDropoffDate = "";
            String? actualDropoffDate = "";
            int totalMileageUsed = 0;
            Decimal initialAmountPaid = 0.00m;
            Decimal extraCharges = 0.00m;
            String empBooked = "";
            String empReturned = "";
            String pickupBranch = "";
            String dropOffBranch = "";
            String classRequested = "";
            String vehicleGotten = "";

            SqlDataReader reader = connection.executeReader(query);
            if (reader.Read())
            {
                customerName = reader.GetString("customer_name");
                startDate = reader.GetDateTime("start_date").ToString("D");
                expectedDropoffDate = reader.GetDateTime("expected_dropoff_date").ToString("D");
                actualDropoffDate = reader.GetDateTime("actual_dropoff_date").ToString("D");
                totalMileageUsed = reader.GetInt32("total_mileage_used");
                initialAmountPaid = reader.GetDecimal("initial_amount_paid");
                extraCharges = reader.GetDecimal("extra_charges");
                empBooked = reader.GetString("emp_who_booked");
                empReturned = reader.GetString("emp_who_returned");
                pickupBranch = reader.GetString("pickup_branch");
                dropOffBranch = reader.GetString("dropoff_branch");
                classRequested = reader.GetString("class_requested");
                vehicleGotten = reader.GetString("vehicle_gotten");
            }
            String fullDetails = "Customer Name: " + customerName +
                "\nBooking start date: " + startDate +
                "\nExpected drop off date: " + expectedDropoffDate +
                "\nActual Drop off date: " + (String.Equals(actualDropoffDate, "January 1, 1900") ? "N/A" : actualDropoffDate) + 
                "\nTotal mileage used: " + (totalMileageUsed == -1 ? "N/A" : totalMileageUsed) +
                "\nInitial amount paid: " + initialAmountPaid +
                "\nExtra charges: " + (Decimal.Equals(extraCharges, -1.00m) ? "N/A" : extraCharges) +
                "\nBooking Employee: " + empBooked +
                "\nReturning Employee: " + empReturned +
                "\nPickup branch: " + pickupBranch +
                "\nDropoff branch: " + dropOffBranch +
                "\nClass Requested: " + classRequested + 
                "\nVehicle Rented: " + vehicleGotten;

            MessageBox.Show(fullDetails,"FULL RENTAL DETAILS");
        }

        private void rentalsDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            rentalsDataView.ClearSelection();
        }

        private void rentalsDataView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectAVehicleLabel.Visible = false;
            currentRentalId = rentalsDataView.CurrentRow.Cells["rental_id"].Value.ToString().ToUpper();
            
        }
    }
}
