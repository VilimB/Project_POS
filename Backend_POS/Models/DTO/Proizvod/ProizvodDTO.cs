using Backend_POS.Models.DTO.Stavke_Racuna;

namespace Backend_POS.Models.DTO.Proizvod
{
    public class ProizvodDTO
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public int JedinicaMjere { get; set; }
        public decimal Cijena { get; set; }
        public int Stanje { get; set; }
        public required List<StavkeRacunaDTO> StavkeRacunas { get; set; }
    }
}
