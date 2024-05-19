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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VSMSOOPProject
{
    public partial class frmLoginSupplier : Form
    {
        public frmLoginSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password, tableName = "Suppliers";
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

        private void frmLoginSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
