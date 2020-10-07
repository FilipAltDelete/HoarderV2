using System;
using System.Collections.Generic;
using HoarderApp.Models;
using HoarderApp.API;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HoarderApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            //BackgroundColor = Constants.BackgroundColor;
            //loginicon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            Constants.User = new AccountDetails(Entry_Username.Text, Entry_Password.Text);
            RestService service = new RestService();

            AccountDetails userFromDB = await service.SignIn(Constants.apiURLLocal, Constants.User);

            if(userFromDB == null)
            {
                await DisplayAlert("Login", "Login Failed, wrong username and password", "Proceed");
            }
            else
            {
                await DisplayAlert("Login", "Login Success!", "Proceed");
                GoToSignedInContentPage(userFromDB);


            }
           
        }
        private void GoToSignedInContentPage(AccountDetails signedInUser)
        {
            Application.Current.MainPage = new NavigationPage(new SignedInContentPage(signedInUser));
            //Navigation.PushModalAsync(new SignedInContentPage(signedInUser));
        }
    }
}
