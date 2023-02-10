using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoktorController : Controller
    {
        private readonly AuthenticationContext db;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public DoktorController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim, AuthenticationContext db)
        {
            this.db = db;
            userManager = um;
            signInManager = sim;
        }

        [HttpPost]
        [Route("Registracija")]
        public async Task<Object> PostDoktor(DoktorVMReg kor)
        {
            var role = "Doktor";
            var korisnik = new Doktor()
            {
                UserName = kor.KorisnickoIme,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                Titula = kor.Titula
            };

            try
            {
                var result = await userManager.CreateAsync(korisnik, kor.Lozinka);
                await userManager.AddToRoleAsync(korisnik, role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetSveDoktore")]
        public async Task<Object> GetUserProfile()
        {
            IList<IdentityUser> doktoriIU = userManager.GetUsersInRoleAsync("Doktor").Result;
            List<DoktorVMGet> doktori = new List<DoktorVMGet>();
            foreach (var iu in doktoriIU)
            {
                Doktor dok = iu as Doktor;
                doktori.Add(new DoktorVMGet { Id = dok.Id, Ime = dok.Ime, Prezime = dok.Prezime, UserName = dok.UserName, Titula = dok.Titula, EMail = dok.Email, Telefon = dok.PhoneNumber });
            }
            if (doktori != null)
            {
                return doktori;
            }
            return BadRequest(new { message = "Korisnik nije doktor." });
        }
    }
}
