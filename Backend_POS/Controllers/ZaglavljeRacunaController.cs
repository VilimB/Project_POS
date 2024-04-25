
using Backend_POS.Data;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.ZaglavljeRacuna;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaglavljeRacunaController : ControllerBase
    {
        private readonly DataContext _context;
        public ZaglavljeRacunaController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zaglavljeRacuna =await _context.ZaglavljeRacuna.ToListAsync();
            var zaglavljeRacunaDTO = zaglavljeRacuna.Select(s => s.ToZaglavljeRacunaDTO());
            return Ok(zaglavljeRacuna);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var zaglavljeRacuna =await _context.ZaglavljeRacuna.FindAsync(id);

            if (zaglavljeRacuna == null)
            {
                return NotFound();
            }

            return Ok(zaglavljeRacuna.ToZaglavljeRacunaDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateZaglavljeRacunaRequestDTO zaglavljeRacunaDTO)
        {
            var zaglavljeRacunaModel = zaglavljeRacunaDTO.ToZaglavljeRacunaFromCreateDTO();
            await _context.ZaglavljeRacuna.AddAsync(zaglavljeRacunaModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = zaglavljeRacunaModel.Id }, zaglavljeRacunaModel.ToZaglavljeRacunaDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateZaglavljeRacunaRequestDTO updateZaglavljeRacunaDTO)
        {
            var zaglavljeRacunaModel =await _context.ZaglavljeRacuna.FirstOrDefaultAsync(x => x.Id == id);

            if (zaglavljeRacunaModel == null)
            {
                return NotFound();
            }
            zaglavljeRacunaModel.Broj = updateZaglavljeRacunaDTO.Broj;
            zaglavljeRacunaModel.Datum = updateZaglavljeRacunaDTO.Datum;
            zaglavljeRacunaModel.Napomena = updateZaglavljeRacunaDTO.Napomena;
            await _context.SaveChangesAsync();

            return Ok(zaglavljeRacunaModel.ToZaglavljeRacunaDTO());


        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var zaglavljeRacunaModel =await _context.ZaglavljeRacuna.FirstOrDefaultAsync(x => x.Id == id);
            if (zaglavljeRacunaModel == null)
            {
                return NotFound();
            }

            _context.ZaglavljeRacuna.Remove(zaglavljeRacunaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

   



