using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacijentController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public PacijentController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }

        [HttpPost]
        [Route("Registracija")]
        public async Task<Object> PostPacijent(PacijentVMReg kor)
        {
            var role = "Pacijent";
            var korisnik = new Pacijent()
            {
                UserName = kor.KorisnickoIme,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                JMBG = kor.JMBG,
                datumRodjenja = DateTime.Parse(kor.DatumRodjenja),
                Lokacija = new Lokacija() { Adresa = kor.Lokacija.Adresa, Latitude = kor.Lokacija.Latitude, Longitude = kor.Lokacija.Longitude}
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
    }
}
