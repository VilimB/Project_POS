namespace Backend_POS.Models
{
    public class Proizvod
    {
        public int ID { get; set; } // Primarni ključ
        public string ŠIFRA { get; set; } // Unique key
        public string NAZIV { get; set; }
        public string JEDINICA_MJERE { get; set; }
        public decimal CIJENA { get; set; }
        public int STANJE { get; set; }

        // Ova kolekcija omogućuje jednostruku relaciju (1:N) s tablicom StavkeRacuna
        public ICollection<Stavke_racuna> Stavke_racuna { get; set; }
    }

}
