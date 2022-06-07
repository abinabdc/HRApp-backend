using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext ctx)
        {
            _context = ctx;

        }
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.Include(p => p.Going).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events.Include(p => p.Going).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetTodayEvent(DateDto dateDto)
        {
            return await _context.Events.Include(p => p.Going).Where(p => dateDto.TodayDate >= p.FromDate && dateDto.TodayDate <= p.ToDate).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingEvents(DateDto dateDto)
        {
            return await _context.Events.Include(p => p.Going).Where(p => dateDto.TodayDate < p.ToDate).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void Update(Event evt)
        {
            _context.Entry(evt).State = EntityState.Modified;
        }

        public async Task<bool> UsersAlreadyGoing(int id)
        {
            return await _context.Users_Events.AnyAsync(x => x.AppUserId == id);
        }
    }
}
