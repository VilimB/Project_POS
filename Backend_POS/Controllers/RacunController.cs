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
                return NotFound(new { message = "Ra�un nije prona�en." });
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
            Console.WriteLine($"Po�etak slanja e-ra�una za zaglavlje ID: {request.ZaglavljeId} na email: {request.Email}");

            // Generiraj e-ra�un prije slanja
            string eRacunXml = _racunService.GenerateERacunXml(request.ZaglavljeId);

            if (string.IsNullOrEmpty(eRacunXml))
            {
                Console.WriteLine("E-ra�un nije generiran za ovaj ra�un.");
                return BadRequest(new { message = "E-ra�un nije generiran za ovaj ra�un." });
            }

            // Po�alji e-ra�un putem emaila
            bool emailSent = _racunService.SendERacunEmail(request.Email, eRacunXml);

            if (!emailSent)
            {
                Console.WriteLine("Do�lo je do gre�ke prilikom slanja emaila.");
                return BadRequest(new { message = "Gre�ka prilikom slanja e-ra�una." });
            }

            Console.WriteLine("E-ra�un je uspje�no poslan!");
            return Ok(new { message = "E-ra�un je uspje�no poslan." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gre�ka prilikom slanja e-ra�una: {ex.Message}");
            return BadRequest(new { message = $"Gre�ka: {ex.Message}" });
        }
    }



    // Pomo�na metoda za validaciju email adrese
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
            Console.WriteLine($"Po�etak slanja e-ra�una za zaglavlje ID: {request.ZaglavljeId} na email: {request.Email}");

            // Provjeri da li postoji ra�un s danim ID-om
            var zaglavlje = _context.ZaglavljeRacuna.Find(request.ZaglavljeId);
            if (zaglavlje == null)
            {
                Console.WriteLine("Ra�un s tim ID-om nije prona�en.");
                return NotFound(new { message = "Ra�un nije prona�en." });
            }

            // Poziv metode za slanje emaila
            _racunService.SendERacunEmail(zaglavlje.XmlRacun, request.Email);
            Console.WriteLine("E-ra�un je uspje�no poslan!");

            return Ok(new { message = "E-ra�un je uspje�no poslan." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gre�ka prilikom slanja e-ra�una: {ex.Message}");
            return BadRequest(new { message = $"Gre�ka prilikom slanja e-ra�una: {ex.Message}" });
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
        return Ok(new { message = "E-ra�un je uspje�no poslan." });
    }
    else
    {
        return BadRequest(new { message = "Gre�ka prilikom slanja e-ra�una." });
    }
}
*/