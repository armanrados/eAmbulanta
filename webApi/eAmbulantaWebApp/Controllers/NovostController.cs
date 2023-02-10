using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NovostController : Controller
    {
        private readonly AuthenticationContext db;

        public NovostController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllNovost()
        {
            var NovostiSorted = db.Novost.OrderByDescending(n => n.datumIVrijemeObjave).ToList();
            return Ok(NovostiSorted);
        }

        [HttpGet]
        [Route("GetNovost")]
        public async Task<IActionResult> GetNovost([FromQuery] int id)
        {
            var Novost = await db.Novost.FirstOrDefaultAsync(n => n.Id == id);
            return Ok(Novost);
        }

        [HttpGet]
        [Route("GetAllNajstarije")]
        public async Task<IActionResult> GetAllNajstarije()
        {
            var NovostiSorted = db.Novost.OrderBy(n => n.datumIVrijemeObjave).ToList();
            return Ok(NovostiSorted);
        }

        [HttpGet]
        [Route("GetAllPretrazivanje")]
        public async Task<IActionResult> GetAllPretrazivanjeNovost([FromQuery] string input)
        {
            var NovostiSorted = db.Novost.OrderByDescending(n => n.datumIVrijemeObjave).ToList();
            var NovostiInput = NovostiSorted.Where(n => n.Naziv.Contains(input));
            return Ok(NovostiInput);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("Add")]
        public async Task<IActionResult> AddNovost([FromBody] NovostVMAdd novost)
        {
            try
            {
                var n = new Novost()
                {
                    Administrator = db.Administrator.ToList().Find(adm => adm.Id == novost.AdministratorID)
                };
                n.Naziv = novost.Naziv;
                n.Opis = novost.Opis;
                n.Sadrzaj = novost.Sadrzaj;
                n.Slika = novost.Slika;
                n.datumIVrijemeObjave = DateTime.ParseExact(novost.datum + ' ' + novost.vrijeme, "yyyy-MM-dd H:mm", System.Globalization.CultureInfo.InvariantCulture);
                await db.Novost.AddAsync(n);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteNovost([FromRoute] int id)
        {
            var n = await db.Novost.FirstOrDefaultAsync(x => x.Id == id);
            if (n != null)
            {
                db.Remove(n);
                await db.SaveChangesAsync();
                return Ok(n);
            }
            return NotFound("Ne postoji novost sa tim id-om u bazi podataka.");
        }
    }
}
