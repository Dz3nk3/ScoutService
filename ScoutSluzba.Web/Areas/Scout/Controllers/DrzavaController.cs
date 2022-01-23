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
    public class DrzavaController : Controller
    {
        private MyContext _context;
        public DrzavaController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new DrzavaIndexVM
            {                rows = _context.Drzava
            .Select(x => new DrzavaIndexVM.Row
            {
             DrzavaID = x.DrzavaID,
             Naziv = x.Naziv,
             Oznaka = x.Oznaka

             }).ToList()
            };
            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new DrzavaDodajVM();

            return View(model);
        }


        //Akcija: Uredi Drzavu
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Drzava.Find(id);

            var model = new DrzavaUrediVM
            {
                DrzavaID = id,
                Naziv = pronadji.Naziv,
                Oznaka = pronadji.Oznaka
            };

            return View(model);
        }

        public IActionResult Obrisi(int Id)
        {
            var z = _context.Drzava.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Drzave!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Drzave!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}
