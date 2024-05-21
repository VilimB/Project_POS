using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DbSet
{
    public class Kupac
    {
        [Key]
        public int KupacId { get; set; }
        [Required]
        public required string SifraKupac { get; set; } 
        [Required]
        public required string NazivKupac { get; set; } 
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
        public ICollection<ZaglavljeRacuna> ZaglavljeRacunas { get; set; }

        
    }

}
