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
using System.Windows.Media.Imaging;
using App2.ViewModels;

namespace App2
{
    public partial class PageMenze : PhoneApplicationPage
    {
        public PageMenze()
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

                        Menza m = JsonConvert.DeserializeObject<Menza>(strObjData);
                        naslov.Text = m.Naziv;
                        radnoVreme.Text = m.RadnoVreme;
                        adresa.Text = m.Adresa;
                        telefon.Text = m.Telefon;
                        poslovodja.Text = m.Poslovodja;
                        opis.Text = m.Opis;
                       
                    }
                }

                isolatedStorage.DeleteFile(filePath);
            }
        }

    }
}