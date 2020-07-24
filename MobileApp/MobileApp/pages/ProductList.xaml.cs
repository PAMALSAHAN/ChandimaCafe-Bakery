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
    public partial class ProductList : ContentPage
    {
        public ObservableCollection<ProductByCategory> productsCollections;
        public ProductList(int id ,string categoryName)
        {
            productsCollections = new ObservableCollection<ProductByCategory>();
            InitializeComponent();
            LblCategoryName.Text = categoryName;
            GetProducts(id);
        }

        private async void GetProducts(int categoryId)
        {
            var productList=await ApiService.GetProductsByCategory(categoryId);
            foreach (var product in productList)
            {
                productsCollections.Add(product);
            }
            CvProducts.ItemsSource = productsCollections;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}