using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministratorController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AdministratorController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }

        [HttpPost]
        [Route("Registracija")]
        public async  Task<Object>PostAdministrator(AdministratorVMReg kor)
        {
            var role = "Administrator";
            var korisnik = new Administrator()
            {
                UserName = kor.KorisnickoIme,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email
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
