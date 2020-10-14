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
        RestService service;
        public CollectionPage(AccountDetails User)
        {
            service = new RestService();
            SignedInUser = User;
            InitializeComponent();
            GetCollectionsFromDB(User);
            Title = "Collections";
            

        }

        async void GetCollectionsFromDB(AccountDetails user)
        {
            List<CollectionDTO> collections = await service.GetCollections(user);
            CollectionListView.ItemsSource = collections;
            BindingContext = collections;

            
        }

        async void ClickedOnCollection(object sender, EventArgs e)
        {
            var myListView = (ListView)sender;
            CollectionDTO collection = (CollectionDTO)myListView.SelectedItem;
            

            await Navigation.PushAsync(new ItemPage(collection, SignedInUser));
        }

        async void DeleteClickedCollection(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.CommandParameter.ToString());

            var answer = await DisplayAlert("Delete Collection", "Are you sure?", "Yes", "No");
            if (answer)
            {
                
                service.DeleteCollection(id);
                var vUpdatedPage = new CollectionPage(SignedInUser);
                Navigation.InsertPageBefore(vUpdatedPage, this);
                await Navigation.PopAsync();
                
            }

        }

        async void AddNewCollection(object sender, EventArgs e)
        {
            //signedInUser = SignedInUser;
            await Navigation.PushAsync(new CreateCollectionPage(SignedInUser));
        }
    }
}
