using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class DepartmentRepository : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext ctx)
        {
            _context = ctx;

        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Department> GetDepartmentByName(string DepartmentName)
        {
            return await _context.Departments.Where(p => p.DepartmentName == DepartmentName).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
        }
    }
}
