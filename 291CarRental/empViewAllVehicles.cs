﻿using System;
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
    /// <summary>
    /// Form/Class for when the employee is viewing vehicles. The employee  can view vehicles or rent for a customer
    /// </summary>
    public partial class EmpViewAllVehicles : Form
    {
        private EmployeeLandingPage previousPage;
        private String empId;// empId that's viewing or renting for a customer
        private String currentCustName;// the current customer that's renting. CHANGE THIS 

        private DbConnection connection;

        public EmpViewAllVehicles(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            this.previousPage = previousPage;
            this.empId = empId;
            this.currentCustName = "";

            this.Size = new Size(1194, 450);// starting size, will be changed accordingly
            vehicleDataGridView.Columns.Clear();// clear whatever is in the data grid view

            fromDatePicker.Value = DateTime.Now.AddDays(1);// set the default start date to 1 daya fter
            toDatePicker.Value = DateTime.Now.AddDays(2);
            fillComboBoxes();// fill the combo boxes: vehicle class, branches, find customer by

            customerDetailsPanel.Visible = false;// hide the panel that will show the customer information
            
        }

        /// <summary>
        /// This method gets the vehicles that are available and loads it into the data view
        /// </summary>
        /// <param name="vehicleClassId"></param>
        /// <returns>Returns a data table to be loaded into the data grid view</returns>
        private DataTable getAvailableVehicleList(int vehicleClassId)
        {
            int branchId = (int)branchComboBox.SelectedIndex;// get the current id for to use  filters

            String from = addQuotes(fromDatePicker.Value.Date.ToString("d"));
            String to = addQuotes(toDatePicker.Value.Date.ToString("d"));

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
		WHERE [start_date] >= " + from + @" and expected_dropoff_date <= " + to + @")
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE  " + from + @" >= [start_date] and " + from + @" <= expected_dropoff_date)
		)
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE expected_dropoff_date >= " + to + @" and [start_date] <= " + to + @")
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

        /// <summary>
        /// back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        /// <summary>
        /// This method uses the getAvailableVehicleList method to fill the data grid view and set its appropriate properties
        /// </summary>
        /// <param name="vehicleClassId"></param>
        private void fillVehicleDataView(int vehicleClassId)
        {
            vehicleDataGridView.DataSource = getAvailableVehicleList(vehicleClassId);// fill the data view
            vehicleDataGridView.Columns["vehicle_id"].Visible = false;// hide the vehicle id column, vehicle id will be used to get the prices

            foreach (DataGridViewColumn dataGridViewColumn in vehicleDataGridView.Columns)
            {//disable sorting the columns
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (vehicleDataGridView.CurrentCell != null) 
            {
                vehicleDataGridView.CurrentCell.Selected = false;
            }
            vehicleDataViewPanel.Visible = true;// show the panel containing the vehicles
            String fromToDate = fromDatePicker.Value.Date.ToString("D").ToUpper() + " TO " + toDatePicker.Value.Date.ToString("D").ToUpper();
            showingVehiclesLabel.Text = "SHOWING AVAILABLE VEHICLES FROM " + fromToDate;
        }

        /// <summary>
        /// on click method for when the findAvailableVehicle button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            String noVehiclesMessage = "THERE ARE NO " + vehicleClassCombobox.SelectedItem + " VEHICLES AVAILABLE ";
            noVehiclesMessage += "IN " + branchComboBox.SelectedItem;// message to display if there are no vehicles avaialble

            if (findByCombobox.SelectedIndex == 0 && validateSearchDetails())
            {// not applicable was selected and the search filters are good. Employee is only viewing
                errorMessageLabel.Visible = false;
                fillVehicleDataView((int)vehicleClassCombobox.SelectedIndex);// fill the data view with the vehicle class that's selected
                if (vehicleDataGridView.Rows.Count > 0)// data grid view is not empty
                {// there are vehicles available
                    rentVehicleButton.Visible = false;// employee is viewing vehicles so they shouldn't be  able to rent
                    this.Size = new Size(this.Width, 1043);// adjust size accordingly
                    this.CenterToScreen();
                }
                else
                {// no vehicles available
                    MessageBox.Show(noVehiclesMessage);
                }
            }
            else if (findByCombobox.SelectedIndex > 0 &&  validateSearchDetails() && validateCustomerInfo())
            {// id/phone number was selected, filters and customer details are good. Customer is renting
                errorMessageLabel.Visible = false;
                getCustomerDetails();
                customerDetailsPanel.Visible = true;// show customer name and gold status
                rentVehicleButton.Visible = true;// the rentVehicleButton is hidden when the employee is only viewing vehicles
                fillVehicleDataView((int)vehicleClassCombobox.SelectedIndex);// fill the data view with the vehicle class that's selected
                if (vehicleDataGridView.Rows.Count > 0)// data grid view is not empty
                {// there are vehicles available, adjust size to show vehicles
                    this.Size = new Size(this.Width, 1043);
                    this.CenterToScreen();
                }
                else
                {// vehicles are not available, check gold status
                    if (String.Equals("YES", goldMemberLabel.Text))
                    {// a gold member
                        DialogResult confirmVehicleUpgrade = MessageBox.Show(
                            noVehiclesMessage + ".\n" + 
                            "WOULD THE GOLD MEMBER LIKE A FREE UPGRADE TO THE NEXT AVAILABLE CLASS?",
                            "CONFIRM UPGRADE",
                            MessageBoxButtons.YesNo);
                        if (confirmVehicleUpgrade == DialogResult.Yes)
                        {// customer wants a free upgrade
                            int nextVehicleClassId = (int)vehicleClassCombobox.SelectedIndex + 1;// id of the next vehicle class
                            if (nextVehicleClassId > vehicleClassCombobox.Items.Count)// customer requested the highest vehicle class, there's no next class
                            {
                                MessageBox.Show(vehicleClassCombobox.SelectedItem + " CLASS IS THE HIGHEST CLASS WE CURRENTLY HAVE.");
                            }
                            else
                            {// there are vehicle clases to show
                                // find the next available class
                                for (int i = nextVehicleClassId; i <= vehicleClassCombobox.Items.Count - 1; i++)
                                {
                                    fillVehicleDataView(i);// fill the data view
                                    if (vehicleDataGridView.Rows.Count > 0)// check if it's not empty
                                    {// not empty, that class has vehicles available, show the data view and exit the loop
                                        this.Size = new Size(this.Width, 1043);
                                        this.CenterToScreen();
                                        break;
                                    }
                                }
                                if (vehicleDataGridView.Rows.Count <= 0)// all vehicle classes has been checked and there are no available vehicles in the branch
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

        /// <summary>
        /// this method validated the customer information. 
        /// </summary>
        /// <returns></returns>
        private bool validateCustomerInfo()
        {
            bool result = false;
            if (findByCombobox.SelectedIndex == 1)// finding by customer id
            {
                if (String.IsNullOrEmpty(customerInfoTextbox.Text))// empty text box
                {
                    errorMessageLabel.Text = "CUSTOMER ID REQUIRED";
                }
                else if (!idOrPhoneNumberInDb("ID", customerInfoTextbox.Text))// id is not in database
                {
                    errorMessageLabel.Text = "CUSTOMER ID NOT FOUND";
                }
                else// everything is okay
                {
                    result = true;
                }
            }
            else if (findByCombobox.SelectedIndex == 2)// phone number validations
            {
                if (String.IsNullOrEmpty(customerInfoTextbox.Text))// empty text box
                {
                    errorMessageLabel.Text = "PHONE NUMBER REQUIRED";
                }
                else if (customerInfoTextbox.Text.Length != 10)// phone number should be 10 digits
                {
                    errorMessageLabel.Text = "PHONE NUMBER MUST BE 10 DIGITS";
                }
                else if (!idOrPhoneNumberInDb("NUMBER", customerInfoTextbox.Text))// phone number not in db
                {
                    errorMessageLabel.Text = "PHONE NUMBER NOT FOUND";
                }
                else// everything is okay
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// this method gets the customer's last name and first name and their gold status
        /// </summary>
        private void getCustomerDetails()
        {
            if (findByCombobox.SelectedIndex == 0)
            {// NOT APPLICABLE WAS SELECTED
                return;
            }
            String idOrPhoneNumber = customerInfoTextbox.Text;
            //base query
            String query = @"SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name AS name, membership_type, gold_membership_date
                            FROM Customer";

            if (findByCombobox.SelectedIndex == 1)// CUSTOMER ID WAS SELECTED
            {
                query += "\nWHERE customer_id = " + idOrPhoneNumber;
            }
            else if (findByCombobox.SelectedIndex == 2)// PHONE NUMBER WAS SELECTED
            {
                query += "\nWHERE CAST(area_code + phone_number AS BIGINT) = " + idOrPhoneNumber;
            }

            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                currentCustName = reader.GetString(0);// save customer name
                customerNameLabel.Text = currentCustName;// show it to screen
                if (reader.GetString(1).Equals("Gold"))
                {// a gold customer
                    DateTime goldMemberDate = reader.GetDateTime(2);// date the customer became a gold member
                    DateTime goldMemberExpiryDate = goldMemberDate.AddYears(1);// the expiry date, 1 year from the date they got membership
                    if (goldMemberExpiryDate <= DateTime.Now)// membership has expired for gold customer
                    {
                        goldMemberLabel.Text = "NO";

                        expiresLabel.Text = "EXPIRED:";
                        expiryDate.Text = goldMemberExpiryDate.ToString("yyyy-MM-dd");

                        expiresLabel.Visible = true;
                        expiryDate.Visible = true;

                        expiresLabel.ForeColor = Color.Red;
                        expiryDate.ForeColor = Color.Red;
                    }
                    else// membership has NOT EXPIRED for gold customer
                    {
                        expiresLabel.Text = "EXPIRES:";
                        goldMemberLabel.Text = "YES";
                        expiryDate.Text = reader.GetDateTime(2).AddYears(1).ToString("yyyy-MM-dd");

                        expiresLabel.Visible = true;
                        expiryDate.Visible = true;

                        expiresLabel.ForeColor = Color.Green;
                        expiryDate.ForeColor = Color.Green;
                    }
                }
                else// not a gold customer/never been a gold customer
                {
                    goldMemberLabel.Text = "NO";
                    expiresLabel.Visible = false;
                    expiryDate.Visible = false;
                }
            }
            reader.Close();
        }

        /// <summary>
        /// this method checks if the search filter details are valid. I.e, month, vehicle class, branch
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// this method checks if an id or phone number is in the database. The flag parameter can be NUMBER OR ID
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="idOrPhoneNumber"></param>
        /// <returns>tTrue if the id or phone number is in the database, false if not</returns>
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

        /// <summary>
        /// Method to simply add quotes to sql query variables. Closing and opening quotes and adding '' seemed too confusing
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns>A string with '' surrounding it. E.g parameter today will return 'Today'</returns>
        private String addQuotes(String rawString)
        {
            String temp1 = rawString.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        /// <summary>
        /// on click method for the rent this vehicle button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rentThisVehicleButton_Click(object sender, EventArgs e)
        {
            if (vehicleDataGridView.SelectedRows.Count == 0)// no vehicle has been selected
            {
                selectAVehicleLabel.Visible = true;
                return;
            }
            // get the values of the currently selected row
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
                doRentInDb();// do renting
                // upgrading to gold if eligible
                String query = @"SELECT count(*) -- count the customer's rentals
FROM Rental, Customer
WHERE Rental.customer_id = Customer.customer_id AND Rental.customer_id = " + customerInfoTextbox.Text + @" AND (SELECT YEAR([start_date])) = YEAR(GETDATE())
GROUP BY Rental.customer_id;";

                if ((Convert.ToInt16(connection.executeScalar(query)) == 3))// if num of rentals == 3, upgrade to gold
                { // they have 3 rentals, upgrade to gold
                    query = @"UPDATE Customer
SET membership_type = 'Gold', gold_membership_date = CAST(GETDATE() AS DATE)
WHERE customer_id = " + customerInfoTextbox.Text + ";";
                    connection.executeNonQuery(query);
                    MessageBox.Show(customerNameLabel.Text + " IS NOW A GOLD MEMBER".ToUpper());
                }
                // hide this screen, open a new instance, close the previous screen
               // this.Visible = false;
                //new EmpViewAllVehicles(previousPage, empId, connection).ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// this method does the actual renting of vehicles. 
        /// </summary>
        private void doRentInDb()
        {
            // get the values frorm the currently selected row
            String from = fromDatePicker.Value.Date.ToString("d");
            String to = toDatePicker.Value.Date.ToString("d");
            String? vehicleId = vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value.ToString();
            String? tempBranchName = vehicleDataGridView.CurrentRow.Cells["Location"].Value.ToString().ToUpper();
            String branchId = branchComboBox.Items.IndexOf(tempBranchName).ToString();
            String classRequested = (vehicleClassCombobox.SelectedIndex).ToString();
            
            String query = "INSERT INTO Rental" +
                "\n([start_date], expected_dropoff_date, initial_amount_paid, emp_id_booking, " +
                "pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)" +
                "\nVALUES" +
                "\n( " + addQuotes(from) + ", " + addQuotes(to) + ", " + estimatedCostLabel.Text + ", " +
                empId + ", " + branchId + ", " + vehicleId + ", " + classRequested +
                ", " + customerInfoTextbox.Text + ");";



            //int rowsAffected = connection.executeNonQuery(query);
            MessageBox.Show((connection.executeNonQuery(query) == 1 ? "VEHICLE RENTED SUCCESFULLY" : 
                "DATABASE ERROR IN empViewAllVehicles: doRentInDb, contact your administrator"));
            //if (rowsAffected > 0)
            //{
            //    MessageBox.Show("VEHICLE RENTED SUCCESSFULLY.");
            //}
            //else// shoudln't execute
            //{
            //    MessageBox.Show("DATABASE ERROR IN empViewAllVehicles: doRentInDb, contact your administrator");
            //}

        }

        /// <summary>
        /// this method fills the comboboxes: findbyCombobox, vehicleClassCombobox, branchCombobox
        /// </summary>
        private void fillComboBoxes()
        {
            // find by combo box
            findByCombobox.Items.Add("NOT APPLICABLE");
            findByCombobox.Items.Add("CUSTOMER ID");
            findByCombobox.SelectedIndex = 1;
            findByCombobox.Items.Add("PHONE NUMBER");
            //
            vehicleClassCombobox.Items.Add("SELECT ONE"); 
            vehicleClassCombobox.SelectedIndex = 0;

            branchComboBox.Items.Add("ALL BRANCHES");// default branch is the employees branch, it will be added below

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
                branchComboBox.SelectedIndex = reader.GetInt32("branch_id");// make the default branch the branch of the employee that logged in 
            }
        }

        /// <summary>
        /// exit button
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
        /// this method gets the address of the current branch that's selected in the combo bix
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns>a string containing the address of the current branch</returns>
        private String getBranchAddress(int branchId)
        {
            if (branchId == 0)// all branches selected, no address
            {
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

        /// <summary>
        /// tjis method defines what happens when the branch combo box item is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (branchComboBox.SelectedIndex == 0)// all branches selected
            {
                addressPanel.Visible = false;// hide the address panel
                filtersValueChanged(sender, e);// resize screen so the employee would need to refresh the vehicles list
                return;
            }
            //a branch was selected, show the address, and resize screen so the employee would need to refresh the vehicles ist
            addressLabel.Text = getBranchAddress((int)branchComboBox.SelectedIndex).ToUpper();
            addressPanel.Visible = true;
            filtersValueChanged(sender, e);
        }
       
        /// <summary>
        /// This method defines what happens when the empoyee clicks on a cell. The estimated lable text will be updated with
        /// the appropriate price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectAVehicleLabel.Visible = false;// disable the error message
            if (vehicleDataGridView.CurrentCell == null)// exception happens without this, not sure why
            {
                return;
            }
            int vehicleClassRequested = (vehicleClassCombobox.SelectedIndex);

            
            int daysBetween = ((toDatePicker.Value.Day - fromDatePicker.Value.Day));
            // get rates
            Decimal dailyRate = getRates(vehicleClassRequested).Item1;
            Decimal weeklyRate = getRates(vehicleClassRequested).Item2;
            Decimal monthlyRate = getRates(vehicleClassRequested).Item3;

            estimatedCostLabel.Text = "$0.00";
            if (daysBetween <= 7)// daily rate
            {
                estimatedCostLabel.Text = (daysBetween * dailyRate).ToString("C");
            }
            else if (daysBetween > 7 && daysBetween < 30)// weekly rate
            {
                Decimal weekly = (daysBetween / 7) * weeklyRate;
                Decimal daily = (daysBetween % 7) * dailyRate;
                estimatedCostLabel.Text = (weekly + daily).ToString("C");
            }
            else // monthly rate
            {
                Decimal monthly = (daysBetween / 14) * monthlyRate;
                Decimal weekly = (daysBetween % 14) * weeklyRate;
                estimatedCostLabel.Text = (monthly + weekly).ToString("C");
            }
            
            // add amount of days
            amountOfDaysLabel.Text = daysBetween + " DAY";
            if (daysBetween > 1) {
                amountOfDaysLabel.Text += "S";
            }
        }

        /// <summary>
        /// this method gets the daily, weekly and monthly rate of the current vehicle that is selected 
        /// (change query to not use joins. Use vehicle class from data  view)
        /// </summary>
        /// <param name="currentVehicleId"></param>
        /// <returns>A tuple of decimals containing the rates</returns>
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

        /// <summary>
        /// This method defines what happens when the find by combobox changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorMessageLabel.Visible = false;// hide the error message
            customerDetailsPanel.Visible = false;// hide the panel that shows customer name and gold status
            if (findByCombobox.SelectedIndex == 0)// not applicable was selected, hide text box
            {
                getCustomerInfoPanel.Visible = false;
                filtersValueChanged(sender, e);
                return;
            }
            else if (findByCombobox.SelectedIndex == 1)// customer id was selected
            {
                customerInfoTextbox.MaxLength = 5;
            }
            else if (findByCombobox.SelectedIndex == 2)// phone number was selected
            {
                customerInfoTextbox.MaxLength = 10;
            }
            customerInfoTextbox.Clear();// clear the textbox each time
            getCustomerInfoPanel.Visible = true;// show the panel that containst the text box
            findByLabel.Text = findByCombobox.SelectedItem.ToString();// change the label to tehe selected item
            filtersValueChanged(sender, e);// resize screen so the employee will need to refresh the vehicle list
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

        /// <summary>
        /// resize to show only filters screen when the employee changes important information like either booking start date, end date 
        /// class requested, branch name, find by combo box and id/phone number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filtersValueChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Width, 450);
            this.CenterToScreen();
            customerDetailsPanel.Visible = false;
        }

        /// <summary>
        /// This method defines what happens after the vehicles have been loaded into the data view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            vehicleDataGridView.ClearSelection();//clear any selection
        }

        /// <summary>
        /// This method links the EmpViewVehicles page to create  a customer account. If the account was created successfully,
        /// the phone number of the new customer will be prefilled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createCustomerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorMessageLabel.Visible = false;// hide error message
            CreateCustomerAccount page = new CreateCustomerAccount(connection);
            page.ShowDialog();// show create account
            if (page.getPhoneNumber() != null)
            {
                findByCombobox.SelectedIndex = 2;// swtich combobox to phone number
                customerInfoTextbox.Text = page.getPhoneNumber();// pre fill with customer 
            }
            
        }
    }
}
