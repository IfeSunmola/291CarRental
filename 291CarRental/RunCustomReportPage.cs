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
    public partial class RunCustomReportPage : Form
    {
        private EmployeeLandingPage previousPage;
        private DbConnection connection;
        
        public RunCustomReportPage(EmployeeLandingPage previousPage, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            this.Size = new Size(this.Width, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.connection = connection;

            fillComboboxes();
        }

        private void fillComboboxes()
        {
            reportCombobox.Items.Add("VEHICLE REPORTS");
            reportCombobox.Items.Add("EMPLOYEE REPORTS");
            reportCombobox.Items.Add("BRANCH REPORTS");
            reportCombobox.SelectedIndex = 0;
            //////////////////////////////////////////////////////////
            vehicleMostLeastCombobox.Items.Add("MOST");
            vehicleMostLeastCombobox.Items.Add("LEAST");
            vehicleMostLeastCombobox.SelectedIndex = 0;
            //////////////////////////////////////////////////////////
            branchCombobox.Items.Add("ALL BRANCHES");
            colorCombobox.Items.Add("ALL COLORS");
            brandCombobox.Items.Add("ALL BRANDS");
            yearCombobox.Items.Add("ALL YEARS");
            //////////////////////////////////////////////////////////
            branchCombobox.SelectedIndex = 0;
            colorCombobox.SelectedIndex = 0;
            brandCombobox.SelectedIndex = 0;
            yearCombobox.SelectedIndex = 0;
            String query = "SELECT branch_name FROM Branch; SELECT DISTINCT color FROM Vehicle; " +
                "SELECT DISTINCT brand FROM Vehicle;";
            SqlDataReader reader = connection.executeReader(query);
            while (reader.Read())
            {
                branchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            reader.NextResult();
            while (reader.Read())
            {
                colorCombobox.Items.Add(reader.GetString("color").ToUpper());
            }
            reader.NextResult();
            while (reader.Read())
            {
                brandCombobox.Items.Add(reader.GetString("brand").ToUpper());
            }
            
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                yearCombobox.Items.Add(i);
            }
        }
       
        // vehicle reports
        private DataTable classRequestedReport(String sign)
        {// = is for getting requested and was available; != is for getting requested and not available
            String branchId = (branchCombobox.SelectedIndex > 0 ? 
                "\nAND pickup_branch_id = " + branchCombobox.SelectedIndex : "");
            DataTable result = new DataTable();
            String query = @"
SELECT 
	(SELECT vehicle_class FROM Vehicle_Class WHERE T1.vehicle_class_requested = Vehicle_Class.vehicle_class_id) AS [Class Requested],
	[Number of times requested]
FROM
	(SELECT TOP (1000)
		vehicle_class_requested,
		COUNT(*) AS [Number of times requested]
	FROM Rental 
	WHERE Rental.vehicle_class_requested " + sign + @" 
			(SELECT Vehicle.vehicle_class_id FROM Vehicle, Vehicle_Class WHERE Vehicle.vehicle_id = Rental.vehicle_id 
					AND Vehicle_Class.vehicle_class_id = Vehicle.vehicle_class_id)
		AND [start_date] BETWEEN " + addQuotes(filterFromDate.Value.ToString("d")) + @"AND " + addQuotes(filterToDate.Value.ToString("d")) + @"
		" + branchId + @"
	GROUP BY vehicle_class_requested
	ORDER BY [Number of times requested] DESC) AS T1
";
            result.Load(connection.executeReader(query));
            return result;
        }

        private DataTable mileageReport()
        {
            DataTable result = new DataTable();
            String branch = (branchCombobox.SelectedIndex > 0 ?
               "\nAND branch_id = " + branchCombobox.SelectedIndex : "");
            String color = (colorCombobox.SelectedIndex > 0 ?
               "\nAND color = " + addQuotes(colorCombobox.SelectedItem.ToString()) : "");
            String brand = (brandCombobox.SelectedIndex > 0 ?
               "\nAND brand = " + addQuotes(brandCombobox.SelectedItem.ToString()) : "");
            String year = (yearCombobox.SelectedIndex > 0 ?
               "\nAND year = " + yearCombobox.SelectedItem.ToString(): "");
            String query = @"
SELECT plate_number [Plate Number], current_mileage [Current Mileage], [year] [Year], brand [Brand], model [Model], color [Color]
FROM Vehicle
WHERE current_mileage >= " + mileageNumericUpdown.Value + branch + color + brand + year;
            result.Load(connection.executeReader(query));
            return result;
        }
        
        private DataTable classRentedMostLeast(String flag)
        {
            DataTable result = new DataTable();
            flag = (flag.Equals("MOST") ? "DESC" : "ASC");
            String branch = (branchCombobox.SelectedIndex > 0 ?
             "\nAND branch_id = " + branchCombobox.SelectedIndex : "");

            String query = @"
SELECT TOP (1)
	vehicle_class [Vehicle Class],
	COUNT(*) [Number of times rented]
FROM Rental, Vehicle, Vehicle_Class
WHERE Rental.vehicle_id = Vehicle.vehicle_id AND Vehicle_Class.vehicle_class_id 
					IN(SELECT Vehicle.vehicle_class_id FROM Vehicle WHERE vehicle_id = Rental.vehicle_id )
        AND [start_date] BETWEEN " + addQuotes(filterFromDate.Value.ToString("d")) + @" AND " + addQuotes(filterToDate.Value.ToString("d")) + branch +         @" 
GROUP BY vehicle_class
ORDER BY [Number of times rented] " + flag;

            result.Load(connection.executeReader(query));
            return result;

        }
       
        private void reportCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (vehicleRadio1.Checked)
            {// requested and NOT available 
                reportsDataView.DataSource = classRequestedReport("!=");

                reportsDataView.Size = new Size(386, 192);
                reportsDataView.Location = new Point(411, 606);
                this.Size = new Size(this.Width, 900);
                this.CenterToScreen();
            }
            else if (vehicleRadio2.Checked)
            {// requested and was availablee
                reportsDataView.DataSource = classRequestedReport("=");

                reportsDataView.Size = new Size(386, 192);
                reportsDataView.Location = new Point(411, 606);
                this.Size = new Size(this.Width, 900);
                this.CenterToScreen();
            }
            else if (vehicleRadio3.Checked)
            {// mileage report
                reportsDataView.DataSource = mileageReport();

                reportsDataView.Size = new Size(1000, 192);
                reportsDataView.Location = new Point(111, 601);
                this.Size = new Size(this.Width, 900);
                this.CenterToScreen();
            }
            else if (vehicleRadio4.Checked)
            {// class rernted the most/least

                if (vehicleMostLeastCombobox.SelectedIndex == 0)
                {
                    reportsDataView.DataSource = classRentedMostLeast("MOST");
                }
                else
                {
                    reportsDataView.DataSource = classRentedMostLeast("LEAST");
                }

                

                reportsDataView.Location = new Point(396, 595);
                reportsDataView.Size = new Size(386, 91);
                this.Size = new Size(this.Width, 800);
                this.CenterToScreen();
            }
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
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

        private void sizeDGV(DataGridView dgv)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgv.ScrollBars = ScrollBars.None;
            var totalHeight = dgv.Rows.GetRowsHeight(states) + dgv.ColumnHeadersHeight;
            totalHeight += dgv.Rows.Count * 4;  // a correction I need
            var totalWidth = dgv.Columns.GetColumnsWidth(states) + dgv.RowHeadersWidth;
            dgv.ClientSize = new Size(totalWidth, totalHeight);

        }

        private void vehicleRadio3_CheckedChanged(object sender, EventArgs e)
        {// when "mileage" is checked, disable date filters
            filterFromDate.Enabled = !vehicleRadio3.Checked;
            filterToDate.Enabled = !vehicleRadio3.Checked;
            vehicleFilters.Visible = vehicleRadio3.Checked;
        }
    }
}
