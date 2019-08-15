using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginPage
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

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text) && string.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Error", "Both fields must be completed", "Ok");
            }
            else if (string.IsNullOrEmpty(email.Text))
            {
                await DisplayAlert("Error", "Email field is empty", "Ok");
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Error", "Password field is empty", "Ok");
            }
            else
            {
                await DisplayAlert("Welcome", $"Hello {email.Text}", "Ok");
            }
        }
    }
}
