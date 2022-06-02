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
    public partial class StartAReturnPage : Form
    {
        public StartAReturnPage()
        {
            InitializeComponent(); 
            this.StartPosition = FormStartPosition.CenterScreen;
            amountDuePanel.Visible = false;
        }

        private void calculateAmountDue_ButtonClicked(object sender, EventArgs e)
        {
            amountDuePanel.Visible = true;
        }

        private void finishReturn_ButtonClicked(object sender, EventArgs e)
        {
            DialogResult confirmPayment = MessageBox.Show(
                "HAS THE CUSTOMER PAID THE AMOUNT DUE OF $120?", 
                "CONFIRM PAYMENT", 
                MessageBoxButtons.YesNo);

            if (confirmPayment == DialogResult.Yes)
            {
                DialogResult confirmReturn = MessageBox.Show(

              "Confirm returning of 2022 TOYOTA COROLLA for JOHN SMITH (031)",
              "CONFIRM RETURN VEHICLE",
              MessageBoxButtons.YesNo);

                if (confirmReturn == DialogResult.Yes)
                {
                    MessageBox.Show("VEHICLE RETURNED SUCCESSFULLY");
                }
                else if (confirmReturn == DialogResult.No)
                {
                    MessageBox.Show("VEHICLE RETURN CANCELLED");
                }
            }
            else if(confirmPayment == DialogResult.No)
            {
                MessageBox.Show("COLLECT PAYMENT FROM THE CUSTOMER");
            }
            
        }
    }
}
