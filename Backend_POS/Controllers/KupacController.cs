using Backend_POS.Data;
using Backend_POS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        private readonly DataContext _context;

        public KupacController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kupac>>> GetKupci()
        {
            return await _context.Kupac.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kupac>> GetKupac(int id)
        {
            var kupac = await _context.Kupac.FindAsync(id);

            if (kupac == null)
            {
                return NotFound();
            }

            return kupac;
        }

        [HttpPost]
        public async Task<ActionResult<Kupac>> AddKupac(Kupac kupac)
        {
            _context.Kupac.Add(kupac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKupac", new { id = kupac.ID }, kupac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKupac(int id, Kupac kupac)
        {
            if (id != kupac.ID)
            {
                return BadRequest();
            }

            _context.Entry(kupac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(id))
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
        public async Task<IActionResult> DeleteKupac(int id)
        {
            var kupac = await _context.Kupac.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }

            _context.Kupac.Remove(kupac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KupacExists(int id)
        {
            return _context.Kupac.Any(e => e.ID == id);
        }
    }
}
