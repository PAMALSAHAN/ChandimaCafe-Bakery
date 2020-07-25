using MobileApp.service;
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
    public partial class ProductDetails : ContentPage
    {
        public ProductDetails(int ProductId)
        {
            InitializeComponent();
            GetProductById(ProductId);
        }

        private async void GetProductById(int productId)
        {
            var Product = await ApiService.GetProductById(productId);
            LblName.Text = Product.name;
            LblPrice.Text = Product.price.ToString();
            LblDetail.Text = Product.detail;
            ImgProduct.Source = Product.FullImageUrl;
            LblTotalPrice.Text = LblPrice.Text;
        }
    }
}