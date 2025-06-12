using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Models
{
    public class KargoYonetici
    {
        private List<Gonderi> gonderiler;

        public KargoYonetici()
        {
            gonderiler = new List<Gonderi>();
        }

        public void GonderiEkle(Gonderi gonderi)
        {
            gonderiler.Add(gonderi);
        }

        public Gonderi GonderiBul(string takipNumarasi)
        {
            return gonderiler.FirstOrDefault(g => g.TakipNumarasi == takipNumarasi);
        }

        public List<Gonderi> TumGonderiler()
        {
            return gonderiler;
        }

        public bool DurumGuncelle(string takipNumarasi, KargoDurum yeniDurum)
        {
            var gonderi = GonderiBul(takipNumarasi);
            if (gonderi != null)
            {
                gonderi.DurumGuncelle(yeniDurum);
                return true;
            }
            return false;
        }
    }
}
