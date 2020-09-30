﻿using System;
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
            ActivitySpinner.IsVisible = false;
            //loginicon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            AccountDetails user = new AccountDetails(Entry_Username.Text, Entry_Password.Text);
            RestService service = new RestService();

            AccountDetails userFromDB = await service.SignIn(Constants.apiURL, user);

            if(userFromDB == null)
            {
                await DisplayAlert("Login", "Login Failed, wrong username and password", "Proceed");
            }
            else
            {
                await DisplayAlert("Login", "Login Success!", "Proceed");
                GoToSignedIdContentPage(userFromDB);


            }
           
        }
        private void GoToSignedIdContentPage(AccountDetails signedInUser)
        {
            Navigation.PushModalAsync(new SignedInContentPage(signedInUser));
        }
    }
}