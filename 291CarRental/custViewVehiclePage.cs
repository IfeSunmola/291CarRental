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
    /// <summary>
    /// This form/class shows the customer the vehicles
    /// </summary>
    public partial class CustViewVehiclePage : Form
    {
        private DbConnection connection;// connection to the database

        //information from the filters page
        private CustSelectVehicleFilters previousPage;
        private DateTimePicker fromDate;
        private DateTimePicker toDate;
        private int vehicleClassId;
        private int branchId;

        /// <summary>
        /// Constructor to initialize objects
        /// </summary>
        /// <param name="previousPage"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="vehicleClassId"></param>
        /// <param name="branchId"></param>
        /// <param name="connection"></param>
        public CustViewVehiclePage(CustSelectVehicleFilters previousPage, DateTimePicker fromDate, DateTimePicker toDate, int vehicleClassId, int branchId, DbConnection connection)
        {
            InitializeComponent();
            // initializae instance variables gotten from the filters page 
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.previousPage = previousPage;
            this.vehicleClassId = vehicleClassId;
            this.branchId = branchId;
            this.connection = connection;

            // remove anything that happens to be in the data view
            vehicleDataGridView.Columns.Clear();

            showingVehiclesLabel.Text += fromDate.Value.Date.ToString("D").ToUpper() + " TO " + toDate.Value.Date.ToString("D").ToUpper(); ;

            estimatedCostLabel.Text = "";

            vehicleDataGridView.DataSource = getAvailableVehicleList();
            vehicleDataGridView.Columns["vehicle_id"].Visible = false;// hide vehicle id from the data grid view. the id is later used to get the prices
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in vehicleDataGridView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        /// <summary>
        /// method to get the vehicles that are available and add them to the DataTable
        /// </summary>
        /// <returns>A DataTable containing the vehicles that are available to be rented</returns>
        private DataTable getAvailableVehicleList()
        {
            DataTable vehicles = new DataTable();
            String from = addQuotes(fromDate.Value.Date.ToString("d"));// convert to sql format date 
            String to = addQuotes(toDate.Value.Date.ToString("d"));// and add single quotes for sql purposes

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
		WHERE [start_date] >= " + from + @" and expected_dropoff_date <= " + to + @")
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE  " + from + @" >= [start_date] and " + from + @" <= expected_dropoff_date)
		)
		UNION(
			(SELECT [vehicle_id]
			FROM Rental
			WHERE expected_dropoff_date >= " + to + @" and [start_date] <= " + to + @")
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
            SqlDataReader reader = connection.executeReader(query);
            vehicles.Load(reader);// load the result into the DataTable
            reader.Close();
            return vehicles;
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
        /// This method is called anytime a cell on the data grid view is clicked on. It updates the estimated cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentVehicleId = (int)vehicleDataGridView.CurrentRow.Cells["vehicle_id"].Value;
            int daysBetween = (toDate.Value - fromDate.Value).Days + 1;
            Decimal dailyRate = getRates(currentVehicleId).Item1;// get the rates
            Decimal weeklyRate = getRates(currentVehicleId).Item2;
            Decimal monthlyRate = getRates(currentVehicleId).Item3;

            estimatedCostLabel.Text = "ESTIMATED COST: ";
            if (daysBetween <= 7)// less than a week
            {
                estimatedCostLabel.Text += (daysBetween * dailyRate).ToString("C");
            }
            else if (daysBetween > 7 && daysBetween < 30)
            {// more than a week but less than a month

                Decimal weekly = (daysBetween / 7) * weeklyRate;
                Decimal daily = (daysBetween % 7) * dailyRate;
                estimatedCostLabel.Text += (weekly + daily).ToString("C");
            }
            else
            {//anything else
                Decimal monthly = (daysBetween / 14) * monthlyRate;
                Decimal weekly = (daysBetween % 14) * weeklyRate;
                estimatedCostLabel.Text += (monthly + weekly).ToString("C");
            }
        }

        /// <summary>
        /// This method gets the daily, weekly and monthly rate of a vehicle. 
        /// </summary>
        /// <param name="currentVehicleId"></param>
        /// <returns>A tuple containing the 3 rates of a vehicle class. Daily, weekly and monthly</returns>
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
                if (reader.GetName(0).Equals("daily_rate"))// 1st column
                {
                    dailyRate = reader.GetDecimal(0);
                }
                if (reader.GetName(1).Equals("weekly_rate"))// 2nd column
                {
                    weeklyRate = reader.GetDecimal(1);
                }
                if (reader.GetName(2).Equals("monthly_rate"))// 3rd column
                {
                    monthlyRate = reader.GetDecimal(2);
                }

            }
            return Tuple.Create(dailyRate, weeklyRate, monthlyRate);
        }
    }
}
