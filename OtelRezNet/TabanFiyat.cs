using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace OtelRezNet
{
    public class TabanFiyat
    {
        public DateTime Gun { get; set; }
        public decimal Fiyat { get; set; }
        public void TabanFiyatEkleVeyaDegistir()
        {
            SqlCommand komut = new SqlCommand("EXEC TabanFiyatDegistir @Gun,@Fiyat", Datacon.baglanti());
            komut.Parameters.AddWithValue("@Gun", Gun);
            komut.Parameters.AddWithValue("@Fiyat", Fiyat);
            int cmd = komut.ExecuteNonQuery();
            if (cmd != 0)
            {
                Datacon.baglanti().Close();
            }
            else { Datacon.baglanti().Close(); }
        }
    }
}
