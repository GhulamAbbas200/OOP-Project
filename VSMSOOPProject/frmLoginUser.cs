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
    public partial class frmLoginUser : Form
    {
        public frmLoginUser()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-BSVHRGN; Initial Catalog = DB_VSMSOOPProject; Integrated Security = True");


        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = textBox1.Text;
            user_password = textBox3.Text;

            try 
            {
                string querry = "Select * from Customers where Username = '"+username+"'and  Password = '"+user_password+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox3.Text;

                    frmInventroy obj = new frmInventroy();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Details","Error", MessageBoxButtons.OK);
                    textBox1.Clear();
                    textBox3.Clear();

                    textBox1.Focus();
                }
            } 
            catch 
            {
                MessageBox.Show("Invalid Log in Details");
            } 
            finally 
            {
                conn.Close();
            }
        }

        private void frmLoginUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();

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
