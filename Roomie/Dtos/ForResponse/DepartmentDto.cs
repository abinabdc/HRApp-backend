using Roomie.Entity;

namespace Roomie.Dtos.ForResponse
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeesInDepartment> EmployeesInDepartment { get; set; }
    }
    public class EmployeesInDepartment
    {
        public string UserName { get; set; }
        public string Gender { get; set; }
        public UserPhoto ProfilePicture { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public List<Leave> Leaves { get; set; }

    }
}
