using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public string Oznaka { get; set; }
        public string Pozicija { get; set; }
        public string Opis { get; set; }
        public string Dob { get; set; }
    }
}
