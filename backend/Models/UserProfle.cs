using System;

namespace backend.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string ProfileName { get; set; }

    }
}
