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
            Title = signedInUser.Username;
            //Welcome.Text = signedInUser.Username;
        }



        async void GoToCollection(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionPage(User) );
        }
        async void GoToBrowseUsers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowseUsers(User));
        }
    }
}
