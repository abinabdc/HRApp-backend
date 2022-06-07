using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Entity;
using Roomie.Interfaces;
using Roomie.Interfaces.Repository;

namespace Roomie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccancyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVaccancyRepository _vaccancyRepo;

        public VaccancyController(DataContext ctx, IVaccancyRepository repo)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccancy>> GetVaccancy(int id)
        {
            var result = await _vaccancyRepo.GetVaccancyByIdAsync(id);
            return Ok(result);
        }
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<Vaccancy>> DeleteVaccancy(int id)
        {
            var result = await _vaccancyRepo.GetVaccancyByIdAsync(id);
            return Ok(result);
        }*/

        [HttpPut("change-validity/{id}")]
        public async Task<ActionResult> ChangeValidity(int id)
        {
            var result = await _vaccancyRepo.GetVaccancyByIdAsync(id);
            if (result.isValid)
            {
                result.isValid = false;
            }
            else
            {
                result.isValid = true;
            }
            if (await _vaccancyRepo.SaveAllAsync())
            {
                return Ok("The satatus has been changed");
            }
            else
            {
                return BadRequest("Something went wrong while changing the status");
            }
        }

        [Authorize]
        [HttpPost("new")]
        public async Task<ActionResult<Vaccancy>> NewVaccancy(ReqVaccancy vac)
        {
            var vaccancy = new Vaccancy
            {
                Position = vac.Position,
                Experience = vac.Experience,
                Description = vac.Description,
                SalaryOffered = vac.SalaryOffered,
                isValid = true,
                DepartmentId = vac.DepartmentId
            };
            _context.Vaccancies.Add(vaccancy);

            if (await _vaccancyRepo.SaveAllAsync())
            {
                return Ok("Vaccancy has been posted");
            }
            return BadRequest("Something went wrong while posting new vaccancy.");

        }


    }
}
