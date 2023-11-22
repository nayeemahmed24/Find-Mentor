using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        public ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //_configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "WebService"))
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder
                .UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
