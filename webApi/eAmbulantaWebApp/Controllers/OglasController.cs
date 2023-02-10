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
    public class OglasController : Controller
    {
        //private readonly AppDbContext db;

        //public OglasController(AppDbContext db)
        //{
        //    this.db = db;
        //}

        private readonly AuthenticationContext db;

        public OglasController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllOglas()
        {
            var Oglasi = await db.Oglas.ToListAsync();
            return Ok(Oglasi);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateOglas([FromRoute] int id, [FromBody] OglasVMUpdate oglas)
        {
            var ogl = await db.Oglas.FirstOrDefaultAsync(x => x.Id == id);
            if (ogl != null)
            {
                ogl.Naziv = oglas.Naziv;
                ogl.Sadrzaj = oglas.Sadrzaj;
                await db.SaveChangesAsync();
                return Ok(ogl);
            }
            return NotFound("Ne postoji oglas sa tim id-om u bazi podataka.");
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteOglas([FromRoute] int id)
        {
            var ogl = await db.Oglas.FirstOrDefaultAsync(x => x.Id == id);
            if (ogl != null)
            {
                db.Remove(ogl);
                await db.SaveChangesAsync();
                return Ok(ogl);
            }
            return NotFound("Ne postoji oglas sa tim id-om u bazi podataka.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("Add")]
        public async Task<IActionResult> AddOglas([FromBody] OglasVMAdd oglas)
        {
            try
            {
                var ogl = new Oglas()
                {
                    Administrator = db.Administrator.ToList().Find(adm => adm.Id == oglas.AdministratorID)
                };
                ogl.Naziv = oglas.Naziv;
                ogl.Sadrzaj = oglas.Sadrzaj;
                ogl.Administrator = await db.Administrator.FirstOrDefaultAsync(x => x.Id == ogl.Administrator.Id);
                db.Administrator.ToList().Find(adm => ogl.Administrator.Id == adm.Id)?.Oglasi.Add(ogl);
                await db.Oglas.AddAsync(ogl);
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
