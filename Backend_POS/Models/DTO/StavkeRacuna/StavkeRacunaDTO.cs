namespace Backend_POS.Models.DTO.Stavke_Racuna
{
    public class StavkeRacunaDTO
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
    }
}
