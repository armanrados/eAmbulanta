using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.Models
{
    [Table("AspNetUsers")]
    public class Doktor : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        //titule mogu biti npr. dr., prim., spec. itd.
        public string? Titula { get; set; }
        //Specijalizacija moze biti null jer je odnos izmedju doktora i specijalizacije 0 naprema 1, sto ce reci da doktor moze imati specijalizaciju ali i ne mora, sto je realno

        public int? SpecijalizacijaDoktorId { get; set; }
        public Specijalizacija? SpecijalizacijaDoktor { get; set; }

        public List<Pregled> DoktorPregledi { get; set; } = new List<Pregled>();

        public List<Lijek> DoktorLijekovi { get; set; } = new List<Lijek>();
    }
}
