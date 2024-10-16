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

}


/*using Backend_POS.Service;
using Microsoft.AspNetCore.Mvc;
using Backend_POS.Models.DTO.Racun;
using Backend_POS.Models.DTO.ZaglavljeRacuna;

[ApiController]
[Route("api/racun")]
public class RacunController : ControllerBase
{
    private readonly RacunService _racunService;

    // Konstruktor koji prima RacunService putem DI
    public RacunController(RacunService racunService)
    {
        _racunService = racunService;
    }

    [HttpPost]
    [Route("generate-e-racun")]
    public IActionResult GenerateERacun([FromBody] int zaglavljeId)
    {
        try
        {
            // Generiraj e-raèun
            string xmlRacun = _racunService.GenerateERacunXml(zaglavljeId);

            // Dohvati zaglavlje raèuna
            var zaglavlje = _racunService.GetERacunById(zaglavljeId);

            if (zaglavlje == null)
            {
                return NotFound(new { message = "Raèun nije pronaðen." });
            }

            // Kreiraj DTO s podacima i generiranim XML-om
            var response = new ZaglavljeRacunaDTO
            {
                ZaglavljeId = zaglavlje.ZaglavljeId,
                Broj = zaglavlje.Broj,
                Datum = zaglavlje.Datum,
                KupacId = zaglavlje.KupacId,
                XmlRacun = xmlRacun  // Generirani XML
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    [Route("get-e-racun/{zaglavljeId}")]
    public IActionResult GetERacun(int zaglavljeId)
    {
        try
        {
            // Dohvati zaglavlje raèuna s XML-om
            var zaglavlje = _racunService.GetERacunById(zaglavljeId);

            if (zaglavlje == null || string.IsNullOrEmpty(zaglavlje.XmlRacun))
            {
                return NotFound(new { message = "E-raèun nije pronaðen ili nije generiran." });
            }

            // Vrati generirani XML kao odgovor
            return Ok(new { xml = zaglavlje.XmlRacun });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
*/