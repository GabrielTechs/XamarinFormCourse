using LoginPage.Models;
using LoginPage.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class NewBeePhonesViewModel : INotifyPropertyChanged
    {
        IApiService apiService = new ApiService();
        public ICommand GetDirectoryCommand { get; set; }
        public string Directory { get; set; }
        public ObservableCollection<PhonesDirectory> Directories { get; set; } = new ObservableCollection<PhonesDirectory>();
        PhonesDirectory directory;

        public event PropertyChangedEventHandler PropertyChanged;

        public PhonesDirectory SelectedDirectory
        {
            get
            {
                return directory;
            }
            set
            {
                directory = value;

                if (directory != null)
                    OnSelectItemAsync(directory);
            }
        }
        public NewBeePhonesViewModel()
        {
            GetDirectoryCommand = new Command(async () =>
            {
                await GetDirectory();
            });

            GetDirectoryCommand.Execute(null);
        }


        async Task GetDirectory()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    var directory = await apiService.GetDirectories();
                    Directories.Add(directory);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Unable to connect to the server", "Ok");
            }
        }
        async System.Threading.Tasks.Task OnSelectItemAsync(PhonesDirectory directory)
        {

        }
    }
}
