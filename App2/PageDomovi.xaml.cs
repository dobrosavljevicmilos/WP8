using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using Newtonsoft.Json;
using App2.ViewModels;
using System.Windows.Media.Imaging;

namespace App2
{
    public partial class PageDomovi : PhoneApplicationPage
    {
        public PageDomovi()
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

                   
                        Dom d = JsonConvert.DeserializeObject<Dom>(strObjData);
                        naslov.Text = d.Naziv;
                        telefon.Text = d.Telefon;
                        adresa.Text = d.Adresa;
                        sajt.Content = d.Web;
                        sajt.NavigateUri = new Uri(d.Web);
                        prevoz.Text = d.Prevoz;
                        opis.Text = d.Opis;


                        BitmapImage i = new BitmapImage();
                        i.UriSource = new Uri(d.Images[0]);
                        logo.Source = i;
                        
                    }
                }

                isolatedStorage.DeleteFile(filePath);
            }
        }





    }
}