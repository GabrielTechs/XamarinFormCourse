using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    class RegisterPageViewModel: INotifyPropertyChanged
    {
        public string ConfirmPasswordlbl { get; set; }
        public bool NameVisibility { get; set; } = false;
        public bool EmailVisibility { get; set; } = false;
        public bool PasswordVisibility { get; set; } = false;
        public bool ConfirmPasswordVisibility { get; set; } = false;
        public UserRegister UserAuth { get; set; } = new UserRegister();
        public ICommand RegisterCommand { get; set; }

        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(async () =>
            {
                NameVisibility = false;
                EmailVisibility = false;
                PasswordVisibility = false;
                ConfirmPasswordVisibility = false;
                if (string.IsNullOrEmpty(UserAuth.UserName))
                {
                    NameVisibility = true;
                }
                else if (string.IsNullOrEmpty(UserAuth.UserEmail))
                {
                    EmailVisibility = true;
                }
                else if (string.IsNullOrEmpty(UserAuth.UserPassword))
                {
                    PasswordVisibility = true;
                }
                else if (string.IsNullOrEmpty(UserAuth.UserConfirmPassword))
                {
                    ConfirmPasswordlbl = "Confirm password field is empty";
                    ConfirmPasswordVisibility = true;
                }
                else if (UserAuth.UserPassword != UserAuth.UserConfirmPassword)
                {
                    ConfirmPasswordlbl = "Passwords fields do not match";
                    ConfirmPasswordVisibility = true;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Congratulations!", $"{UserAuth.UserName} you have a Gabapp account", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
