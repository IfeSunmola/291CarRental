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

            this.Size = new Size(1479, 550);
            this.CenterToScreen();
            this.connection = connection;
            fillReportComboBox();
            fillBranchCombobox();
        }

        private void fillBranchCombobox()
        {
            topBranchCombobox.Items.Add("ALL BRANCHES");
            bottomBranchCombobox.Items.Add("ALL BRANCHES");
            String query = "SELECT branch_name FROM Branch;";
            SqlDataReader reader = connection.executeReader(query);
            while (reader.Read())
            {
                topBranchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
                bottomBranchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            topBranchCombobox.SelectedIndex = 0;
            bottomBranchCombobox.SelectedIndex = 0;
        }
        
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void fillReportComboBox()
        {
            reportCombobox.Items.Add("EMPLOYEES STATISTICS");
            reportCombobox.Items.Add("BRANCH STATISTICS");
            reportCombobox.Items.Add("VEHICLE CLASS STATISTICS");
            reportCombobox.SelectedIndex = 0;
            reportCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        private DataTable generateEmployeeStats(String flag, NumericUpDown numOfEmployees, DateTimePicker fromDate, DateTimePicker toDate, ComboBox branch)
        {
            //int currentBranchid = branch.SelectedIndex + 1;
            DataTable result = new DataTable();
            String query = @"
SELECT 
	(SELECT CONCAT (first_name, ' ', last_name, ' (', emp_id, ')') FROM Employee WHERE E1.emp_id = Employee.emp_id) AS [Name (id)],
	(SELECT COUNT(*) FROM Rental WHERE E1.emp_id = Rental.emp_id_booking) [Number of rentals]
FROM
	(SELECT TOP (" + numOfEmployees.Value.ToString() + @") E.emp_id
	FROM Employee E, Rental R
	WHERE E.emp_id = R.emp_id_booking
	    AND [start_date] BETWEEN " + addQuotes(fromDate.Value.ToString("d")) + @" AND " + addQuotes(toDate.Value.ToString("d"));

            if (branch.SelectedIndex != 0)// all branches was NOT selected
            {
                query += "AND E.branch_id = " + branch.SelectedIndex;
            }

            query += "\nGROUP BY E.emp_id\nORDER BY COUNT(*) " + flag + ") AS E1;";
            result.Load(connection.executeReader(query));
            return result;
        }

        private DataTable generateBranchStats(String flag, NumericUpDown number, DateTimePicker fromDate, DateTimePicker toDate)
        {
            DataTable result = new DataTable();
            String query = @"
SELECT
	(SELECT branch_name FROM Branch WHERE Branch.branch_id = T1.pickup_branch_id) AS [Branch Name],
    (SELECT '(' + area_code + ')' + ' ' + phone_number FROM Branch WHERE Branch.branch_id = T1.pickup_branch_id) AS [Branch phone number],
	T1.[Number of Rentals]
FROM 
	(SELECT pickup_branch_id, COUNT(*) AS [Number of Rentals]
	FROM Branch, Rental
	WHERE Branch.branch_id = Rental.pickup_branch_id  
		AND [start_date] BETWEEN " + addQuotes(fromDate.Value.ToString("d")) + @" AND " + addQuotes(toDate.Value.ToString("d")) +  @"
	GROUP BY pickup_branch_id
	HAVING COUNT (*) " + flag + number.Value.ToString() + @") AS T1
";

            result.Load(connection.executeReader(query));
            MessageBox.Show(query);
            return result;
        }
        
        private DataTable vehicleClassRequested()
        {
            DataTable result = new DataTable();
            String query = "";
            result.Load(connection.executeReader(query));
            return result;
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

        private void reportCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportCombobox.SelectedIndex == 0)
            {// emp stats selected
                employeeStatsPanel.Location = new Point(68, 77);
                branchStatsPanel.Location = new Point(68, 768);
                vehicleStatsPanel.Location = new Point(68, 1111);
            }
            if (reportCombobox.SelectedIndex == 1)
            {// branch stats selected
                branchStatsPanel.Location = new Point(68, 77);
                employeeStatsPanel.Location = new Point(68, 768);
                vehicleStatsPanel.Location = new Point(68, 1111);
            }
            if (reportCombobox.SelectedIndex == 2)
            {// vehicle class stats selected
                vehicleStatsPanel.Location = new Point(68, 77);
                employeeStatsPanel.Location = new Point(68, 768);
                branchStatsPanel.Location = new Point(68, 1111);
            }
            this.Size = new Size(1479, 550);
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

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (reportCombobox.SelectedIndex == 0)// emp stats
            {
                if (topRadioButton.Checked)
                {
                    reportsDataView.DataSource = generateEmployeeStats("DESC", topNumericUpdown, topFromDatePicker, topToDatePicker, topBranchCombobox);
                    //reportsDataView.AutoResizeColumns();
                    //reportsDataView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    //sizeDGV(reportsDataView);

                }
                if (bottomRadioButton.Checked)
                {
                    reportsDataView.DataSource = generateEmployeeStats("ASC", bottomNumericUpdown, bottomFromDatePicker, bottomToDatePicker, bottomBranchCombobox);
                    //reportsDataView.AutoResizeColumns();
                    //reportsDataView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    //sizeDGV(reportsDataView);
                }
            }
            else if (reportCombobox.SelectedIndex == 1)// branch stats
            {
                if (branchTopRadio.Checked)
                {
                    reportsDataView.DataSource = generateBranchStats(">=", branchNumericUpdown1, branchUpFromDate, branchUpToDate);
                }
                if (branchBottomRadio.Checked)
                {
                    reportsDataView.DataSource = generateBranchStats("<", branchNumericUpdown2, branchDownFromDate, branchDownToDate);
                }
            }
            reportsDataView.AutoResizeColumns();
            this.Size = new Size(1478, 820);
            this.CenterToScreen();
        }
    }
}
