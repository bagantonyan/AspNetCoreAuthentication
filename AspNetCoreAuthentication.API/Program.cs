using AspNetCoreAuthentication.API.Extensions;
using AspNetCoreAuthentication.API.Mappings;
using AspNetCoreAuthentication.BLL.Mappings;
using AspNetCoreAuthentication.BLL.Services.Abstractions;
using AspNetCoreAuthentication.BLL.Services.Implementations;
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

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureAuthentication(configuration);

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<BLLMappingProfile>();
                config.AddProfile<APIMappingProfile>();
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

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

            app.UseCors("CorsPolicy");


            app.UseAuthentication();
            app.UseAuthorization();

            app.MigrateDatabase();

            app.MapControllers();

            app.Run();
        }
    }
}