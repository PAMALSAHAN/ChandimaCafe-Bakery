using System;
using System.Collections.Generic;
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
        public OrderDetails()
        {
            InitializeComponent();
            GetOrderDetails();
        }

        private void GetOrderDetails()
        {
            Console.WriteLine("hellow");
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}