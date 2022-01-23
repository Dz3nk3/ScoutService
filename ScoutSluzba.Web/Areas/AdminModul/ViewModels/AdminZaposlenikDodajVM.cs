﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class AdminZaposlenikDodajVM
    {
        public int ZaposlenikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Kontakt_br { get; set; }
        public string Datum_rodjenja { get; set; }

        public string Spol { get; set; }

        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }

        public int TipZaposlenikaID { get; set; }
        public List<SelectListItem> TipZaposlenika { get; set; }


        public string KorisnickiNalog { get; set; }
    }
}
