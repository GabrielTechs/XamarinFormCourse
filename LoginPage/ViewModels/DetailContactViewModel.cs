using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    class DetailContactViewModel : INotifyPropertyChanged
    {
        public Contact NewContact { get; set; } = new Contact();

        public DetailContactViewModel()
        {
            MessagingCenter.Subscribe<HomePageViewModel, Contact>(this, "ContactDetail", (sender, param) =>
            {
                NewContact = param;
            });

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
