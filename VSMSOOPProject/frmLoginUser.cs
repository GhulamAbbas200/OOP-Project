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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            clsCustomer objclsCustomer = new clsCustomer();
            string username, user_password, tableName = "Customers";
            clsDBHandler DB = new clsDBHandler();

            username = textBox1.Text;
            user_password = textBox2.Text;

            if (DB.mtdCheckUser(username, tableName, user_password))
            {
                frmInventroy obj = new frmInventroy();
                obj.Show();

            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void frmLoginUser_Load(object sender, EventArgs e)
        {

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
