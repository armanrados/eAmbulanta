namespace eAmbulantaWebApp.ViewModels
{
    public class PregledVMGet
    {
        public int Id { get; set; }
        public bool Odobreno { get; set; }
        public bool Obavljeno { get; set; }
        public string Datum { get; set; }
        public string Vrijeme { get; set; }
        public string? Napomena { get; set; }
        public string? Odgovor { get; set; }
        public string? Dijagnoza { get; set; }
        public string? Terapija { get; set; }
        public string DoktorId { get; set; }
        public string PacijentId { get; set; }
    }
}
