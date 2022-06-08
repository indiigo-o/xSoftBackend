using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using xSoftBackend.Models;
using xSoftBackend.ModelsAutentififkacija;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace xSoftBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<KategorijaKnjige> KategorijaKnjige { get; set; }
        public DbSet<Knjiga> Knjiga { get; set; }
       
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
