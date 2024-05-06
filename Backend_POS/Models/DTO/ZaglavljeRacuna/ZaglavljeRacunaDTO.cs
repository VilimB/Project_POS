using Backend_POS.Models.DTO.Stavke_Racuna;

namespace Backend_POS.Models.DTO.ZaglavljeRacuna
{
    public class ZaglavljeRacunaDTO
    {
        public int Id { get; set; } 
        public int Broj { get; set; } 
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Napomena { get; set; } = string.Empty;
        public long KupacId { get; set; }
        public List<StavkeRacunaDTO> StavkeRacunas { get; set; }

    }
}
