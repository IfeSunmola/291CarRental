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
        EmployeeLandingPage previousPage;
        public RunCustomReportPage(EmployeeLandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }
    }
}
