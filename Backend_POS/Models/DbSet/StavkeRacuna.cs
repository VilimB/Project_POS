namespace Backend_POS.Models.DbSet
{
    public class StavkeRacuna
    {
        public int Id { get; set; } // Primarni ključ
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public int ZaglavljeRacunaId { get; set; }
        public ZaglavljeRacuna ZaglavljeRacuna { get; set; }

        // Vanjski ključ koji povezuje tablicu StavkaRacuna s tablicom PROIZVOD
        /* public int ProizvodID { get; set; }
         public required Proizvod Proizvod { get; set; }

         // Vanjski ključ koji povezuje tablicu StavkaRacuna s tablicom ZaglavljeRacuna
         public int Zaglavlje_racunaID { get; set; }
         public required Zaglavlje_racuna ZaglavljeRacuna { get; set; }*/
    }

}
