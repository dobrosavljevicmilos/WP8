using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Media.Imaging;

namespace App2
{
    public partial class PageFakultet : PhoneApplicationPage
    {
        public PageFakultet()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string filePath = "objectData";
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isolatedStorage.FileExists(filePath))
                {
                    using (IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile(filePath, FileMode.Open, FileAccess.Read))
                    {
                        string strObjData = string.Empty;
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            strObjData = reader.ReadToEnd();
                        }

                        Fakultet f = JsonConvert.DeserializeObject<Fakultet>(strObjData);
                        naslov.Text = f.Naziv;
                        telefon.Text = f.Telefon;
                        adresa.Text = f.Adresa;
                        sajt.Content = f.Sajt;
                        sajt.NavigateUri = new Uri(f.Sajt);
                        email.Text = f.Email;
                        dekan.Text = f.Dekan;
                        opis.Text = f.Tekst;
                        smerovi.Text = f.Smerovi;
                        zvanja.Text = f.Zvanja;
                        uslovi.Text = f.Uslovi_upisa;
                       
                        BitmapImage i = new BitmapImage();
                       // i.UriSource = new Uri(f.Images[0]);    ovaj ovde uri nije dobar :S 
                        logo.Source = i;
                    }
                }

                isolatedStorage.DeleteFile(filePath);
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}