using eAmbulantaWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Data
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<IdentityUser> AspNetUsers { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<MedicinskaSestraTehnicar> MedicinskaSestraTehnicar { get; set; }
        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<Odluka> Odluka { get; set; }
        public DbSet<Novost> Novost { get; set; }
        public DbSet<JavnaNabavka> JavnaNabavka { get; set; }
        public DbSet<Specijalizacija> Specijalizacija { get; set; }
        public DbSet<Pregled> Pregled { get; set; }
        public DbSet<Lijek> Lijek { get; set; }
        public DbSet<Bolest> Bolest { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<MedicinskiTretman> MedicinskiTretman { get; set; }
        public DbSet<Posjeta> Posjeta { get; set; }
    }
}
