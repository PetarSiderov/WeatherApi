using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WeatherApi.Entities;

namespace WeatherApi.Repositories
{
    public class WeatherContextt : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

        public WeatherContextt(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySQL(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorldCity>().HasNoKey();
        }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<WorldCity> WorldCities { get; set; }
    }
}
