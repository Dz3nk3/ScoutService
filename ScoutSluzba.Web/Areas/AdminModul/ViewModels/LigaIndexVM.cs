using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class LigaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int LigaID { get; set; }
            public string Naziv { get; set; }
            public string Sampion { get; set; }
            public string BrTimova { get; set; }
           
        }
    }
}
