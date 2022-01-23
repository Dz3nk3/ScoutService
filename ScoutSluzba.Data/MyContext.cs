using Microsoft.EntityFrameworkCore;
using ScoutSluzba.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoutSluzba.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> x):base(x)
        {

        }


        public DbSet<Drzava> Drzava { get; set; } 
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Greska> Greska { get; set; }
        public DbSet<Igrac> Igrac{ get; set; }
        public DbSet<Kategorija> Kategorija{ get; set; }
        public DbSet<KorisnickiNalog> korisnickiNalog{ get; set; }
        public DbSet<Liga> Liga{ get; set; }
        public DbSet<Lokacija> Lokacija{ get; set; }
        public DbSet<OcjenaKomentar> OcjenaKomentar{ get; set; }
        public DbSet<Specifikacija> Specifikacija{ get; set; }
        public DbSet<Team> Team{ get; set; }
        public DbSet<Zaposlenik> Zaposlenik{ get; set; }
        public DbSet<TipZaposlenika> TipZaposlenika{ get; set; }
    }
}
