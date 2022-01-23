using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Igrac
    {
        public int IgracID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Visina { get; set; }
        public string Tezina { get; set; }
        public string Datum_rodjenja { get; set; }


        public Grad Grad { get; set; }
        public int GradID { get; set; }


        public Kategorija Kategorija{ get; set; }
        public int KategorijaID { get; set; }


        public Specifikacija Specifikacija{ get; set; }
        public int SpecifikacijaID { get; set; }


        public Team Team { get; set; }
        public int TeamID { get; set; }
    }
}
