using System;
using System.Collections.Generic;
using HoarderApp.API;
using HoarderApp.Models;
using Xamarin.Forms;

namespace HoarderApp.Views
{
    public partial class ItemContentPage : ContentPage
    {
        CollectionDTO CurrentCollection;
        Item CurrentItem;
        AccountDetails SignedInUser;
        public ItemContentPage(Item currentItem, CollectionDTO currentCollection, AccountDetails signedInUser)
        {

            SignedInUser = signedInUser;
            CurrentCollection = currentCollection;
            CurrentItem = currentItem;
            InitializeComponent();
            ItemName.Text = currentItem.ItemName;
            ItemDesc.Text = currentItem.Description;
            GetImagesFromDB(currentItem);
        }

        async void GetImagesFromDB(Item currentItem)
        {
            RestService service = new RestService();
            List<string> images = await service.GetImages(currentItem);

            if(images.Count == 0)
            {
                ItemImage.Source = "https://www.gardeningknowhow.com/wp-content/uploads/2010/02/iStock-524907632.jpg";
            }
            else
            {
                ItemImage.Source = images[0];

            }
        }

        async void EditItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditItemPage(CurrentItem, CurrentCollection, SignedInUser));
        }

    }
}
