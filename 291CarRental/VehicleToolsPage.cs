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
        private void addVehicleButton_Click2(object sender, EventArgs e)
        {
            String year = add_yearTextbox.Text.ToString();
            String? brand;
            var temp = add_brandCombobox.SelectedItem;
            if (temp == null)
            {
                MessageBox.Show("SELECT A BRAND");
                return;
            }
            else
            {
                brand = temp.ToString();
            }
            String model = add_modelTextbox.Text;

            temp = add_transmissionTypeCombobox.SelectedItem;
            String? transmissionType;
            if (temp == null)
            {
                MessageBox.Show("SELECT A TRASMISSION TYPE");
                return;
            }
            else
            {
                transmissionType = temp.ToString();
            }

            
            String numOfSeats = add_numOfSeatsTextbox.Text.ToString();
            String currentMileage = add_currentMileageTextbox.TextAlign.ToString();
            
            temp = add_colorCombobox.SelectedItem;
            String? color;
            if (temp == null)
            {
                MessageBox.Show("SELECT A COLOR");
                return;
            }
            else
            {
                color = temp.ToString();
            }

            
            String plateNumber = add_plateNumberTextbox.Text;

            temp = add_branchCombobox.SelectedItem;
            String? branch;
            if (temp == null)
            {
                MessageBox.Show("SELECT A BRANCH");
                return;
            }
            else
            {
                branch = temp.ToString();
            }

            temp = add_vehicleClassCombobox.SelectedItem;
            String? vehicleClass;
            if (temp == null)
            {
                MessageBox.Show("SELECT A VEHICLE CLASS");
                return;
            }
            else
            {
                vehicleClass = temp.ToString();
            }


            MessageBox.Show(year + "\n" + brand + "\n" + model + "\n" + transmissionType + "\n"
                + numOfSeats + "\n" + currentMileage + "\n" + color + "\n" + plateNumber + "\n"
                + branch + "\n" + vehicleClass);

            DialogResult confirmAdding = MessageBox.Show(
               "Confirm adding of (vehicle details?)",
               "CONFIRM ADDING VEHICLE",
               MessageBoxButtons.YesNo);

            if (confirmAdding == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE ADDED SUCCESSFULLY");
            }
            else if (confirmAdding == DialogResult.No)
            {
                MessageBox.Show("VEHICLE NOT ADDED");
            }
        }

        private void addVehicleButton_Click(object sender, EventArgs e)
        {
            bool validated = doValidation(add_yearTextbox, add_brandCombobox, add_modelTextbox, add_transmissionTypeCombobox,
                add_numOfSeatsTextbox, add_currentMileageTextbox, add_colorCombobox, add_plateNumberTextbox, add_branchCombobox, add_vehicleClassCombobox);
            if (validated)
            {
                MessageBox.Show("GOOD");
            }
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
            updatePanel.Visible = true;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmUpdating = MessageBox.Show(
               "Confirm updating of (vehicle details?)",
               "CONFIRM UPDATE VEHICLE",
               MessageBoxButtons.YesNo);

            if (confirmUpdating == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE UPDATED SUCCESSFULLY");
            }
            else if (confirmUpdating == DialogResult.No)
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
                    add_brandCombobox.Items.Add(reader.GetString("brand").ToUpper());
                }
                reader.Close();
            }
            add_brandCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            add_vehicleClassCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            add_branchCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            // transmission
            add_transmissionTypeCombobox.Items.Add("AUTOMATIC");
            add_transmissionTypeCombobox.Items.Add("HYBRID");
            add_transmissionTypeCombobox.Items.Add("MANUAL");
            add_transmissionTypeCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            // color
            add_colorCombobox.Items.Add("BLACK");
            add_colorCombobox.Items.Add("BLUE");
            add_colorCombobox.Items.Add("GREY");
            add_colorCombobox.Items.Add("LIGHT BLUE");
            add_colorCombobox.Items.Add("RED");
            add_colorCombobox.Items.Add("SILVER");
            add_colorCombobox.Items.Add("WHITE");
            add_colorCombobox.Items.Add("YELLOW");
            add_colorCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
