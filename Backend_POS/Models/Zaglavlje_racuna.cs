using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models
{
    public class Zaglavlje_racuna
    {
        public int ID { get; set; } // Primarni ključ
        public string BROJ { get; set; } // Unique key
        public DateTime DATUM { get; set; }
        public string NAPOMENA { get; set; }

        public ICollection<Stavke_racuna> Stavke_racuna { get; set; }
        // Vanjski ključ koji povezuje tablicu ZaglavljeRacuna s tablicom KUPAC
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }
    }

}
