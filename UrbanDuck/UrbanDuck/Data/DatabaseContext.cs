using Microsoft.EntityFrameworkCore;
using UrbanDuck.Models;

namespace UrbanDuck.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("UrbanDuckDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Listing> Listings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            
        //}
    }
}
