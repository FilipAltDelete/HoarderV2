namespace backend.Models
{
    public class UserCollections
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public bool IsShared { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}