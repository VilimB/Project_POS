namespace Backend_POS.Models.DTO.Stavke_Racuna
{
    public class StavkeRacunaDTO
    {   public int StavkaId { get; set; } 
        public int Kolicina { get; set; }
        public decimal CijenaStavka { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
        public int ProizvodId { get; set; }
        public int ZaglavljeId { get; set; }

    }
}