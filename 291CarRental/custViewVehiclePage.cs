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
        private int vehicleClassId;
        private int branchId;

        
        public CustViewVehiclePage(CustSelectVehicleFilters previousPage, DateTimePicker fromDate, DateTimePicker toDate, int vehicleClassId, int branchId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.fromDate = fromDate;
            this.toDate = toDate; 
            this.previousPage = previousPage;
            this.vehicleClassId = vehicleClassId;
            this.branchId = branchId;

            String stringToAppend = fromDate.Value.Date.ToString("D").ToUpper() + " TO " + toDate.Value.Date.ToString("D").ToUpper();
            showingVehiclesLabel.Text += stringToAppend;

            estimatedCostLabel.Text = "";

            vehicleDataGridView.DataSource = getAvailableVehicleList();
            vehicleDataGridView.Columns["vehicle_id"].Visible = false;
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in vehicleDataGridView.Columns)
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
                                 AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id
                                 AND Vehicle.branch_id = " + branchId + 
                                 "AND Vehicle.vehicle_class_id = " + vehicleClassId+ ";";

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

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        private void vehicleDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentVehicleId = (int)vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value;
            int daysBetween = (toDate.Value - fromDate.Value).Days + 1;
            Decimal dailyRate = getRates(currentVehicleId).Item1;
            Decimal weeklyRate = getRates(currentVehicleId).Item2;
            Decimal monthlyRate = getRates(currentVehicleId).Item3;

            MessageBox.Show("Daily: " + dailyRate +
                "\nWeekly: " + weeklyRate +
                "\nMonthly: " + monthlyRate);

            if (daysBetween <= 7)
            {
                estimatedCostLabel.Text = string.Empty;
            }
            else if (daysBetween > 7 && daysBetween < 30)
            {
                
            }
            else //if (daysBetween >= 30)
            {
                
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
    }
}
