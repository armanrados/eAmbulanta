using eAmbulantaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinskiTretmanController : Controller
    {
        private readonly AuthenticationContext db;

        public MedicinskiTretmanController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> getAllTretmani()
        {
            var medicinskiTretmani = await db.MedicinskiTretman.ToListAsync();
            return Ok(medicinskiTretmani);
        }



    }
}
