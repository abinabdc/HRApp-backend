using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos.ForResponse;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class DepartmentRepository : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepartmentRepository(IMapper mapper, DataContext ctx)
        {
            _context = ctx;
            _mapper = mapper;

        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Department> GetDepartmentByName(string DepartmentName)
        {
            return await _context.Departments.Where(p => p.DepartmentName == DepartmentName).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            return await _context.Departments.Include(p=>p.Users).ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider).ToListAsync();
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
