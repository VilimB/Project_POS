namespace Backend_POS.Models.DbSet
{
    public class Proizvod
    {
        public int Id { get; set; } 
        public int Sifra { get; set; }
        public string Naziv{ get; set; } = string.Empty;
        public int JedinicaMjere { get; set; }
        public decimal Cijena { get; set; }
        public int Stanje { get; set; }
        public ICollection<StavkeRacuna>? StavkeRacunas { get; set; }

        /*// Ova kolekcija omogućuje jednostruku relaciju (1:N) s tablicom StavkeRacuna
        public required ICollection<Stavke_racuna> StavkeRacuna { get; set; }*/
    }

}
