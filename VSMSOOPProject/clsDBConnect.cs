using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VSMSOOPProject
{
    internal class clsDBHandler
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T7IMJL\SQLEXPRESS;Initial Catalog=VSMS-DB_OOP-FP;Integrated Security=True;");

        public bool mtdCheckUser(string username, string tableName, string password)
        {
            bool IsLoginSuccess = false;

            try
            {
                    con.Open();
                    string query = $"SELECT * FROM {tableName} WHERE Username = '{username}' AND Password = '{password}'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        IsLoginSuccess = true;

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK);
                        return false;
                    }

                    reader.Close();
                }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return IsLoginSuccess;
        }

        public bool SignUp(string username, string password, string contact, string address, string email)
        {
            try
            {
                // Open connection
                con.Open();

                // Construct the query string
                string query = $"INSERT INTO Customers (Username, Password, Email, PhoneNumber, ,Address, Role) VALUES " +
                               $"('{username}', '{password}', '{email}', '{contact}', '{address}', 'Customer')";

                // Create and execute the command
                SqlCommand cmd = new SqlCommand(query, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the insertion was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Signup successful!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
            finally
            {
                // Close connection
                con.Close();
            }
        }
    }
}
