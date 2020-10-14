using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class RegisterUserPage : ContentPage
    {
        RestService service;
        public RegisterUserPage()
        {
            service = new RestService();
            InitializeComponent();
            Init();
        }
        void Init()
        {
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_Password2.Focus();
            Entry_Password2.Completed += (s, e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Location.Focus();
            Entry_Location.Completed += (s, e) => Entry_Contact.Focus();
            Entry_Contact.Completed += (s, e) => Entry_ProfileName.Focus();
            Entry_ProfileName.Completed += (s, e) => Entry_ProfileName.Focus();
            Entry_ProfileName.Completed += (s, e) => RegisterProcedure(s, e);
        }

        async void RegisterProcedure(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser(Entry_Username.Text,
                Entry_Password.Text,
                Entry_Password2.Text,
                Entry_Email.Text,
                Entry_Location.Text,
                Entry_Contact.Text,
                Entry_ProfileName.Text);
            await service.CreateNewUser(newUser);

            Application.Current.MainPage = new LoginPage();
        }
    }
}
