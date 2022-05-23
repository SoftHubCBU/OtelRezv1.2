using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelRezNet
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string MusteriTelefonNumarasi { get; set; }
        public string MusteriAdres { get; set; }
        public string MusteriEposta { get; set; }
        public string MusteriSifre { get; set; }

        public bool MusteriGirisSorgu()
        {
            SqlCommand komut = new SqlCommand("EXEC checkIn @KullaniciEposta,@KullaniciSifre,@KullaniciTipiId", Datacon.baglanti());
            komut.Parameters.AddWithValue("@KullaniciEposta", MusteriEposta);
            komut.Parameters.AddWithValue("@KullaniciSifre", MusteriSifre);
            komut.Parameters.AddWithValue("@KullaniciTipiId", 3);

            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
                return true;
            }
            else { Datacon.baglanti().Close(); return false; }
        }
        public bool MusteriKayit()
        {
            SqlCommand komut = new SqlCommand("EXEC KullaniciKayit @KullaniciAd,@KullaniciSoyad,@KullaniciEposta,@KullaniciSifre,@KullaniciTipiId", Datacon.baglanti());
            komut.Parameters.AddWithValue("@KullaniciAd", MusteriAd);
            komut.Parameters.AddWithValue("@KullaniciSoyad", MusteriSoyad);
            komut.Parameters.AddWithValue("@KullaniciEposta", MusteriEposta);
            komut.Parameters.AddWithValue("@KullaniciSifre", MusteriSifre);
            komut.Parameters.AddWithValue("@KullaniciTipiId", 3);

            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
                return true;
            }
            else { Datacon.baglanti().Close(); return false; }
        }
    }
}
