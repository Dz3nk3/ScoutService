using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class LokacijaDodajVM
    {
        public int LokacijaID { get; set; }
        public string Naziv { get; set; }
        public string Ulica { get; set; }
        public string Adresa { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }
    }
}
