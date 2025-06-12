# 🚚 Express Kargo Takip Merkezi

Bu proje, Windows Forms kullanılarak C# ile geliştirilmiş bir **Kargo Takip Sistemi**'dir. Gönderi takibi, yeni gönderi ekleme, durum güncelleme ve kargo sorgulama işlemlerini kolaylıkla yapabilmenizi sağlar.

---

## Özellikler

- **Gönderi Listesi:** Tüm gönderiler liste halinde gösterilir.
- **Yeni Gönderi Ekleme:** Yurtiçi ve yurtdışı gönderi detayları ile yeni sipariş oluşturma.
- **Durum Güncelleme:** Gönderi durumlarını kolayca güncelleme imkanı.
- **Kargo Sorgulama:** Takip numarasına göre gönderi detaylarını görüntüleme.

---

## Kullanılan Teknolojiler

- C#
- Windows Forms (.NET Framework)
- Nesne yönelimli programlama (OOP)

---

## Kurulum ve Çalıştırma

1. Projeyi klonlayın veya indirin.
2. Visual Studio ile açın.
3. Projeyi derleyip çalıştırın.
4. Ana ekranda gönderileri görüntüleyebilir, yeni gönderi ekleyebilir, durumları güncelleyebilir ve kargo sorgulayabilirsiniz.

---

## Proje Yapısı

- `Form1` : Ana form, gönderi listesi ve butonlar.
- `GonderiEkleForm` : Yeni gönderi eklemek için form.
- `DurumGuncelleForm` : Gönderi durumlarını güncellemek için form.
- `KargoYonetici` : Gönderi yönetim sınıfı.
- `YurticiKargo` ve `YurtdisiKargo` : Gönderi türlerini temsil eden sınıflar.
- `KargoDurum` : Gönderi durumlarını temsil eden enum.




