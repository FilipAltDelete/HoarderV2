using System;
namespace HoarderApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public bool ForSale { get; set; }
        public string AuctionURL { get; set; }
        public string ImageURL { get; set; }
    }
}
