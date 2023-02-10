using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    [Table("Novost")]
    public class Novost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sadrzaj { get; set; }
        public byte[]? Slika { get; set; }
        public DateTime datumIVrijemeObjave { get; set; }

        public string AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
    }
}
