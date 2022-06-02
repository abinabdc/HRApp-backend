using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Dtos.ForResponse;
using Roomie.Entity;
using Roomie.Interfaces;

namespace Roomie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IMapper mapper, DataContext ctx, IDepartmentService dpt)
        {
            _mapper = mapper;
            _context = ctx;
            _departmentService = dpt;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetCategories()
        {
            var result = await _departmentService.GetDepartmentsAsync();
            return Ok(result);
        }
        [HttpPost("add-department")]
        public async Task<ActionResult<Department>> PostDepartment(RequestDepartment reqDepartment)
        {
            if (await DepartmentExists(reqDepartment.Name)) return BadRequest("Department already exists");
            var department = new Department
            {
                DepartmentName = reqDepartment.Name,
                Description = reqDepartment.Description,
            };
            _context.Departments.Add(department);
            
            if(await _departmentService.SaveAllAsync())
            {
                return Ok("Department Created Succesfully");
            }
            return BadRequest("Problem posting new Department");
        }

        private async Task<bool> DepartmentExists(string departmentName)
        {
            return await _context.Departments.AnyAsync(x => x.DepartmentName == departmentName.ToLower());
        }



    }
}
