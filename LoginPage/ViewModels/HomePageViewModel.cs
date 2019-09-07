using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public ICommand AddContactCommand { get; set; }

        Contact contact;
        public Contact SelectedContact
        {
            get
            {
                return contact;
            }set{
                contact = value;

                if (contact != null)
                    OnSelectItemAsync(contact);
            }
        }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand DeleteElementCommand { get; set; }
        public ICommand MoreOptionsCommand { get; set; }

        public HomePageViewModel()
        {
            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "NewContact", (sender, param) =>
            {
                Contacts.Add(param);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditContact", (sender, param) =>
            {
                for (int i = 0; i < Contacts.Count; i++)
                {
                    if (Contacts[i] == SelectedContact)
                    {
                        Contacts[i] = param;
                    } }
            });

            MoreOptionsCommand = new Command<Contact>(async (param) =>
            {
                //Action sheet sample
                var result = await App.Current.MainPage.DisplayActionSheet
                (null, "Cancel", null, $"Call {param.Phone}", "Edit");

                if (result == $"Call {param.Phone}")
                {
                    Device.OpenUri(new Uri(String.Format("tel:{0}", $"{param.Phone}")));
                }
                if (result == "Edit")
                {
                    MessagingCenter.Send<HomePageViewModel, Contact>(this, "NewContactToEdit", param);
                    await App.Current.MainPage.Navigation.PushAsync(new EditContactPage());
                }
            });

            DeleteElementCommand = new Command<Contact>(async (param) =>
            {
                //Action sheet sample
                var result = await App.Current.MainPage.DisplayActionSheet
                ("Are you sure you want to delete the contact?", "Cancel", "Yes I am");
                if (result == "Yes I am")
                {
                    Contacts.Remove(SelectedContact);
                }

            });
            AddContactCommand = new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
                });
        }
        async System.Threading.Tasks.Task OnSelectItemAsync(Contact contact)
        {
            MessagingCenter.Send<HomePageViewModel, Contact>(this, "ContactDetail", SelectedContact);
            await App.Current.MainPage.Navigation.PushAsync(new DetaileContactPage());
        }

        void AddContact()
        {
            //MessagingCenter.Send<AddContactViewModel, Contact>(this, "NewContact", NewContact);
            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "NewContact", (sender, param) =>
             {
                 Contacts.Add(param);
             });
            MessagingCenter.Unsubscribe<AddContactViewModel, Contact>(this, "NewContact");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
