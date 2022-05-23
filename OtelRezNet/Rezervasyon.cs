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
    }
}
