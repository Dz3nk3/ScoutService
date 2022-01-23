using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.ViewModels
{
    public class GradUrediVM
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBr { get; set; }
        public int DrzavaID { get; set; }
        public List<SelectListItem> Drzava { get; set; }
    }
}
