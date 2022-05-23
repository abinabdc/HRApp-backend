using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Roomie.Entity
{
    public class AppUser : IdentityUser<int>
    {

     
        public string Gender { get; set; }
        public UserPhoto ProfilePicture { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }


        //relationship
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        //
        public List<Leave> Leaves { get; set; }



    }
}
