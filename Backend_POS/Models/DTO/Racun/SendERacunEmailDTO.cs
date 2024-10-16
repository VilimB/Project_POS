using Backend_POS.Models.DTO.Stavke_Racuna;

namespace Backend_POS.Models.DTO.Racun
{
    public class SendERacunEmailDTO
    {
        public int ZaglavljeId { get; set; }  // To identify the e-invoice
        public string Email { get; set; }     // The email address where the invoice is sent
    }

}
