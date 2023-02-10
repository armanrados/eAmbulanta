using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class korisnickiNalogController : Controller
    {
        //private readonly AppDbContext db;

        //public korisnickiNalogController(AppDbContext db)
        //{
        //    this.db = db;
        //}

        //public korisnickiNalogController(AuthenticationContext db)
        //{
        //    this.db = db;
        //}

        private readonly AuthenticationContext db;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly ApplicationSettings appSettings;

        public korisnickiNalogController(AuthenticationContext db, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim, IOptions<ApplicationSettings> apps)
        {
            this.db = db;
            userManager = um;
            signInManager = sim;
            appSettings = apps.Value;
        }

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> Authenticate([FromBody] korisnickiNalogVM Korisnik)
        //{
        //    if (Korisnik == null)
        //        return BadRequest();

        //    var korObj = await db.AspNetUsers.FirstOrDefaultAsync(x => x.UserName == Korisnik.korisnickoIme
        //    && x.PasswordHash == Korisnik.lozinka);
        //    if (korObj == null)
        //    {
        //        return NotFound(new { Message = "Korisnik nije pronađen!" });

        //    }

        //    return Ok(new { Message = "Uspješan login!" });
        //}


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] korisnickiNalogVM korisnik)
        {
            var user = await userManager.FindByNameAsync(korisnik.korisnickoIme);
            if (user != null && await userManager.CheckPasswordAsync(user, korisnik.lozinka)) 
            {
                var role = await userManager.GetRolesAsync(user);
                IdentityOptions opt = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(opt.ClaimsIdentity.RoleClaimType, role.FirstOrDefault()) //ovdje ce bit null greska ako korisnik nema role
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Korisnicko ime i/ili lozinka nije/nisu tacno/a/i." });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserProfile")]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            if ((user as Pacijent) != null)
            {
                var pac = user as Pacijent;
                var lok = await db.Lokacija.FirstOrDefaultAsync(x => x.Id == pac.LokacijaID);

                return new
                {
                    pac.Id,
                    pac.UserName,
                    pac.Ime,
                    pac.Prezime,
                    pac.JMBG,
                    pac.Email,
                    pac.PhoneNumber,
                    pac.datumRodjenja,
                    lok
                };
            }
            else if ((user as Administrator) != null)
            {
                var adm = user as Administrator;
                return new
                {
                    adm.Id,
                    adm.UserName,
                    adm.Ime,
                    adm.Prezime,
                    adm.Email,
                    adm.PhoneNumber
                };
            }
            else if ((user as Doktor) != null)
            {
                var dok = user as Doktor;
                var spec = await db.Specijalizacija.FirstOrDefaultAsync(x => x.id == dok.SpecijalizacijaDoktorId);

                return new
                {
                    dok.Id,
                    dok.UserName,
                    dok.Ime,
                    dok.Prezime,
                    dok.Email,
                    dok.PhoneNumber,
                    dok.Titula,
                    spec
                };
            }
            else if ((user as MedicinskaSestraTehnicar) != null)
            {
                var mst = user as MedicinskaSestraTehnicar;
                return new
                {
                    mst.Id,
                    mst.UserName,
                    mst.Ime,
                    mst.Prezime,
                    mst.Email,
                    mst.PhoneNumber,
                    mst.Obrazovanje
                };
            }
            return BadRequest(new { message = "Korisnik nije ni pacijent ni administrator ni doktore ni medst." });
        }

    }
}
