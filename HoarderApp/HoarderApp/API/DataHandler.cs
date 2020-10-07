using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoarderApp.Models;

namespace HoarderApp.API
{
    public class DataHandler
    {
        public DataHandler()
        {
        }


        public async Task<List<Item>> GenerateItem(CollectionDTO collection)
        {
            RestService service = new RestService();
            List<ItemDTO> DTOitems = await service.GetItemsFromDB(collection);
            List<string> imageURLS = await service.GetAllImages(collection);
            List<Item> items = new List<Item>();
            int i = 0;
            foreach (var item in DTOitems)
            {
                Item it = new Item();
                it.Id = item.Id;
                it.ItemName = item.ItemName;
                it.Description = item.Description;
                it.AuctionURL = item.AuctionURL;
                it.ForSale = item.ForSale;
                it.ImageURL = imageURLS[i];
                items.Add(it);
                i++;
            }

            return items;
        }
    }
}
