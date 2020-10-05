using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage(AccountDetails User)
        {
            InitializeComponent();
            GetCollectionsFromDB(User);


        }

        async void GetCollectionsFromDB(AccountDetails user)
        {
            RestService service = new RestService();
            List<CollectionDTO> collections = await service.GetCollections(Constants.apiURL, user);
            BindingContext = collections;
            
        }

        async void ClickedOnCollection(object sender, EventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;

            //await Navigation.PushAsync(new CollectionPage(User));
        }
    }
}
