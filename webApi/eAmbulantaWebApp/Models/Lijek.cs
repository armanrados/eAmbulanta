using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class Lijek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Odobreno { get; set; }
        //Kolicina npr. jedna kutija, dvije pumpice, jedna ampula itd.
        public string Kolicina { get; set; }
        public string? Napomena { get; set; }
        //u Odgovor se potencijalno pohranjuje, ukoliko doktor odbije zahtjev, razlog odbijanja i eventualno dalje upute za pacijenta
        public string? Odgovor { get; set; }

        public Doktor? Doktor { get; set; }

        public Pacijent? Pacijent { get; set; }
    }
}
