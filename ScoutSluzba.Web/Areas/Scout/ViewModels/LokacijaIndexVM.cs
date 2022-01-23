using ScoutSluzba.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class LokacijaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int LokacijaID { get; set; }
            public string Naziv { get; set; }
            public string Ulica { get; set; }
            public string Adresa { get; set; }
            public int GradID { get; set; }

        }
    }
}
