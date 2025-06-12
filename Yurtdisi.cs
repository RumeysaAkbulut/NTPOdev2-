using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Models
{
    public class Yurtdisi : Gonderi
    {
        public string Ulke { get; set; }
        public string GumrukKodu { get; set; }

        public Yurtdisi(string gonderenAd, string gonderenAdres, string aliciAd, string aliciAdres,
                             double agirlik, string ulke, string gumrukKodu)
            : base(gonderenAd, gonderenAdres, aliciAd, aliciAdres, agirlik)
        {
            Ulke = ulke;
            GumrukKodu = gumrukKodu;
        }

        public override string TakipBilgisi()
        {
            return $"[YURTDIŞI] {TakipNumarasi} | {GonderenAd} → {AliciAd} | {Ulke} | {DurumMetni()} | {Agirlik}kg | {TeslimatUcreti():C}";
        }

        public override double TeslimatUcreti()
        {
            return Agirlik * 45.75; 
        }

        private string DurumMetni()
        {
            switch (Durum)
            {
                case KargoDurum.Hazirlaniyor:
                    return "Hazırlanıyor";
                case KargoDurum.Yolda:
                    return "Yolda";
                case KargoDurum.TeslimEdildi:
                    return "Teslim Edildi";
                default:
                    return "Bilinmiyor";
            }
        }


    }
}
