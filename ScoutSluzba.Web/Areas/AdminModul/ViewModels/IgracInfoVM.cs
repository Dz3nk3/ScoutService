using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class IgracInfoVM
    {
        public int IgracID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Visina { get; set; }
        public string Tezina { get; set; }
        public string Datum_rodjenja { get; set; }


        //kategorija-----------------------------------------
        public int KategorijaID { get; set; }
        public string Oznaka { get; set; }
        public string Pozicija { get; set; }
        public string Opis { get; set; }
        public string Dob { get; set; }
        //------------------------------------------------


        //specifikacija-----------------------------------------
        public int SpecifikacijaID { get; set; }
        public string BrojPogodaka { get; set; }
        public string BrojKornera { get; set; }
        public string BrojSlobodnih { get; set; }
        public string BrOffside { get; set; }
        public string CrveniKarton { get; set; }
        public string ZutiKarton { get; set; }
        //------------------------------------------------

        public string Grad { get; set; }

        public string Team { get; set; }
    }
}
