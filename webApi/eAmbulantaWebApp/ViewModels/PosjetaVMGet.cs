namespace eAmbulantaWebApp.ViewModels
{
    public class PosjetaVMGet
    {
        public string Id { get; set; }
        public bool Odobreno { get; set; }
        public string? Napomena { get; set; }
        public string? Odgovor { get; set; }
        public string? MedicinskaSestraTehnicarID {get; set;}
        public string? PacijentID { get; set; }
    }
}
