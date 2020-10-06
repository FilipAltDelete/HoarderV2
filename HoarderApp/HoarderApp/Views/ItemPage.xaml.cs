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
            List<ItemDTO> items = await service.GetItemsFromDB(collection);
            ItemListview.ItemsSource = items;
            
            BindingContext = items;
        }

        async void OnClickedItem(object sender, EventArgs e)
        {
            var myListView = (ListView)sender;
            ItemDTO myItem = (ItemDTO)myListView.SelectedItem;


            await Navigation.PushAsync(new ItemContentPage(myItem, CurrentCollection, SignedInUser));
        }

        async void AddNewItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateItemPage(SignedInUser, CurrentCollection));
        }
    }
}
