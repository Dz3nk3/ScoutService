using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class SpecifikacijaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
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
}
