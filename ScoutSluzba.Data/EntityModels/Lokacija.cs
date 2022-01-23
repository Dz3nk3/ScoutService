using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data.EntityModels
{
    public class Lokacija
    {
        public int LokacijaID { get; set; }
        public string Naziv { get; set; }
        public string Ulica { get; set; }
        public string Adresa { get; set; }

        public Grad Drzava { get; set; }
        public int GradID { get; set; }
    }
}
