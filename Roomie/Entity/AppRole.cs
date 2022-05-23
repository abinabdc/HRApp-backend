using Microsoft.AspNetCore.Identity;

namespace Roomie.Entity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
