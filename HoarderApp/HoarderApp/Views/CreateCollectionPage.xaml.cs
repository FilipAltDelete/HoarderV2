using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;

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
    }
}
