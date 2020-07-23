using MobileApp.pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var token=Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(token))
            {
                MainPage = new NavigationPage(new SignUp());
            }
            else
            {
                MainPage = new NavigationPage(new Home());
            }


            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
