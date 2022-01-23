using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class IgracDodajVM
    {
        public int IgracID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Visina { get; set; }
        public string Tezina { get; set; }
        public string DatumRodjenja { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int GradID { get; set; }


        public List<SelectListItem> Kategorija { get; set; }
        public int KategorijaID { get; set; }

        public List<SelectListItem> Specifikacija { get; set; }
        public int SpecifikacijaID { get; set; }

        public List<SelectListItem> Team { get; set; }
        public int TeamID { get; set; }
        public double Prosjek { get; set; }


    }
}
