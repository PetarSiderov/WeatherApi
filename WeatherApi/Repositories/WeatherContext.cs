﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeatherApi.Repositories
{
    public class WeatherContextt : IdentityDbContext<IdentityUser>
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

       // public DbSet<User> Users { get; set; }
    }
}