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
    public partial class EmpViewAllVehicles : Form
    {
        private const String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection? connection;
        private SqlCommand? command;
        private SqlDataReader? reader;
        private EmployeeLandingPage previousPage;
        private String empId;
        private String currentCustName;

        public EmpViewAllVehicles(EmployeeLandingPage previousPage, String empId)
        {
            InitializeComponent();

            this.previousPage = previousPage;
            this.empId = empId;
            this.currentCustName = "";

            this.StartPosition = FormStartPosition.CenterScreen;
            vehicleDataGridView.Columns.Clear();

            fromDatePicker.Value = DateTime.Now.AddDays(1);
            toDatePicker.Value = DateTime.Now.AddDays(2);
            addressLabel.Visible = false;
            fillComboBoxes();

            customerDetailsPanel.Visible = false;
        }

        private DataTable getAvailableVehicleList()
        {
            int branchId = (int)branchComboBox.SelectedIndex;
            int vehicleClassId = (int)vehicleClassCombobox.SelectedIndex;

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
	--WHERE branch_id = " + branchId + @"
	EXCEPT 
	(
		(SELECT [vehicle_id]
		FROM Rental
		WHERE start_date_of_booking >= " + addQuotes(from) + @" and expected_dropoff_date <= " + addQuotes(to) + @")
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE  " + addQuotes(from) + @" >= start_date_of_booking and " + addQuotes(from) + @" <= expected_dropoff_date)
		)
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE expected_dropoff_date >= " + addQuotes(to) + @" and start_date_of_booking <= " + addQuotes(to) + @")
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

          // MessageBox.Show(query);
            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();
                cars.Load(reader);
                reader.Close();
            }
            return cars;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void findAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            if (validateSearchDetails())
            {
                getCustomerDetails();
                vehicleDataGridView.DataSource = getAvailableVehicleList();
                vehicleDataGridView.Columns["vehicle_id"].Visible = false;
                //disable sorting the columns
                foreach (DataGridViewColumn dataGridViewColumn in vehicleDataGridView.Columns)
                {
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                showVehicleDataGripViewPanel.Visible = true;
                String toAppend = fromDatePicker.Value.Date.ToString("D").ToUpper() + " TO " + toDatePicker.Value.Date.ToString("D").ToUpper();
                showingVehiclesLabel.Text = "SHOWING AVAILABLE VEHICLES FROM " + toAppend;
            }
        }

        private void getCustomerDetails()
        {
            String customerId = customerIdTextbox.Text;
            String query = "SELECT SUBSTRING (last_name, 1, 1) + '. ' + first_name AS name, membership_type" +
                            "\nFROM Customer " +
                            "\nWHERE customer_id = " + customerId;

            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentCustName = reader.GetString(0);
                    customerNameLabel.Text = "CUSTOMER NAME: " + currentCustName;
                    if (reader.GetString(1).Equals("Gold"))
                    {
                        goldMemberLabel.Text = "GOLD MEMBER: YES";
                    }
                    else
                    {
                        goldMemberLabel.Text = "GOLD MEMBER: NO";
                    }
                }
                customerDetailsPanel.Visible = true;    
                reader.Close();
            }
        }

        private bool validateSearchDetails()
        {
            bool result = false;
            String vehicleClassSelected = (String)vehicleClassCombobox.SelectedItem;
            String branchSelected = (String)branchComboBox.SelectedItem;
            if (fromDatePicker.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Vehicles must be booked one day before");
            }
            else if (fromDatePicker.Value.Date >= toDatePicker.Value.Date)
            {
                MessageBox.Show("FROM DATE HAS TO BE BEFORE TO DATE");
            }
            // below are redundant but that's okay because hehehehe
            else if (String.IsNullOrEmpty(vehicleClassSelected))
            {
                MessageBox.Show("SELECT A VEHICLE CLASS");
            }
            else if (String.IsNullOrEmpty(branchSelected))
            {
                MessageBox.Show("SELECT A BRANCH");
            }
            else
            {
                result = true;
            }
            return result;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        private void rentThisVehicleButton_Click(object sender, EventArgs e)
        {
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
              MessageBoxButtons.YesNo) ;

            if (confirmRenting == DialogResult.Yes)
            {
                doRentInDb();
            }
        }

        private void doRentInDb()
        {
            String from = fromDatePicker.Value.Date.ToString("d");
            String to = toDatePicker.Value.Date.ToString("d");
            String? vehicleId = vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value.ToString();
            String branchId = branchComboBox.SelectedIndex.ToString();
            String classRequested = vehicleClassCombobox.SelectedIndex.ToString();
            String query = "INSERT INTO Rental" +
                "\n(start_date_of_booking, expected_dropoff_date, amount_due_now, emp_id_booking, " +
                "pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)" +
                "\nVALUES" +
                "\n( " + addQuotes(from) + ", " + addQuotes(to) + ", " + estimatedCostLabel.Text + ", " + 
                empId + ", " + branchId + ", " + vehicleId + ", " + classRequested + 
                ", " + customerIdTextbox.Text + ");";

            MessageBox.Show(query);

            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("VEHICLE RENTED SUCCESSFULLY.");
                }
                else
                {
                    MessageBox.Show("AN ERROR OCCURED, TRY AGAIN");
                }
            }
        }

        private void fillComboBoxes()
        {
            vehicleClassCombobox.Items.Add("ALL CLASSES");
            branchComboBox.Items.Add("ALL BRANCHES");
            vehicleClassCombobox.SelectedIndex = 0;
            //branchComboBox.SelectedIndex = 0;

            String query = "SELECT vehicle_class FROM Vehicle_Class;" +
                "\nSELECT branch_name FROM Branch;" +
                "\nSELECT Employee.branch_id" +
                "\nFROM Employee, Branch " +
                "\nWHERE Employee.branch_id = Branch.branch_id" +
                "\nAND emp_id = " + empId ;
            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();
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
                reader.Close();
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

        private String getBranchAddress()
        {
            int branchId = (int)branchComboBox.SelectedIndex;// not adding +1 because of "ALL BRANCHES"
            if (branchId == 0)
            {
                return "";
            }
            String branchAddress = "";
            String query =
                @"SELECT trim(street_number + ' ' + street_name + ', ' + city)
                        FROM Branch 
                    WHERE  branch_id = " + branchId + ";";
            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {

                connection.Open();
                // null checking is not needed here because of the earlier validations but... why not
                var rawBranchAddress = command.ExecuteScalar();
                if (rawBranchAddress != null)
                {
                    branchAddress = (String)rawBranchAddress;
                }
            }
            return branchAddress;
        }

        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressLabel.Text = getBranchAddress();
            addressLabel.Visible = true;
        }

        private void vehicleDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentVehicleId = (int)vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value;
            int daysBetween = (toDatePicker.Value - fromDatePicker.Value).Days + 1;
            Decimal dailyRate = getRates(currentVehicleId).Item1;
            Decimal weeklyRate = getRates(currentVehicleId).Item2;
            Decimal monthlyRate = getRates(currentVehicleId).Item3;

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
        }

        private Tuple<Decimal, Decimal, Decimal> getRates(int currentVehicleId)
        {
            String query = "SELECT daily_rate, weekly_rate, monthly_rate" +
                  "\nFROM Vehicle_Class, Vehicle " +
                  "\nWHERE vehicle.vehicle_id = " + currentVehicleId +
                  "\nAND Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id;";

            Decimal dailyRate = 0.0m, weeklyRate = 0.0m, monthlyRate = 0.0m;
            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();
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
                reader.Close();
            }
            return Tuple.Create(dailyRate, weeklyRate, monthlyRate);
        }

        // this method make the employee id textbox only accept numbers
        // copy and paste won't work because Shortcuts are disabled
        private void customerIdTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void phoneNumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
