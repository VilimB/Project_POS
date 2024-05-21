using Backend_POS.Data;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Interfaces;

namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProizvodRepository _proizvodRepo;

        public ProizvodController(DataContext context, IProizvodRepository proizvodRepo)
        {
            _proizvodRepo = proizvodRepo;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proizvod = await _proizvodRepo.GetAllAsync();
            var proizvodDTO= proizvod.Select(s => s.ToProizvodDTO());
            return Ok(proizvod);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var proizvod = await _proizvodRepo.GetByIdAsync(id);

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
            await _proizvodRepo.CreateAsync(proizvodModel);
            return CreatedAtAction(nameof(GetById), new {id = proizvodModel.ProizvodId}, proizvodModel.ToProizvodDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProizvodRequestDTO updateDTO)
        {
            var proizvodModel = await _proizvodRepo.UpdateAsync(id, updateDTO);
            
            if (proizvodModel == null)
            {
                return NotFound();
            }
            
            return Ok(proizvodModel.ToProizvodDTO());
            }
            
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var proizvodModel = await _proizvodRepo.DeleteAsync(id);
            if (proizvodModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
