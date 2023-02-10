using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class Bolest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string? Opis { get; set; }
        //ICDKod je kod kojeg svaka bolest ima, ICD znaci International Classification of Diseases, sto je oficijalna klasifikacija bolesti SZO(Svjetske Zdravstvene Organizacije)
        public string ICDKod { get; set; }

        public Pacijent Pacijent { get; set; }
    }
}
