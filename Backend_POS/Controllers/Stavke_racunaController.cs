using Backend_POS.Data;
using Backend_POS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stavke_racunaController : ControllerBase
    {
        private readonly DataContext _context;

        public Stavke_racunaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stavke_racuna>>> GetStavke_racuna()
        {
            return await _context.Stavke_racuna.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stavke_racuna>> GetStavka_racuna(int id)
        {
            var stavka_racuna = await _context.Stavke_racuna.FindAsync(id);

            if (stavka_racuna == null)
            {
                return NotFound();
            }

            return stavka_racuna;
        }

        [HttpPost]
        public async Task<ActionResult<Stavke_racuna>> AddStavka_racuna(Stavke_racuna stavka_racuna)
        {
            _context.Stavke_racuna.Add(stavka_racuna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStavka_racuna", new { id = stavka_racuna.ID }, stavka_racuna);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStavka_racuna(int id, Stavke_racuna stavka_racuna)
        {
            if (id != stavka_racuna.ID)
            {
                return BadRequest();
            }

            _context.Entry(stavka_racuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stavka_racunaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStavka_racuna(int id)
        {
            var stavka_racuna = await _context.Stavke_racuna.FindAsync(id);
            if (stavka_racuna == null)
            {
                return NotFound();
            }

            _context.Stavke_racuna.Remove(stavka_racuna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Stavka_racunaExists(int id)
        {
            return _context.Stavke_racuna.Any(e => e.ID == id);
        }
    }
}
