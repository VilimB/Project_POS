namespace Backend_POS.Models.DTO.Kupac
{
    public class KupacDTO
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
    }
}
