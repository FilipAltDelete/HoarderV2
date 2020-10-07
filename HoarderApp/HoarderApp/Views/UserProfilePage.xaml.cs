using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class UserProfilePage : ContentPage
    {
        AccountDetails SignedInUser;
        UserProfile SelectedUser;
        public UserProfilePage(AccountDetails signedInUser,UserProfile selectedUser)
        {
            SignedInUser = signedInUser;
            SelectedUser = selectedUser;
            InitializeComponent();
        }

    }
}
