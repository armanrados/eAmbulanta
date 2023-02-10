using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinskaSestraTehnicarController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public MedicinskaSestraTehnicarController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }

        [HttpPost]
        [Route("Registracija")]
        public async Task<Object> PostMedicinskaSestraTehnicar(MedicinskaSestraTehnicarVMReg kor)
        {
            var role = "MedicinskaSestraTehnicar";
            var korisnik = new MedicinskaSestraTehnicar()
            {
                UserName = kor.KorisnickoIme,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                Obrazovanje = kor.Obrazovanje
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
