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
            updatePanel.Visible = false;// hide the update and delete tabs
            deletePanel.Visible = false;
            fillComboBoxes();// fill comb boxes
        }

        // add 
        /// <summary>
        /// This method adds a vehicle to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addVehicleButton_Click(object sender, EventArgs e)
        {
            // validate input before adding
            if (addPanelValidated())
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

                // confirm the vehicle to be added 
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
                    // add vehicle
                    String branchId = (add_branchCombobox.SelectedIndex + 1).ToString();
                    String vehicleClassId = (add_vehicleClassCombobox.SelectedIndex + 1).ToString();
                    String query = "INSERT INTO Vehicle VALUES" +
                        "( " + addQuotes(plateNumber) + ", " + year + ", " + addQuotes(brand) + ", "
                        + addQuotes(model) + ", " + addQuotes(transmissionType) + ", " + numOfSeats + ", "
                        + currentMileage + ", " + addQuotes(color) + ", " + branchId + ", " + vehicleClassId + ");";

                    if (connection.executeNonQuery(query) == 1)
                    {
                        MessageBox.Show("VEHICLE ADDED SUCCESSFULLY");
                        // clear all the boxes if they want to add another vehicle
                        add_yearTextbox.Value = add_yearTextbox.Minimum;
                        add_brandCombobox.SelectedIndex = -1;
                        add_modelTextbox.Clear();
                        add_transmissionTypeCombobox.SelectedIndex = -1;
                        add_numOfSeatsTextbox.Value = add_numOfSeatsTextbox.Minimum;
                        add_currentMileageTextbox.Value = add_currentMileageTextbox.Minimum;
                        add_colorCombobox.SelectedIndex = -1;
                        add_plateNumberTextbox.Clear();
                        add_branchCombobox.SelectedIndex = -1;
                        add_vehicleClassCombobox.SelectedIndex = -1;
                    }
                    else
                    {// shouldn't happen but shit happens yuno
                        MessageBox.Show("INTERNAL ERROR OCCURRED VehicleToolsPage.cs, contact your administrator");
                    }
                }
                else
                {
                    MessageBox.Show("VEHICLE NOT ADDED");
                }
            }
        }

        /// <summary>
        /// This method validates the input information in the add panel/tab
        /// </summary>
        /// <returns></returns>
        private bool addPanelValidated()
        {
            add_errorMessageLabel.Visible = true; ;
            if (String.IsNullOrEmpty(add_yearTextbox.Text.ToString()))
            {
                add_errorMessageLabel.Text = "YEAR CANNOT BE EMPTY";
                return false;
            }

            if (add_brandCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "BRAND IS REQUIRED";
                return false;
            }

            if (String.IsNullOrEmpty(add_modelTextbox.Text.ToString()))
            {
                add_errorMessageLabel.Text = "MODEL IS REQURIED";
                return false;
            }

            if (add_transmissionTypeCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "TRANSMISSION TYPE IS REQUIRED";
                return false;
            }

            if (String.IsNullOrEmpty(add_numOfSeatsTextbox.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE NUMBER OF SEATS";
                return false;
            }

            if (String.IsNullOrEmpty(add_currentMileageTextbox.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE MILEAGE";
                return false;
            }

            if (add_colorCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A COLOR";
                return false;
            }

            if (String.IsNullOrEmpty(add_plateNumberTextbox.Text.ToString()))
            {
                add_errorMessageLabel.Text = "ENTER THE PLATE NUMBER";
                return false;
            }
            else
            {
                if (!Regex.IsMatch(add_plateNumberTextbox.Text.ToString(), "^[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]$"))
                {
                    add_errorMessageLabel.Text = "PLATE NUMBER MUST BE IN THE FORM A1B-C2D3";
                    return false;
                }
                if (plateNumberInDb(add_plateNumberTextbox))
                {
                    add_errorMessageLabel.Text = "PLATE NUMBER " + add_plateNumberTextbox.Text + " ALREADY EXISTS IN THE SYSTEM";
                    return false;
                }
            }

            if (add_branchCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A BRANCH";
                return false;
            }

            if (add_vehicleClassCombobox.SelectedItem == null)
            {
                add_errorMessageLabel.Text = "SELECT A VEHICLE CLASS";
                return false;
            }
            add_errorMessageLabel.Visible = false;
            return true;
        }

        // update
        /// <summary>
        ///  This method looks for the plate number to update and prefills the car details if found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startUpdatingButton_Click(object sender, EventArgs e)
        {
            if (isValidPlateNumber(edit_plateNumberSearch, edit_ErrorMessageLabel))
            {
                edit_ErrorMessageLabel.Visible = true;// prepare to show error/success message
                edit_ErrorMessageLabel.ForeColor = Color.Red;
                if (plateNumberInDb(edit_plateNumberSearch))
                {
                    edit_ErrorMessageLabel.ForeColor = Color.Green;// success message
                    edit_ErrorMessageLabel.Text = "PLATE NUMBER FOUND. CURRENT VALUES HAS BEEN PRE FILLED";
                    // prefill the details so the employee can see what they're updating
                    String query = "SELECT year, brand, model, transmission_type, num_seats, current_mileage, " +
      "color, plate_number, branch_id, vehicle_class_id " +
      "\nFROM Vehicle " +
      "\nWHERE plate_number = " + addQuotes(edit_plateNumberSearch.Text) + ";";

                    SqlDataReader reader = connection.executeReader(query);
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
                    updatePanel.Visible = true;// employee can now start updating
                }
                else
                {
                    edit_ErrorMessageLabel.Text = "PLATE NUMBER NOT FOUND";
                }
            }
        }

        /// <summary>
        /// This method saves the changes made to the vehicle information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            edit_plateNumErrorLabel.Visible = false;
            if (!isValidPlateNumber(edit_plateNumberTextbox, edit_ErrorMessageLabel))
            {// plate number is not valid
                return;
            }
            if (plateNumberUpdateCheckbox.Checked && plateNumberInDb(edit_plateNumberTextbox))
            {// employee is updating plate number and the new plate number is already in the database
                edit_plateNumErrorLabel.Visible = true;
                edit_plateNumErrorLabel.Text = "PLATE NUMBER ALREADY IN DATABASE";
                return;
            }
            // valid details from here on, confirm update
            DialogResult confirmUpdate = MessageBox.Show(
                "CONFIRM NEW VEHICLE DETAILS BELOW" +
                "\nYear: " + edit_yearTextbox.Text +
                "\nBrand: " + edit_brandCombobox.Text +
                "\nModel: " + edit_modelTextbox.Text +
                "\nTransmission Type: " + edit_transmissionComobox.Text +
                "\nNumber of Seats: " + edit_numOfSeatsTextbox.Text +
                "\nCurrent Mileage: " + edit_currentMileageTextbox.Text +
                "\nColor: " + edit_colorCombobox.Text +
                "\nPlate Number: " + edit_plateNumberTextbox.Text +
                "\nBranch: " + edit_branchCombobox.SelectedItem +
                "\nVehicle Class: " + edit_vehicleClassCombobox.SelectedItem,
                "CONFIRM EDITING",
                MessageBoxButtons.YesNo
                );

            if (confirmUpdate == DialogResult.Yes)
            {
                String query = "UPDATE Vehicle" +
                "\nSET year = " + edit_yearTextbox.Text + ", brand = " + addQuotes(edit_brandCombobox.Text) + ", model = " + addQuotes(edit_modelTextbox.Text) +
                ", transmission_type = " + addQuotes(edit_transmissionComobox.Text) + ", num_seats = " + edit_numOfSeatsTextbox.Text +
                ", current_mileage = " + edit_currentMileageTextbox.Text + ", color = " + addQuotes(edit_colorCombobox.Text) +
                ", plate_number = " + addQuotes(edit_plateNumberTextbox.Text) + ", branch_id = " + edit_branchCombobox.SelectedItem +
                ", vehicle_class_id = " + edit_vehicleClassCombobox.SelectedItem +
                "\nWHERE plate_number = " + addQuotes(edit_plateNumberSearch.Text);


                MessageBox.Show((connection.executeNonQuery(query) == 1 ? "VEHICLE UPDATED SUCCESSFULLY" : "UPDATE FAILED, DATABASE PROBLEM. CONTAT ADMINSTRATOR"));
                updatePanel.Visible = false;// updating is done so hide the panel
            }
            else
            {// no was selected
                MessageBox.Show("VEHICLE NOT UPDATED");
            }
        }

        // delete
        /// <summary>
        ///  This method looks for the plate number to delete and calls another method to prefill the details if found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startDeletingButton_Click(object sender, EventArgs e)
        {
            if (isValidPlateNumber(delete_plateNumberSearch, delete_errorMessageLabel))// plate number is valid
            {
                delete_errorMessageLabel.Visible = true;
                delete_errorMessageLabel.ForeColor = Color.Red;
                if (plateNumberInDb(delete_plateNumberSearch))// plate number is in database, pre fill details
                {
                    delete_errorMessageLabel.ForeColor = Color.Green;
                    delete_errorMessageLabel.Text = "PLATE NUMBER FOUND";
                    // prefill to show the customer what they're deleting
                    prefillDetails();
                    deletePanel.Visible = true;// show the panel
                }
                else// plate not found, hide the panel
                {
                    delete_errorMessageLabel.Text = "PLATE NUMBER NOT FOUND";
                    deletePanel.Visible = false;
                }
            }
        }

        /// <summary>
        /// This method prefills the delete panel information so the employee can see the vehicle they're deleting
        /// </summary>
        private void prefillDetails()
        {
            String query = @"SELECT year, brand, model, transmission_type, num_seats, current_mileage, color, plate_number, 
(SELECT branch_name FROM Branch
WHERE Branch.branch_id = Vehicle.branch_id) branch_id,
(SELECT vehicle_class FROM Vehicle_Class
WHERE Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id)
vehicle_class_id
FROM Vehicle
WHERE plate_number = " + addQuotes(delete_plateNumberSearch.Text) + @";";
            SqlDataReader reader = connection.executeReader(query);
            while (reader.Read())
            {
                delete_yearTextbox.Text = reader.GetInt16("year").ToString();
                String brandText = reader.GetString("brand");
                delete_brandCombobox.Items.Add(brandText);
                delete_brandCombobox.SelectedItem = brandText;
                delete_modelTextbox.Text = reader.GetString("model");
                String transmissionTypeText = reader.GetString("transmission_type");
                delete_transmissionComobox.Items.Add(transmissionTypeText);
                delete_transmissionComobox.SelectedItem = transmissionTypeText;
                delete_numOfSeatsTextbox.Text = reader.GetInt16("num_seats").ToString();
                delete_currentMileageTextbox.Text = reader.GetInt32("current_mileage").ToString();
                String colorText = reader.GetString("color");
                delete_colorCombobox.Items.Add(colorText);
                delete_colorCombobox.SelectedItem = colorText;
                delete_plateNumberTextbox.Text = reader.GetString("plate_number");
                String branchText = reader.GetString("branch_id");
                delete_branchCombobox.Items.Add(branchText);
                delete_branchCombobox.SelectedItem = branchText;
                String vehicleClassText = reader.GetString("vehicle_class_id");
                delete_vehicleClassCombobox.Items.Add(vehicleClassText);
                delete_vehicleClassCombobox.SelectedItem = vehicleClassText;
            }
            reader.Close();
        }
        
        /// <summary>
        /// This method deletes a vehicle from the data base, using the plate number 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteVehicleButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete this vehicle?" +
                "\nThis process is IRREVERSIBLE.",
                "CONFORM VEHICLE DELETE",
                MessageBoxButtons.YesNo);


            if (confirmDelete == DialogResult.Yes)
            {
                if (vehicleIsRented(delete_plateNumberTextbox.Text))// don't delete vehicle if it is has been rented out
                {
                    MessageBox.Show("THIS VEHICLE IS CURRENTLY RENTED OUT\nVEHICLE NOT DELETED");
                }
                else
                {
                    String query = "DELETE FROM Vehicle WHERE plate_number = " + addQuotes(delete_plateNumberTextbox.Text) + ";";
                    String message = connection.executeNonQuery(query) > 0 ? "VEHICLE DELETED" : " DATABASE ERROR IN deleteVehicle, contact administrator";
                    MessageBox.Show(message);
                }
                deletePanel.Visible = false;
            }
            else
            {
                MessageBox.Show("VEHICLE NOT DELETED");
            }
        }

        /// <summary>
        /// This method returns true if a vehicle is currently on rent out and false if it's not
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <returns></returns>
        private bool vehicleIsRented(String plateNumber)
        {
            String query = @"
SELECT plate_number
FROM Vehicle
WHERE plate_number = " + addQuotes(plateNumber) + @" AND vehicle_id IN (SELECT vehicle_id FROM Rental WHERE actual_dropoff_date IS NULL)";

            return connection.executeScalar(query) != null;
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
        /// This method checks if a plate number exists in the database
        /// </summary>
        /// <param name="plateNumberTextbox"></param>
        /// <returns>True if the plate number exists, false if not</returns>
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

        /// <summary>
        /// This method checks if the plate number format is valid
        /// </summary>
        /// <param name="plateNumberTextbox"></param>
        /// <param name="errorMessageLabel"></param>
        /// <returns>True if valid, false if not</returns>
        private bool isValidPlateNumber(TextBox plateNumberTextbox, Label errorMessageLabel)
        {
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
        /// Method to fill the combo boxes
        /// </summary>
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

        /// <summary>
        /// Method to hide the panels if the searcrh text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_TextChanged(object sender, EventArgs e)
        {
            updatePanel.Visible = false;
            deletePanel.Visible = false;
            delete_errorMessageLabel.Visible = false;
            edit_ErrorMessageLabel.Visible = false;
        }
    }
}
