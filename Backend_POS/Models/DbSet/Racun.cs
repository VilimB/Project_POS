namespace Backend_POS.Models.DbSet
{
    public class Racun
    {
        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public DateTime DatumIzdavanja { get; set; }

        public List<StavkeRacuna> Stavke { get; set; }
        public Kupac Kupac { get; set; }
        public string XmlRacun { get; set; }  // Polje za pohranu XML-a
        public string Status { get; set; } = "poslan"; // Status e-raèuna
        public int ZaglavljeId { get; set; }
        public ZaglavljeRacuna ZaglavljeRacuna { get; set; }


    }
}