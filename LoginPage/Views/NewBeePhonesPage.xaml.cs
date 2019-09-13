using LoginPage.Services;
using LoginPage.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBeePhonesPage : ContentPage
    {
        public NewBeePhonesPage()
        {
            InitializeComponent();
            BindingContext = new NewBeePhonesViewModel();
        }
    }
}