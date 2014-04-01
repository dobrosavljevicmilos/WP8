using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App2.ViewModels;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Windows.System;
using System.Windows.Threading;
using Microsoft.Phone.Net.NetworkInformation;

namespace App2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        //Data d = new Data();
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listFakulteti.SelectedIndex != -1)
            {
                string filePath = "objectData";
                using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(filePath))
                    {
                        isolatedStorage.DeleteFile(filePath);
                    }

                    using (IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile(filePath, FileMode.Create, FileAccess.Write))
                    {
                        string writeDate = JsonConvert.SerializeObject(Data.Fakulteti[listFakulteti.SelectedIndex]);

                        // Save to IsolatedStorage. 
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            writer.WriteLine(writeDate);
                        }
                    }
                }
                NavigationService.Navigate(new Uri("/PageFakultet.xaml", UriKind.Relative));
                listFakulteti.SelectedIndex = -1;
            }
        }

        private async void listVesti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listVesti.SelectedIndex != -1)
            {
                Vest v = listVesti.SelectedItem as Vest;
                await Launcher.LaunchUriAsync(new Uri(v.Url));
                listVesti.SelectedIndex = -1;
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                strana.IsEnabled = false;
                ((ApplicationBarIconButton)sender).IsEnabled = false;
                progressBar.Visibility = Visibility.Visible;

                Data.update();

                progressBar.Visibility = Visibility.Collapsed;
                strana.IsEnabled = true;
                ((ApplicationBarIconButton)sender).IsEnabled = true;
            }
        }


        private void listDomovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listDomovi.SelectedIndex != -1)
            {
                string filePath = "objectData";
                using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(filePath))
                    {
                        isolatedStorage.DeleteFile(filePath);
                    }

                    using (IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile(filePath, FileMode.Create, FileAccess.Write))
                    {
                        string writeDate = JsonConvert.SerializeObject(Data.Domovi[listDomovi.SelectedIndex]);

                        // Save to IsolatedStorage. 
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            writer.WriteLine(writeDate);
                        }
                    }
                }
                NavigationService.Navigate(new Uri("/PageDomovi.xaml", UriKind.Relative));
                listDomovi.SelectedIndex = -1;
            }
        }

        private void listMenze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listMenze.SelectedIndex != -1)
            {
                string filePath = "objectData";
                using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(filePath))
                    {
                        isolatedStorage.DeleteFile(filePath);
                    }

                    using (IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile(filePath, FileMode.Create, FileAccess.Write))
                    {
                        string writeDate = JsonConvert.SerializeObject(Data.Menze[listMenze.SelectedIndex]);

                        // Save to IsolatedStorage. 
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            writer.WriteLine(writeDate);
                        }
                    }
                }
                NavigationService.Navigate(new Uri("/PageMenze.xaml", UriKind.Relative));
                listMenze.SelectedIndex = -1;
            }
        }
    }
}