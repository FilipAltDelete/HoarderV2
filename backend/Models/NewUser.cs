namespace backend.Models
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
    }
}