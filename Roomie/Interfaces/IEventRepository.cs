using Roomie.Dtos.ForRequest;
using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface IEventRepository
    {
        void Update(Event evt);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<IEnumerable<Event>> GetUpcomingEvents(DateDto dateDto);
        Task<Event> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetTodayEvent(DateDto dateDto);
        
    }
}
