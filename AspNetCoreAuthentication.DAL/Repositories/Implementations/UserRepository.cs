using AspNetCoreAuthentication.DAL.Contexts;
using AspNetCoreAuthentication.DAL.Entities.Users;
using AspNetCoreAuthentication.DAL.Repositories.Abstractions;

namespace AspNetCoreAuthentication.DAL.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        public UserRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
