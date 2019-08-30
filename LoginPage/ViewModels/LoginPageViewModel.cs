using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public bool EmailVisibility { get; set; } = false;
        public bool PasswordVisibility { get; set; } = false;
        public UsersLogin UserAuth { get; set; } = new UsersLogin();
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                EmailVisibility = false;
                PasswordVisibility = false;
                if (string.IsNullOrEmpty(UserAuth.UserEmail) && (string.IsNullOrEmpty(UserAuth.UserPassword)))
                {
                    EmailVisibility = true;
                    PasswordVisibility = true;
                }
                else if (string.IsNullOrEmpty(UserAuth.UserEmail))
                {
                    EmailVisibility = true;
                }
                else if (string.IsNullOrEmpty(UserAuth.UserPassword))
                {
                    PasswordVisibility = true;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Welcome", $"Hello {UserAuth.UserEmail}", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
            });
            RegisterCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
