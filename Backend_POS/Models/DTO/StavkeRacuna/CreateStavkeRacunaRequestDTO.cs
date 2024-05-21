namespace Backend_POS.Models.DTO.StavkeRacuna
{
    public class CreateStavkeRacunaRequestDTO
    {
        public int Kolicina { get; set; }
        public decimal CijenaStavka { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
        public int ProizvodId { get; set; }
        public int ZaglavljeId { get; set; }
        public int Broj {  get; set; }
        public string NazivProizvod { get; set; } = string.Empty;


    }
}
