
using Backend_POS.Data;
using Backend_POS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Backend_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Zaglavlje_racunaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public Zaglavlje_racunaController(DataContext dataContext)
        {
           _dataContext = dataContext;
        }
        [HttpPost]

        public async Task<IActionResult> AddZaglavlje_racuna(Zaglavlje_racuna zaglavlje_racuna)
        {
            _dataContext.Zaglavlje_racuna.Add(zaglavlje_racuna);
            await _dataContext.SaveChangesAsync();

            return Ok();
         }    
    
    } 
}    
