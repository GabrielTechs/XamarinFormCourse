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

    class AddContactViewModel : INotifyPropertyChanged
    {
        public Contact NewContact { get; set; } = new Contact();
        public ICommand AddContactCommand { get; set; }
        public List<PhoneType> PhoneTypeList { get; set; }
        public List<EmailType> EmailTypeList { get; set; }
        public AddContactViewModel()
        {
            AddContactCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(NewContact.FirstName) && string.IsNullOrEmpty(NewContact.Phone))
                {
                    await App.Current.MainPage.DisplayAlert("Bye", "There was no contact to add", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else if (string.IsNullOrEmpty(NewContact.FirstName))
                {
                    NewContact.FirstName = NewContact.Phone;
                    MessagingCenter.Send<AddContactViewModel, Contact>(this, "NewContact", NewContact);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    MessagingCenter.Send<AddContactViewModel, Contact>(this, "NewContact", NewContact);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
            PhoneTypeList = PhoneTypes;
            EmailTypeList = EmailTypes;
        }
        public List<PhoneType> PhoneTypes
        {
            get
            {
                var phonetypes = new List<PhoneType>()
            {
                new PhoneType(){Key = 1, PhoneTypeValue = "Mobile"},
                new PhoneType(){Key = 2, PhoneTypeValue = "Home"},
                new PhoneType(){Key = 3, PhoneTypeValue = "Work"},
                new PhoneType(){Key = 4, PhoneTypeValue = "Principal"}
            }; return phonetypes;
            }
        }

        public List<EmailType> EmailTypes
        {
            get
            {
                var emailtypes = new List<EmailType>()
            {
                new EmailType(){Key = 1, EmailTypeValue = "Home"},
                new EmailType(){Key = 2, EmailTypeValue = "Work"},
                new EmailType(){Key = 3, EmailTypeValue = "Other"}
            }; return emailtypes;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
