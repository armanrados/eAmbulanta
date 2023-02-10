using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    [Table("Odluka")]
    public class Odluka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Opis { get; set; }
        public byte[] pdfFajl { get; set; }

        public Administrator Administrator { get; set; }
    }
}
