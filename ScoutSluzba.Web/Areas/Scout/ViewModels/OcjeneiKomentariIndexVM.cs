using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class OcjeneiKomentariIndexVM
    {
        public List<Row> row { get; set; }

        public class Row
        {
            public int OcjenaKomentarID { get; set; }
            public int Ocjena { get; set; }
            public string Komentar { get; set; }
            public int ZaposlenikID { get; set; }
            public string Zaposlenik { get; set; }
            public int IgracID { get; set; }
            public string Igrac { get; set; }

        }
    }
}
