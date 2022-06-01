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
    public partial class custViewVehiclePage : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader? reader; // nullable, initialization not needed
        public custViewVehiclePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;


            showVehicleDataGridView.DataSource = getAvailableVehicleList();
            showVehicleDataGridView.Columns["vehicle_id"].Visible = false;
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in showVehicleDataGridView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private DataTable getAvailableVehicleList()
        {
            DataTable cars = new DataTable();
            String query = @"SELECT vehicle_id, branch_name Location, vehicle_class Class, [year] Year, brand Brand, model Model
                                 FROM Vehicle, Branch, Vehicle_Class
                                 WHERE Vehicle.branch_id = Branch.branch_id
                                 AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id;
                                ";
            try
            {
                connection.Open();
                command.CommandText = query;
                reader = command.ExecuteReader();
                cars.Load(reader);
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return cars;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
