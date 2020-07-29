using MobileApp.models;
using MobileApp.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;




 
namespace MobileApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetails : ContentPage
    {
        public ObservableCollection<OrderDetail> OrderDetailCollection;
        public OrderDetails(int orderId)
        {
            InitializeComponent();
            OrderDetailCollection = new ObservableCollection<OrderDetail>();
            GetOrderDetail(orderId);
        }
        private async void GetOrderDetail(int orderId)
        {
            var orders = await ApiService.GetOrderDetails(orderId);
            var orderDetails = orders[0].orderDetails;
            foreach (var item in orderDetails)
            {
                OrderDetailCollection.Add(item);
            }

            LvOrderDetail.ItemsSource = OrderDetailCollection;

            LblTotalPrice.Text = orders[0].orderTotal + " $ ";
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}