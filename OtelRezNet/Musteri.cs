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
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
    }
}
