using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OdlukaController : Controller
    {
        //private readonly AppDbContext db;

        //public OdlukaController(AppDbContext db)
        //{
        //    this.db = db;
        //}

        private readonly AuthenticationContext db;

        public OdlukaController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> getAllOdluka()
        {
            var Odluke = await db.Odluka.ToListAsync();
            return Ok(Odluke);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateOdluka([FromRoute] int id, [FromBody] OdlukaVMUpdate odluka)
        {
            var odl = await db.Odluka.FirstOrDefaultAsync(x => x.Id == id);
            if (odl != null)
            {
                odl.Opis = odluka.Opis;
                await db.SaveChangesAsync();
                return Ok(odl);
            }
            return NotFound("Ne postoji odluka sa tim id-om u bazi podataka.");
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteOdluka([FromRoute] int id)
        {
            var odl = await db.Odluka.FirstOrDefaultAsync(x => x.Id == id);
            if (odl != null)
            {
                db.Remove(odl);
                await db.SaveChangesAsync();
                return Ok(odl);
            }
            return NotFound("Ne postoji odluka sa tim id-om u bazi podataka.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("Add")]
        public async Task<IActionResult> AddOdluka([FromBody] OdlukaVMAdd odluka)
        {
            try
            {
                var odl = new Odluka()
                {
                    Administrator = db.Administrator.ToList().Find(adm => adm.Id == odluka.AdministratorID)
                };
                odl.Opis = odluka.Opis;
                odl.pdfFajl = odluka.pdfFajl;
                odl.Administrator = await db.Administrator.FirstOrDefaultAsync(x => x.Id == odl.Administrator.Id);
                db.Administrator.ToList().Find(adm => odl.Administrator.Id == adm.Id)?.Odluke.Add(odl);
                await db.Odluka.AddAsync(odl);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }
    }
}
