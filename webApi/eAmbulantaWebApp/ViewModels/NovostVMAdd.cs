namespace eAmbulantaWebApp.ViewModels
{
    public class NovostVMAdd
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sadrzaj { get; set; }
        public byte[]? Slika { get; set; }
        public string datum { get; set; }
        public string vrijeme { get; set; }
        public string AdministratorID { get; set; }
    }
}
