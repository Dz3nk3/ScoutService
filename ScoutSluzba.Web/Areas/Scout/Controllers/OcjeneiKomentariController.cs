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
    public class OcjeneiKomentariController : Controller
    {

        private MyContext _context;

        public OcjeneiKomentariController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var model = new OcjeneiKomentariIndexVM
            {
                row = _context.OcjenaKomentar
               .Select(x => new OcjeneiKomentariIndexVM.Row
               {
                   OcjenaKomentarID = x.OcjenaKomentarID,
                   Ocjena = x.Ocjena,
                   Komentar = x.Komentar,
                   ZaposlenikID = x.ZaposlenikID,
                   //Zaposlenik = _context.Zaposlenik.Find(x.ZaposlenikID).Ime + ' '+ _context.Zaposlenik.Find(x.ZaposlenikID).Prezime,
                   IgracID = x.IgracID,
                   //Igrac = _context.Igrac.Find(x.IgracID).Ime + ' ' + _context.Igrac.Find(x.IgracID).Prezime

               })
               .ToList()
            };

            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new OcjeneiKomentariDodajVM();

            model.Zaposlenik = _context.Zaposlenik.Select(x => new SelectListItem
            {
                Value = x.ZaposlenikID.ToString(),
                Text = x.Ime +' '+ x.Prezime
            }).ToList();

            model.Igrac = _context.Igrac.Select(x => new SelectListItem
            {
                Value = x.IgracID.ToString(),
                Text = x.Ime + ' ' + x.Prezime
            }).ToList();


            return View(model);
        }


        //Akcija: Uredi Ocjenu i komentar
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.OcjenaKomentar.Find(id);

            var zaposlenik = _context.Zaposlenik.Find(pronadji.ZaposlenikID);
            var igrac = _context.Igrac.Find(pronadji.IgracID);
            var model = new OcjeneiKomentariUrediVM
            {
                OcjenaKomentarID = id,
                Ocjena = pronadji.Ocjena,
                Komentar = pronadji.Komentar,

                Zaposlenik = _context.Zaposlenik.Select(x => new SelectListItem
                {
                    Value = x.ZaposlenikID.ToString(),
                    Text = x.Ime + ' ' + x.Prezime
                }).ToList(),

                Igrac = _context.Igrac.Select(x => new SelectListItem
                {
                    Value = x.IgracID.ToString(),
                    Text = x.Ime + ' ' + x.Prezime
                }).ToList(),

             };

            return View(model);
        }

        public IActionResult Obrisi(int Id)
        {
            var z = _context.OcjenaKomentar.Find(Id);
            //var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Ocjene i komentara!!!";
            }
            else
            {
                _context.Remove(z);
                //_context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Ocjene i komentara!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

    }
}
