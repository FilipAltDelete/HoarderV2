using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;
using HoarderApp.API;
namespace HoarderApp.Views
{
    public partial class CreateItemPage : ContentPage
    {
        AccountDetails SignedInUser;
        CollectionDTO CurrentCollection;
        public CreateItemPage(AccountDetails signedInUser,CollectionDTO currentCollection)
        {
            SignedInUser = signedInUser;
            CurrentCollection = currentCollection;
            SignedInUser = signedInUser;
            InitializeComponent();
        }
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            RestService service = new RestService();
            ItemDTO newitem = new ItemDTO();

            newitem.ItemName = newItemName.Text;
            newitem.ForSale = false;
            newitem.UserCollectionsId = CurrentCollection.Id;
            if (newitem != null || newitem.ItemName != "")
            {
                service.PostNewItemToDB(newitem).Wait();
                await Navigation.PushAsync(new CollectionPage(SignedInUser));

            }


        }
    }
}
