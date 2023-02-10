using eAmbulantaWebApp.Models;

namespace eAmbulantaWebApp.ViewModels
{
    public class PacijentVMReg
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string JMBG { get; set; }
        public string DatumRodjenja { get; set; }
        public Lokacija Lokacija { get; set; }
    }
}
