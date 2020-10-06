using System;
using System.Collections.Generic;
using HoarderApp.Models;
using HoarderApp.API;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class ItemPage : ContentPage
    {
        AccountDetails SignedInUser;
        CollectionDTO CurrentCollection;
        public ItemPage(CollectionDTO collection, AccountDetails signedInUser)
        {
            SignedInUser = signedInUser;
            CurrentCollection = collection;
            InitializeComponent();
            GetItemsDB(collection);
        }

        async void GetItemsDB(CollectionDTO collection)
        {
            Title = collection.CollectionName;
            RestService service = new RestService();
            List<ItemDTO> DTOitems = await service.GetItemsFromDB(collection);
            List<string> imageURLS = await service.GetAllImages(collection);
            List<Item> items = new List<Item>();
            int i = 0;
            foreach(var item in DTOitems)
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

            ItemListview.ItemsSource = items;
            BindingContext = items;
        }

        async void OnClickedItem(object sender, EventArgs e)
        {
            var myListView = (ListView)sender;
            Item myItem = (Item)myListView.SelectedItem;


            await Navigation.PushAsync(new ItemContentPage(myItem, CurrentCollection, SignedInUser));
        }

        async void AddNewItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateItemPage(SignedInUser, CurrentCollection));
        }
    }
}
