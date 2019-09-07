using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoginPage.Models
{
    class Contact : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
