using Roomie.Entity;

namespace Roomie.Dtos.ForResponse
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Gender { get; set; }

        /*public List<Post> Posts { get; set; }*/
        public string ProfilePicture { get; set; }
        public ICollection<RoleDto> UserRoles { get; set; }
        public List<Leave> Leaves { get; set; }
        public int DepartmentId { get; set; }
    }
    public class RoleDto
    {
        public AppRole Role { get; set; }
    }
    
}
