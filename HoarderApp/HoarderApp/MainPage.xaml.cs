using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoarderApp.API;
using Xamarin.Forms;

namespace HoarderApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            loginicon.Source = "http://localhost:5000/api/image";
        }

       
    }
}
