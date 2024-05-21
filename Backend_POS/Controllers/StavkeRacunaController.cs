using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.Stavke_Racuna;
using Backend_POS.Models.DTO.StavkeRacuna;
using Backend_POS.Models.DTO.ZaglavljeRacuna;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StavkeRacunaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IStavkeRacunaRepository _stavkeRacunaRepo;
        private readonly IZaglavljeRacunaRepository _zaglavljeRacunaRepo;
        private readonly IProizvodRepository _proizvodRepo;

        public StavkeRacunaController(DataContext context, IStavkeRacunaRepository stavkeRacunaRepo, IZaglavljeRacunaRepository zaglavljeRacunaRepo, IProizvodRepository proizvodRepo)
        {
            _stavkeRacunaRepo = stavkeRacunaRepo;
            _context = context;
            _zaglavljeRacunaRepo = zaglavljeRacunaRepo;
            _proizvodRepo= proizvodRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stavkeRacuna = await _stavkeRacunaRepo.GetAllAsync();
            var stavkeRacunaDTO = stavkeRacuna.Select(s => s.ToStavkeRacunaDTO());
            return Ok(stavkeRacuna);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stavkeRacuna = await _stavkeRacunaRepo.GetByIdAsync(id);

            if (stavkeRacuna == null)
            {
                return NotFound();
            }

            return Ok(stavkeRacuna.ToStavkeRacunaDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStavkeRacunaRequestDTO stavkeRacunaDTO)
        {
            Console.WriteLine("Received request:");
            Console.WriteLine($"Broj: {stavkeRacunaDTO.Broj}");
            Console.WriteLine($"Naziv: {stavkeRacunaDTO.NazivProizvod}");
            var zaglavljeRacunaId = await _zaglavljeRacunaRepo.GetIdByNumber(stavkeRacunaDTO.Broj);
            if (zaglavljeRacunaId == null)
            {
                return BadRequest("Zaglavlje računa ne postoji");
            }

            var proizvodId = await _proizvodRepo.GetIdByName(stavkeRacunaDTO.NazivProizvod);
            if (proizvodId == null)
            {
                // Logiranje za debugging
                Console.WriteLine($"Proizvod s nazivom {stavkeRacunaDTO.NazivProizvod} ne postoji.");
                return BadRequest("Proizvod ne postoji");
            }

            var stavkeRacunaModel = stavkeRacunaDTO.ToStavkeRacunaFromCreateDTO(proizvodId.Value, zaglavljeRacunaId.Value);

            await _stavkeRacunaRepo.CreateAsync(stavkeRacunaModel);

            return CreatedAtAction(nameof(GetById), new { id = stavkeRacunaModel.StavkaId }, stavkeRacunaModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStavkeRacunaRequestDTO updateStavkeRacunaDTO)
        {
            var stavkeRacunaModel = await _stavkeRacunaRepo.UpdateAsync(id, updateStavkeRacunaDTO);

            if (stavkeRacunaModel == null)
            {
                return NotFound();
            }
           
            return Ok(stavkeRacunaModel.ToStavkeRacunaDTO());
        }
        



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stavkeRacunadModel = await _stavkeRacunaRepo.DeleteAsync(id);
            if (stavkeRacunadModel == null)
            {
                return NotFound();
            }
            return Ok(stavkeRacunadModel);
        }

    }
}