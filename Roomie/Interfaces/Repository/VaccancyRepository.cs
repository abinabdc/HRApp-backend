using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class VaccancyRepository : IVaccancyRepository
    {
        private readonly DataContext _context;
        public VaccancyRepository(DataContext ctx)
        {
            _context = ctx;

        }
        public async Task<IEnumerable<Vaccancy>> GetVaccanciesAsync()
        {
            return await _context.Vaccancies.ToListAsync();
        }

        public async Task<Vaccancy> GetVaccancyByIdAsync(int id)
        {
            return await _context.Vaccancies.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vaccancy>> GetValidVaccanciesAsync()
        {
            return await _context.Vaccancies.Where(x => x.isValid == true).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Vaccancy vaccancy)
        {
            _context.Entry(vaccancy).State = EntityState.Modified;
        }
    }
}
