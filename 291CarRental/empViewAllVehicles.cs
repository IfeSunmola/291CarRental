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

//1194, 1082
namespace _291CarRental
{
    public partial class EmpViewAllVehicles : Form
    {
        private EmployeeLandingPage previousPage;
        private String empId;
        private String currentCustName;

        private DbConnection connection;

        public EmpViewAllVehicles(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            this.previousPage = previousPage;
            this.empId = empId;
            this.currentCustName = "";

            this.Size = new Size(1194, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            vehicleDataGridView.Columns.Clear();

            fromDatePicker.Value = DateTime.Now.AddDays(1);
            toDatePicker.Value = DateTime.Now.AddDays(2);
            fillComboBoxes();

            findByCombobox.Items.Add("NOT APPLICABLE");
            findByCombobox.Items.Add("CUSTOMER ID");
            findByCombobox.SelectedIndex = 1;
            findByCombobox.Items.Add("PHONE NUMBER");


            findByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            customerDetailsPanel.Visible = false;
            
        }

        private DataTable getAvailableVehicleList(int vehicleClassId)
        {
            int branchId = (int)branchComboBox.SelectedIndex;

            String from = fromDatePicker.Value.Date.ToString("d");
            String to = toDatePicker.Value.Date.ToString("d");

            DataTable cars = new DataTable();
            String query = @"
SELECT vehicle_id, branch_name as 'Location', vehicle_class AS 'Class', [year] AS 'Year', brand AS 'Brand', model AS 'Model'
FROM Vehicle, Branch, Vehicle_Class 
WHERE Vehicle.branch_id = Branch.branch_id
AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id
AND vehicle_id IN 
(	SELECT vehicle_id
	FROM Vehicle 
	EXCEPT 
	(
		(SELECT [vehicle_id]
		FROM Rental
		WHERE [start_date] >= " + addQuotes(from) + @" and expected_dropoff_date <= " + addQuotes(to) + @")
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE  " + addQuotes(from) + @" >= [start_date] and " + addQuotes(from) + @" <= expected_dropoff_date)
		)
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE expected_dropoff_date >= " + addQuotes(to) + @" and [start_date] <= " + addQuotes(to) + @")
		)
	) 
)
";

            if (branchId != 0)// a specific branch was selected, add filters
            {
                query += "\nAND Vehicle.branch_id = " + branchId + "";
            }
            if (vehicleClassId != 0)// a specific class was selected, add filters
            {
                query += "\nAND Vehicle.vehicle_class_id = " + vehicleClassId + ";";
            }
            cars.Load(connection.executeReader(query));
            return cars;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void fillVehicleDataView(int vehicleClassId)
        {
            vehicleDataGridView.DataSource = getAvailableVehicleList(vehicleClassId);
            vehicleDataGridView.Columns["vehicle_id"].Visible = false;

            foreach (DataGridViewColumn dataGridViewColumn in vehicleDataGridView.Columns)
            {//disable sorting the columns
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            showVehicleDataGripViewPanel.Visible = true;
            if (vehicleDataGridView.CurrentCell != null)
            {
                vehicleDataGridView.CurrentCell.Selected = false;
            }
            String fromToDate = fromDatePicker.Value.Date.ToString("D").ToUpper() + " TO " + toDatePicker.Value.Date.ToString("D").ToUpper();
            showingVehiclesLabel.Text = "SHOWING AVAILABLE VEHICLES FROM " + fromToDate;
        }

        private void findAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            String noVehiclesMessage = "THERE ARE NO " + vehicleClassCombobox.SelectedItem + " VEHICLES AVAILABLE ";
            noVehiclesMessage += "IN " + branchComboBox.SelectedItem;

            if (findByCombobox.SelectedIndex == 0 && validateSearchDetails())
            {// not applicable was selected and the search filters are good. Employee is only viewing
                //customerDetailsPanel.Visible = false;
                errorMessageLabel.Visible = false;
                fillVehicleDataView((int)vehicleClassCombobox.SelectedIndex + 1);
                if (vehicleDataGridView.Rows.Count > 0)
                {// there are vehicles available
                    rentVehicleButton.Visible = false;
                    enlarge(990); // not showing rent this vehicle button
                }
                else
                {
                    MessageBox.Show(noVehiclesMessage);
                }
                
            }
            else if (findByCombobox.SelectedIndex > 0 &&  validateSearchDetails() && validateCustomerInfo())
            {// id/phone number was selected, filters and customer details are good. Customer is renting
                errorMessageLabel.Visible = false;
                getCustomerDetails();
                customerDetailsPanel.Visible = true;
                rentVehicleButton.Visible = true;
                fillVehicleDataView((int)vehicleClassCombobox.SelectedIndex + 1);
                if (vehicleDataGridView.Rows.Count > 0)
                {// there are vehicles available
                    enlarge(1043); 
                }
                else
                {
                    if (String.Equals("YES", goldMemberLabel.Text))
                    {// a gold member
                        DialogResult confirmVehicleUpgrade = MessageBox.Show(
                            noVehiclesMessage + ".\n" + 
                            "WOULD THE GOLD MEMBER LIKE A FREE UPGRADE TO THE NEXT AVAILABLE CLASS?",
                            "CONFIRM UPGRADE",
                            MessageBoxButtons.YesNo);
                        if (confirmVehicleUpgrade == DialogResult.Yes)
                        {
                            int nextVehicleClassId = (int)vehicleClassCombobox.SelectedIndex + 2;
                            if (nextVehicleClassId > vehicleClassCombobox.Items.Count)
                            {// customer requested the highest vehicle class, there's no next
                                MessageBox.Show(vehicleClassCombobox.SelectedItem + " CLASS IS THE HIGHEST CLASS WE CURRENTLY HAVE.");
                            }
                            else
                            {
                                for (int i = nextVehicleClassId; i <= vehicleClassCombobox.Items.Count; i++)
                                {
                                    fillVehicleDataView(i);
                                    if (vehicleDataGridView.Rows.Count > 0)
                                    {
                                        enlarge(1043);
                                        break;
                                    }
                                }
                                if (vehicleDataGridView.Rows.Count <= 0)
                                {
                                    String errorMessage = "WE CURRENTLY DON'T HAVE ANY AVAILABLE VEHICLES IN THIS BRANCH. CHECK BACK LATER";
                                    MessageBox.Show(errorMessage);
                                }
                            }
                        }
                    }
                    else
                    {// not gold member
                        MessageBox.Show(noVehiclesMessage);
                    }
                }
                
            }
        }

        private bool validateCustomerInfo()
        {
            bool result = false;
            if (findByCombobox.SelectedIndex == 1)
            {// customer id validations
                if (String.IsNullOrEmpty(customerInfoTextbox.Text))
                {// empty text box
                    errorMessageLabel.Text = "CUSTOMER ID REQUIRED";
                }
                else if (!idOrPhoneNumberInDb("ID", customerInfoTextbox.Text))
                {
                    errorMessageLabel.Text = "CUSTOMER ID NOT FOUND";
                }
                else
                {
                    result = true;
                }
            }
            else if (findByCombobox.SelectedIndex == 2)
            {// phone number validations
                if (String.IsNullOrEmpty(customerInfoTextbox.Text))
                {// empty text box
                    errorMessageLabel.Text = "PHONE NUMBER REQUIRED";
                }
                else if (customerInfoTextbox.Text.Length != 10)
                {
                    errorMessageLabel.Text = "PHONE NUMBER MUST BE 10 DIGITS";
                }
                else if (!idOrPhoneNumberInDb("NUMBER", customerInfoTextbox.Text))
                {
                    errorMessageLabel.Text = "PHONE NUMBER NOT FOUND";
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        private void getCustomerDetails()
        {
            if (findByCombobox.SelectedIndex == 0)
            {// NOT APPLICABLE WAS SELECTED
                return;
            }
            String idOrPhoneNumber = customerInfoTextbox.Text;
            String query = @"SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name AS name, membership_type, gold_membership_date
                            FROM Customer";

            if (findByCombobox.SelectedIndex == 1)
            {// CUSTOMER ID WAS SELECTED
                query += "\nWHERE customer_id = " + idOrPhoneNumber;
            }
            else if (findByCombobox.SelectedIndex == 2)
            {// PHONE NUMBER WAS SELECTED
                query += "\nWHERE CAST(area_code + phone_number AS BIGINT) = " + idOrPhoneNumber;
            }

            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                currentCustName = reader.GetString(0);
                customerNameLabel.Text = currentCustName;
                if (reader.GetString(1).Equals("Gold"))
                {// a gold customer
                    DateTime goldMemberDate = reader.GetDateTime(2);
                    DateTime goldMemberExpiryDate = goldMemberDate.AddYears(1);
                    if (goldMemberExpiryDate <= DateTime.Now)
                    {// membership has expired for gold customer
                        goldMemberLabel.Text = "NO";

                        expiresLabel.Text = "EXPIRED:";
                        expiryDate.Text = goldMemberExpiryDate.ToString("yyyy-MM-dd");

                        expiresLabel.Visible = true;
                        expiryDate.Visible = true;

                        expiresLabel.ForeColor = Color.Red;
                        expiryDate.ForeColor = Color.Red;
                    }
                    else
                    {// membership has NOT EXPIRED for gold customer
                        expiresLabel.Text = "EXPIRES:";
                        goldMemberLabel.Text = "YES";
                        expiryDate.Text = reader.GetDateTime(2).AddYears(1).ToString("yyyy-MM-dd");

                        expiresLabel.Visible = true;
                        expiryDate.Visible = true;

                        expiresLabel.ForeColor = Color.Green;
                        expiryDate.ForeColor = Color.Green;
                    }
                }
                else
                {// not a gold customer/never been a gold customer
                    goldMemberLabel.Text = "NO";
                    expiresLabel.Visible = false;
                    expiryDate.Visible = false;
                }
            }
        }

        private bool validateSearchDetails()
        {
            bool result = false;
            String vehicleClassSelected = (String)vehicleClassCombobox.SelectedItem;
            String branchSelected = (String)branchComboBox.SelectedItem;
            errorMessageLabel.Visible = true;
            if (fromDatePicker.Value.Date <= DateTime.Now.Date)
            {
                errorMessageLabel.Text = "Vehicles must be booked one day before".ToUpper();
            }
            else if (fromDatePicker.Value.Date >= toDatePicker.Value.Date)
            {
                errorMessageLabel.Text = "FROM DATE HAS TO BE BEFORE TO DATE";
            }
            else if (String.Equals(vehicleClassSelected, "SELECT ONE"))
            {
                errorMessageLabel.Text = "SELECT A VEHICLE CLASS";
            }
            else if (String.IsNullOrEmpty(branchSelected))
            {// not really needed but it is what it is
                errorMessageLabel.Text = "SELECT A BRANCH";
            }
            else
            {
                result = true;
            }
            return result;
        }

        private bool idOrPhoneNumberInDb(String flag, String idOrPhoneNumber)
        {
            String query = "SELECT customer_id FROM Customer WHERE ";
            if (String.Equals(flag, "ID"))
            {// find id
                query += "customer_id  = " + idOrPhoneNumber;
            }
            else if (String.Equals(flag, "NUMBER"))
            {// find phone number
                query += "CAST (area_code + phone_number AS BIGINT) = " + idOrPhoneNumber;
            }
            return connection.executeScalar(query) != null;// not null: data was found
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        private void rentThisVehicleButton_Click(object sender, EventArgs e)
        {
            //if (vehicleDataGridView.CurrentCell == null)
            if (vehicleDataGridView.SelectedRows.Count == 0)
            {// no vehicle has been selected
                selectAVehicleLabel.Visible = true;
                return;
            }
            Int16 year = (Int16)vehicleDataGridView.CurrentRow.Cells["year"].Value;
            String brand = (String)vehicleDataGridView.CurrentRow.Cells["brand"].Value;
            String model = (String)vehicleDataGridView.CurrentRow.Cells["model"].Value;
            String from = fromDatePicker.Value.Date.ToString("D");
            String to = toDatePicker.Value.Date.ToString("D");

            DialogResult confirmRenting = MessageBox.Show(
              "Confirm renting of " + year + " " + brand + " " + model + " for " + currentCustName +
              "\nAmount Due now: " + estimatedCostLabel.Text +
              "\nPick up and drop off location: " + addressLabel.Text +
              "\nPickup date: " + from +
              "\nExpected dropoff date: " + to,
              "CONFIRM RENTING VEHICLE",
              MessageBoxButtons.YesNo);

            if (confirmRenting == DialogResult.Yes)
            {
                doRentInDb();
                // upgrading to gold if eligible
                String query = @"SELECT count(*)
FROM Rental, Customer
WHERE Rental.customer_id = Customer.customer_id AND Rental.customer_id = " + customerInfoTextbox.Text + @" AND (SELECT YEAR(start_date_of_booking)) = YEAR(GETDATE())
GROUP BY Rental.customer_id;";

                if ((Convert.ToInt16(connection.executeScalar(query)) == 3))
                { // they have 3 rentals, upgrade to gold
                    query = @"UPDATE Customer
SET membership_type = 'Gold', gold_membership_date = CAST(GETDATE() AS DATE)
WHERE customer_id = " + customerInfoTextbox.Text + ";";
                    connection.executeNonQuery(query);
                    MessageBox.Show(customerNameLabel.Text + " is now a gold boy hehe");
                }
            }
        }

        private void doRentInDb()
        {
            String from = fromDatePicker.Value.Date.ToString("d");
            String to = toDatePicker.Value.Date.ToString("d");
            String? vehicleId = vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value.ToString();
            String? tempBranchName = vehicleDataGridView.CurrentRow.Cells["Location"].Value.ToString().ToUpper();
            String branchId = branchComboBox.Items.IndexOf(tempBranchName).ToString();
            String classRequested = (vehicleClassCombobox.SelectedIndex + 1).ToString();
            
            String query = "INSERT INTO Rental" +
                "\n(start_date_of_booking, expected_dropoff_date, initial_amount_paid, emp_id_booking, " +
                "pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)" +
                "\nVALUES" +
                "\n( " + addQuotes(from) + ", " + addQuotes(to) + ", " + estimatedCostLabel.Text + ", " +
                empId + ", " + branchId + ", " + vehicleId + ", " + classRequested +
                ", " + customerInfoTextbox.Text + ");";



            int rowsAffected = connection.executeNonQuery(query);
            if (rowsAffected > 0)
            {
                MessageBox.Show("VEHICLE RENTED SUCCESSFULLY.");
            }
            else
            {
                MessageBox.Show("DATABASE ERROR IN empViewAllVehicles: doRentInDb");
            }

        }

        private void fillComboBoxes()
        {
            // will be removed in vehicleClassCombobox_DropDownClosed when the user selects an option
            vehicleClassCombobox.Items.Add("SELECT ONE");
            vehicleClassCombobox.SelectedIndex = 0;

            branchComboBox.Items.Add("ALL BRANCHES");

            String query = "SELECT vehicle_class FROM Vehicle_Class;" +
                "\nSELECT branch_name FROM Branch;" +
                "\nSELECT Employee.branch_id" +
                "\nFROM Employee, Branch " +
                "\nWHERE Employee.branch_id = Branch.branch_id" +
                "\nAND emp_id = " + empId;
            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                vehicleClassCombobox.Items.Add(reader.GetString("vehicle_class").ToUpper());
            }
            reader.NextResult();
            while (reader.Read())
            {
                branchComboBox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            reader.NextResult();
            if (reader.Read())
            {
                branchComboBox.SelectedIndex = reader.GetInt32("branch_id");
            }

            vehicleClassCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            branchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private String getBranchAddress(int branchId)
        {
            //int branchId = (int)branchComboBox.SelectedIndex;// not adding +1 because of "ALL BRANCHES"
            if (branchId == 0)
            {// all branches selected, no address
                addressPanel.Visible = false;
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
                branchAddress = "DATABASE ERROR OCCURED IN EmployeeLandingPage";
            }

            return branchAddress;
        }

        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (branchComboBox.SelectedIndex == 0)
            {// all branches selected
                addressPanel.Visible = false;
                filtersValueChanged(sender, e);
                return;
            }
            addressLabel.Text = getBranchAddress((int)branchComboBox.SelectedIndex).ToUpper();
            addressPanel.Visible = true;
            filtersValueChanged(sender, e);
        }

        private void vehicleDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectAVehicleLabel.Visible = false;
            if (vehicleDataGridView.CurrentCell == null)
            {// exception without this
                return;
            }
            //int currentVehicleId = (int)vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value;
            //int vehicleClassClicked = (vehicleClassCombobox.Items.IndexOf(tempVehicleClass) + 1);
            String tempVehicleClass = vehicleDataGridView.CurrentRow.Cells["Class"].Value.ToString().ToUpper();
            int vehicleClassRequested= (vehicleClassCombobox.SelectedIndex + 1);

            
            int daysBetween = ((toDatePicker.Value.Day - fromDatePicker.Value.Day));
            Decimal dailyRate = getRates(vehicleClassRequested).Item1;
            Decimal weeklyRate = getRates(vehicleClassRequested).Item2;
            Decimal monthlyRate = getRates(vehicleClassRequested).Item3;

            estimatedCostLabel.Text = "$0.00";
            if (daysBetween <= 7)
            {
                estimatedCostLabel.Text = (daysBetween * dailyRate).ToString("C");
            }
            else if (daysBetween > 7 && daysBetween < 30)
            {
                Decimal weekly = (daysBetween / 7) * weeklyRate;
                Decimal daily = (daysBetween % 7) * dailyRate;
                estimatedCostLabel.Text = (weekly + daily).ToString("C");
            }
            else //if (daysBetween >= 30)
            {
                Decimal monthly = (daysBetween / 14) * monthlyRate;
                Decimal weekly = (daysBetween % 14) * weeklyRate;
                estimatedCostLabel.Text = (monthly + weekly).ToString("C");
            }
            
            amountOfDaysLabel.Text = daysBetween + " DAY";
            if (daysBetween > 1) {
                amountOfDaysLabel.Text += "S";
            }
        }

        private Tuple<Decimal, Decimal, Decimal> getRates(int currentVehicleId)
        {// change currentVehicleId to vehicleClassRequested
            String query = "SELECT daily_rate, weekly_rate, monthly_rate" +
                  "\nFROM Vehicle_Class, Vehicle " +
                  "\nWHERE vehicle.vehicle_id = " + currentVehicleId +
                  "\nAND Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id;";

            query = @"SELECT daily_rate, weekly_rate, monthly_rate
FROM Vehicle_Class
WHERE vehicle_class_id = " + currentVehicleId;

            Decimal dailyRate = 0.0m, weeklyRate = 0.0m, monthlyRate = 0.0m;
            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                if (reader.GetName(0).Equals("daily_rate"))
                {
                    dailyRate = reader.GetDecimal(0);
                }
                if (reader.GetName(1).Equals("weekly_rate"))
                {
                    weeklyRate = reader.GetDecimal(1);
                }
                if (reader.GetName(2).Equals("monthly_rate"))
                {
                    monthlyRate = reader.GetDecimal(2);
                }

            }

            return Tuple.Create(dailyRate, weeklyRate, monthlyRate);
        }

        private void findByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorMessageLabel.Visible = false;
            customerDetailsPanel.Visible = false;
            if (findByCombobox.SelectedIndex == 0)
            {// not applicable was selected, hide text box
                customerInfoPanel.Visible = false;
                filtersValueChanged(sender, e);
                return;
            }
            else if (findByCombobox.SelectedIndex == 1)
            {// customer id was selected
                customerInfoTextbox.MaxLength = 5;
            }
            else if (findByCombobox.SelectedIndex == 2)
            {// phone number was selected
                customerInfoTextbox.MaxLength = 10;
            }
            customerInfoTextbox.Clear();
            customerInfoPanel.Visible = true;
            findByLabel.Text = findByCombobox.SelectedItem.ToString();
            filtersValueChanged(sender, e);
        }

        // ignore anything that isn't numbers
        private void customerInfoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        // resize to filters screen when the employee changes either booking start date, end date
        // class requested, branch name, find by combo box and id/phone number textbox
        private void filtersValueChanged(object sender, EventArgs e)
        {
            reduce(450);
            customerDetailsPanel.Visible = false;
        }

        private void reduce(int newHeight)
        {
            while (this.Height >= newHeight)
            {
                this.Height -= 13;
                this.CenterToScreen();
                Application.DoEvents();
            }
        }

        private void enlarge(int newHeight)
        {
            while (this.Height <= newHeight)
            {
                this.Height += 50;
                this.CenterToScreen();
                Application.DoEvents();
            }
            estimatedCostLabel.Text = "";
            amountOfDaysLabel.Text = "";
        }

        private void vehicleClassCombobox_DropDownClosed(object sender, EventArgs e)
        {
            if (!String.Equals(vehicleClassCombobox.SelectedItem, "SELECT ONE") || vehicleClassCombobox.SelectedIndex == -1)
            {
                vehicleClassCombobox.Items.Remove("SELECT ONE");
            }
        }

        private void vehicleDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            vehicleDataGridView.ClearSelection();
        }
    }
}
