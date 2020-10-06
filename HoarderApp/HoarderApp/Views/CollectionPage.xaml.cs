using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class CollectionPage : ContentPage
    {
        AccountDetails SignedInUser;
        public CollectionPage(AccountDetails User)
        {
            SignedInUser = User;
            InitializeComponent();
            GetCollectionsFromDB(User);
            Title = "Collections";
            

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
            CollectionDTO collection = (CollectionDTO)myListView.SelectedItem;
            

            await Navigation.PushAsync(new ItemPage(collection, SignedInUser));
        }

        async void AddNewCollection(object sender, EventArgs e)
        {
            //signedInUser = SignedInUser;
            await Navigation.PushAsync(new CreateCollectionPage(SignedInUser));
        }
    }
}
