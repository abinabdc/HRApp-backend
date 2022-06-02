using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roomie.Entity
{
    public class AppUser : IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool FirstTimeLogin { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
        public string position { get; set; }
        public UserPhoto ProfilePicture { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public List<Leave> Leaves { get; set; }
        public int WFHGiven { get; set; }
        public int DayOffGiven { get; set; }
        public int SickLeaveGiven { get; set; }
        public int VacationGiven { get; set; }
        public int WFHAvailable { get; set; }
        public int DayOffAvailable { get; set; }
        public int SickLeaveAvailable { get; set; }
        public int VacationAvailable { get; set; }



        //relationship

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        //



    }
}
