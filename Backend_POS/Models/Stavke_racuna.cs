namespace Backend_POS.Models
{
    public class Stavke_racuna
    {
        public int ID { get; set; } // Primarni ključ
        public int KOLICINA { get; set; }
        public decimal CIJENA { get; set; }
        public decimal POPUST { get; set; }
        public decimal IZNOS_POPUSTA { get; set; }
        public decimal VRIJEDNOST { get; set; }

        // Vanjski ključ koji povezuje tablicu StavkaRacuna s tablicom PROIZVOD
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        // Vanjski ključ koji povezuje tablicu StavkaRacuna s tablicom ZaglavljeRacuna
        public int Zaglavlje_racunaID { get; set; }
        public Zaglavlje_racuna Zaglavlje_racuna { get; set; }
    }

}
