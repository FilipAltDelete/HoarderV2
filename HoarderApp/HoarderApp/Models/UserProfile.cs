using System;
namespace HoarderApp.Models
{
    public class UserProfile
    {

        public int Id { get; set; }
        public int AccountDetailsId { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string ProfileName { get; set; }

        

    }
}
