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
    public class TimoviController : Controller
    {
        private MyContext _context;
        public TimoviController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var model = new TimoviIndexVM
            {
                rows = _context.Team
             .Select(x => new TimoviIndexVM.Row
             {
                 TimID = x.TeamID,
                 Naziv = x.Naziv,
                 Trener = x.Trener,
                 Stadion = x.Stadion,
                 Manager = x.Manager,
                 Predsjednik = x.President,
                 Lokacija = x.Lokacija

                }).ToList()
            };
            return View(model);

          //  var path = Path.Combine(
          //           Directory.GetCurrentDirectory(), "wwwroot/Slike",
          //           "ae.png");


          //  byte[] imageArray = System.IO.File.ReadAllBytes(path);
          //  string imageBase64 = Convert.ToBase64String(imageArray);



          //  List<Softver> softveri = _context.Softver.ToList();
          //  ViewBag.Softveri = softveri;


          //  int ExcludeRecords = (pageSize * pageNumber) - pageSize;
          //  var model = new SoftvareKlijentIndexVM();
          //  var result = new PagedResult<SoftvareKlijentIndexVM.Row>();
          //  //var ocjenaTrazi = _context.SoftverNarudzba.Where(x=>x.oc)

          //  model.rows = _context.Softver
          //.Select(x => new SoftvareKlijentIndexVM.Row
          //{
          //    SoftverID = x.SoftverID,
          //    imgfilename = x.imgurl,
          //    Naziv = x.Naziv,
          //    Verzija = x.Verzija,
          //    Cijena = x.Cijena,

          //    Ocjena = (int)_context.SoftverNarudzba.Where(z => z.SoftverID == x.SoftverID)
          //    .Select(z => z.Ocjena).Average(),

          //    Komentar = _context.SoftverNarudzba.OrderByDescending(c => c.Datum)
          //    .Where(z => z.SoftverID == x.SoftverID)
          //    .Select(z => z.Komentar).FirstOrDefault(),

          //    TipSoftvera = x.TipSoftvera.Naziv

          //}).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

          //  result = new PagedResult<SoftvareKlijentIndexVM.Row>
          //  {
          //      Data = model.rows.ToList(),
          //      TotalItems = _context.Softver.Count(),
          //      PageNumber = pageNumber,
          //      PageSize = pageSize
          //  };

          //  return View(result);
        }




        public IActionResult Info(int id)
        {
            var pronadji = _context.Team.Find(id);
            var Liga = _context.Liga.Find(pronadji.LigaID);
            var model = new TimoviInfoVM
            {
                TimID = id,
                Naziv = pronadji.Naziv,
                Trener = pronadji.Trener,
                Stadion = pronadji.Stadion,
                Manager = pronadji.Manager,
                Predsjednik = pronadji.President,
                Lokacija = pronadji.Lokacija,
                LigaID = Liga.LigaID,
                Liga = Liga.Naziv

            };


            return View(model);
        }



        public IActionResult Dodaj()
        {
            var model = new TimoviDodajVM();

            model.Liga = _context.Liga.Select(x => new SelectListItem
            {
                Value = x.LigaID.ToString(),
                Text = x.Naziv
            }).ToList();



            return View(model);
        }




        public IActionResult Obrisi(int Id)
        {
            var z = _context.Team.Find(Id);
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
