using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roomie.Data;
using Roomie.Dtos.ForResponse;
using Roomie.Entity;
using Roomie.Extensions;
using Roomie.Interfaces;

namespace Roomie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


        public UserController(UserManager<AppUser> userManager, IUserRepository userRepository, DataContext ctx, IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _userRepo = userRepository;
            _mapper = mapper;
            _roleManager = roleManager;
            _context = ctx;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserDto>>> GetUsers()
        {
            var users = await _userRepo.GetUsersAsync();
            return Ok(users);
        }
        [HttpGet("my-details")]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> GetDetails()
        {
            var username = User.GetUsername();
            var userId = Int32.Parse(username);
            return await _userRepo.GetUserByIdAsync(userId);
        }


    }
}
