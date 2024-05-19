using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSMSOOPProject
{
    public partial class DeleteVehicle : Form
    {
        public DeleteVehicle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             frmDashboardAdmin obj = new frmDashboardAdmin();
            obj.Show();

            this.Hide();
        }
    }
}
