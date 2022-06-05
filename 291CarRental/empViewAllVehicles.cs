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
        
        public EmpViewAllVehicles(EmployeeLandingPage previousPage, String empId)
        {
            InitializeComponent();

            this.previousPage = previousPage;
            this.empId = empId;

            this.StartPosition = FormStartPosition.CenterScreen;

            fromDatePicker.Value = DateTime.Now.AddDays(1);
            toDatePicker.Value = DateTime.Now.AddDays(2);
            addressLabel.Visible = false;
            fillComboBoxes();
        }

        private DataTable getAvailableVehicleList()
        {
            DataTable cars = new DataTable();
            String query = @"SELECT vehicle_id, branch_name Location, vehicle_class Class, [year] Year, brand Brand, model Model
                                 FROM Vehicle, Branch, Vehicle_Class
                                 WHERE Vehicle.branch_id = Branch.branch_id
                                 AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id;
                                ";

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
            //new empViewVehiclePage().Show();
            // load data into the DataGripView
            //showVehicleDataGridView.Rows.Clear();
            showVehicleDataGridView.DataSource = getAvailableVehicleList();
            showVehicleDataGridView.Columns["vehicle_id"].Visible = false;
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in showVehicleDataGridView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            showVehicleDataGripViewPanel.Visible = true;
            rentVehicleButton.Visible = true;
        }

        private void vehicleInfoRow_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            String query = "";
            try
            {
                connection.Open();
                command.CommandText = query;
                // reader = command.ExecuteReader();

                //reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            estimatedCostLabel.Text = "ESTIMATED COST: $120";
        }

        private void rentThisVehicleButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmRenting = MessageBox.Show(
              "Confirm renting of 2022 KIA SPORTAGE for JOHN DOE (003) ",
              "CONFIRM RENTING VEHICLE",
              MessageBoxButtons.YesNo);

            if (confirmRenting == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE RENTED SUCCESSFULLY");
                this.Close();
                previousPage.Visible = true;
            }
            else if (confirmRenting == DialogResult.No)
            {
                MessageBox.Show("VEHICLE NOT RENTED");
            }
        }
        
        private void fillComboBoxes()
        {
            vehicleClassCombobox.Items.Add("ALL CLASSES");
            branchComboBox.Items.Add("ALL BRANCHES");
            vehicleClassCombobox.SelectedIndex = 0;
            branchComboBox.SelectedIndex = 0;

            String query = "SELECT vehicle_class FROM Vehicle_Class; SELECT branch_name FROM Branch;";
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
                reader.Close();
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
                    branchAddress = "Address: " + (String)rawBranchAddress;
                }
            }
            return branchAddress;
        }

        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressLabel.Text = getBranchAddress();
            addressLabel.Visible = true;
        }
    }
}
