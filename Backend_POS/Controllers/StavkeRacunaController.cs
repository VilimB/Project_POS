using Backend_POS.Data;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.Stavke_Racuna;
using Backend_POS.Models.DTO.StavkeRacuna;
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

        public StavkeRacunaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stavkeRacuna = await _context.StavkeRacuna.ToListAsync();
            var stavkeRacunaDTO=stavkeRacuna.Select(s => s.ToStavkeRacunaDTO());
            return Ok(stavkeRacuna);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stavkeRacuna = await _context.StavkeRacuna.FindAsync(id);

            if (stavkeRacuna == null)
            {
                return NotFound();
            }

            return Ok(stavkeRacuna.ToStavkeRacunaDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStavkeRacunaRequestDTO stavkeRacunaDTO)
        {
            var stavkeRacunaModel = stavkeRacunaDTO.ToStavkeRacunaFromCreateDTO();
            await _context.StavkeRacuna.AddAsync(stavkeRacunaModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stavkeRacunaModel.Id }, stavkeRacunaModel.ToStavkeRacunaDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStavkeRacunaRequestDTO updateStavkeRacunaDTO)
        {
            var stavkeRacunaModel = await _context.StavkeRacuna.FirstOrDefaultAsync(x => x.Id == id);

            if (stavkeRacunaModel == null)
            {
                return NotFound();
            }
            stavkeRacunaModel.Kolicina = updateStavkeRacunaDTO.Kolicina;
            stavkeRacunaModel.Cijena = updateStavkeRacunaDTO.Cijena;
            stavkeRacunaModel.Popust = updateStavkeRacunaDTO.Popust;
            stavkeRacunaModel.IznosPopusta = updateStavkeRacunaDTO.IznosPopusta;
            stavkeRacunaModel.Vrijednost = updateStavkeRacunaDTO.Vrijednost;
            await _context.SaveChangesAsync();
            return Ok(stavkeRacunaModel.ToStavkeRacunaDTO());


        }




        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var proizvodModel = await _context.Proizvod.FirstOrDefaultAsync(x => x.Id == id);
            if (proizvodModel == null)
            {
                return NotFound();
            }

            _context.Proizvod.Remove(proizvodModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}