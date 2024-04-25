namespace Backend_POS.Models.DTO.StavkeRacuna
{
    public class CreateStavkeRacunaRequestDTO
    {
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
    }
}
