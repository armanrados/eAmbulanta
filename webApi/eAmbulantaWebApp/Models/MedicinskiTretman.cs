using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eAmbulantaWebApp.Models
{
    public class MedicinskiTretman
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Obavljen { get; set; }
        public string Opis { get; set; }
        //DatumIVrijemePropisa je varijablja u koju ce se pohraniti vrijeme kada je doktor propisao da dati tretman treba biti obavljen
        public DateTime DatumIVrijemePropisa { get; set; }
        //DatumIVrijemeObavljanja je varijablja u koju ce se pohraniti vrijeme kada MedicinskaSestraTehnicar potvrdi da je tretman obavljen tj. kada se vrijednost varijable Obavljen promijeni na true 
        public DateTime? DatumIVrijemeObavljanja { get; set; }
        public string? Napomena { get; set; }

        //MedicinskaSestraTehnicarID i MedicinskaSestraTehnicar su postavljeni tako da mogu biti null jer logika entity frameworka ne dozvoljava da, ukoliko klasa u bazi ima vezu sama sa sobom, foreign key-ovi budu not null,
        //a drugi razlog je taj sto kada doktor kreira tretman koji je potrebno obaviti nema potrebu odrediti koja sestra ili tehnicar treba da odradi taj tretman, sto je realnije,
        //u ove varijable ce se pohraniti vrijednost tek kada sestra ili tehnicar obave ovaj tretman, onaj ko promijeni vrijednost varijable obavljen njihov ID ce se pohraniti

        public MedicinskaSestraTehnicar? MedicinskaSestraTehnicar { get; set; }


        public Pacijent? Pacijent { get; set; }
    }
}
