using Backend_POS.Models.DTO.ZaglavljeRacuna;

namespace Backend_POS.Models.DTO.Kupac
{
    public class KupacDTO
    {
        public long Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
        public List<ZaglavljeRacunaDTO> ZaglavljeRacunas { get; set; }
    }
}
