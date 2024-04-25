namespace Backend_POS.Models.DTO.ZaglavljeRacuna
{
    public class ZaglavljeRacunaDTO
    {
        public int Id { get; set; } 
        public int Broj { get; set; } 
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Napomena { get; set; } = string.Empty;

    }
}
