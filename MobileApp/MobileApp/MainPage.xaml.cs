using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BName_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("userName",Ent_userName.Text);
        }

        private void Btn_Retrive_Clicked(object sender, EventArgs e)
        {
           var Response= Preferences.Get("userName", string.Empty);
            Lbl_RetriveName.Text = Response;
        }
    }
}
