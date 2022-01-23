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
    public class IgraciController : Controller
    {
        private MyContext _context;

        public IgraciController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new IgracIndexVM
            {
                igraci = _context.Igrac
                .Select(x => new IgracIndexVM.Row
                {
                    IgracID = x.IgracID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Visina = x.Visina,
                    Tezina = x.Tezina,
                    DatumRodjenja = x.Datum_rodjenja,
                    GradID = x.GradID,
                    TeamID = x.TeamID,
                    Prosjek = '-'

                })
                .ToList()
            };

            return View(model);
        }



        //Akcija: Dodaj novog zaposlenika
        public IActionResult Dodaj()
        {
            var model = new IgracDodajVM();

            model.Grad = _context.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();

            //ZA KATEGORIJU I SPECIFIKACIJU TREBA DA SE NAPRAVI NOVA DODAJ FORMA

            //model.Kategorija = _context.Kategorija.Select(x => new SelectListItem
            //{
            //    Value = x.KategorijaID.ToString(),
            //    Text = x.Pozicija
            //}).ToList();


            //model.Specifikacija = _context.Specifikacija.Select(x => new SelectListItem
            //{
            //    Value = x.SpecifikacijaID.ToString(),
            //    Text = x.BrojSlobodnih
            //}).ToList();


            model.Team = _context.Team.Select(x => new SelectListItem
            {
                Value = x.TeamID.ToString(),
                Text = x.Naziv
            }).ToList();


            return View(model);
        }


        ////Akcija: Uredi zaposlenika
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Igrac.Find(id);
            //var Kategorij = new Kategorija();
            //var Specifikacija = new Specifikacija();

            var Kategorij = _context.Kategorija.Find(pronadji.KategorijaID);
            var Specifikacija = _context.Specifikacija.Find(pronadji.SpecifikacijaID);
            var model = new IgracUrediVM
            {
                IgracID = id,
                Ime = pronadji.Ime,
                Prezime = pronadji.Prezime,
                Visina = pronadji.Visina,

                Tezina = pronadji.Tezina,
                Datum_rodjenja = pronadji.Datum_rodjenja,

             

                //kategorija-----------------------------------
                KategorijaID = Kategorij.KategorijaID,
                Oznaka = Kategorij.Oznaka,
                Pozicija = Kategorij.Pozicija,
                Opis = Kategorij.Opis,
                Dob = Kategorij.Dob,
                //------------------------------------------------



                //specifikacija-----------------------------------
                SpecifikacijaID = Specifikacija.SpecifikacijaID,
                BrojPogodaka = Specifikacija.BrojPogodaka,
                BrojKornera = Specifikacija.BrojKornera,
                BrojSlobodnih = Specifikacija.BrojSlobodnih,
                BrOffside = Specifikacija.BrOffside,
                CrveniKarton = Specifikacija.CrveniKarton,
                ZutiKarton = Specifikacija.ZutiKarton,
                //------------------------------------------------

                Grad = _context.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),



                Team = _context.Team.Select(x => new SelectListItem
                {
                    Value = x.TeamID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };


            return View(model);
        }


        public IActionResult Info(int id)
        {
            var pronadji = _context.Igrac.Find(id);
            //var Kategorij = new Kategorija();
            //var Specifikacija = new Specifikacija();

            var Kategorij = _context.Kategorija.Find(pronadji.KategorijaID);
            var Specifikacija = _context.Specifikacija.Find(pronadji.SpecifikacijaID);
            var Grad = _context.Grad.Find(pronadji.GradID);
            var Team = _context.Team.Find(pronadji.TeamID);
            IgracInfoVM model = new IgracInfoVM
            {
                IgracID = id,
                Ime = pronadji.Ime,
                Prezime = pronadji.Prezime,
                Visina = pronadji.Visina,

                Tezina = pronadji.Tezina,
                Datum_rodjenja = pronadji.Datum_rodjenja,



                //kategorija-----------------------------------
                KategorijaID = Kategorij.KategorijaID,
                Oznaka = Kategorij.Oznaka,
                Pozicija = Kategorij.Pozicija,
                Opis = Kategorij.Opis,
                Dob = Kategorij.Dob,
                //------------------------------------------------



                //specifikacija-----------------------------------
                SpecifikacijaID = Specifikacija.SpecifikacijaID,
                BrojPogodaka = Specifikacija.BrojPogodaka,
                BrojKornera = Specifikacija.BrojKornera,
                BrojSlobodnih = Specifikacija.BrojSlobodnih,
                BrOffside = Specifikacija.BrOffside,
                CrveniKarton = Specifikacija.CrveniKarton,
                ZutiKarton = Specifikacija.ZutiKarton,
                //------------------------------------------------

                Grad = Grad.Naziv,
                Team = Team.Naziv
            };


            return View(model);
        }

        //Akcija: Snimi
        //public IActionResult Snimi(IgracDodajVM input)
        //{
        //    Igrac igrac;
        //    if (input.IgracID == 0)
        //    {
        //        igrac = new Igrac();
        //        _context.Add(igrac);
        //    }
        //    else
        //    {
        //        igrac = _context.Zaposlenik.Find(input.ZaposlenikID);
        //    }
        //    igrac.Ime = input.Ime;
        //    igrac.Prezime = input.Prezime;
        //    igrac.Visina = input.Visina;
        //    igrac.Tezina = input.Tezina;
        //    igrac.Datum_rodjenja = input.Datum_rodjenja;
        //    igrac.GradID = input.GradID;

        //    _context.SaveChanges();


        //    KorisnickiNalog kn = new KorisnickiNalog();
        //    if (igrac.KorisnickiNalogID == null)
        //    {
        //        kn.KorisnickoIme = igrac.Ime;
        //        kn.Lozinka = igrac.Ime;
        //        kn.TipKorisnickogNaloga = "Zaposlenik";

        //        _context.korisnickiNalog.Add(kn);
        //        _context.SaveChanges();

        //        //igrac.KorisnickiNalogID = kn.KorisnickiNalogID;

        //        _context.Zaposlenik.Update(igrac);
        //        _context.SaveChanges();
        //    }

        //    _context.Dispose();

        //    TempData["porukaSuccess"] = "Zaposlenik uspjesno dodat!!!";
        //    return RedirectToAction("Index");

        //}


        //Akcija: Obrisi zaposlenika
        public IActionResult Obrisi(int Id)
        {
            var z = _context.Igrac.Find(Id);
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
