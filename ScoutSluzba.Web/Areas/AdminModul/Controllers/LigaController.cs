using Microsoft.AspNetCore.Mvc;
using ScoutSluzba.Data;
using ScoutSluzba.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.Controllers
{
    public class LigaController : Controller
    {

        private MyContext _context;
        public LigaController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new LigaIndexVM
            {
                rows = _context.Liga
           .Select(x => new LigaIndexVM.Row
           {
               LigaID = x.LigaID,
               Naziv = x.Naziv,
               Sampion = x.Sampion,
               BrTimova = x.BrTimova             

           }).ToList()
            };
            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new LigaDodajVM();
            //??
            return View(model);
        }

        public IActionResult Obrisi(int Id)
        {
            var z = _context.Liga.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Igraca!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Igraca!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }


    }
}
