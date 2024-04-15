namespace Backend_POS.Models
{
    public class Kupac
    {
        public int ID { get; set; } // Primarni ključ
        public string ŠIFRA { get; set; } // Unique key
        public string NAZIV { get; set; }
        public string ADRESA { get; set; }
        public string MJESTO { get; set; }

        // Ova kolekcija omogućuje jednostruku relaciju (1:N) s tablicom ZaglavljeRacuna
        public ICollection<Zaglavlje_racuna> Zaglavlje_racuna { get; set; }
    }

}
