﻿using System;
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
    public partial class frmLoginSupplier : Form
    {
        public frmLoginSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True");

            string username, user_password;

            username = textBox1.Text;
            user_password = textBox3.Text;

            try
            {
                string querry = "Select * from Suppliers where Username = '" + username + "'and  Password = '" + user_password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox3.Text;

                    frmDashboardSupplier obj = new frmDashboardSupplier();
                    obj.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Details", "Error", MessageBoxButtons.OK);
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
                con.Close();
            }
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
