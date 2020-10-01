using System;
using System.Collections.Generic;
using HoarderApp.Models;
using HoarderApp.API;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoarderApp.Views
{
    public partial class SignedInContentPage : ContentPage
    {
        AccountDetails User;
        public SignedInContentPage(AccountDetails signedInUser )
        {
            InitializeComponent();
            User = signedInUser;
            Welcome.Text = signedInUser.Username;
        }



        async void GoToCollection(object sender, EventArgs e)
        {
            //CollectionPage CollectionPage ();
            await Navigation.PushModalAsync(new CollectionPage(User) );
        }
    }
}
