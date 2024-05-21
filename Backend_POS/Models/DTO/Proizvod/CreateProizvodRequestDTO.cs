namespace Backend_POS.Models.DTO.Proizvod
{
    public class CreateProizvodRequestDTO
    {
        public string SifraProizvod { get; set; } = string.Empty;
        public string NazivProizvod { get; set; } = string.Empty;
        public string JedinicaMjere { get; set; } = string.Empty;
        public decimal CijenaProizvod { get; set; }
        public int Stanje { get; set; }
    }
}
