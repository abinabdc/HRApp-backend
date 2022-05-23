using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos;
using Roomie.Entity;
using Roomie.Interfaces;

namespace Roomie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DataContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, DataContext ctx)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = ctx;
            _roleManager = roleManager; 


        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("User Already Exists Please sign in to continue.");
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                Gender = registerDto.Gender,
                PhoneNumber = registerDto.ContactNumber

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };

        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return NotFound($"User with {loginDto.Username} username doesnot exists.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
/*        [HttpPost]
        public async Task<ActionResult> PostRole()
        {

            //add roles 
            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole {Name = "Admin"},
                new AppRole{Name = "Moderator"},
            };
            foreach (var rolw in roles)
            {
                await _roleManager.CreateAsync(rolw);
            }
            return Ok();

        }*/
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}
