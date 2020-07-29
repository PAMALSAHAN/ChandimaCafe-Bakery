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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
                Preferences.Set("email", EntEmail.Text);
                Preferences.Set("password", EntPassword.Text);

                if (response)
                {
                    Application.Current.MainPage = new NavigationPage(new Home());
                }
                else
                {
                    await DisplayAlert("Oops", "Your Email and Password is Wrong", "Cancel");
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("warning", ex.Message.ToString(), "Cancel");
            }
        }
    }
}