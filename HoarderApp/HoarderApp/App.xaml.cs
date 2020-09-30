﻿using System;
using HoarderApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoarderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
