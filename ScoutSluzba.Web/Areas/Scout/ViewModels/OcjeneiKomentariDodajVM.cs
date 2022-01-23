using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class OcjeneiKomentariDodajVM
    {
        public int OcjenaKomentarID { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> Zaposlenik { get; set; }
        public int IgracID { get; set; }
        public List<SelectListItem> Igrac { get; set; }
    }
}
