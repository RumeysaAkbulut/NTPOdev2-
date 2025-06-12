using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Models
{
    public class YurticiKargo : Gonderi
    {

        public string Il { get; set; }
        public string Ilce { get; set; }

        public YurticiKargo(string gonderenAd, string gonderenAdres, string aliciAd, string aliciAdres,
                            double agirlik, string il, string ilce)
            : base(gonderenAd, gonderenAdres, aliciAd, aliciAdres, agirlik)
        {
            Il = il;
            Ilce = ilce;
        }

        public override string TakipBilgisi()
        {
            return $"[YURTİÇİ] {TakipNumarasi} | {GonderenAd} → {AliciAd} | {Il}/{Ilce} | {DurumMetni()} | {Agirlik}kg | {TeslimatUcreti():C}";
        }

        public override double TeslimatUcreti()
        {
            return Agirlik * 15.50; // Yurtiçi kg başına 15.50 TL
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
