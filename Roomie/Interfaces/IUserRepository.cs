using Roomie.Dtos.ForResponse;
using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUserDto>> GetUsersAsync();
        Task<AppUserDto> GetUserByIdAsync(int id);
        Task<AppUserDto> GetUserByUsernameAsync(string username);
    }
}
