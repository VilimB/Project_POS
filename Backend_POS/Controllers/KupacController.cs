using Backend_POS.Data;
using Backend_POS.Interfaces;
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
        private readonly IKupacRepository _kupacRepo;

        public KupacController(DataContext context, IKupacRepository kupacRepo)
        {
            _context = context;
            _kupacRepo = kupacRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var kupac = await _kupacRepo.GetAllAsync();
            var kupacDTO=kupac.Select(s => s.ToKupacDTO());
            return Ok(kupac);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var kupac = await _kupacRepo.GetByIdAsync(id);

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
            await _kupacRepo.CreateAsync(kupacModel);
            return CreatedAtAction(nameof(GetById), new {id = kupacModel.KupacId}, kupacModel.ToKupacDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateKupacRequestDTO updateKupacDTO)
        {
            var kupacModel = await _kupacRepo.UpdateAsync(id, updateKupacDTO);

            if (kupacModel == null)
            {
                return NotFound();
            }
            
            return Ok(kupacModel.ToKupacDTO());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var kupacModel = await _kupacRepo.DeleteAsync(id);
            if (kupacModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}

