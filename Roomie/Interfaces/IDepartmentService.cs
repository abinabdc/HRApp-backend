using Roomie.Dtos.ForResponse;
using Roomie.Entity;

namespace Roomie.Interfaces
{
    public interface IDepartmentService
    {
        void Update(Department department);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task<Department> GetDepartmentById(int id);
        Task<Department> GetDepartmentByName(string DepartmentName);

    }
}
