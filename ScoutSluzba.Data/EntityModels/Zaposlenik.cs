using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Zaposlenik
    {
        public int ZaposlenikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Kontakt_br { get; set; }
        public string Datum_rodjenja { get; set; }
        public string Spol { get; set; }
        public Grad Grad { get; set; }
        public int GradID { get; set; }
        public TipZaposlenika TipZaposlenika { get; set; }
        public int TipZaposlenikaID { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
