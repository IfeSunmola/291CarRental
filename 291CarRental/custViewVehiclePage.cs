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
        private DbConnection connection;

        private CustSelectVehicleFilters previousPage;
        private DateTimePicker fromDate;
        private DateTimePicker toDate;
        private int vehicleClassId;
        private int branchId;


        public CustViewVehiclePage(CustSelectVehicleFilters previousPage, DateTimePicker fromDate, DateTimePicker toDate, int vehicleClassId, int branchId, DbConnection connection)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.previousPage = previousPage;
            this.vehicleClassId = vehicleClassId;
            this.branchId = branchId;
            this.connection = connection;

            vehicleDataGridView.Columns.Clear();

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
            DataTable vehicles = new DataTable();
            String from = fromDate.Value.Date.ToString("d");
            String to = toDate.Value.Date.ToString("d");

            String query = @"
SELECT vehicle_id, branch_name as 'Location', vehicle_class AS 'Class', [year] AS 'Year', brand AS 'Brand', model AS 'Model'
FROM Vehicle, Branch, Vehicle_Class 
WHERE Vehicle.branch_id = Branch.branch_id
AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id
AND vehicle_id IN 
(	SELECT vehicle_id
	FROM Vehicle 
	EXCEPT 
	(
		(SELECT [vehicle_id]
		FROM Rental
		WHERE [start_date] >= " + addQuotes(from) + @" and expected_dropoff_date <= " + addQuotes(to) + @")
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE  " + addQuotes(from) + @" >= [start_date] and " + addQuotes(from) + @" <= expected_dropoff_date)
		)
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE expected_dropoff_date >= " + addQuotes(to) + @" and [start_date] <= " + addQuotes(to) + @")
		)
	) 
)
";

            if (branchId != 0)// a specific branch was selected, add filters
            {
                query += "\nAND Vehicle.branch_id = " + branchId + "";
            }
            if (vehicleClassId != 0)// a specific class was selected, add filters
            {
                query += "\nAND Vehicle.vehicle_class_id = " + vehicleClassId + ";";
            }
            // MessageBox.Show(query);

            SqlDataReader reader = connection.executeReader(query);
            vehicles.Load(reader);
            return vehicles;
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

            estimatedCostLabel.Text = "ESTIMATED COST: ";
            if (daysBetween <= 7)
            {
                estimatedCostLabel.Text += (daysBetween * dailyRate).ToString("C");
            }
            else if (daysBetween > 7 && daysBetween < 30)
            {

                Decimal weekly = (daysBetween / 7) * weeklyRate;
                Decimal daily = (daysBetween % 7) * dailyRate;
                estimatedCostLabel.Text += (weekly + daily).ToString("C");
            }
            else //if (daysBetween >= 30)
            {
                Decimal monthly = (daysBetween / 14) * monthlyRate;
                Decimal weekly = (daysBetween % 14) * weeklyRate;
                estimatedCostLabel.Text += (monthly + weekly).ToString("C");
            }
        }

        private Tuple<Decimal, Decimal, Decimal> getRates(int currentVehicleId)
        {
            String query = "SELECT daily_rate, weekly_rate, monthly_rate" +
                  "\nFROM Vehicle_Class, Vehicle " +
                  "\nWHERE vehicle.vehicle_id = " + currentVehicleId +
                  "\nAND Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id;";

            Decimal dailyRate = 0.0m, weeklyRate = 0.0m, monthlyRate = 0.0m;

            SqlDataReader reader = connection.executeReader(query);
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
            return Tuple.Create(dailyRate, weeklyRate, monthlyRate);
        }
    }
}
