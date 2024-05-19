using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VSMSOOPProject
{
    public partial class frmDashboardAdmin : Form
    {
        public frmDashboardAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmADUSupplier obj = new frmADUSupplier();
            obj.Show();

            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewSupplier obj = new ViewSupplier();
            obj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteSupplier obj = new DeleteSupplier();
            obj.Show();

            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmADUSalesman obj = new frmADUSalesman();
            obj.Show();

            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteSalesmen obj = new DeleteSalesmen();
            obj.Show();

            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewSalesmen obj = new ViewSalesmen();
            obj.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmADUVehicles obj = new frmADUVehicles();
            obj.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteVehicle obj = new DeleteVehicle();
            obj.Show();

            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Viewvehicle obj = new Viewvehicle();
            obj.Show();

            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmWelcome obj = new frmWelcome();
            obj.Show();
            this.Hide();
        }
    }
}
