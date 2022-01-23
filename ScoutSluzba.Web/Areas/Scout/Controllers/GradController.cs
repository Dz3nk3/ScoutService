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
    public class GradController : Controller
    {

        private MyContext _context;

        public GradController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new GradIndexVM
            {
                rows = _context.Grad
               .Select(x => new GradIndexVM.Row
               {
                   GradID = x.GradID,
                   Naziv = x.Naziv,
                   PostanskiBr = x.PostanskiBr,
                   DrzavaID = x.DrzavaID

               })
               .ToList()
            };

            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new GradDodajVM();

            model.Drzava = _context.Drzava.Select(x => new SelectListItem
            {
                Value = x.DrzavaID.ToString(),
                Text = x.Naziv
            }).ToList();



            return View(model);
        }


        //Akcija: Uredi Grad
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Grad.Find(id);

            var Drzava = _context.Drzava.Find(pronadji.DrzavaID);
            var model = new GradUrediVM
            {
                GradID = id,
                Naziv = pronadji.Naziv,
                PostanskiBr = pronadji.PostanskiBr,

                Drzava = _context.Drzava.Select(x => new SelectListItem
                {
                    Value = x.DrzavaID.ToString(),
                    Text = x.Naziv
                }).ToList(),

            };

            return View(model);
        }

        public IActionResult Obrisi(int Id)
        {
            var z = _context.Grad.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Grada!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Grada!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

    }
}
