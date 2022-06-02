using Microsoft.EntityFrameworkCore;
using Roomie.Data;
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
