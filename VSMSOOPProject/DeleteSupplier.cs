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
    public partial class DeleteSupplier : Form
    {
        public DeleteSupplier()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Suppliers where Username=@Username and Password=@Password", con);
            cmd.Parameters.AddWithValue("@Username", textBox6.Text);
            cmd.Parameters.AddWithValue("@Password", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Supplier deleted successfully");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDashboardAdmin obj = new frmDashboardAdmin();
            obj.Show();

            this.Hide();
        }
    }
}
