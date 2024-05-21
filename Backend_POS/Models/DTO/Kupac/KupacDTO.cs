using Backend_POS.Models.DTO.ZaglavljeRacuna;

namespace Backend_POS.Models.DTO.Kupac
{
    public class KupacDTO
    {
        public int KupacId { get; set; }
        public string SifraKupac { get; set; } = string.Empty;
        public string NazivKupac { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
        public List<ZaglavljeRacunaDTO>? ZaglavljeRacunas { get; set; }
    }
}
