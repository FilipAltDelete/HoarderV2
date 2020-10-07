using System;
using System.Collections.Generic;
using HoarderApp.Models;
using Xamarin.Forms;
using HoarderApp.API;
using System.Linq;

namespace HoarderApp.Views
{
    public partial class BrowseUsers : ContentPage
    {
        AccountDetails SignedInUser;
        public BrowseUsers(AccountDetails User)
        {
            SignedInUser = User;
            InitializeComponent();
            GetUsersFromDB(User);
            Title = "Browse Users";
        }
        async void GetUsersFromDB(AccountDetails user)
        {
            RestService service = new RestService();
            List<UserProfile> usersFromDB = await service.GetUsers(Constants.apiURLLocal, user);
            var users= usersFromDB.Where(c => c.AccountDetailsId != SignedInUser.Id).ToList();
            
            UserListView.ItemsSource = users;
            
            BindingContext = users;


        }
        async void OnClickedUser(object sender, EventArgs e)
        {
            var listView = (ListView)sender;
            UserProfile selectedUser = (UserProfile)listView.SelectedItem;

            await Navigation.PushAsync(new UserProfilePage(SignedInUser, selectedUser));
        }


    }
}
