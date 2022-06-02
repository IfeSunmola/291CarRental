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
    public partial class CustViewVehiclePage : Form
    {
        private const String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection? connection;
        private SqlCommand? command;
        private SqlDataReader? reader;

        private CustSelectVehicleFilters previousPage;
        private DateTimePicker fromDate;
        private DateTimePicker toDate;
        
        public CustViewVehiclePage(CustSelectVehicleFilters previousPage, DateTimePicker fromDate, DateTimePicker toDate)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.fromDate = fromDate;
            this.toDate = toDate; 
            this.previousPage = previousPage;

            String stringToAppend = fromDate.Value.Date.ToString("D").ToUpper() + " TO " + toDate.Value.Date.ToString("D").ToUpper();
            showingVehiclesLabel.Text += stringToAppend;


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
    }
}
