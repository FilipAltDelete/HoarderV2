using System;
using System.Collections.Generic;
using HoarderApp.Models;
using HoarderApp.API;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class ItemPage : ContentPage
    {
        public ItemPage(CollectionDTO collection)
        {

            InitializeComponent();
            GetItemsDB(collection);
        }

        async void GetItemsDB(CollectionDTO collection)
        {
            RestService service = new RestService();
            List<ItemDTO> items = await service.GetItemsFromDB(collection);
            ItemListview.ItemsSource = items;
            
            BindingContext = items;
        }
    }
}
