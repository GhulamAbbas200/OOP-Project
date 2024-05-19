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

namespace VSMSOOPProject
{
    public partial class frmADUSalesman : Form
    {
        public frmADUSalesman()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDashboardAdmin obj = new frmDashboardAdmin();
            obj.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Salesmen values(@Username,@Password)", con);
            MessageBox.Show("Supplier Added successfully!");
        }
    }
}
