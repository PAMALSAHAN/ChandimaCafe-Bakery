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
    public partial class Orders : ContentPage
    {
        public ObservableCollection<OrderByUser> OrdersCollections;
        public Orders()
        {
            OrdersCollections = new ObservableCollection<OrderByUser>();
            InitializeComponent();
            GetOrderItems();
        }

        private async void GetOrderItems()
        {
           var orders= await ApiService.GetOrderByUser(Preferences.Get("userId",0));
            foreach (var order in orders)
            {
                OrdersCollections.Add(order);
            }
            LvOrders.ItemsSource = OrdersCollections;

        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();

        }

        private void LvOrders_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            
            DisplayAlert("try", , "cacel");

            Navigation.PushModalAsync(new OrderDetails());

        }
    }
}