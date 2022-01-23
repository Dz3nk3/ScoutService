using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class KorisnickiNalog
    {
        public int KorisnickiNalogID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string TipKorisnickogNaloga { get; set; }
    }
}
