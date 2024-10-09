using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DbSet
{
    public class ZaglavljeRacuna
    {
        [Key]
        public int ZaglavljeId { get; set; } 
        
        public int Broj { get; set; } 
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Napomena { get; set; } = string.Empty;
        public ICollection<StavkeRacuna> StavkeRacunas { get; set; } = new List<StavkeRacuna>();

        public int KupacId { get; set; }
        
        public Kupac? Kupac { get; set; }
        public string? XmlRacun { get; set; }




    }

}
