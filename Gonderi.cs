using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Models
{
    public abstract class Gonderi : ITakipEdilebilir
    {
        public string TakipNumarasi { get; private set; }
        public string GonderenAd { get; set; }
        public string GonderenAdres { get; set; }
        public string AliciAd { get; set; }
        public string AliciAdres { get; set; }
        public KargoDurum Durum { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public double Agirlik { get; set; }

        public Gonderi(string gonderenAd, string gonderenAdres, string aliciAd, string aliciAdres, double agirlik)
        {       TakipNumarasi = TakipNumarasiOlustur();
        GonderenAd = gonderenAd;
        GonderenAdres = gonderenAdres;
        AliciAd = aliciAd;
        AliciAdres = aliciAdres;
        Agirlik = agirlik;
        Durum = KargoDurum.Hazirlaniyor;
        GonderimTarihi = DateTime.Now;
    }

    private string TakipNumarasiOlustur()
        {
            Random random = new Random();
            return "TK" + random.Next(100000, 999999).ToString();
        }

        public void DurumGuncelle(KargoDurum yeniDurum)
        {
            Durum = yeniDurum;
        }

        public abstract string TakipBilgisi();
        public abstract double TeslimatUcreti();
    }
}
