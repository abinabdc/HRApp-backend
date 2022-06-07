using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface IUserEventRepository
    {
        Task<User_Event> GetEventsWithUserID(int id);
    }
}
