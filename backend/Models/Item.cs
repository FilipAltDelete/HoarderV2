namespace backend.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int UserCollectionsId { get; set; }
        public UserCollections UserCollections { get; set; }
        public string Description { get; set; }
        public bool ForSale { get; set; }
        public string AuctionURL { get; set; }
        public string ImageId { get; set; }
    }
}