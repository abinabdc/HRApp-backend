using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface IVaccancyRepository
    {
        void Update(Vaccancy vaccancy);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Vaccancy>> GetVaccanciesAsync();
        Task<IEnumerable<Vaccancy>> GetValidVaccanciesAsync();
        Task<Vaccancy> GetVaccancyByIdAsync(int id);
    }
}
