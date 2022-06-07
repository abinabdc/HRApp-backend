using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Entity;
using Roomie.Interfaces;

namespace Roomie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IEventRepository _eventRepo;
        public EventController(DataContext ctx, IEventRepository evt, IUserRepository userRepository)
        {
            _context = ctx;
            _userRepo = userRepository;
            _eventRepo = evt;

        }
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<Event>>> GetUpcomingEvents(DateDto dateDto)
        {
            var result = await _eventRepo.GetUpcomingEvents(dateDto);
            return Ok(result);
        }
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<Event>>> GetTodayEvents(DateDto dateDto)
        {
            var result = await _eventRepo.GetTodayEvent(dateDto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetById(int id)
        {
            var result = await _eventRepo.GetEventByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateEvents(ReqEventDto eventDto)
        {
            var newEvent = new Event
            {
                Name = eventDto.Name,
                Type = eventDto.Type,
                FromDate = eventDto.FromDate,
                Time = eventDto.Time,
                ToDate = eventDto.ToDate,
                LocationType = eventDto.LocationType,
                Location = eventDto.Location
            };
            _context.Events.Add(newEvent);
            if (await _eventRepo.SaveAllAsync())
            {
                return Ok("Event has been posted");
            }
            return BadRequest("Something went wrong while posting new event."); 
        }

    }
}
