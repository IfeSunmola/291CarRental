using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            this.StartPosition = FormStartPosition.CenterScreen;
            this.connection = connection;
            fillComboBox();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void fillComboBox()
        {
            reportCombobox.Items.Add("EMPLOYEES STATISTICS");
            reportCombobox.Items.Add("BRANCH STATISTICS");
            reportCombobox.SelectedIndex = 0;
            reportCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private DataTable generateEmpStats()
        {
            DataTable result = new DataTable();
            if (radioButton1.Checked)
            {
                String query = @"SELECT 
	(SELECT first_name + ' ' + last_name FROM Employee WHERE emp_id_booking = emp_id) [Employee Name],
	COUNT(*) [Number of rentals]
FROM Rental
GROUP BY emp_id_booking
ORDER BY [Number of rentals] DESC";
                result.Load(connection.executeReader(query));
            }
            else if (radioButton2.Checked)
            {

            }
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
            {
                //radioButton1.Text = "EMPLOYEES WITH THE MOST RENTALS";
                radioButton1.Text = "AMOUNT OF RENTALS EACH EMPLOYEE HAS MADE";
                radioButton2.Text = "EMPLOYEES WITH THE LEAST RENTALS";
            }
            else if(reportCombobox.SelectedIndex == 1)
            {
                radioButton1.Text = "BRANCHES WITH THE MOST VEHICLE CLASSES RENTED";
                radioButton2.Text = "BRANCHES WITH THE LEAST VEHICLE CLASSES RENTED";
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (reportCombobox.SelectedIndex == 0)// emp stats
            {
                if (radioButton1.Checked)
                {
                    reportsDataView.DataSource = generateEmpStats();
                    //disable sorting the columns
                    foreach (DataGridViewColumn dataGridViewColumn in reportsDataView.Columns)
                    {
                        dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    reportsDataView.Size = new Size(335, 192);
                    reportsDataView.Location = new Point(249, 294);
                }
            }
            else if (reportCombobox.SelectedIndex == 1)// branch stats
            {

            }
        }
    }
}
