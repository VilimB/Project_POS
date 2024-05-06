namespace Backend_POS.Models.DTO.StavkeRacuna
{
    public class UpdateStavkeRacunaRequestDTO
    {
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
        public int ProizvodId { get; set; }
        public int ZaglavljeRacunaId { get; set; }
    }
}
