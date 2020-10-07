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
            List<ImageDTO> imageURLS = await service.GetAllImages(collection);
            List<Item> items = new List<Item>();

            foreach(var item in DTOitems)
            {
                foreach(var image in imageURLS)
                {
                    if(item.Id == image.ItemId)
                    {
                        Item it = new Item();
                        it.Id = item.Id;
                        it.ItemName = item.ItemName;
                        it.Description = item.Description;
                        it.AuctionURL = item.AuctionURL;
                        it.ForSale = item.ForSale;
                        it.ImageURL = image.ImageURL;
                        items.Add(it);
                    }
                }
            }

            return items;
        }
    }
}
