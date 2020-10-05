using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class ItemContentPage : ContentPage
    {
        public ItemContentPage(ItemDTO item)
        {
            InitializeComponent();
            ItemName.Text = item.ItemName;
            ItemDesc.Text = item.Description;
            GetImagesFromDB(item);
        }

        async void GetImagesFromDB(ItemDTO item)
        {
            RestService service = new RestService();
            List<ImageDTO> images = await service.GetImages(item);
            ItemImage.Source = images[0].ImageURL;



        }
    }
}
