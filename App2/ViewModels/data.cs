using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Xml.Linq;
using System.Net;
using Microsoft.Phone.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.IO.IsolatedStorage;

namespace App2.ViewModels
{

    public class Fakultet
    {
        private string naziv, telefon, sajt, email, adresa, dekan, tekst, smerovi, zvanja, uslovi_upisa;
        private int id;
        private string logo;
        private ObservableCollection<string> images;

        public ObservableCollection<string> Images
        {
            get { return images; }
            set { images = value; }
        }
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        public string Sajt
        {
            get { return sajt; }
            set { sajt = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public string Dekan
        {
            get { return dekan; }
            set { dekan = value; }
        }
        public string Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public string Smerovi
        {
            get { return smerovi; }
            set { smerovi = value; }
        }
        public string Zvanja
        {
            get { return zvanja; }
            set { zvanja = value; }
        }
        public string Uslovi_upisa
        {
            get { return uslovi_upisa; }
            set { uslovi_upisa = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Fakultet(string naziv, string telefon, string sajt, string email, string adresa, string dekan, string tekst, string smerovi, string zvanja, string uslovi_upisa, ObservableCollection<string> tempImages, int id)
        {
            this.naziv = naziv;
            this.telefon = telefon;
            this.sajt = sajt;
            this.email = email;
            this.adresa = adresa;
            this.dekan = dekan;
            this.tekst = tekst;
            this.smerovi = smerovi;
            this.zvanja = zvanja;
            this.uslovi_upisa = uslovi_upisa;
            this.id = id;
            //images = tempImages;
            //logo = images[0];

        }
    }

    public class Dom
    {
        private string naziv, adresa, telefon, opis, prevoz;
        private string web;
        private int id;
        private ObservableCollection<string> images;

        public ObservableCollection<string> Images
        {
            get { return images; }
            set { images = value; }
        }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Web
        {
            get { return web; }
            set { web = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string Prevoz
        {
            get { return prevoz; }
            set { Prevoz = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Dom(string naziv, string adresa, string telefon, string web, string opis, string prevoz, ObservableCollection<string> tempImages, int id)
        {
            this.naziv = naziv;
            images = new ObservableCollection<string>();
            this.adresa = adresa;
            this.telefon = telefon;
            this.web = web;
            this.opis = opis;
            this.prevoz = prevoz;
            this.id = id;
            this.Images = tempImages;
        }
    }

    public class Menza
    {

        private string naziv, radnoVreme, telefon, poslovodja, opis, adresa;
        private int id;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string RadnoVreme
        {
            get { return radnoVreme; }
            set { radnoVreme = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Poslovodja
        {
            get { return poslovodja; }
            set { poslovodja = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Menza(string naziv, int id, string radnoVreme, string telefon, string poslovodja, string opis, string adresa)
        {
            this.naziv = naziv;
            this.id = id;
            this.radnoVreme = radnoVreme;
            this.telefon = telefon;
            this.poslovodja = poslovodja;
            this.opis = opis;
            this.adresa = adresa;
        }

        public Menza()
        {
            // TODO: Complete member initialization
        }

    }

    public class Vest
    {
        private string naslov, url, datum, kategorija;

        public string Kategorija
        {
            get { return kategorija; }
            set { kategorija = value; }
        }

        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }

        public Vest(string naslov, string url, string datum, string kategorija)
        {
            this.naslov = naslov;
            this.url = url;
            this.datum = datum;
            this.kategorija = kategorija;
        }

        public Vest()
        {
            // TODO: Complete member initialization
        }

    }

    public class Data
    {
        public Data()
        {
            load(1);
        }

        #region observableColls

        private static ObservableCollection<Fakultet> fakulteti = new ObservableCollection<Fakultet>();
        public static ObservableCollection<Fakultet> Fakulteti
        {
            get { return fakulteti; }
            set { fakulteti = value; }
        }

        private static ObservableCollection<Dom> domovi = new ObservableCollection<Dom>();
        public static ObservableCollection<Dom> Domovi
        {
            get { return domovi; }
            set { domovi = value; }
        }

        private static ObservableCollection<Menza> menze = new ObservableCollection<Menza>();
        public static ObservableCollection<Menza> Menze
        {
            get { return menze; }
            set { menze = value; }
        }

        private static ObservableCollection<Vest> vesti = new ObservableCollection<Vest>();
        public static ObservableCollection<Vest> Vesti
        {
            get { return vesti; }
            set { vesti = value; }
        }
        private static ObservableCollection<Vest> vesti1 = new ObservableCollection<Vest>();
        public static ObservableCollection<Vest> Vesti1
        {
            get { return vesti1; }
            set { vesti1 = value; }
        }
        #endregion

        static string jsonText;
        static string kategorijaVesti;
        static WebClient webClient = new WebClient();
        static public IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;

        public static void load(int x)
        {
            fakulteti.Clear();
            menze.Clear();
            domovi.Clear();

            if (iss.Contains("asd.json"))
            {
                jsonText = iss["asd.json"].ToString();
                //MessageBox.Show("Asd");
            }
            else
            {
                var resource = Application.GetResourceStream(new Uri("aaa.txt", UriKind.Relative));
                StreamReader streamReader = new StreamReader(resource.Stream);
                jsonText = streamReader.ReadToEnd();

                iss.Add("asd.json", jsonText);
            }

            popuni();

            #region vesti
            if (x == 1)
            {

                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    string rss_link = " http://rss.infostud.com/prijemni/1";
                    WebClient web = new WebClient();
                    web.DownloadStringAsync(new Uri(rss_link));
                    web.DownloadStringCompleted += webClient1_DownloadStringCompleted;
                    
                }
                else
                {
                    Vesti.Add(new Vest("Nema neta", "", "", ""));
                }

            }
            #endregion
        }

        private static void webClient1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            var rss = e.Result;
            XElement xmlVesti = XElement.Parse(rss);
            var vestii = xmlVesti.Descendants("item");
            foreach (var item in vestii)
            {
                try
                {
                    Vest v = new Vest(item.Element("title").Value, item.Element("link").Value, item.Element("pubDate").Value.Substring(5, item.Element("pubDate").Value.Length - 20), kategorijaVesti);
                    Vesti.Add(v);
                }
                catch { }

                sortirajVesti();
            }
             
        }

        private static void popuni()
        {
            JObject o = JObject.Parse(jsonText);

            #region fakulteti

            int temp3 = 0;
            foreach (var fakultetValue in o["fakulteti"])
            {
                Fakultet f = JsonConvert.DeserializeObject<Fakultet>(fakultetValue.ToString());
                f.Id = temp3;
                Fakulteti.Add(f);
                temp3++;
            }

            sortiraj();

            #endregion

            #region domovi

            int temp2 = 0;
            foreach (var domValue in o["domovi"])
            {
                Dom d = JsonConvert.DeserializeObject<Dom>(domValue.ToString());
                d.Id = temp2;
                Domovi.Add(d);
                temp2++;
            }


            #endregion

            #region menze

            int temp = 0;
            foreach (var menzaValue in o["menze"])
            {
                Menza m = JsonConvert.DeserializeObject<Menza>(menzaValue.ToString());
                m.Id = temp;
                menze.Add(m);
                temp++;
            }

            #endregion

        }

        public static void sortiraj()
        {
            for (int i = 0; i < Fakulteti.Count - 1; i++)
            {
                for (int j = i + 1; j < Fakulteti.Count; j++)
                {
                    if (Fakulteti[i].Naziv[0] > Fakulteti[j].Naziv[0])
                    {
                        Fakultet pom = Fakulteti[i];
                        Fakulteti[i] = Fakulteti[j];
                        fakulteti[j] = pom;
                    }
                }
            }
        }

        public static void sortirajVesti()
        {
            for (int i = 0; i < Vesti.Count - 1; i++)
            {
                for (int j = i + 1; j < Vesti.Count; j++)
                {
                    DateTime d1, d2;
                    d1 = DateTime.ParseExact(Vesti[i].Datum, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    d2 = DateTime.ParseExact(Vesti[j].Datum, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    if (d1.Date < d2.Date)
                    {
                        Vest pom = Vesti[i];
                        Vesti[i] = Vesti[j];
                        Vesti[j] = pom;
                    }
                }
            }
        }

        public static void update()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                WebClient webClient1 = new WebClient();
                webClient1.DownloadStringCompleted += update_DownloadStringCompleted;
                webClient1.DownloadStringAsync(new Uri(string.Format("https://raw.github.com/markostakic/31/master/aaa1.txt")));
            }
            else
            {
                MessageBox.Show("Nema neta");
            }
        }

        private static void update_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result == "")
            {
                WebClient webClient2 = new WebClient();
                webClient2.DownloadStringCompleted += webClient_DownloadStringCompleted;
                webClient2.DownloadStringAsync(new Uri(string.Format("https://raw.github.com/markostakic/31/master/aaa.json")));
            }
            else
            {
                MessageBox.Show("Nema promena");
            }
        }

        private static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result != jsonText)
            {
                jsonText = e.Result;
                iss.Remove("asd.json");
                iss.Add("asd.json", jsonText);
                MessageBox.Show("Updateovano uspesno");
                load(0);
            }
            else
            {
                MessageBox.Show("Nema promena");
            }
        }
    }
}
