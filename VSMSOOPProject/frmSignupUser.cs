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

using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VSMSOOPProject
{
    public partial class frmSignupUser : Form
    {
        public frmSignupUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string contact = textBox4.Text;
            string address = textBox5.Text;
            string email = textBox2.Text;

            clsDBHandler DB = new clsDBHandler();6
            bool IsSignin = DB.SignUp(username, password, contact, address, email);

            if (IsSignin)
            {
                frmLoginUser objfrmLoginUser = new frmLoginUser();
                objfrmLoginUser.Show();
            }
            else
            {
                MessageBox.Show("Signin Unsuccessful");
            }
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            frmWelcome obj = new frmWelcome();
            obj.Show();

            this.Hide();
        }

        private void frmSignupUser_Load(object sender, EventArgs e)
        {

        }
    }
}
