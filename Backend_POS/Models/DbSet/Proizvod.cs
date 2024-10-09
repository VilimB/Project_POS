using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DbSet
{
    public class Proizvod
    {
        [Key]
        public int ProizvodId { get; set; }

        public string SifraProizvod { get; set; } = string.Empty;
        public string NazivProizvod { get; set; } = string.Empty;
        public string JedinicaMjere { get; set; } = string.Empty;
        public decimal CijenaProizvod { get; set; }
        public int Stanje { get; set; }
        public ICollection<StavkeRacuna> StavkeRacunas { get; set; } = new List<StavkeRacuna>();


    }

}