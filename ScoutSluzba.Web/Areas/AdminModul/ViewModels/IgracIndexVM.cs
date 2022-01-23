using ScoutSluzba.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class IgracIndexVM
    {
        public List<Row> igraci { get; set; }

        public class Row
        {
            public int IgracID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Visina { get; set; }
            public string Tezina { get; set; }
            public string DatumRodjenja { get; set; }
            public string Grad { get; set; }
            public int GradID { get; set; }
            public string Team { get; set; }
            public int TeamID { get; set; }
            public double Prosjek { get; set; }
        }
    }

}
