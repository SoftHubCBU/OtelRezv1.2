using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezNet
{
    public class RezervasyonTarihi
    {
        public int RezervasyonTarihID { get; set; }
        public DateTime RezervasyonYapilmaTarihi { get; set; }
        public DateTime RezervasyonBaslangicTarih { get; set; }
        public DateTime RezervasyonBitisTarihi { get; set; }
    }
}
