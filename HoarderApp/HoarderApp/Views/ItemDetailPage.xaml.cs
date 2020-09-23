using System.ComponentModel;
using Xamarin.Forms;
using HoarderApp.ViewModels;

namespace HoarderApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}