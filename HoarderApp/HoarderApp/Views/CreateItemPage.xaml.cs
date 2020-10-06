using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;

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
    }
}
