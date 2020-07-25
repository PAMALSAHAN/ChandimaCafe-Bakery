using MobileApp.models;
using MobileApp.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrder : ContentPage
    {
        private readonly double totalAmount;

        public PlaceOrder(double totalAmount)
        {
            InitializeComponent();
            this.totalAmount = totalAmount;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {
            try
            {
                var order = new Order();
                order.userId = Preferences.Get("userId", 0);
                order.fullName = EntName.Text;
                order.address = EntAddress.Text;
                order.phone = EntPhone.Text;
                order.orderTotal = totalAmount;

                var response = await ApiService.placeOrder(order);
                if (response != null)
                {
                    await DisplayAlert("Done", "Your Order Id is " + response.orderId, "Alright");
                    Application.Current.MainPage = new NavigationPage(new Home());
                }
                else
                {
                    await DisplayAlert("Ops", "Something Went Wrong", "Cansel");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Cansel");

            }
            

        }
    }
}