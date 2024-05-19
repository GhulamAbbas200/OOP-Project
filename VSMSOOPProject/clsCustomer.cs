using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMSOOPProject
{
    internal class clsCustomer : absUser
    {
        // Constructor
        public clsCustomer(string username, string password, string email, string phoneNumber, string address, string role): base(username, password, email, phoneNumber, address, role)
        {

        }

        // Implement abstract methods for sign-in and login
        public override bool SignIn(string username, string password)
        {

        }

        public override bool Login(string username, string password)
        {
            // Implement login logic specific to Customers
            throw new NotImplementedException();
        }
    }

}
}
