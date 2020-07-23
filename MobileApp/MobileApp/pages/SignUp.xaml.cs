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
            try
            {
                //check whether password mismathch or not
                if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
                {
                    await DisplayAlert("Password Mismatch", "Please Check Your Confirm Password", "Cancel");
                }
                else
                {


                    try
                    {
                        var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
                        if (response)
                        {
                            await DisplayAlert("Hi", "Your Account has been Created", "Alright");

                            var login = new Login();
                            await Navigation.PushModalAsync(login);
                            
                        }
                        else
                        {
                            await DisplayAlert("Oops", "Something gone Wrong", "Cancel");
                        }

                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("warning", ex.Message.ToString(), "Cancel");
                    }
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("warning", ex.Message.ToString(), "Cancel");
            }

        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var login = new Login();
                await Navigation.PushModalAsync(login);
               
            }
            catch (Exception ex)
            {

                await DisplayAlert("warning", ex.Message.ToString(), "Cancel");
            }
        }
    }
}