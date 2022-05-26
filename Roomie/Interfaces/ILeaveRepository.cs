using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface ILeaveRepository
    {
        void Update(Leave leave);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Leave>> GetLeavesAsync();
        Task<Leave> GetLeaveByIdAsync(int id);
        
    }
}
