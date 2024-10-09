using Backend_POS.Service;
using Microsoft.AspNetCore.Mvc;
using Backend_POS.Models.DTO.Racun;
using Backend_POS.Models.DTO.ZaglavljeRacuna;

[ApiController]
[Route("api/racun")]  
public class RacunController : ControllerBase
{
    private readonly RacunService _racunService;
    private readonly CreateRacunDTO _createRacun;
    // Konstruktor koji prima RacunService putem DI
    public RacunController(RacunService racunService, CreateRacunDTO createRacun)
    {
        _racunService = racunService;
        _createRacun = createRacun;
    }

    // API endpoint za generiranje e-raèuna
    /*[HttpPost]
    [Route("generate-e-racun")]
    public IActionResult GenerateERacun([FromBody] int zaglavljeId)
    {
        try
        {
            // Generiraj e-raèun i spremi u bazu
            string xmlRacun = _racunService.GenerateERacunXml(zaglavljeId);
            _racunService.SaveERacunToDatabase(zaglavljeId);

            // Vrati generirani XML kao odgovor
            return Ok(new { xml = xmlRacun });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }*/
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
