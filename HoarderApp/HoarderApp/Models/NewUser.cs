using System;
namespace HoarderApp.Models
{
    public class NewUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string ProfileName { get; set; }

        public NewUser(
            string username,
            string password,
            string verifyPassword,
            string email,
            string location,
            string contact,
            string profileName)
        {
            this.Username = username;
            this.Password = password;
            this.VerifyPassword = verifyPassword;
            this.Email = email;
            this.Location = location;
            this.Contact = contact;
            this.ProfileName = profileName;
        }

    }
}
