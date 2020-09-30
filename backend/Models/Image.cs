namespace backend.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string ImageURL { get; set; }
    }
    public class ImageData
    {
        public string Image { get; set; }
    }
}