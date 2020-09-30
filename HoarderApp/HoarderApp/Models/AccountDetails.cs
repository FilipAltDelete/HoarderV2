using System;
namespace HoarderApp.Models
{
    public class AccountDetails
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AccountDetails() { }
        public AccountDetails(string username, string password) { this.Username = username; this.Password = password; }
        public AccountDetails(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

    }
}
