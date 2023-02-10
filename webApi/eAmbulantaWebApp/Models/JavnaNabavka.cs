using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    [Table("JavnaNabavka")]
    public class JavnaNabavka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Opis { get; set; }
        public byte[] pdfFajl { get; set; }

        public Administrator Administrator { get; set; }
    }
}
