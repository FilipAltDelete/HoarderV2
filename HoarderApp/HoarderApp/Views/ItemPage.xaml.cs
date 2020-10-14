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
        RestService service;

        public ItemPage(CollectionDTO collection, AccountDetails signedInUser)
        {
            service = new RestService();
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
        
         async void DeleteClickedItem(object sender, EventArgs e)
         {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.CommandParameter.ToString());

            var answer = await DisplayAlert("system Message", "Do you wan't to exit the App?", "Yes", "No");
            if (answer)
            {
                service.DeleteItem(id);
                var vUpdatedPage = new ItemPage(CurrentCollection, SignedInUser);
                Navigation.InsertPageBefore(vUpdatedPage, this);
                await Navigation.PopAsync();
            }
            
         }
        
        async void AddNewItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateItemPage(SignedInUser, CurrentCollection));
        }
    }
}
