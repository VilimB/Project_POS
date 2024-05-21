using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DbSet
{
    public class StavkeRacuna
    {
        [Key]
        public int StavkaId { get; set; } 
       
        public int Kolicina { get; set; }
        public decimal CijenaStavka { get; set; }
        public decimal Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        public decimal Vrijednost { get; set; }
        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public int ZaglavljeId { get; set; }
        public ZaglavljeRacuna ZaglavljeRacuna { get; set; }

        
    }

}
