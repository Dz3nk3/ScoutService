using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class ZaposlenikIndexVM
    {
        public List<Row> rows;

        public class Row
        {
            public int ZaposlenikID { get; set; }

            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Kontakt_br { get; set; }
            public string Datum_rodjenja { get; set; }
            public string Spol { get; set; }

            public string Grad { get; set; }

            public string TipZaposlenika { get; set; }

            public string KorisnickiNalog { get; set; }

        }
    }
}
