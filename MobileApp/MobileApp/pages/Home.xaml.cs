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
    public partial class Home : ContentPage
    {
        public ObservableCollection<PopularProducts> popularProducts;
        public ObservableCollection<Category> categoryCollection;
        public Home()
        {
            popularProducts = new ObservableCollection<PopularProducts>();
            categoryCollection = new ObservableCollection<Category>();
            InitializeComponent();
            GetPopularProducts();
            GetCategories();
            LblUserName.Text = Preferences.Get("userName", string.Empty);
        }

        private async void GetCategories()
        {
            var categories=await ApiService.GetCategories();
            foreach (var category in categories)
            {
                categoryCollection.Add(category);
            }
            CvCategories.ItemsSource = categoryCollection;

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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var items=await ApiService.GetTotalCardItems(Preferences.Get("userId", 0));
            LblTotalItems.Text = items.totalItems.ToString();
        }

        private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection=e.CurrentSelection.FirstOrDefault() as Category;
            if (currentSelection == null) return;
            ((CollectionView)sender).SelectedItem = null;
            Navigation.PushModalAsync(new ProductList(currentSelection.id,currentSelection.name));
           
            
        }

        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as PopularProducts;
            if (currentSelection == null) return;
            ((CollectionView)sender).SelectedItem = null;
            Navigation.PushModalAsync(new ProductDetails(currentSelection.id));
        }
    }
}