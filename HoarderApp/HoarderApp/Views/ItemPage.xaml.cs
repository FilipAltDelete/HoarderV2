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

            DataHandler data = new DataHandler();
            List<Item> items = await data.GenerateItem(collection);

            ItemListview.ItemsSource = items;
            BindingContext = items;
        }

        async void OnClickedItem(object sender, EventArgs e)
        {
            var listView = (ListView)sender;
            Item selectedItem = (Item)listView.SelectedItem;

            await Navigation.PushAsync(new ItemContentPage(selectedItem, CurrentCollection, SignedInUser));
        }

        void DeleteClickedItem(object sender, EventArgs e)
        {
            var listView = (ListView)sender;
            Item selectedItem = (Item)listView.SelectedItem;

            Console.WriteLine("asd");
        }

        async void AddNewItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateItemPage(SignedInUser, CurrentCollection));
        }

    }
}
