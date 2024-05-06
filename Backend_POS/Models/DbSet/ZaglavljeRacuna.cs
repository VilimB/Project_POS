using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DbSet
{
    public class ZaglavljeRacuna
    {
        public int Id { get; set; } // Primarni ključ
        public int Broj { get; set; } // Unique key
        public DateTime? Datum { get; set; } = DateTime.Now;
        public string Napomena { get; set; } = string.Empty;
        public ICollection<StavkeRacuna> StavkeRacunas { get; set; }
        public long KupacId { get; set; }
        
        public Kupac Kupac{ get; set; }

        /*
        public required ICollection<Stavke_racuna> StavkeRacuna { get; set; }
        // Vanjski ključ koji povezuje tablicu ZaglavljeRacuna s tablicom KUPAC
        public int KupacID{ get; set;}*/

    }

}
