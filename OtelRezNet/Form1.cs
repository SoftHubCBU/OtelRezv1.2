using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace OtelRezNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("EXEC KullaniciGirisSorgu 'crayzbaris@gmail.com','01470147',3 ", Datacon.baglanti());
            ////komut.Parameters.AddWithValue("@p1", tipi);
            ////komut.Parameters.AddWithValue("@p2", kullaniciadi);
            ////komut.Parameters.AddWithValue("@p3", sifre);
            //SqlDataReader dr = komut.ExecuteReader();
            //if (dr.Read())
            //{
            //    MessageBox.Show(Convert.ToString(dr[0]) + Convert.ToString(dr[1]));
            //    Datacon.baglanti().Close();

            //}
            Rezervasyon rez = new Rezervasyon();
            rez.RezervasyonCek();
            MessageBox.Show(rez.rezlist[0].Musteri.MusteriAd+rez.rezlist[1].Odeme.OdemeTutari);
        }

    }
}
