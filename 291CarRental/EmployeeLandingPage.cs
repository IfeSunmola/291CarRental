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
    public partial class EmployeeLandingPage : Form
    {
        
        public EmployeeLandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EmpViewVehiclesInfoRequest().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new VehicleToolsPage().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ReturnAVehiclePage().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new RunCustomReportPage().Show();  
        }
    }
}
