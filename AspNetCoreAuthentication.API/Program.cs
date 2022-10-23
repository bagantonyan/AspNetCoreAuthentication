using AspNetCoreAuthentication.API.Extensions;
using AspNetCoreAuthentication.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAuthentication.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            ConfigurationManager configuration = builder.Configuration;

            builder.Services.AddDbContext<AuthenticationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}