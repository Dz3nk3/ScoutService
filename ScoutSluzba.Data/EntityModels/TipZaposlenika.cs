using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class TipZaposlenika
    {
        public int TipZaposlenikaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
