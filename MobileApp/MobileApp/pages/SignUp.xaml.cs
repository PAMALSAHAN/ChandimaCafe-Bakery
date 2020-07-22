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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            //check whether password mismathch or not
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Password Mismatch", "Please Check Your Confirm Password", "Cancel");
            }
            else
            {
                var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
                if (response)
                {
                    await DisplayAlert("Hi", "Your Account has been Created", "Alright");
                }
                else
                {
                    await DisplayAlert("Oops", "Something gone Wrong", "Cancel");
                }
            }
        }
    }
}