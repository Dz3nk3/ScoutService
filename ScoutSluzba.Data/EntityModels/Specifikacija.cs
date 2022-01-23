using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Specifikacija
    {
        public int SpecifikacijaID { get; set; }
        public string BrojPogodaka { get; set; }
        public string BrojKornera { get; set; }
        public string BrojSlobodnih { get; set; }
        public string BrOffside { get; set; }
        public string CrveniKarton { get; set; }
        public string ZutiKarton { get; set; }
    }
}
