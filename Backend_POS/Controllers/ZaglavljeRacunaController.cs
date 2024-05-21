
using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Mappers;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.StavkeRacuna;
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
        private readonly IZaglavljeRacunaRepository _zaglavljeRacunaRepo;
        private readonly IKupacRepository _kupacRepo;
        public ZaglavljeRacunaController(DataContext context, IZaglavljeRacunaRepository zaglavljeRacunaRepo, IKupacRepository kupacRepo)
        {
            _context = context;
            _zaglavljeRacunaRepo= zaglavljeRacunaRepo;
            _kupacRepo= kupacRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zaglavljeRacuna =await _zaglavljeRacunaRepo.GetAllAsync();
            var zaglavljeRacunaDTO = zaglavljeRacuna.Select(s => s.ToZaglavljeRacunaDTO());
            return Ok(zaglavljeRacuna);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var zaglavljeRacuna = await _zaglavljeRacunaRepo.GetByIdAsync(id);

            if (zaglavljeRacuna == null)
            {
                return NotFound();
            }

            return Ok(zaglavljeRacuna.ToZaglavljeRacunaDTO());
        }
        [HttpPost("{kupacId}")]
        public async Task<IActionResult> Create([FromRoute] int kupacId, [FromBody] CreateZaglavljeRacunaRequestDTO zaglavljeRacunaDTO)
        {
            if (!await _kupacRepo.KupacExists(kupacId))
            {
                return BadRequest("Kupac ne postoji");
            }

            var zaglavljeRacunaModel = zaglavljeRacunaDTO.ToZaglavljeRacunaFromCreateDTO(kupacId);
            await _zaglavljeRacunaRepo.CreateAsync(zaglavljeRacunaModel);
            return CreatedAtAction(nameof(GetById), new { id = zaglavljeRacunaModel.ZaglavljeId }, zaglavljeRacunaModel.ToZaglavljeRacunaDTO());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateZaglavljeRacunaRequestDTO updateZaglavljeRacunaDTO)
        {
            var zaglavljeRacunaModel =await _zaglavljeRacunaRepo.UpdateAsync(id, updateZaglavljeRacunaDTO);

            if (zaglavljeRacunaModel == null)
            {
                return NotFound();
            }
            
            return Ok(zaglavljeRacunaModel.ToZaglavljeRacunaDTO());


        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var zaglavljeRacunaModel =await _zaglavljeRacunaRepo.DeleteAsync(id);
            if (zaglavljeRacunaModel == null)
            {
                return NotFound();
            }

            return Ok(zaglavljeRacunaModel);
        }

    }
}

   



