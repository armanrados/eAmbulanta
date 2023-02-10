using eAmbulantaWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.ViewModels
{
  
    public class korisnickiNalogVM
    {
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }

    }
}
