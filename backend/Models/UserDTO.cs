namespace backend.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int AccountDetailsId { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}