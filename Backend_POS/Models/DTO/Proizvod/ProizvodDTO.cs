using Backend_POS.Models.DTO.Stavke_Racuna;

namespace Backend_POS.Models.DTO.Proizvod
{
    public class ProizvodDTO
    {
        public int ProizvodId { get; set; }
        public string SifraProizvod { get; set; } = string.Empty;
        public string NazivProizvod { get; set; } = string.Empty;
        public string JedinicaMjere { get; set; } = string.Empty;
        public decimal CijenaProizvod { get; set; }
        public int Stanje { get; set; }
        public  List<StavkeRacunaDTO>? StavkeRacunas { get; set; }
    }
}
