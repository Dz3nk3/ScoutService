using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoutSluzba.Data;
using ScoutSluzba.Data.EntityModels;
using ScoutSluzba.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutSluzba.Web.Controllers
{
    public class ZaposlenikController : Controller
    {
        private MyContext _context;
        public ZaposlenikController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ZaposlenikIndexVM
            {
                rows = _context.Zaposlenik
                .Select(x => new ZaposlenikIndexVM.Row
                {
                    ZaposlenikID = x.ZaposlenikID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    Kontakt_br = x.Kontakt_br,
                    Datum_rodjenja = x.Datum_rodjenja,
                    Grad = x.Grad.Naziv,
                    //TipZaposlenika = x.TipZaposlenika.Naziv,
                    //KorisnickiNalog = x.KorisnickiNalog.TipKorisnickogNaloga

                }).ToList()
            };
            return View(model);
        }

        //Akcija: Dodaj novog zaposlenika
        public IActionResult Dodaj()
        {
            var model = new AdminZaposlenikDodajVM();

            model.Grad = _context.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();


            model.TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
            {
                Value = x.TipZaposlenikaID.ToString(),
                Text = x.Naziv
            }).ToList();

            return View(model);
        }


        ////Akcija: Uredi zaposlenika
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Zaposlenik.Find(id);
            var model = new AdminZaposlenikUrediVM
            {
                ZaposlenikID = id,
                Ime = pronadji.Ime,
                Prezime = pronadji.Prezime,
                Email = pronadji.Email,

                Kontakt_br = pronadji.Kontakt_br,
                Datum_rodjenja = pronadji.Datum_rodjenja,

                Grad = _context.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),


                TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
                {
                    Value = x.TipZaposlenikaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
            };

            return View(model);
        }

        //Akcija: Snimi
        public IActionResult Snimi(AdminZaposlenikDodajVM input)
        {
            Zaposlenik zaposlenik;
            if (input.ZaposlenikID == 0)
            {
                zaposlenik = new Zaposlenik();
                _context.Add(zaposlenik);
            }
            else
            {
                zaposlenik = _context.Zaposlenik.Find(input.ZaposlenikID);
            }
            zaposlenik.Ime = input.Ime;
            zaposlenik.Prezime = input.Prezime;
            zaposlenik.Email = input.Email;
            zaposlenik.Kontakt_br = input.Kontakt_br;
            zaposlenik.Datum_rodjenja = input.Datum_rodjenja;
            zaposlenik.GradID = input.GradID;
            zaposlenik.TipZaposlenikaID = input.TipZaposlenikaID;

            _context.SaveChanges();


            KorisnickiNalog kn = new KorisnickiNalog();
            if (zaposlenik.KorisnickiNalogID == null)
            {
                kn.KorisnickoIme = zaposlenik.Ime;
                kn.Lozinka = zaposlenik.Ime;
                kn.TipKorisnickogNaloga = "Zaposlenik";

                _context.korisnickiNalog.Add(kn);
                _context.SaveChanges();

                zaposlenik.KorisnickiNalogID = kn.KorisnickiNalogID;

                _context.Zaposlenik.Update(zaposlenik);
                _context.SaveChanges();
            }

            _context.Dispose();

            TempData["porukaSuccess"] = "Zaposlenik uspjesno dodat!!!";
            return RedirectToAction("Index");

        }


        //Akcija: Obrisi zaposlenika
        public IActionResult Obrisi(int id)
        {
            var z = _context.Zaposlenik.Find(id);
            var kn = _context.korisnickiNalog.Where(x => x.KorisnickiNalogID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju zaposlenika!!!";
            }
            else
            {
                _context.Remove(z);
                _context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali zaposlenika!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

    }
}
