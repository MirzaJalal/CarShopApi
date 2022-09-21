using CarShopApi.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.Models
{
    public class CarContext :DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(v=>v.Vehicles)
                .WithOne(c => c.Category)
                .HasForeignKey(c =>c.CategoryId);

            modelBuilder.Seed();
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
