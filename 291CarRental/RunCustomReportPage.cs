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
        AND [start_date] BETWEEN " + addQuotes(filterFromDate.Value.ToString("d")) + @" AND " + addQuotes(filterToDate.Value.ToString("d")) + branch + @" 
GROUP BY vehicle_class
ORDER BY [Number of times rented] " + flag;

            result.Load(connection.executeReader(query));
            return result;

        }

        // employee reports
        private DataTable employeeReport(String flag)
        {
            DataTable result = new DataTable();
            NumericUpDown numericUpDown = (flag.Equals("BEST") ? employeeNumeric1 : employeeNumeric2);
            flag = (flag.Equals("BEST") ? "DESC" : "ASC");
            String branch = (branchCombobox.SelectedIndex > 0 ?
               "\nAND branch_id = " + branchCombobox.SelectedIndex : "");
            String query = @"
SELECT 
	(SELECT CONCAT (first_name, ' ', last_name, ' (', emp_id, ')') FROM Employee WHERE E1.emp_id = Employee.emp_id) AS [Name (id)],
	(SELECT COUNT(*) FROM Rental WHERE E1.emp_id = Rental.emp_id_booking) [Number of rentals]
FROM
	(SELECT TOP (" + numericUpDown.Value.ToString() + @") E.emp_id
	FROM Employee E, Rental R
	WHERE E.emp_id = R.emp_id_booking
	    AND [start_date] BETWEEN " + addQuotes(filterFromDate.Value.ToString("d")) + @" AND " + addQuotes(filterToDate.Value.ToString("d")) + 
        branch + @"
        GROUP BY E.emp_id
        ORDER BY COUNT(*) " + flag + @") AS E1;
";

            //MessageBox.Show(query);
            result.Load(connection.executeReader(query));
            return result;
        }
       
        // branch reports
        private DataTable branchReport(String flag)
        {
            DataTable result = new DataTable();
            NumericUpDown numericUpDown = (flag.Equals("AT LEAST") ? branchNumeric1 : branchNumeric2);
            flag = (flag.Equals("AT LEAST") ? ">=" : "<");

            String query = @"
SELECT
	(SELECT branch_name FROM Branch WHERE Branch.branch_id = T1.pickup_branch_id) AS [Branch Name],
    (SELECT '(' + area_code + ')' + ' ' + phone_number FROM Branch WHERE Branch.branch_id = T1.pickup_branch_id) AS [Branch phone number],
	T1.[Number of Rentals]
FROM 
	(SELECT pickup_branch_id, COUNT(*) AS [Number of Rentals]
	FROM Branch, Rental
	WHERE Branch.branch_id = Rental.pickup_branch_id  
		AND [start_date] BETWEEN " + addQuotes(filterFromDate.Value.ToString("d")) + @" AND " + addQuotes(filterToDate.Value.ToString("d")) + @"
	GROUP BY pickup_branch_id
	HAVING COUNT (*) " + flag + numericUpDown.Value.ToString() + @") AS T1
";

            result.Load(connection.executeReader(query));
            return result;
        }
       
        private void reportCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disable branch filter when branch is selected
            branchCombobox.Enabled = reportCombobox.SelectedIndex != 2;

            // move whatever is visible away from the screen by offsetting their location
            // and show the content by updating it's  location to be visible
            // and update anything needed
            if (reportCombobox.SelectedIndex == 0)
            {// vehicle reports was selected
                employeeStatsPanel.Location = new Point(1000, 1000);
                branchStatsPanel.Location = new Point(1000, 1000);

                vehicleStatsPanel.Location = new Point(181, 60);
                filtersPanel.Location = new Point(181, 328);

            }
            if (reportCombobox.SelectedIndex == 1)
            {// employee reports was selected
                vehicleStatsPanel.Location = new Point(1000, 1000);
                branchStatsPanel.Location = new Point(1000, 1000);

                employeeStatsPanel.Location = new Point(181, 60);
                filtersPanel.Location = new Point(181, 250);
            }
            if (reportCombobox.SelectedIndex == 2)
            {//branch reports was selected
                vehicleStatsPanel.Location = new Point(1000, 1000);
                employeeStatsPanel.Location = new Point(1000, 1000);

                branchStatsPanel.Location = new Point(181, 60);
                filtersPanel.Location = new Point(181, 250);
            }
            foreach (Control radio in vehicleStatsPanel.Controls)
            {
                if (radio is RadioButton)
                {
                    ((RadioButton)radio).Checked = false;
                }
            }
            foreach (Control radio in employeeStatsPanel.Controls)
            {
                if (radio is RadioButton)
                {
                    ((RadioButton)radio).Checked = false;
                }
            }
            foreach (Control radio in branchStatsPanel.Controls)
            {
                if (radio is RadioButton)
                {
                    ((RadioButton)radio).Checked = false;
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //vehicle
            if (vehicleRadio1.Checked)
            {// requested and NOT available 
                reportsDataView.DataSource = classRequestedReport("!=");

                reportsDataView.Size = new Size(386, 192);
                reportsDataView.Location = new Point(411, 606);
                this.Size = new Size(this.Width, 900);
            }
            else if (vehicleRadio2.Checked)
            {// requested and was availablee
                reportsDataView.DataSource = classRequestedReport("=");

                reportsDataView.Size = new Size(386, 192);
                reportsDataView.Location = new Point(411, 606);
                this.Size = new Size(this.Width, 900);
            }
            else if (vehicleRadio3.Checked)
            {// mileage report
                reportsDataView.DataSource = mileageReport();

                reportsDataView.Size = new Size(1000, 192);
                reportsDataView.Location = new Point(111, 601);
                this.Size = new Size(this.Width, 900);
                
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
            }
           
            //employee
            else if (employeeRadio1.Checked)
            {
                reportsDataView.DataSource = employeeReport("BEST");

                reportsDataView.Location = new Point(411, 606);
                reportsDataView.Size = new Size(386, 192);
                this.Size = new Size(this.Width, 900);
            }
            else if (employeeRadio2.Checked)
            {
                reportsDataView.DataSource = employeeReport("WORST");

                reportsDataView.Location = new Point(411, 606);
                reportsDataView.Size = new Size(386, 192);
                this.Size = new Size(this.Width, 900);
            }
            
            // branch
            else if (branchRadio1.Checked)
            {
                reportsDataView.DataSource = branchReport("AT LEAST");

                reportsDataView.Location = new Point(330, 606);
                reportsDataView.Size = new Size(520, 192);
                this.Size = new Size(this.Width, 900);
            }
            else if (branchRadio2.Checked)
            {
                reportsDataView.DataSource = branchReport("LESS THAN");

                reportsDataView.Location = new Point(330, 606);
                reportsDataView.Size = new Size(520, 192);
                this.Size = new Size(this.Width, 900);
            }
            this.CenterToScreen();
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
