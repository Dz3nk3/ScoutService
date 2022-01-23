using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class OcjenaKomentar
    {
        public int OcjenaKomentarID { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }


        public Zaposlenik Zaposlenik{ get; set; }
        public int ZaposlenikID { get; set; }


        public Igrac Igrac{ get; set; }
        public int IgracID { get; set; }
    }
}
