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
    public class JavnaNabavkaController : Controller
    {
        //private readonly AppDbContext db;

        //public JavnaNabavkaController(AppDbContext db)
        //{
        //    this.db = db;
        //}

        private readonly AuthenticationContext db;

        public JavnaNabavkaController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        //Get All JavnaNabavka
        public async Task<IActionResult> GetAllJavnaNabavka()
        {
            var JavneNabavke = await db.JavnaNabavka.ToListAsync();
            return Ok(JavneNabavke);
        }

        [HttpPut]
        [Authorize(Roles ="Administrator")]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateJavnaNabavka([FromRoute] int id, [FromBody] JavnaNabavkaVM javnaNabavka)
        {
            var jn = await db.JavnaNabavka.FirstOrDefaultAsync(x => x.Id == id);
            if (jn != null)
            {
                jn.Opis = javnaNabavka.Opis;
                await db.SaveChangesAsync();
                return Ok(jn);
            }
            return NotFound("Ne postoji javna nabavka sa tim id-om u bazi podataka.");
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteJavnaNabavka([FromRoute] int id)
        {
            var jn = await db.JavnaNabavka.FirstOrDefaultAsync(x => x.Id == id);
            if (jn != null)
            {
                db.Remove(jn);
                await db.SaveChangesAsync();
                return Ok(jn);
            }
            return NotFound("Ne postoji javna nabavka sa tim id-om u bazi podataka.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("Add")]
        public async Task<IActionResult> AddJavnaNabavka([FromBody] JavnaNabavkaVMAdd javnaNabavka)
        {
            try
            {
                var jn = new JavnaNabavka()
                {
                    Administrator = db.Administrator.ToList().Find(adm => adm.Id == javnaNabavka.AdministratorID)
                };
                jn.Opis = javnaNabavka.Opis;
                jn.pdfFajl = javnaNabavka.pdfFajl;
                jn.Administrator = await db.Administrator.FirstOrDefaultAsync(x => x.Id == jn.Administrator.Id);
                db.Administrator.ToList().Find(adm => jn.Administrator.Id == adm.Id)?.JavneNabavke.Add(jn);
                await db.JavnaNabavka.AddAsync(jn);
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
