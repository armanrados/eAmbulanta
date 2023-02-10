using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    [Table("Oglas")]
    public class Oglas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }

        public Administrator Administrator { get; set; }
    }
}
