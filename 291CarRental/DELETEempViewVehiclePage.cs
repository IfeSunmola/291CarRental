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
    public partial class DELETEempViewVehiclePage : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        public DELETEempViewVehiclePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // load data into the DataGripView
            showVehicleDataGridView.DataSource = getAvailableVehicleList();
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in showVehicleDataGridView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void rentVehicleButton(object sender, EventArgs e)
        {
            DialogResult confirmRental = MessageBox.Show(
                "Confirm rental of 2022 KIA SPORTAGE?" + 
                "\nCUSTOMER NAME: John Doe (003)" + 
                "\nFROM: June 12, 2022" +
                "\nTO June 19, 2022" + 
                "\nAMOUNT DUE NOW: $130", 
                "CONFIRM RENTAL DETAILS", 
                MessageBoxButtons.YesNo);
            if (confirmRental == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Vehicle has been rented successfully" +
                    "\nCustomer name: John Doe (003)" +
                    "\nRental ID: 001" +
                    "\nPick up date: June 12, 2022" +
                    "\nPick up address: 112 flying bison drive SW" +
                    "\nDrop off date: June 19, 2022" +
                    "\nVehicle Details: 2022 Toyota, Corolla" +
                    "\nAmount Paid: $130",
                    "VEHICLE RENTAL SUCESS");
                //new EmployeeLandingPage().Show();

            }
            else if (confirmRental == DialogResult.No)
            {

            }
        }

        private DataTable getAvailableVehicleList()
        {
            DataTable cars = new DataTable();
            String query = @"SELECT branch_name Location, vehicle_class Class, [year] Year, brand Brand, model Model
                                 FROM Vehicle, Branch, Vehicle_Class
                                 WHERE Vehicle.branch_id = Branch.branch_id
                                 AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id;
                                ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        //connection.Open();
                        cars.Load(reader);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return cars;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                MessageBox.Show("Daily Price: $78.99\nWeekly Price: $100.22\nMonthly Price: $200.99", "RENTAL PRICES");
            }
        }

        private void showVehicleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
