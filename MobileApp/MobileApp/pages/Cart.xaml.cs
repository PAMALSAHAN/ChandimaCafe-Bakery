using MobileApp.models;
using MobileApp.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public ObservableCollection<ShoppingCartItem> ShoppingCartItemCollection;
        public Cart()
        {
            ShoppingCartItemCollection = new ObservableCollection<ShoppingCartItem>();
            InitializeComponent();
            GetShoppingItems();
            GetTotalPrice();
        }

        private async void GetTotalPrice()
        {
            var total=await ApiService.GetSubTotal(Preferences.Get("userId", 0));
            LblTotalPrice.Text = total.subTotal.ToString();
        }

        private async void GetShoppingItems()
        {
            var shoppingCartItems=await ApiService.GetShoppingCartItems(Preferences.Get("userId", 0));
            foreach (var item in shoppingCartItems)
            {
                ShoppingCartItemCollection.Add(item);
            }
            LvShoppingCart.ItemsSource = ShoppingCartItemCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TapClearCart_Tapped(object sender, EventArgs e)
        {
           var response=await ApiService.ClearShoppingCart(Preferences.Get("userId", 0));
            if (response)
            {
                await DisplayAlert("Done", "Your cart has been Cleared", "Alright");
                LvShoppingCart.ItemsSource = null;
                LblTotalPrice.Text = "0";
            }
            else
            {
                await DisplayAlert("Oops", "Something Went wrong", "Cancel");
            }

        }

        private void BtnProceed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PlaceOrder(Convert.ToDouble(LblTotalPrice.Text)));
        }
    }
}