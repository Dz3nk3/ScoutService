using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoutSluzba.Data;
using ScoutSluzba.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.Controllers
{
    public class SpecifikacijaController : Controller
    {
        private MyContext _context;

        public SpecifikacijaController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new SpecifikacijaIndexVM
            {
                rows = _context.Specifikacija
               .Select(x => new SpecifikacijaIndexVM.Row
               {
                   SpecifikacijaID = x.SpecifikacijaID,
                   BrojPogodaka = x.BrojPogodaka,
                   BrojKornera = x.BrojKornera,
                   BrojSlobodnih = x.BrojSlobodnih,
                   BrOffside = x.BrOffside,
                   CrveniKarton = x.CrveniKarton,
                   ZutiKarton = x.ZutiKarton

               })
               .ToList()
            };

            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new SpecifikacijaDodajVM();

            return View(model);
        }
        public IActionResult Obrisi(int Id)
        {
            var z = _context.Specifikacija.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Specifikacije!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Specifikacije!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

    }
}
