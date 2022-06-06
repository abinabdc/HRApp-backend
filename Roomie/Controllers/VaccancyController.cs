using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roomie.Data;
using Roomie.Entity;
using Roomie.Interfaces.Repository;

namespace Roomie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccancyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly VaccancyRepository _vaccancyRepo;

        public VaccancyController(DataContext ctx, VaccancyRepository repo)
        {
            _context = ctx;
            _vaccancyRepo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccancy>>> GetAvailableVaccancies()
        {
            var result = await _vaccancyRepo.GetValidVaccanciesAsync();
            return Ok(result);  
        }
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Vaccancy>>> GetAllVaccancies()
        {
            var result = await _vaccancyRepo.GetVaccanciesAsync();
            return Ok(result);
        }


    }
}
