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
    public partial class frmSignupUser : Form
    {
        public frmSignupUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-BSVHRGN;Initial Catalog=DB_VSMSOOPProject;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    // Specify column names in the INSERT statement
                    string query = "INSERT INTO Customers (CustomerID,Username, Password, PhoneNumber, Address) VALUES (@CustomerID,@Username, @Password, @PhoneNumber, @Address)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters with explicit SqlDbType
                        cmd.Parameters.Add("@CustomerID",SqlDbType.Int).Value=textBox2.Text;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = textBox3.Text;
                        cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = textBox4.Text;  // Assuming textBox4 is for PhoneNumber
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = textBox5.Text;

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account created successfully!");

                    // Show the welcome form only on success
                    frmWelcome obj = new frmWelcome();
                    obj.Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
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
