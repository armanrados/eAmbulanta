using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.Models
{
    [Table("AspNetUsers")]
    public class Pacijent: IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Column(TypeName = "nvarchar(13)")]
        public string? JMBG { get; set; }
        public DateTime? datumRodjenja { get; set; }

        public List<Pregled> PacijentPregledi { get; set; } = new List<Pregled>();

        public List<Lijek> PacijentLijekovi { get; set; } = new List<Lijek>();
        public List<Bolest> Bolesti { get; set; } = new List<Bolest>();

        public List<MedicinskiTretman> PropisaniTretmani { get; set; } = new List<MedicinskiTretman>();

        public List<Posjeta> ZatrazenePosjete { get; set; } = new List<Posjeta>();

        //LokacijaID i Lokacija nisu nullable jer veza izmedju pacijenta i lokacije treba da bude 1 naprema 1 jer ne moze postojati pacijent bez da je unijeo adresu stanovanja
        public int? LokacijaID { get; set; }
        public Lokacija? Lokacija { get; set; }
       
    }
}
