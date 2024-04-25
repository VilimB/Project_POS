namespace Backend_POS.Models.DTO.Proizvod
{
    public class CreateProizvodRequestDTO
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public int JedinicaMjere { get; set; }
        public decimal Cijena { get; set; }
        public int Stanje { get; set; }
    }
}
