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
    public partial class frmADUSupplier : Form
    {
        public frmADUSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Suppliers values(@SupplierID,@Username,@Password,@PhoneNumber)",con);
            cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@SupplierID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Supplier Added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDashboardAdmin obj = new frmDashboardAdmin();
            obj.Show();

            this.Hide();
        }

        private void frmADUSupplier_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
