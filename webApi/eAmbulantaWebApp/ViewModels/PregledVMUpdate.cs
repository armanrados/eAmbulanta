using eAmbulantaWebApp.Models;

namespace eAmbulantaWebApp.ViewModels
{
    public class PregledVMUpdate
    {
        public int Id { get; set; }
        public bool Odobreno { get; set; }
        public bool Obavljeno { get; set; }
        public string DatumIVrijeme { get; set; }
        public string? Odgovor { get; set; }
        public string? Dijagnoza { get; set; }
        public string? Terapija { get; set; }

        public string DoktorId { get; set; }

        public string PacijentId { get; set; }
    }
}
