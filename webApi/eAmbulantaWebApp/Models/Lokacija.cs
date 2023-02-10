using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class Lokacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Adresa { get; set; }
        //Longitude i Latitude su potrebne za Google Maps
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
