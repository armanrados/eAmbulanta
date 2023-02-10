using eAmbulantaWebApp.Models;

namespace eAmbulantaWebApp.ViewModels
{
    public class PregledVMAdd
    {
        public string Datum { get; set; }
        public string Vrijeme { get; set; }
        public string? Napomena { get; set; }
        public string DoktorId { get; set; }
        public string PacijentId { get; set; }
    }
}
