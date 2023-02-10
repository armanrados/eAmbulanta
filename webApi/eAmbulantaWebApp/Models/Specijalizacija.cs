using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.Models
{
    public class Specijalizacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        //Naziv npr. Internist, Pulmolog, Otorinolaringolog, Dermatolog itd.
        public string naziv { get; set; }
    }
}
