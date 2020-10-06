using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class ItemContentPage : ContentPage
    {
        //List<string> images = new List<string>();
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
            List<string> images = await service.GetImages(item);
            //images = await service.GetImages(item);

            if(images.Count == 0)
            {
                ItemImage.Source = "https://www.gardeningknowhow.com/wp-content/uploads/2010/02/iStock-524907632.jpg";
            }
            else
            {
                ItemImage.Source = images[1];

            }

        }
    }
}
