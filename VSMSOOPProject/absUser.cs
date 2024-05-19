using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VSMSOOPProject
{
    internal class absUser
    {
        private string username;
        private string password;
        private string email;
        private string phoneNumber;
        private string address;
        private string role;

        public absUser(string username, string password, string email, string phoneNumber, string address, string role)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.role = role;
        }

        public abstract class User
        {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username must be between 1 and 50 characters", MinimumLength = 1)]
        public abstract string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 1 and 100 characters", MinimumLength = 1)]
        public abstract string Password { get; set; }

        [StringLength(100, ErrorMessage = "Email must be at most 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public abstract string Email { get; set; }

        [StringLength(20, ErrorMessage = "Phone number must be at most 20 characters")]
        public abstract string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public abstract string Address { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(50, ErrorMessage = "Role must be between 1 and 50 characters", MinimumLength = 1)]
        public abstract string Role { get; set; }

        // Constructor
        protected User(string username, string password, string email, string phoneNumber, string address, string role)
        {
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Role = role;
        }

        // Abstract method for sign-in
        public abstract bool SignIn(string username, string password);

        // Abstract method for login
        public abstract bool Login(string username, string password);
    }

}
    }
}
