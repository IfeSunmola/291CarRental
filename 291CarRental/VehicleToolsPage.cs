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
        private DbConnection connection;
        private EmployeeLandingPage previousPage;
        private String empId;

        public VehicleToolsPage(EmployeeLandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            this.previousPage = previousPage;
            this.empId = empId;
            this.StartPosition = FormStartPosition.CenterScreen;
            updatePanel.Visible = false;
            deletePanel.Visible = false;
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


            if (connection.executeNonQuery(query) == 1)// 1 row was modified
            {
                return true;
            }

            return false;
        }

        private bool doValidation(NumericUpDown year, ComboBox brandCombobox, TextBox model, ComboBox transmissionCombobox,
            NumericUpDown numOfSeats, NumericUpDown currentMileage, ComboBox colorCombobox, TextBox plateNumber,
            ComboBox branchCombobox, ComboBox vehicleClassCombobox)
        {
            add_errorMessageLabel.Visible = true; ;
            if (String.IsNullOrEmpty(year.Text.ToString()))
            {
                add_errorMessageLabel.Text = "YEAR CANNOT BE EMPTY";
                return false;
            }

            if (brandCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "BRAND IS REQUIRED";
                return false;
            }

            if (String.IsNullOrEmpty(model.Text.ToString()))
            {
                add_errorMessageLabel.Text = "MODEL IS REQURIED";
                return false;
            }

            if (transmissionCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "TRANSMISSION TYPE IS REQUIRED";
                return false;
            }

            if (String.IsNullOrEmpty(numOfSeats.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE NUMBER OF SEATS";
                return false;
            }

            if (String.IsNullOrEmpty(currentMileage.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE MILEAGE";
                return false;
            }

            if (colorCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A COLOR";
                return false;
            }

            if (String.IsNullOrEmpty(plateNumber.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE PLATE NUMBER";
                return false;
            }
            else
            {
                if (!Regex.IsMatch(plateNumber.Text.ToString(), "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
                {
                    add_errorMessageLabel.Text = "PLATE NUMBER MUST BE IN THE FORM A1B-C2D3";
                    return false;
                }
                if (plateNumberInDb(plateNumber))
                {
                    add_errorMessageLabel.Text = "PLATE NUMBER " + plateNumber.Text + " ALREADY EXISTS IN THE SYSTEM";
                    return false;
                }
            }

            if (branchCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A BRANCH";
                return false;
            }

            if (vehicleClassCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A VEHICLE CLASS";
                return false;
            }
            add_errorMessageLabel.Visible = false;
            return true;
        }


        // update
        private void startUpdatingButton_Click(object sender, EventArgs e)
        {

            if (isValidPlateNumber(edit_plateNumberSearch, edit_ErrorMessageLabel))
            {
                edit_ErrorMessageLabel.Visible = true;
                edit_ErrorMessageLabel.ForeColor = Color.Red;
                if (plateNumberInDb(edit_plateNumberSearch))
                {
                    edit_ErrorMessageLabel.ForeColor = Color.Green;
                    edit_ErrorMessageLabel.Text = "PLATE NUMBER FOUND. CURRENT VALUES HAS BEEN PRE FILLED";
                    prefillEditDetails(edit_plateNumberSearch, edit_yearTextbox, edit_brandCombobox, edit_modelTextbox,
                        edit_transmissionComobox, edit_numOfSeatsTextbox, edit_currentMileageTextbox, edit_colorCombobox,
                        edit_plateNumberTextbox, edit_branchCombobox, edit_vehicleClassCombobox);
                    updatePanel.Visible = true;
                }
                else
                {
                    edit_ErrorMessageLabel.Text = "PLATE NUMBER NOT FOUND";
                }
            }
        }

        private void prefillEditDetails(TextBox search_plateNumberTextbox, NumericUpDown year, ComboBox brand, TextBox model,
            ComboBox transmissionType, NumericUpDown numOfSeats, NumericUpDown currentMileage, ComboBox color, TextBox plateNumber,
            ComboBox branch, ComboBox vehicleClass)
        {
            String query = "SELECT year, brand, model, transmission_type, num_seats, current_mileage, " +
                "color, plate_number, branch_id, vehicle_class_id " +
                "\nFROM Vehicle " +
                "\nWHERE plate_number = " + addQuotes(search_plateNumberTextbox.Text) + ";";



            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                year.Text = reader.GetInt16("year").ToString();
                brand.SelectedItem = reader.GetString("brand");
                model.Text = reader.GetString("model");
                transmissionType.SelectedItem = reader.GetString("transmission_type");
                numOfSeats.Text = reader.GetInt16("num_seats").ToString();
                currentMileage.Text = reader.GetInt32("current_mileage").ToString();
                color.SelectedItem = reader.GetString("color");
                plateNumber.Text = reader.GetString("plate_number");
                branch.SelectedIndex = reader.GetInt32("branch_id") - 1;// - 1 because index starts from 0
                vehicleClass.SelectedIndex = reader.GetInt32("vehicle_class_id") - 1;
            }
        }



        private bool validateEditPlateNumber()
        {
            if (String.IsNullOrEmpty(edit_plateNumberSearch.Text))
            {
                MessageBox.Show("ENTER THE PLATE NUMBER");
                return false;
            }
            if (!Regex.IsMatch(edit_plateNumberSearch.Text, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
            {
                MessageBox.Show("PLATE NUMBER MUST BE IN THE FORM A1B-C2D3");
                return false;
            }
            if (!plateNumberInDb(edit_plateNumberSearch))
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
                "\nWHERE plate_number = " + addQuotes(edit_plateNumberSearch.Text);



            int rowsAffected = connection.executeNonQuery(query);
            if (rowsAffected >= 1)
            {
                MessageBox.Show(rowsAffected + " vehicle has been updated");
            }

        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            edit_plateNumErrorLabel.Visible = false;
            if (!isValidPlateNumber(edit_plateNumberTextbox, edit_ErrorMessageLabel))
            {
                return;
            }
            if (plateNumberInDb(edit_plateNumberTextbox))
            {
                edit_plateNumErrorLabel.Visible = true;
                edit_plateNumErrorLabel.Text = "PLATE NUMBER ALREADY IN DATABASE.\nVEHICLE NOT ADDED";
                return;
            }
            // valid details from here on
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
            if (vehicleIsRented(delete_plateNumberTextbox.Text))
            {
                MessageBox.Show("RENTED OUT");
            }
            else
            {
                MessageBox.Show("NOT RENTED OUT");
            }
            /*
            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete this vehicle?" +
                "\nThis process is IRREVERSIBLE.",
                "CONFORM VEHICLE DELETE",
                MessageBoxButtons.YesNo);

           
            if (confirmDelete == DialogResult.Yes)
            {

                if (vehicleIsRented(delete_plateNumberTextbox.Text))
                {
                    MessageBox.Show("THIS VEHICLE IS CURRENTLY RENTED OUT\nVEHICLE NOT DELETED");
                }
                else
                {
                    if (vehicleWasDeleted(delete_plateNumberTextbox.Text))
                    {
                        MessageBox.Show("Vehicle deleted");
                    }
                    else
                    {
                        MessageBox.Show("INTERNAL ERROR IN VehicleToolsPage.cs: deleteVehicleButton_Click");
                    }
                }

            }
            else
            {
                MessageBox.Show("VEHICLE NOT DELETED");
            }*/
        }

        private void startDeletingButton_Click(object sender, EventArgs e)
        {
            if (isValidPlateNumber(delete_plateNumberSearch, delete_errorMessageLabel))
            {
                delete_errorMessageLabel.Visible = true;
                delete_errorMessageLabel.ForeColor = Color.Red;
                if (plateNumberInDb(delete_plateNumberSearch))
                {
                    delete_errorMessageLabel.ForeColor = Color.Green;
                    delete_errorMessageLabel.Text = "PLATE NUMBER FOUND";
                    prefillDeleteDetails(delete_plateNumberSearch, delete_yearTextbox, delete_brandCombobox, delete_modelTextbox,
                       delete_transmissionComobox, delete_numOfSeatsTextbox, delete_currentMileageTextbox, delete_colorCombobox,
                       delete_plateNumberTextbox, delete_branchCombobox, delete_vehicleClassCombobox);
                    deletePanel.Visible = true;
                }
                else
                {
                    delete_errorMessageLabel.Text = "PLATE NUMBER NOT FOUND";
                    deletePanel.Visible = false;
                }
            }
        }

        private void prefillDeleteDetails(TextBox search_plateNumberTextbox, NumericUpDown year, ComboBox brand, TextBox model,
           ComboBox transmissionType, NumericUpDown numOfSeats, NumericUpDown currentMileage, ComboBox color, TextBox plateNumber,
           ComboBox branch, ComboBox vehicleClass)
        {
            String query = @"SELECT year, brand, model, transmission_type, num_seats, current_mileage, color, plate_number, 
(SELECT branch_name FROM Branch
WHERE Branch.branch_id = Vehicle.branch_id) branch_id,
(SELECT vehicle_class FROM Vehicle_Class
WHERE Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id)
vehicle_class_id
FROM Vehicle
WHERE plate_number = " + addQuotes(search_plateNumberTextbox.Text) + @";";



            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                year.Text = reader.GetInt16("year").ToString();
                //brand.SelectedItem = reader.GetString("brand");
                String brandText = reader.GetString("brand");
                brand.Items.Add(brandText);
                brand.SelectedItem = brandText;

                model.Text = reader.GetString("model");
                //transmissionType.SelectedItem = reader.GetString("transmission_type");
                String transmissionTypeText = reader.GetString("transmission_type");
                transmissionType.Items.Add(transmissionTypeText);
                transmissionType.SelectedItem = transmissionTypeText;
                //----------------------------
                numOfSeats.Text = reader.GetInt16("num_seats").ToString();
                currentMileage.Text = reader.GetInt32("current_mileage").ToString();
                //color.SelectedItem = reader.GetString("color");
                String colorText = reader.GetString("color");
                color.Items.Add(colorText);
                color.SelectedItem = colorText;
                plateNumber.Text = reader.GetString("plate_number");
                //branch.SelectedIndex = reader.GetInt32("branch_id") - 1;// - 1 because index starts from 0
                String branchText = reader.GetString("branch_id");
                branch.Items.Add(branchText);
                branch.SelectedItem = branchText;

                //vehicleClass.SelectedIndex = reader.GetInt32("vehicle_class_id") - 1;
                String vehicleClassText = reader.GetString("vehicle_class_id");
                vehicleClass.Items.Add(vehicleClassText);
                vehicleClass.SelectedItem = vehicleClassText;
            }
        }


        private bool vehicleWasDeleted(String plateNumber)
        {
            String query = "DELETE FROM Vehicle WHERE plate_number = " + addQuotes(plateNumber) + ";";
            int rowsAffected = connection.executeNonQuery(query);
            return rowsAffected > 0;
        }

        private bool vehicleIsRented(String plateNumber)
        {
            String query = @"
SELECT plate_number
FROM Vehicle
WHERE plate_number = " + addQuotes(plateNumber) + @" AND vehicle_id NOT IN (SELECT vehicle_id FROM Rental WHERE actual_dropoff_date IS NOT NULL)";

            if (connection.executeScalar(query) == null)
            {
                return false;
            }
            return true;
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

        private bool plateNumberInDb(TextBox plateNumberTextbox)
        {
            String plateNumber = plateNumberTextbox.Text;
            String query = "SELECT plate_number" +
                "\nFROM Vehicle" +
                "\nWHERE plate_number = " + addQuotes(plateNumber) + ";";


            if (connection.executeScalar(query) != null)
            {// not null means the plate number is in the db
                return true;
            }

            return false;
        }

        private bool isValidPlateNumber(TextBox plateNumberTextbox, Label errorMessageLabel)
        {// returns true if the plate number is valid, false if not
            String plateNumber = plateNumberTextbox.Text;
            errorMessageLabel.ForeColor = Color.Red;
            errorMessageLabel.Visible = true;
            if (String.IsNullOrEmpty(plateNumber))
            {
                errorMessageLabel.Text = "ENTER THE PLATE NUMBER";
                return false;
            }
            if (!Regex.IsMatch(plateNumber, "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
            {
               errorMessageLabel.Text = "PLATE NUMBER MUST BE IN THE FORM A1B-C2D3";
                return false;
            }
            errorMessageLabel.Visible = false;
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

            SqlDataReader reader = connection.executeReader(query);
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            updatePanel.Visible = false;
            deletePanel.Visible = false;
            delete_errorMessageLabel.Visible = false;
            edit_ErrorMessageLabel.Visible = false;
        }
    }
}
