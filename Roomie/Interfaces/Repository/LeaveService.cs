using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class LeaveService : ILeaveRepository
    {
        private readonly DataContext _context;
        public LeaveService(DataContext ctx)
        {
            _context = ctx;

        }
        public async Task<Leave> GetLeaveByIdAsync(int id)
        {
            return await _context.Leaves.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Leave>> GetTodayLeaves(DateDto dateDto)
        {
            /*dateDto.TodayDate >= leave.FromDate && dateDto.TodayDate <= leave.ToDate*/
            return await _context.Leaves.Where(p => p.Status == "Approved").Where(p => dateDto.TodayDate >= p.FromDate && dateDto.TodayDate <= p.ToDate).ToListAsync();
        }
        public async Task<IEnumerable<Leave>> GetApprovedLeaveAsync()
        {
            return await _context.Leaves.Where(p => p.Status == "Approved").ToListAsync();
        }

        public async Task<IEnumerable<Leave>> GetLeavesAsync()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void Update(Leave leave)
        {
            _context.Entry(leave).State = EntityState.Modified;
        }
    }
}
