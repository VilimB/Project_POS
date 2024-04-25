using Backend_POS.Data;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
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
        public async Task<IActionResult> GetAll()
        {
            var kupac = await _context.Kupac.ToListAsync();
            var kupacDTO=kupac.Select(s => s.ToKupacDTO());
            return Ok(kupac);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var kupac = await _context.Kupac.FindAsync(id);

            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(kupac.ToKupacDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateKupacRequestDTO kupacDTO)
        {
            var kupacModel= kupacDTO.ToKupacFromCreateDTO();
            await _context.Kupac.AddAsync(kupacModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = kupacModel.Id}, kupacModel.ToKupacDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateKupacRequestDTO updateKupacDTO)
        {
            var kupacModel = await _context.Kupac.FirstOrDefaultAsync(x => x.Id == id);
            
            if (kupacModel == null)
            {
                return NotFound();
            }
            kupacModel.Sifra = updateKupacDTO.Sifra;
            kupacModel.Naziv = updateKupacDTO.Naziv;
            kupacModel.Adresa = updateKupacDTO.Adresa;
            kupacModel.Mjesto = updateKupacDTO.Mjesto;
            await _context.SaveChangesAsync();
            return Ok(kupacModel.ToKupacDTO());


        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var kupacModel = await _context.Kupac.FirstOrDefaultAsync(x => x.Id ==id);
            if (kupacModel == null)
            {
                return NotFound();
            }

            _context.Kupac.Remove(kupacModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

