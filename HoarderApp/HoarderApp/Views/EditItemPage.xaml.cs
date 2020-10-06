using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class EditItemPage : ContentPage
    {
        ItemDTO CurrentItem;
        CollectionDTO CurrentCollection;
        AccountDetails SignedInUser;

        public EditItemPage(ItemDTO currentItem, CollectionDTO currentCollection, AccountDetails signedInUser)
        {
            SignedInUser = signedInUser;
            CurrentItem = currentItem;
            CurrentCollection = currentCollection;
            InitializeComponent();
        }
    }
}
