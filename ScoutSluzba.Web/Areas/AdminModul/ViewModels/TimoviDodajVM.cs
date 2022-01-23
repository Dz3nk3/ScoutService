using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class TimoviDodajVM
    {
        public int TimID { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }
        public string Stadion { get; set; }
        public string Manager { get; set; }
        public string Predsjednik { get; set; }
        public string Lokacija { get; set; }
        public int LigaID { get; set; }
        public List<SelectListItem> Liga { get; set; }
    }
}
