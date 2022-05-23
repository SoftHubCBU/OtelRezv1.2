using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelRezNet
{
    public class Rezervasyon
    {
        public int RezervasyonID { get; set; }
        public Musteri Musteri { get; set; }
        public Oda Oda { get; set; }
        public Odeme Odeme { get; set; }
        public RezervasyonTarihi RezervasyonTarihi { get; set; }
        public RezervasyonTuru RezervasyonTuru { get; set; }

        public Rezervasyon()
        {
            Musteri = new Musteri();
            Oda = new Oda();
            RezervasyonTuru = new RezervasyonTuru();
            RezervasyonTarihi=new RezervasyonTarihi();
            Odeme = new Odeme();
        }

        public List<Rezervasyon> rezlist = new List<Rezervasyon>();

        public bool CheckIn()
        {
            SqlCommand komut = new SqlCommand("EXEC checkIn @RezId", Datacon.baglanti());
            komut.Parameters.AddWithValue("@RezId", RezervasyonID);
 
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
                return true;
            }
            else { Datacon.baglanti().Close(); return false; }
        }
        public void RezervasyonCek()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM ViewRezlerGoster", Datacon.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Rezervasyon rezervasyon = new Rezervasyon();
                rezervasyon.Musteri.MusteriAd = Convert.ToString(dr[0]);
                rezervasyon.RezervasyonTarihi.RezervasyonBaslangicTarih = ((DateTime)dr[1]);
                rezervasyon.RezervasyonTarihi.RezervasyonBitisTarihi = ((DateTime)dr[2]);
                rezervasyon.Odeme.OdemeTutari =Convert.ToString(dr[3]);
                rezervasyon.RezervasyonTuru.RezervasyonTurAdi = Convert.ToString(dr[4]);
                rezlist.Add(rezervasyon);

            }
            Datacon.baglanti().Close();
        }
        public void RezDegistir()
        {
            SqlCommand komut = new SqlCommand("EXEC CezaliRezTarihDegistir @RezId,@RezBasla,@RezBit", Datacon.baglanti());
            komut.Parameters.AddWithValue("@RezId", RezervasyonID);
            komut.Parameters.AddWithValue("@RezBasla", RezervasyonTarihi.RezervasyonBaslangicTarih);
            komut.Parameters.AddWithValue("@RezBit", RezervasyonTarihi.RezervasyonBitisTarihi);
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
            }
            else { Datacon.baglanti().Close(); }
        }
        public void OnOdemeliRezYap()
        {
            SqlCommand komut = new SqlCommand("EXEC OnOdemeliRez @KullaniciId,@RezBasla,@RezBit", Datacon.baglanti());
            komut.Parameters.AddWithValue("@KullaniciId", Musteri.MusteriID);
            komut.Parameters.AddWithValue("@RezBasla", RezervasyonTarihi.RezervasyonBaslangicTarih);
            komut.Parameters.AddWithValue("@RezBit", RezervasyonTarihi.RezervasyonBitisTarihi);
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
            }
            else { Datacon.baglanti().Close(); }
        }
        public void AltmisGunOncedenRezYap()
        {
            SqlCommand komut = new SqlCommand("EXEC AltmisGunOncedenRez @KullaniciId,@RezBasla,@RezBit", Datacon.baglanti());
            komut.Parameters.AddWithValue("@KullaniciId", Musteri.MusteriID);
            komut.Parameters.AddWithValue("@RezBasla", RezervasyonTarihi.RezervasyonBaslangicTarih);
            komut.Parameters.AddWithValue("@RezBit", RezervasyonTarihi.RezervasyonBitisTarihi);
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
            }
            else { Datacon.baglanti().Close(); }
        }
        public void KullaniciRezlerGoster()
        {
            SqlCommand komut = new SqlCommand("EXEC KullaniciRezlerGoster @KullaniciId", Datacon.baglanti());
            komut.Parameters.AddWithValue("@KullaniciId", Musteri.MusteriID);
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
            }
            else { Datacon.baglanti().Close(); }
        }

    }
}
