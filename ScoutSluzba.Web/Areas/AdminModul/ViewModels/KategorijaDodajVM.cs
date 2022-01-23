using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class KategorijaDodajVM
    {
        public int KategorijaID { get; set; }
        public string Oznaka { get; set; }
        public string Pozicija { get; set; }
        public string Opis { get; set; }
        public string Dob { get; set; }

    }
}
