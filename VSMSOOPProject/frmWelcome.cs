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
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInventroy obj = new frmInventroy();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLoginUser obj = new frmLoginUser();
            obj.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLoginSalesman obj = new frmLoginSalesman();
            obj.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLoginAdmin obj = new frmLoginAdmin();
            obj.Show();

            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmLoginSupplier obj = new frmLoginSupplier();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSignupUser obj = new frmSignupUser();
            obj.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {

        }
    }
}
