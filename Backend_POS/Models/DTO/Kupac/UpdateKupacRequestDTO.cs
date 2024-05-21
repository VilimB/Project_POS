namespace Backend_POS.Models.DTO.Kupac
{
    public class UpdateKupacRequestDTO
    {
        public string SifraKupac { get; set; } = string.Empty;
        public string NazivKupac { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
    }
}
