using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class UserEventRepository : IUserEventRepository
    {
        private readonly DataContext _context;
        public UserEventRepository(DataContext ctx)
        {
            _context = ctx;

        }

        public async Task<User_Event> GetEventsWithUserID(int id)
        {
            return await _context.Users_Events.Where(p => p.AppUserId == id).FirstOrDefaultAsync();

        }
    }
}
