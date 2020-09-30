using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class SignedInContentPage : ContentPage
    {
        public SignedInContentPage(AccountDetails signedInUser )
        {
            InitializeComponent();
            Welcome.Text = "Välkommen " + signedInUser.Username + "!";
        }
    }
}
