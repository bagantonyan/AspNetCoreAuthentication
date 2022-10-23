using AspNetCoreAuthentication.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAuthentication.API.Extensions
{
    public static class MigrationExtensions
    {
        public static WebApplication MigrateDatabase(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>())
                {
                    dbContext.Database.Migrate();
                }
            }

            return webApplication;
        }
    }
}
