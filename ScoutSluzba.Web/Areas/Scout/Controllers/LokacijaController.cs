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
    public class LokacijaController : Controller
    {
        private MyContext _context;

        public LokacijaController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new LokacijaIndexVM
            {
                rows = _context.Lokacija
               .Select(x => new LokacijaIndexVM.Row
               {
                   LokacijaID = x.LokacijaID,
                   Naziv = x.Naziv,
                   Ulica = x.Ulica,
                   Adresa = x.Adresa,
                   GradID = x.GradID

               })
               .ToList()
            };

            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new LokacijaDodajVM();

            model.Grad = _context.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();



            return View(model);
        }


        //Akcija: Uredi Lokaciju
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Lokacija.Find(id);

            var model = new LokacijaUrediVM
            {
                LokacijaID = id,
                Naziv = pronadji.Naziv,
                Ulica = pronadji.Ulica,
                Adresa = pronadji.Adresa,

                Grad = _context.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),

            };

            return View(model);
        }

        public IActionResult Obrisi(int Id)
        {
            var z = _context.Lokacija.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Lokacije!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Lokacije!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}
