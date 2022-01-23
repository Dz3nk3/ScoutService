using ScoutSluzba.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class GradIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int GradID { get; set; }
            public string Naziv { get; set; }
            public string PostanskiBr { get; set; }
            public int DrzavaID { get; set; }
            public Drzava Drzava { get; set; }

        }
    }
}
