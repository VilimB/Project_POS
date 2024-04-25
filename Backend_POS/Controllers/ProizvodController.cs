using AutoMapper;
using Backend_POS.Data;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_POS.Models.DTO.Proizvod;

namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly DataContext _context;

        public ProizvodController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proizvod = await _context.Proizvod.ToListAsync();
            var proizvodDTO= proizvod.Select(s => s.ToProizvodDTO());
            return Ok(proizvod);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var proizvod = await _context.Proizvod.FindAsync(id);

            if (proizvod == null)
            {
                return NotFound();
            }

            return Ok(proizvod.ToProizvodDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProizvodRequestDTO proizvodDTO)
        {
            var proizvodModel= proizvodDTO.ToProizvodFromCreateDTO();
            await _context.Proizvod.AddAsync(proizvodModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = proizvodModel.Id}, proizvodModel.ToProizvodDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProizvodRequestDTO updateDTO)
        {
            var proizvodModel = await _context.Proizvod.FirstOrDefaultAsync(x => x.Id == id);
            
            if (proizvodModel == null)
            {
                return NotFound();
            }
            proizvodModel.Sifra = updateDTO.Sifra;
            proizvodModel.Naziv = updateDTO.Naziv;
            proizvodModel.JedinicaMjere = updateDTO.JedinicaMjere;
            proizvodModel.Cijena = updateDTO.Cijena;
            proizvodModel.Stanje = updateDTO.Stanje;
            await _context.SaveChangesAsync();
            return Ok(proizvodModel.ToProizvodDTO());


        }
            
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var proizvodModel = await _context.Proizvod.FirstOrDefaultAsync(x => x.Id ==id);
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
