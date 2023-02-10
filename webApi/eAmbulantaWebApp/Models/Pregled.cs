using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class Pregled
    {
        //public Pregled(Pregled pr)
        //{
        //    Id = pr.Id;
        //    Odobreno = pr.Odobreno;
        //    Obavljeno = pr.Obavljeno;
        //    DatumIVrijeme = pr.DatumIVrijeme;
        //    Napomena = pr.Napomena;
        //    Odgovor = pr.Odgovor;
        //    Dijagnoza = pr.Dijagnoza;
        //    Terapija = pr.Terapija;
        //    Doktor = pr.Doktor;
        //    Pacijent = pr.Pacijent;
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Odobreno varijabla se mijenja kada doktor odobri ili ne odobri(default je false) zahtjev za pregled, ovo koristimo da bi mogli filtrirati preglede po odobrenim i neodobrenim
        //te prikazati doktoru koje je preglede odobrio, a koje jos uvijek cekaju na odobrenje s tim sto ima opciju brisanja zahtjeva
        public bool Odobreno { get; set; }
        //Obavljeno se mijenja kada je pregled obavljen, te se on onda pohranjuje u historiju pacijenta
        public bool Obavljeno { get; set; }
        public DateTime DatumIVrijeme { get; set; }
        public string? Napomena { get; set; }
        //u Odgovor se potencijalno pohranjuje, ukoliko doktor odbije zahtjev, razlog odbijanja i eventualno dalje upute za pacijenta
        public string? Odgovor { get; set; }
        public string? Dijagnoza { get; set; }
        public string? Terapija { get; set; }

        public string DoktorId { get; set; }
        public Doktor? Doktor { get; set; }

        public string PacijentId { get; set; }
        public Pacijent? Pacijent { get; set; }
    }
}
