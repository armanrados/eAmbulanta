using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class Posjeta
    {
        [Key]
        public Guid Id { get; set; }
        public bool Odobreno { get; set; }
        public string? Napomena { get; set; }
        public string? Odgovor { get; set; }

        public string? MedicinskaSestraTehnicarId { get; set; }
        public MedicinskaSestraTehnicar? MedicinskaSestraTehnicar { get; set; }
        public string? PacijentId { get; set; }
        public Pacijent? Pacijent { get; set; }
    }
}
