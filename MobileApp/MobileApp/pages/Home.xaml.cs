﻿using MobileApp.models;
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
    public partial class Home : ContentPage
    {
        public ObservableCollection<PopularProducts> popularProducts;
        public Home()
        {
            popularProducts = new ObservableCollection<PopularProducts>();   
            InitializeComponent();
            GetPopularProducts();
        }

        private async void GetPopularProducts()
        {
           var products= await ApiService.GetPopularProducts();
            foreach (var product in products)
            {
                popularProducts.Add(product);
            }
            CvProducts.ItemsSource = popularProducts;
        }

        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 800, Easing.Linear);
        }

        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-2, 0, 800, Easing.Linear);
            GridOverlay.IsVisible = false;

        }
    }
}