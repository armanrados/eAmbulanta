using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.Models
{
    [Table("AspNetUsers")]
    public class Administrator : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<Oglas> Oglasi { get; set; } = new List<Oglas>();
        public List<Odluka> Odluke { get; set; } = new List<Odluka>();
        public List<Novost> Novosti { get; set; } = new List<Novost>();
        public List<JavnaNabavka> JavneNabavke { get; set; } = new List<JavnaNabavka>();
    }
}
