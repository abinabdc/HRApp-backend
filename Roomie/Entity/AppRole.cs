using Microsoft.AspNetCore.Identity;

namespace Roomie.Entity
{
    public class AppRole : IdentityRole<int>
    {
        public IList<AppUserRole> UserRoles { get; set; }
    }
}
