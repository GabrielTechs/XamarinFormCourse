using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public ICommand BacktoLoginCommand { get; set; }

        public HomePageViewModel()
        {
            BacktoLoginCommand = new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
