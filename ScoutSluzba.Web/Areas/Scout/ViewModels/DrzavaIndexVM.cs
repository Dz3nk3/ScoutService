using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class DrzavaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int DrzavaID { get; set; }
            public string Naziv { get; set; }
            public string Oznaka { get; set; }

        }
    }
}
