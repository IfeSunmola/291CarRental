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
    public partial class VehicleToolsPage : Form
    {
        private const String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection? connection;
        private SqlCommand? command;
        private SqlDataReader? reader;
        private EmployeeLandingPage previousPage;
        private String empId;
        
        public VehicleToolsPage(EmployeeLandingPage previousPage, String empId)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.empId = empId;
            this.StartPosition = FormStartPosition.CenterScreen;
            updatePanel.Visible = false;
            fillComboBoxes();
        }

        // add 
        private void addVehicleButton_Click(object sender, EventArgs e)
        {
            bool validated = doValidation(add_yearTextbox, add_brandCombobox, add_modelTextbox, add_transmissionTypeCombobox,
                add_numOfSeatsTextbox, add_currentMileageTextbox, add_colorCombobox, add_plateNumberTextbox, add_branchCombobox, add_vehicleClassCombobox);
            if (validated)
            {
                String year = add_yearTextbox.Text;
                String brand = add_brandCombobox.Text;
                String model = add_modelTextbox.Text;
                String transmissionType = add_transmissionTypeCombobox.Text;
                String numOfSeats = add_numOfSeatsTextbox.Text;
                String currentMileage = add_currentMileageTextbox.Text;
                String color = add_colorCombobox.Text;
                String plateNumber = add_plateNumberTextbox.Text;
                String branch = add_branchCombobox.Text;
                String vehicleClass = add_vehicleClassCombobox.Text;

                DialogResult confirmAdding = MessageBox.Show(
                    "CONFIRM ADDING THIS VEHICLE TO BRANCH " + branch + 
                    "\nYear: " + year +
                    "\nBrand: " + brand +
                    "\nModel: " + model +
                    "\nTransmission Type: " + transmissionType +
                    "\nNumber of seats: " + numOfSeats +
                    "\nCurrent Mileage: " + currentMileage +
                    "\nColor: " + color +
                    "\nPlate Number: " + plateNumber +
                    "\nVehicle Class: " + vehicleClass,
                    "CONFIRM VEHICLE DETAILS",
                    MessageBoxButtons.YesNo
                    );
                if (confirmAdding == DialogResult.Yes)
                {
                    if (addVehicleToDb(year, brand, model, transmissionType, numOfSeats, 
                        currentMileage, color, plateNumber))
                    {
                        MessageBox.Show("VEHICLE ADDED SUCCESSFULLY");
                        this.Close();
                        previousPage.Visible = true;
                    }
                    else
                    {// shouldn't happen but shit happens yuno
                        MessageBox.Show("INTERNAL ERROR OCCURED.");
                    }
                }
                else
                {
                    MessageBox.Show("VEHICLE NOT ADDED");
                }
            }
        }

        private bool addVehicleToDb(String year, String brand, String model, String transmissionType, String numOfSeats, 
            String currentMileage, String color, String plateNumber)
        {   
            String branchId = (add_branchCombobox.SelectedIndex + 1).ToString();
            String vehicleClassId = (add_vehicleClassCombobox.SelectedIndex + 1).ToString();
            String query = "INSERT INTO Vehicle VALUES" +
                "( " + addQuotes(plateNumber) + ", " + year + ", " + addQuotes(brand) + ", "
                + addQuotes(model) + ", " + addQuotes(transmissionType) + ", " + numOfSeats + ", " 
                + currentMileage + ", " + addQuotes(color) + ", " + branchId + ", " + vehicleClassId + ");";

            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (command.ExecuteNonQuery() == 1)// 1 row was modified
                {
                    return true;
                }
            }
                return false;
        }

        private bool doValidation(NumericUpDown year, ComboBox brandCombobox, TextBox model, ComboBox transmissionCombobox,
            NumericUpDown numOfSeats, NumericUpDown currentMileage, ComboBox colorCombobox, TextBox plateNumber,
            ComboBox branchCombobox, ComboBox vehicleClassCombobox)
        {
            if (String.IsNullOrEmpty(year.Text.ToString()))
            {
                MessageBox.Show("ENTER THE YEAR");
                return false;
            }

            if (brandCombobox.SelectedItem == null)
            {
                MessageBox.Show("SELECT A BRAND");
                return false;
            }

            if (String.IsNullOrEmpty(model.Text.ToString()))
            {
                MessageBox.Show("ENTER THE MODEL");
                return false;
            }

            if (transmissionCombobox.SelectedItem == null)
            {
                MessageBox.Show("SELECT A TRANSMISSION TYPE");
                return false;
            }

            if (String.IsNullOrEmpty(numOfSeats.Text.ToString()))
            {
                MessageBox.Show("ENTER THE NUMBER OF SEATS");
                return false;
            }

            if (String.IsNullOrEmpty(currentMileage.Text.ToString()))
            {
                MessageBox.Show("ENTER THE MILEAGE");
                return false;
            }

            if (colorCombobox.SelectedItem == null)
            {
                MessageBox.Show("SELECT A COLOR");
                return false;
            }

            if (String.IsNullOrEmpty(plateNumber.Text.ToString()))
            {
                MessageBox.Show("ENTER THE PLATE NUMBER");
                return false;
            }
            else
            {
                if (!Regex.IsMatch(plateNumber.Text.ToString(), "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$")){
                    MessageBox.Show("PLATE NUMBER MUST BE IN THE FORM A1B-C2D3");
                    return false;
                }
                if (plateNumberInDb(plateNumber.Text))
                {
                    MessageBox.Show("PLATE NUMBER " + plateNumber.Text + " ALREADY EXISTS IN THE SYSTEM");
                    return false;
                }
            }

            if (branchCombobox.SelectedItem == null)
            {
                MessageBox.Show("SELECT A BRANCH");
                return false;
            }

            if (vehicleClassCombobox.SelectedItem == null)
            {
                MessageBox.Show("SELECT A VEHICLE CLASS");
                return false;
            }
            return true;
        }


        // update
        private void startUpdatingButton_Click(object sender, EventArgs e)
        {
            
            if (validateEditPlateNumber())
            {
                MessageBox.Show("PLATE NUMBER FOUND. CURRENT VALUES HAS BEEN PRE FILLED");

                prefillEditDetails(plateNumberSearch.Text);
                updatePanel.Visible = true;
            }
            
        }

        private void prefillEditDetails(String plateNumber)
        {
            String query = "SELECT year, brand, model, transmission_type, num_seats, current_mileage, " +
                "color, plate_number, branch_id, vehicle_class_id " +
                "\nFROM Vehicle " +
                "\nWHERE plate_number = " + addQuotes(plateNumber) + ";";


            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    edit_yearTextbox.Text = reader.GetInt16("year").ToString();
                    edit_brandCombobox.SelectedItem = reader.GetString("brand");
                    edit_modelTextbox.Text = reader.GetString("model");
                    edit_transmissionComobox.SelectedItem = reader.GetString("transmission_type");
                    edit_numOfSeatsTextbox.Text = reader.GetInt16("num_seats").ToString();
                    edit_currentMileageTextbox.Text = reader.GetInt32("current_mileage").ToString();
                    edit_colorCombobox.SelectedItem = reader.GetString("color");
                    edit_plateNumberTextbox.Text = reader.GetString("plate_number");
                    edit_branchCombobox.SelectedIndex = reader.GetInt32("branch_id") - 1;// - 1 because index starts from 0
                    edit_vehicleClassCombobox.SelectedIndex = reader.GetInt32("vehicle_class_id") - 1;
                }
                reader.Close();
            }
        }

        private bool validateEditPlateNumber()
        {
            if (String.IsNullOrEmpty(plateNumberSearch.Text))
            {
                MessageBox.Show("ENTER THE PLATE NUMBER");
                return false;
            }
            if (!Regex.IsMatch(plateNumberSearch.Text, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
            {
                MessageBox.Show("PLATE NUMBER MUST BE IN THE FORM A1B-C2D3");
                return false;
            }
            if (!plateNumberInDb(plateNumberSearch.Text))
            {
                MessageBox.Show("PLATE NUMBER NOT FOUND");
                return false;
            }
            return true;
        }

        private void saveEdits()
        {
            String year = edit_yearTextbox.Text;
            String brand = edit_brandCombobox.Text;
            String model = edit_modelTextbox.Text;
            String transmissionType = edit_transmissionComobox.Text;
            String numSeats = edit_numOfSeatsTextbox.Text;
            String currentMileage = edit_currentMileageTextbox.Text;
            String color = edit_colorCombobox.Text;
            String plateNumber = edit_plateNumberTextbox.Text;
            String branchId = (edit_branchCombobox.SelectedIndex + 1).ToString();
            String vehicleClassID = (edit_vehicleClassCombobox.SelectedIndex + 1).ToString();


            String query = "UPDATE Vehicle" +
                "\nSET year = " + year + ", brand = " + addQuotes(brand) + ", model = " + addQuotes(model) + 
                ", transmission_type = " + addQuotes(transmissionType) + ", num_seats = " + numSeats + 
                ", current_mileage = " + currentMileage + ", color = " + addQuotes(color) + 
                ", plate_number = " + addQuotes(plateNumber) + ", branch_id = " + branchId + 
                ", vehicle_class_id = " + vehicleClassID + 
                "\nWHERE plate_number = " + addQuotes(plateNumberSearch.Text);


            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected >= 1)
                {
                    MessageBox.Show(rowsAffected + " vehicle has been updated");
                }
            }
        }
        
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            String year = edit_yearTextbox.Text;
            String brand = edit_brandCombobox.Text;
            String model = edit_modelTextbox.Text;
            String transmissionType = edit_transmissionComobox.Text;
            String numSeats = edit_numOfSeatsTextbox.Text;
            String currentMileage = edit_currentMileageTextbox.Text;
            String color = edit_colorCombobox.Text;
            String plateNumber = edit_plateNumberTextbox.Text;
            String branchId = (edit_branchCombobox.SelectedIndex + 1).ToString();
            String vehicleClassID = (edit_vehicleClassCombobox.SelectedIndex + 1).ToString();
            //saveEdits();

            DialogResult confirmUpdate = MessageBox.Show(
                "CONFIRM NEW VEHICLE DETAILS BELOW" +
                "\nYear: " + year + 
                "\nBrand: " + brand + 
                "\nModel: " + model + 
                "\nTransmission Type: " + transmissionType + 
                "\nNumber of Seats: " + numSeats + 
                "\nCurrent Mileage: " + currentMileage + 
                "\nColor: " + color + 
                "\nPlate Number: " + plateNumber + 
                "\nBranch: " + edit_branchCombobox.SelectedItem + 
                "\nVehicle Class: " + edit_vehicleClassCombobox.SelectedItem,
                "CONFIRM EDITING",
                MessageBoxButtons.YesNo
                );

            if (confirmUpdate == DialogResult.Yes)
            {
                saveEdits();
            }
            else
            {
                MessageBox.Show("VEHICLE NOT UPDATED");
            }
        }
        // delete

        private void deleteVehicleButton_Click(object sender, EventArgs e)
        {
            // don't delete vehicle if it is has been rented out
            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete (vehicle details)?" +
                "\nThis process is IRREVERSIBLE.",
                "CONFORM VEHICLE DELETE",
                MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                MessageBox.Show("Vehicle deleted");
            }
            else
            {
                MessageBox.Show("Deletion cancelled");
            }
        }
        
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
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

        private bool plateNumberInDb(String plateNumber)
        {
            String query = "SELECT plate_number" +
                "\nFROM Vehicle" +
                "\nWHERE plate_number = " + addQuotes(plateNumber) + ";";

            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (command.ExecuteScalar() != null)
                {// not null means the plate number is in the db
                    return true;
                }
            }
            return false;
        }

        private bool isValidPlateNumber(TextBox plateNumberTextbox)
        {// returns true if the plate number is valid, false if not
            String plateNumber = plateNumberTextbox.Text;
            if (String.IsNullOrEmpty(plateNumber))
            {
                MessageBox.Show("ENTER THE PLATE NUMBER");
                return false;
            }
            if (!Regex.IsMatch(plateNumber, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
            {
                MessageBox.Show("PLATE NUMBER MUST BE IN THE FORM A1B-C2D3");
                return false;
            }
            return true;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }


        private void fillComboBoxes()
        {
            String query = "SELECT vehicle_class FROM Vehicle_Class;" + //get vehicle classes
                "\nSELECT branch_name FROM Branch;" + // get branch name
                "\nSELECT Employee.branch_id" +
                "\nFROM Employee, Branch " +
                "\nWHERE Employee.branch_id = Branch.branch_id" +
                "\nAND emp_id = " + empId + ";" + // get the employee branch
                "\nSELECT DISTINCT brand FROM Vehicle;"; // get the brandS

            using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {// fill vehicle class combo box
                    add_vehicleClassCombobox.Items.Add(reader.GetString("vehicle_class").ToUpper());
                }
                reader.NextResult();
                while (reader.Read())
                {// fill branch combo box
                    add_branchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
                }
                reader.NextResult();
                if (reader.Read())
                {// set the employeee branch as the default branch selected in branch combo box
                    add_branchCombobox.SelectedIndex = (reader.GetInt32("branch_id") - 1);
                }
                reader.NextResult();
                while (reader.Read())
                {// fill brand combo box
                    add_brandCombobox.Items.Add(reader.GetString("brand"));
                }
                reader.Close();
            }
            // transmission
            add_transmissionTypeCombobox.Items.Add("Automatic");
            add_transmissionTypeCombobox.Items.Add("Hybrid");
            add_transmissionTypeCombobox.Items.Add("Manual");         
            // color
            add_colorCombobox.Items.Add("Black");
            add_colorCombobox.Items.Add("Blue");
            add_colorCombobox.Items.Add("Grey");
            add_colorCombobox.Items.Add("Light Blue");
            add_colorCombobox.Items.Add("Red");
            add_colorCombobox.Items.Add("Silver");
            add_colorCombobox.Items.Add("White");
            add_colorCombobox.Items.Add("Yellow");

            // copying combobox items from add vehicle tab to update vehicle tab
            edit_brandCombobox.Items.AddRange(add_brandCombobox.Items.Cast<Object>().ToArray());
            edit_transmissionComobox.Items.AddRange(add_transmissionTypeCombobox.Items.Cast<Object>().ToArray());
            edit_colorCombobox.Items.AddRange(add_colorCombobox.Items.Cast<Object>().ToArray());
            edit_branchCombobox.Items.AddRange(add_branchCombobox.Items.Cast<Object>().ToArray());
            edit_vehicleClassCombobox.Items.AddRange(add_vehicleClassCombobox.Items.Cast<Object>().ToArray());
        }

        private void plateNumberSearch_TextChanged(object sender, EventArgs e)
        {
            updatePanel.Visible = false;
        }
    }
}
