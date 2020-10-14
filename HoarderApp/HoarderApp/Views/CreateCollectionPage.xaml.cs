using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;
using HoarderApp.API;
namespace HoarderApp.Views
{
    public partial class CreateCollectionPage : ContentPage
    {
        AccountDetails SignedInUser;
     
        public CreateCollectionPage(AccountDetails signedInUser)
        {
            SignedInUser = signedInUser;
            InitializeComponent();
            
            Console.WriteLine("Debug");
        }

       async void AddCollection_Clicked(object sender, EventArgs e)
        {
            RestService service = new RestService();
            CollectionDTO newCollection = new CollectionDTO();
            newCollection.CollectionName = newCollectionName.Text;
            newCollection.IsShared = false;
            newCollection.UserProfileId = Convert.ToInt32(SignedInUser.Id);
            if (newCollection != null||newCollection.CollectionName!="")
            {
                service.PostNewColldectionToDB(newCollection).Wait();
                var vUpdatedPage = new CollectionPage(SignedInUser);
                Navigation.InsertPageBefore(vUpdatedPage, this);
                await Navigation.PopAsync();

            }


        }
    }
}
