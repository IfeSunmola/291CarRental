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
    public partial class ReturnAVehiclePage : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private EmployeeLandingPage previousPage;
        public ReturnAVehiclePage(EmployeeLandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            this.StartPosition = FormStartPosition.CenterScreen;

            customerIDRadio.Checked = true;
        }

        private DataTable getCustomerRentals()
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

        private void backButtonClicked(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void findAllRentalsButtonClicked(object sender, EventArgs e)
        {
            // load data into the DataGripView
            customerRentalsDataGripView.DataSource = getCustomerRentals();
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in customerRentalsDataGripView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void startAReturnButtonClicked(object sender, EventArgs e)
        {
            new StartAReturnPage().Show();
        }

        private void customerIDRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = customerIDRadio.Text;
        }

        private void phoneNumberRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = phoneNumberRadio.Text;
        }

        private void plateNumberRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = plateNumberRadio.Text;
        }  
    }
}
