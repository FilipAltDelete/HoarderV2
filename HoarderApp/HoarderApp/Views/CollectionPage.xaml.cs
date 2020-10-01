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
            var collections = await service.GetCollections(Constants.apiURL, user);

            
        } 
    }
}
