using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.Models
{
    [Table("AspNetUsers")]
    public class MedicinskaSestraTehnicar: IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string? Obrazovanje { get; set; }

        public List<MedicinskiTretman> Tretmani { get; set; } = new List<MedicinskiTretman>();

        public List<Posjeta> Posjete { get; set; } = new List<Posjeta>();
    }
}
