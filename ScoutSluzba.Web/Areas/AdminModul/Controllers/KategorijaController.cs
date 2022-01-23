using Microsoft.AspNetCore.Mvc;
using ScoutSluzba.Data;
using ScoutSluzba.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.Controllers
{
    public class KategorijaController : Controller
    {
        public MyContext _context;
        public KategorijaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new KategorijaIndexVM
            {
                rows = _context.Kategorija
               .Select(x => new KategorijaIndexVM.Row
               {
                   KategorijaID = x.KategorijaID,
                   Oznaka = x.Oznaka,
                   Pozicija = x.Pozicija,
                   Opis = x.Opis,
                   Dob = x.Dob

               })
               .ToList()
            };

            return View(model);
        }

        public IActionResult Dodaj()
        {
            var model = new KategorijaDodajVM();

            return View(model);
        }


        public IActionResult Obrisi(int Id)
        {
            var z = _context.Kategorija.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Kategorije!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Kategorije!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}
