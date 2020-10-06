using System;
namespace HoarderApp.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int UserCollectionsId { get; set; }
        public string Description { get; set; }
        public bool ForSale { get; set; }
        public string AuctionURL { get; set; }
        public string ImageId { get; set; }


        public override string ToString()
        {
            return ItemName;
        }
    }
}
