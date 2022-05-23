namespace Roomie.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<AppUser> Users { get; set; }

    }
}
