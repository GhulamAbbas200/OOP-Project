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
    public partial class frmLoginSalesman : Form
    {
        public frmLoginSalesman()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                string querry = "Select * from Salesmen where Username = '" + username + "'and  Password = '" + user_password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;

                    frmDashboardSalesman obj = new frmDashboardSalesman();
                    obj.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Details", "Error", MessageBoxButtons.OK);
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Log in Details");
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmWelcome obj = new frmWelcome();
            obj.Show();

            this.Hide();
        }
    }
}
