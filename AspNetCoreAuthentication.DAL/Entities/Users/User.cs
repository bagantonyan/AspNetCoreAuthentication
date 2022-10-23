using AspNetCoreAuthentication.DAL.Entities.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreAuthentication.DAL.Entities.Users
{
    public class User : IdentityUser<long>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
