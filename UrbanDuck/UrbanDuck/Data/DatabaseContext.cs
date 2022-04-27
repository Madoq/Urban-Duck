using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrbanDuck.Models;

namespace UrbanDuck.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingTags> ListingTagsDb { get; set; }
        public DbSet<Photo> Photos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Company>().HasData(new Company { Id = 1, CompanyName = "Company 1", NipCode = 10});
        //    modelBuilder.Entity<Company>().HasData(new Company { Id = 2, CompanyName = "Company 2", NipCode = 20 });
        //    modelBuilder.Entity<Company>().HasData(new Company { Id = 3, CompanyName = "Company 3", NipCode = 30 });
        //}
    }
}
