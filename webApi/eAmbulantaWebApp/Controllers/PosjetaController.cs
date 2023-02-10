using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosjetaController : Controller
    {
        //private readonly AppDbContext db;

        //public PosjetaController(AppDbContext db)
        //{
        //    this.db = db;
        //}

        private readonly AuthenticationContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;



        public PosjetaController(AuthenticationContext db, UserManager<IdentityUser> um, SignInManager<IdentityUser> sm)
        {
            this.db = db;
            userManager = um;
            signInManager = sm;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> getAllPosjeta()
        {
            var posjete = await db.Posjeta.ToListAsync();
            return Ok(posjete);
        }
        [HttpGet]
        [Authorize(Roles = "Pacijent")]
        [Route("GetMojePosjete")]
        public async Task<IActionResult> GetMojePosjete()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PosjetaVMGet> posjete = new List<PosjetaVMGet>();
            foreach (var po in db.Posjeta)
            {
                if (po.PacijentId == user.Id)
                {
                    posjete.Add(new PosjetaVMGet { Napomena = po.Napomena, Odgovor = po.Odgovor, Odobreno = po.Odobreno, PacijentID = po.PacijentId, MedicinskaSestraTehnicarID = po.MedicinskaSestraTehnicarId });
                }
            }
            return Ok(posjete);
        }


        [HttpPut]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> UpdatePosjete([FromRoute] Guid id, [FromBody] PosjetaVMUpdate posjeta)
        {
            var posj = await db.Posjeta.FindAsync(id);

            if(posj == null)
            {
                return NotFound();
            }

            posj.Odobreno = posjeta.Odobreno;
            posj.Odgovor = posjeta.Odgovor;

            await db.SaveChangesAsync();
            return Ok(posj);

        }
        [HttpGet]
        [Route("Get/{id:Guid}")]
        public async Task<IActionResult> GetPosjeta([FromRoute] Guid id)
        {
          var posjeta =  await db.Posjeta.FirstOrDefaultAsync(x => x.Id == id);
            if(posjeta == null)
            {
                return NotFound();
            }

            //msm da ovako nesto treba da bi radilo, ali iz nekog razloga vraca posjeta.MedicinskaSestraTehnicar.Id null isto i za pacijenta
            //PosjetaVMGet posj = new PosjetaVMGet { Id = posjeta.Id.ToString(), Odobreno = posjeta.Odobreno, Napomena = posjeta.Napomena, Odgovor = posjeta.Odgovor, MedicinskaSestraTehnicarID = posjeta.MedicinskaSestraTehnicar.Id, PacijentID = posjeta.Pacijent.Id };
            //return Ok(posj);
            return Ok(posjeta);
        }
        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public async Task<IActionResult> DeletePosjeta([FromRoute] Guid id)
        {
            var posj = await db.Posjeta.FirstOrDefaultAsync(x => x.Id == id);
            if (posj != null)
            {
                db.Remove(posj);
                await db.SaveChangesAsync();
                return Ok(posj);
            }
            return NotFound("Ne postoji posjeta sa tim id-om u bazi podataka.");
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddPosjeta([FromBody] PosjetaVMAdd posjeta)
        {
            try
            {
                var posj = new Posjeta()
                {
                    MedicinskaSestraTehnicar = db.MedicinskaSestraTehnicar.ToList().Find(mst => mst.Id == posjeta.MedicinskaSestraTehnicarID),
                    Pacijent = db.Pacijent.ToList().Find(pac => pac.Id == posjeta.PacijentID)
                };
                posj.Id = new Guid();
                posj.Napomena = posjeta.Napomena;
                posj.MedicinskaSestraTehnicar = await db.MedicinskaSestraTehnicar.FirstOrDefaultAsync(x => x.Id == posj.MedicinskaSestraTehnicar.Id);
                db.MedicinskaSestraTehnicar.ToList().Find(medst => posj.MedicinskaSestraTehnicar.Id == medst.Id)?.Posjete.Add(posj);
                posj.Pacijent = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == posj.Pacijent.Id);
                db.Pacijent.ToList().Find(pac => posj.Pacijent.Id == pac.Id)?.ZatrazenePosjete.Add(posj);
                await db.Posjeta.AddAsync(posj);
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