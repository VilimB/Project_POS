using Backend_POS.Service;
using Microsoft.AspNetCore.Mvc;
using Backend_POS.Models.DTO.Racun;
using Backend_POS.Models.DTO.ZaglavljeRacuna;
using Microsoft.EntityFrameworkCore;
using Backend_POS.Data;

[ApiController]
[Route("api/racun")]
public class RacunController : ControllerBase
{
    private readonly RacunService _racunService;
    private readonly DataContext _context;

    public RacunController(RacunService racunService, DataContext context)
    {
        _racunService = racunService;
        _context = context;
    }

    [HttpPost]
    [Route("generate-e-racun")]
    public IActionResult GenerateERacun([FromBody] CreateRacunDTO request)
    {
        try
        {
            // Generate e-invoice
            string xmlRacun = _racunService.GenerateERacunXml(request.ZaglavljeId);

            var zaglavlje = _racunService.GetERacunById(request.ZaglavljeId);
            if (zaglavlje == null)
            {
                return NotFound(new { message = "Raèun nije pronaðen." });
            }

            return Ok(new
            {
                ZaglavljeId = zaglavlje.ZaglavljeId,
                XmlRacun = xmlRacun,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost("send-e-racun-email")]
    public IActionResult SendERacunByEmail([FromBody] SendERacunEmailDTO request)
    {
        try
        {
            Console.WriteLine($"Poèetak slanja e-raèuna za zaglavlje ID: {request.ZaglavljeId} na email: {request.Email}");

            // Generiraj e-raèun prije slanja
            string eRacunXml = _racunService.GenerateERacunXml(request.ZaglavljeId);

            if (string.IsNullOrEmpty(eRacunXml))
            {
                Console.WriteLine("E-raèun nije generiran za ovaj raèun.");
                return BadRequest(new { message = "E-raèun nije generiran za ovaj raèun." });
            }

            // Pošalji e-raèun putem emaila
            bool emailSent = _racunService.SendERacunEmail(request.Email, eRacunXml);

            if (!emailSent)
            {
                Console.WriteLine("Došlo je do greške prilikom slanja emaila.");
                return BadRequest(new { message = "Greška prilikom slanja e-raèuna." });
            }

            Console.WriteLine("E-raèun je uspješno poslan!");
            return Ok(new { message = "E-raèun je uspješno poslan." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Greška prilikom slanja e-raèuna: {ex.Message}");
            return BadRequest(new { message = $"Greška: {ex.Message}" });
        }
    }



    // Pomoæna metoda za validaciju email adrese
    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}


    /*[HttpPost("send-e-racun-email")]
    public IActionResult SendERacunByEmail([FromBody] SendERacunEmailDTO request)
    {
        try
        {
            Console.WriteLine($"Poèetak slanja e-raèuna za zaglavlje ID: {request.ZaglavljeId} na email: {request.Email}");

            // Provjeri da li postoji raèun s danim ID-om
            var zaglavlje = _context.ZaglavljeRacuna.Find(request.ZaglavljeId);
            if (zaglavlje == null)
            {
                Console.WriteLine("Raèun s tim ID-om nije pronaðen.");
                return NotFound(new { message = "Raèun nije pronaðen." });
            }

            // Poziv metode za slanje emaila
            _racunService.SendERacunEmail(zaglavlje.XmlRacun, request.Email);
            Console.WriteLine("E-raèun je uspješno poslan!");

            return Ok(new { message = "E-raèun je uspješno poslan." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Greška prilikom slanja e-raèuna: {ex.Message}");
            return BadRequest(new { message = $"Greška prilikom slanja e-raèuna: {ex.Message}" });
        }
    }

}*/
/*[HttpPost("send-e-racun-email")]
public IActionResult SendERacunByEmail([FromBody] SendERacunEmailDTO request)
{
    if (!IsValidEmail(request.Email))
    {
        return BadRequest(new { message = "Neispravna email adresa." });
    }

    bool result = _racunService.SendERacunEmail(request.Email, request.XmlRacun);
    if (result)
    {
        return Ok(new { message = "E-raèun je uspješno poslan." });
    }
    else
    {
        return BadRequest(new { message = "Greška prilikom slanja e-raèuna." });
    }
}
*/