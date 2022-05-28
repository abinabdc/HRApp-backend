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
        public int WFHGiven { get; set; }
        public string PhoneNumber { get; set; }
        public string position { get; set; }
        public int DayOffGiven { get; set; }
        public int SickLeaveGiven { get; set; }
        public int VacationGiven { get; set; }
        public int WFHAvailable { get; set; }
        public int DayOffAvailable { get; set; }
        public int SickLeaveAvailable { get; set; }
        public int VacationAvailable { get; set; }
        public int DepartmentId { get; set; }
    }
    public class RoleDto
    {
        public AppRole Role { get; set; }
    }

    
}
