using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    class EditContactViewModel : INotifyPropertyChanged
    {
        public Contact NewContact { get; set; } = new Contact();
        public ICommand EditContactCommand { get; set; }

        public EditContactViewModel()
        {
            MessagingCenter.Subscribe<HomePageViewModel, Contact>(this, "NewContactToEdit", (sender, param) =>
            {
                NewContact = param;
            });
            EditContactCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(NewContact.FirstName) && string.IsNullOrEmpty(NewContact.Phone))
                {
                    await App.Current.MainPage.DisplayAlert("Hey!", "Fill the name or phone fields!", "Ok");
                }
                else if (string.IsNullOrEmpty(NewContact.FirstName))
                {
                    NewContact.FirstName = NewContact.Phone;
                    MessagingCenter.Send<EditContactViewModel, Contact>(this, "EditContact", NewContact);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    MessagingCenter.Send<EditContactViewModel, Contact>(this, "EditContact", NewContact);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
