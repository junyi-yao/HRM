
using Microsoft.AspNetCore.Identity;
namespace Authentication.API.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }

        public ICollection<UserRole> RolesForUser { get; set; }
    }
}


